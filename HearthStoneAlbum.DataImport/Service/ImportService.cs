using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HearthStoneAlbum.Dal;
using HearthStoneAlbum.DataImport.XmlDomain;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.DataImport.Service {
    public class ImportService : IDisposable {
        private const int defaultLanguageId = 1;

        private HearthStoneAlbumDbContext context;
        private DirectoryInfo assetDirectory;
        Action<string> logger;
        private IList<Card> cards;
        private IList<CardSetLanguage> cardSets;
        private IList<RaceLanguage> races;
        private IList<HeroClassLanguage> heroClasses;
        private IList<Language> languages;
        private IList<AdventureLanguage> adventures;
        private IList<WingLanguage> wings;
        private IList<BossLanguage> bosses;
        private IList<HeroClassChallenge> challenges;
        private Func<Card, string, bool>[] howToGets;
        private Func<Card, string, bool>[] howToGetGolds;

        public ImportService(string assetDirectoryPath, string connectionString, Action<string> logger) {
            this.context = new HearthStoneAlbumDbContext(connectionString);
            this.assetDirectory = new DirectoryInfo(assetDirectoryPath);
            this.logger = logger;
            this.context.Database.Log = logger;
            cards = context.Cards
                .Include(c => c.CardLanguages)
                .Include(c => c.HeroClassCards)
                .Include(c => c.RaceCardSetCards)
                .Include(c => c.AdventureCard)
                .ToList();
            cardSets = context.CardSetLanguages
                .Include(csl => csl.CardSet)
                .Where(csl => csl.LanguageId == defaultLanguageId)
                .ToList();
            context.Rarities.Load();
            races = context.RaceLanguages
                .Include(rl => rl.Race)
                .Where(rl => rl.LanguageId == defaultLanguageId)
                .ToList();
            context.CardTypes.Load();
            heroClasses = context.HeroClassLanguages
                .Include(pcl => pcl.HeroClass)
                .Where(pcl => pcl.LanguageId == defaultLanguageId)
                .ToList();
            languages = context.Languages.ToList();
            adventures = context.AdventureLanguages
                .Include(al => al.Adventure)
                .Where(al => al.LanguageId == defaultLanguageId)
                .ToList();
            wings = context.WingLanguages
                .Include(wl => wl.Wing)
                .Where(wl => wl.LanguageId == defaultLanguageId)
                .ToList();
            bosses = context.BossLanguages
                .Include(bl => bl.Boss)
                .Where(bl => bl.LanguageId == defaultLanguageId)
                .ToList();
            challenges = context.HeroClassChallenges
                .Include(hcc => hcc.HeroClass)
                .Include(hcc => hcc.Wing)
                .ToList();
            this.howToGets = new Func<Card, string, bool>[] {
                ProcessHowToGetByRace,
                ProcessHowToGetByLevel,
                ProcessHowToGetByAdventure,
                ProcessHowToGetByBoss,
                ProcessHowToGetByChallenge,
                ProcessHowToGetByWing,
            };
            this.howToGetGolds = new Func<Card, string, bool>[] {
                ProcessHowToGetGoldByClassLevel,
                ProcessHowToGetGoldByLevel,
                ProcessHowToGetGoldByRace,
                ProcessHowToGetByRace,
                ProcessHowToGetGoldUnused,
            };
        }


        public void Import() {
            IList<Card> importCards = new List<Card>();
            FileInfo[] assets = this.assetDirectory.GetFiles("*.txt");
            if (assets.Count() != this.languages.Count) {
                throw new InvalidOperationException(String.Format("The number of files ({0}) doesn't match the number of languages ({1})",
                    assets.Count(), languages.Count));
            }
            foreach (Language language in this.languages.OrderBy(l => l.LanguageId)) {
                XmlSerializer ser = new XmlSerializer(typeof(CardDefs));
                FileInfo fi = assets.SingleOrDefault(a => a.Name.StartsWith(language.Name, StringComparison.InvariantCultureIgnoreCase));
                if (fi == null) {
                    throw new InvalidOperationException(String.Format("No file found for language {0}", language.Name));
                }
                using (XmlReader reader = XmlReader.Create(fi.FullName)) {
                    CardDefs cardDef = (CardDefs)ser.Deserialize(reader);
                    IEnumerable<Entity> entities = cardDef.Items.Where(e => e.GetBoolValue(EnumId.Collectible));
                    foreach (Entity entity in entities) {
                        FillImportCards(importCards, language, entity);
                    }
                }
            }
            //using (DbContextTransaction transaction = context.Database.BeginTransaction()) {
            //    try {
            SynchronizeCards(importCards);
            context.SaveChanges();
            //    transaction.Commit();
            //} catch (Exception) {
            //    transaction.Rollback();
            //    throw;
            //}
            //}
        }

        private void SynchronizeCards(IList<Card> importCards) {
            foreach (Card importCard in importCards) {
                Card card = cards.SingleOrDefault(c => c.Code == importCard.Code);
                if (card == null) {
                    context.Cards.Add(importCard);
                    logger(String.Format("New card added : {0} - {1}", importCard.Code,
                        importCard.CardLanguages.Single(cl => cl.LanguageId == defaultLanguageId).Name));
                } else {
                    SynchronizeCards(card, importCard);
                }
                //context.SaveChanges();
            }
        }

        private static void SynchronizeCards(Card card, Card importCard) {
            card.CardSet = importCard.CardSet;
            card.CardType = importCard.CardType;
            card.Rarity = importCard.Rarity;
            card.Race = importCard.Race;
            card.HeroClass = importCard.HeroClass;
            card.Cost = importCard.Cost;
            card.Attack = importCard.Attack;
            card.Health = importCard.Health;
            card.Durability = importCard.Durability;
            SynchronizeAdventureCard(card, importCard);
            SynchronizeLanguage(card, importCard);
            SynchronizeRaceCardSet(card, importCard);
            SynchronizeHeroClass(card, importCard);
        }

        private static void SynchronizeAdventureCard(Card card, Card importCard) {
            AdventureCard importAdventureCard = importCard.AdventureCard;
            AdventureCard adventureCard = card.AdventureCard;
            if (importAdventureCard != null) {
                if (adventureCard == null) {
                    card.AdventureCard = importAdventureCard;
                } else {
                    adventureCard.Boss = importAdventureCard.Boss;
                    adventureCard.Wing = importAdventureCard.Wing;
                    adventureCard.HeroClassChallenge = importAdventureCard.HeroClassChallenge;
                }
            }
        }

        private static void SynchronizeHeroClass(Card card, Card importCard) {
            foreach (HeroClassCard importHeroClassCard in importCard.HeroClassCards) {
                HeroClassCard heroClassCard = card.HeroClassCards
                    .SingleOrDefault(hcc => hcc.HeroClass.HeroClassId == importHeroClassCard.HeroClass.HeroClassId
                        && hcc.Golden == importHeroClassCard.Golden);
                if (heroClassCard == null) {
                    card.HeroClassCards.Add(importHeroClassCard);
                }
            }
        }

        private static void SynchronizeRaceCardSet(Card card, Card importCard) {
            foreach (RaceCardSetCard importRaceCardSetCard in importCard.RaceCardSetCards) {
                RaceCardSetCard raceCardSetCard = card.RaceCardSetCards
                    .SingleOrDefault(rcsc => rcsc.CardSet.CardSetId == importRaceCardSetCard.CardSet.CardSetId
                        && rcsc.Race.RaceId == importRaceCardSetCard.Race.RaceId);
                if (raceCardSetCard == null) {
                    card.RaceCardSetCards.Add(importRaceCardSetCard);
                }
            }
        }

        private static void SynchronizeLanguage(Card card, Card importCard) {
            foreach (CardLanguage importCardLanguage in importCard.CardLanguages) {
                CardLanguage cardLanguage = card.CardLanguages
                    .SingleOrDefault(cl => cl.Language.LanguageId == importCardLanguage.Language.LanguageId);
                if (cardLanguage == null) {
                    card.CardLanguages.Add(importCardLanguage);
                } else {
                    cardLanguage.Name = importCardLanguage.Name;
                    cardLanguage.Description = importCardLanguage.Description;
                }
            }
        }

        private void FillImportCards(IList<Card> importCards, Language language, Entity entity) {
            Card card;
            if (language.LanguageId == defaultLanguageId) {
                card = this.Transform(entity);
                if (card != null) {
                    importCards.Add(card);
                }
                this.ProcessHowToGet(card, entity.GetStringValue(EnumId.HowToGet), howToGets);
                this.ProcessHowToGet(card, entity.GetStringValue(EnumId.HowToGetGold), howToGetGolds);
            } else {
                card = importCards.SingleOrDefault(ic => ic.Code == entity.CardId);
            }
            if (card != null) {
                card.CardLanguages.Add(GetLanguage(entity, language));
            }
        }
        private Card Transform(Entity entity) {
            CardType cardType = GetReference<CardType>(entity, EnumId.CardType);
            if (cardType == null) {
                // Hero case -- TODO : get hero names
                return null;
            }
            Card card = new Card {
                Code = entity.CardId,
                CardSet = GetMandatoryReference<CardSet>(entity, EnumId.CardSet),
                HeroClass = GetReference<HeroClass>(entity, EnumId.Hero),
                Rarity = GetMandatoryReference<Rarity>(entity, EnumId.Rarity),
                CardType = cardType,
                Race = GetReference<Race>(entity, EnumId.Race),
                Cost = entity.GetIntValue(EnumId.Cost),
                Attack = entity.GetIntValue(EnumId.Attack),
                Health = entity.GetIntValue(EnumId.Health),
                Durability = entity.GetIntValue(EnumId.Durability),
            };
            return card;
        }
        private CardLanguage GetLanguage(Entity entity, Language language) {
            return new CardLanguage {
                Name = entity.GetStringValue(EnumId.CardName),
                Description = CleanDescription(entity.GetStringValue(EnumId.CardText)),
                Language = language,
            };
        }
        private string CleanDescription(string description) {
            if (String.IsNullOrEmpty(description)) {
                return null;
            }
            return description.Replace("#", String.Empty).Replace("$", String.Empty);
        }

        private T GetReference<T>(Entity entity, EnumId enumId) where T : class {
            int? referenceId = entity.GetIntValue(enumId);
            if (!referenceId.HasValue) {
                return null;
            }
            T reference = context.Set<T>().Find(referenceId);
            return reference;
        }
        private T GetMandatoryReference<T>(Entity entity, EnumId enumId) where T : class {
            T reference = GetReference<T>(entity, enumId);
            if (reference == null) {
                throw new KeyNotFoundException(String.Format("Unknown {0} (id = {1})", reference.GetType(), entity.CardId));
            }
            return reference;
        }


        private void ProcessHowToGet(Card card, string howToGet, Func<Card, string, bool>[] howToGets) {
            if (String.IsNullOrEmpty(howToGet)) {
                return;
            }
            bool found = false;
            foreach (Func<Card, string, bool> processor in howToGets) {
                if (found) {
                    break;
                }
                found = processor(card, howToGet);
            }
            if (!found) {
                throw new ArgumentException(String.Format("No match found for HowToGet {0} (Card.Code = {1})", howToGet, card.Code));
            }
        }

        #region HowToGet
        #region Regular
        private bool ProcessHowToGetByRace(Card card, string howToGet) {
            const string unlockedRace = @"^Unlocked when you have all the (Golden )?(?<" + regexRace + @">\w+)s from the (?<" + regexCardSet + @">\w+) Set\.$";
            Match match = Regex.Match(howToGet, unlockedRace);
            if (match.Success) {
                RaceLanguage raceLanguage = ExtractRace(match, card.Code);
                CardSetLanguage cardSetLanguage = ExtractCardSet(match, card.Code);
                AddRaceCardSet(card, raceLanguage.Race, cardSetLanguage.CardSet);
                return true;
            }
            return false;
        }

        private bool ProcessHowToGetByLevel(Card card, string howToGet) {
            return ProcessHowToGetByLevel(card, howToGet, false);
        }
        private bool ProcessHowToGetByAdventure(Card card, string howToGet) {
            const string unlockedAdventure = @"^Unlocked by defeating every boss in (?<" + regexAdventure + @">\D+)\!$";
            Match match = Regex.Match(howToGet, unlockedAdventure);
            if (match.Success) {
                AdventureLanguage adventureLanguage = ExtractAdventure(match, card.Code);
                Wing wing = adventureLanguage.Adventure.Wings.OrderByDescending(w => w.Order).FirstOrDefault();
                card.AdventureCard = new AdventureCard {
                    Wing = wing,
                };
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetByBoss(Card card, string howToGet) {
            const string unlockedBoss = @"^Unlocked by defeating ([Tt]he )?(?<" + regexBoss + @">\D+) in ([Tt]he )?(?<" + regexWing + @">\D+)\.$";
            Match match = Regex.Match(howToGet, unlockedBoss);
            if (match.Success) {
                BossLanguage bossLanguage = ExtractBoss(match, card.Code);
                card.AdventureCard = new AdventureCard {
                    Boss = bossLanguage.Boss,
                };
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetByChallenge(Card card, string howToGet) {
            const string unlockedChallenge = @"^Unlocked by completing the (?<" + regexHeroClass + @">\w+) Class Challenge in (?<" + regexAdventure + @">\D+)\.$";
            Match match = Regex.Match(howToGet, unlockedChallenge);
            if (match.Success) {
                HeroClassLanguage heroClassLanguage = ExtractHeroClass(match, card.Code);
                AdventureLanguage adventureLanguage = ExtractAdventure(match, card.Code);
                HeroClassChallenge challenge = challenges.Where(hcc => hcc.Wing.Adventure.AdventureId == adventureLanguage.AdventureId)
                    .SingleOrDefault(hcc => hcc.HeroClassId == heroClassLanguage.HeroClassId);
                if (challenge == null) {
                    throw new ArgumentException(String.Format("How to get boss for heroClass {0} and adventure {1} not found (Card.Code = {2})", heroClassLanguage.Name, adventureLanguage.Name, card.Code));
                }
                card.AdventureCard = new AdventureCard {
                    HeroClassChallenge = challenge,
                };
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetByWing(Card card, string howToGet) {
            const string unlockedWing = @"^Unlocked by completing ([Tt]he )?(?<" + regexWing + @">\D+)\.$";
            Match match = Regex.Match(howToGet, unlockedWing);
            if (match.Success) {
                WingLanguage wingLanguage = ExtractWing(match, card.Code);
                card.AdventureCard = new AdventureCard {
                    Wing = wingLanguage.Wing,
                };
                return true;
            }
            return false;
        }
        #endregion
        private const string regexLevel = "level";
        private const string regexCardSet = "cardSet";
        private const string regexRace = "race";
        private const string regexHeroClass = "heroClass";
        private const string regexBoss = "Boss";
        private const string regexWing = "wing";
        private const string regexAdventure = "adventure";

        private static void AddRaceCardSet(Card card, Race race, CardSet cardSet) {
            if (!card.RaceCardSetCards.Any(rcsc => rcsc.Race.RaceId == race.RaceId && rcsc.CardSet.CardSetId == cardSet.CardSetId)) {
                card.RaceCardSetCards.Add(new RaceCardSetCard {
                    Race = race,
                    CardSet = cardSet,
                });
            }
        }

        private int ExtractLevel(Match match, string cardCode) {
            int level;
            string levelValue = match.Groups[regexLevel].Value;
            if (!Int32.TryParse(levelValue, out level)) {
                throw new ArgumentException(String.Format("How to get level {0} must be an integer (Card.Code = {1})", levelValue, cardCode));
            }
            return level;
        }
        private RaceLanguage ExtractRace(Match match, string cardCode) {
            string raceValue = match.Groups[regexRace].Value;
            RaceLanguage raceLanguage = races.SingleOrDefault(rl => rl.Name.Equals(raceValue, StringComparison.InvariantCultureIgnoreCase));
            if (raceLanguage == null) {
                throw new ArgumentException(String.Format("How to get race {0} not found (Card.Code = {1})", raceValue, cardCode));
            }
            return raceLanguage;
        }
        private CardSetLanguage ExtractCardSet(Match match, string cardCode, string cardSetVariable = regexCardSet) {
            string cardSetValue = match.Groups[cardSetVariable].Value.Replace("Expert", "Classic");
            CardSetLanguage cardSetLanguage = cardSets.SingleOrDefault(csl => csl.Name.Equals(cardSetValue, StringComparison.InvariantCultureIgnoreCase));
            if (cardSetLanguage == null) {
                throw new ArgumentException(String.Format("How to get cardSet {0} not found (Card.Code = {1})", cardSetValue, cardCode));
            }
            return cardSetLanguage;
        }
        private HeroClassLanguage ExtractHeroClass(Match match, string cardCode) {
            string heroClassValue = match.Groups[regexHeroClass].Value;
            HeroClassLanguage heroClassLanguage = heroClasses.SingleOrDefault(pcl => pcl.Name.Equals(heroClassValue, StringComparison.InvariantCultureIgnoreCase));
            if (heroClassLanguage == null) {
                throw new ArgumentException(String.Format("How to get heroClass {0} not found (Card.Code = {1})", heroClassValue, cardCode));
            }
            return heroClassLanguage;
        }
        private AdventureLanguage ExtractAdventure(Match match, string cardCode) {
            string adventureValue = match.Groups[regexAdventure].Value;
            AdventureLanguage adventureLanguage = adventures.SingleOrDefault(al => al.Name.Contains(adventureValue));
            if (adventureLanguage == null) {
                throw new ArgumentException(String.Format("How to get adventure {0} not found (Card.Code = {1})", adventureValue, cardCode));
            }
            return adventureLanguage;
        }
        private WingLanguage ExtractWing(Match match, string cardCode) {
            string wingValue = match.Groups[regexWing].Value;
            WingLanguage wingLanguage = wings.SingleOrDefault(wl => wl.Name.Equals(wingValue, StringComparison.InvariantCultureIgnoreCase));
            if (wingLanguage == null) {
                throw new ArgumentException(String.Format("How to get wing {0} not found (Card.Code = {1})", wingValue, cardCode));
            }
            return wingLanguage;
        }
        private BossLanguage ExtractBoss(Match match, string cardCode) {
            string bossValue = match.Groups[regexBoss].Value
                .Replace("Grim Guzzler", "Coren Direbrew")
                .Replace("Dark Iron Arena", "High Justice Grimstone");
            BossLanguage bossLanguage = bosses.SingleOrDefault(bl => bl.Name.Contains(bossValue));
            if (bossLanguage == null) {
                throw new ArgumentException(String.Format("How to get boss {0} not found (Card.Code = {1})", bossValue, cardCode));
            }
            return bossLanguage;
        }
        private bool ProcessHowToGetByLevel(Card card, string howToGet, bool golden) {
            const string unlockedLevel = @"^Unlocked at Level (?<" + regexLevel + @">\d+)\.$";
            Match match = Regex.Match(howToGet, unlockedLevel);
            if (match.Success) {
                int level = ExtractLevel(match, card.Code);
                HeroClassCard heroClassCard = new HeroClassCard() {
                    HeroClass = card.HeroClass,
                    Level = level,
                    Golden = golden,
                };
                card.HeroClassCards.Add(heroClassCard);
                return true;
            }
            return false;
        }
        #region Gold
        private bool ProcessHowToGetGoldByLevel(Card card, string howToGet) {
            return ProcessHowToGetByLevel(card, howToGet, true);
        }
        private bool ProcessHowToGetGoldByClassLevel(Card card, string howToGet) {
            const string unlockedLevel = @"^Unlocked at (?<" + regexHeroClass + @">\w+) Level (?<" + regexLevel + @">\d+)\.$";
            Match match = Regex.Match(howToGet, unlockedLevel);
            if (match.Success) {
                int level = ExtractLevel(match, card.Code);
                HeroClassLanguage heroClassLanguage = ExtractHeroClass(match, card.Code);
                HeroClassCard heroClassCard = new HeroClassCard {
                    HeroClass = heroClassLanguage.HeroClass,
                    Level = level,
                    Golden = true,
                };
                card.HeroClassCards.Add(heroClassCard);
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetGoldByRace(Card card, string howToGet) {
            const string unlockedRace = @"^Unlocked when you have all the Golden (?<" + regexRace + @">\w+)s from the (?<cardSet1>\w+) and (?<cardSet2>\w+) Sets\.$";
            Match match = Regex.Match(howToGet, unlockedRace);
            if (match.Success) {
                RaceLanguage raceLanguage = ExtractRace(match, card.Code);
                CardSetLanguage cardSetLanguageFirst = ExtractCardSet(match, card.Code, "cardSet1");
                AddRaceCardSet(card, raceLanguage.Race, cardSetLanguageFirst.CardSet);
                CardSetLanguage cardSetLanguageSecond = ExtractCardSet(match, card.Code, "cardSet2");
                AddRaceCardSet(card, raceLanguage.Race, cardSetLanguageSecond.CardSet);
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetGoldUnused(Card card, string howToGet) {
            const string unused = @"(^This was rewarded to players who helped test the Store during the Beta.$|^Awarded at BlizzCon 2013.$|^Can be crafted after )";
            Match match = Regex.Match(howToGet, unused);
            return match.Success;
        }
        #endregion
        #endregion

        public void Dispose() {
            if (context != null) {
                context.Dispose();
                GC.SuppressFinalize(context);
            }
        }

    }
}
