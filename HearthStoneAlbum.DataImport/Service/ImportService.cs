using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HearthStoneAlbum.Dal;
using HearthStoneAlbum.DataImport.XmlDomain;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.DataImport.Service {
    public class ImportService : IDisposable {
        private const int defaultLanguageId = 1;

        private HearthStoneAlbumDbContext context;
        Action<string> logger;
        private IList<Card> cards;
        private IList<CardSetLanguage> cardSets;
        private IList<Rarity> rarities;
        private IList<RaceLanguage> races;
        private IList<CardType> cardTypes;
        private IList<PlayerClassLanguage> playerClasses;
        private IList<Language> languages;
        private IList<AdventureLanguage> adventures;
        private IList<WingLanguage> wings;
        private IList<BossLanguage> bosses;
        private Func<Card, string, bool>[] howToGets;
        private Func<Card, string, bool>[] howToGetGolds;

        public ImportService(string connectionString, Action<string> logger) {
            this.context = new HearthStoneAlbumDbContext(connectionString);
            this.logger = logger;
            this.context.Database.Log = logger;
            cards = context.Cards
                .Include(c => c.PlayerClassCards)
                .Include(c => c.RaceCardSetCards)
                .ToList();
            cardSets = context.CardSetLanguages
                .Include(csl => csl.CardSet)
                .Where(csl => csl.LanguageId == defaultLanguageId)
                .ToList();
            rarities = context.Rarities.ToList();
            races = context.RaceLanguages
                .Include(rl => rl.Race)
                .Where(rl => rl.LanguageId == defaultLanguageId)
                .ToList();
            cardTypes = context.CardTypes.ToList();
            playerClasses = context.PlayerClassLanguages
                .Include(pcl => pcl.PlayerClass)
                .Where(pcl => pcl.LanguageId == defaultLanguageId)
                .ToList();
            languages = context.Languages.ToList();
            adventures = context.AdventureLanguages
                .Include(al => al.Adventure.Cards)
                .Where(al => al.LanguageId == defaultLanguageId)
                .ToList();
            wings = context.WingLanguages
                .Include(wl => wl.Wing.Cards)
                .Where(wl => wl.LanguageId == defaultLanguageId)
                .ToList();
            bosses = context.BossLanguages
                .Include(bl => bl.Boss.Cards)
                .Include(bl => bl.Boss.PlayerClassCards)
                .Include(bl => bl.Boss.PlayerClass)
                .Where(bl => bl.LanguageId == defaultLanguageId)
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


        public void Import(IList<Entity> entities) {
            foreach (Entity entity in entities) {
                Import(entity);
            }
            context.SaveChanges();
        }
        private void Import(Entity entity) {
            string code = entity.CardId;
            Card card = GetCard(entity.CardId);
            card.CardSet = GetValue<CardSet>(entity.GetTag("CardSet"));
            card.PlayerClass = GetValue<PlayerClass>(entity.GetTag("Class"));
            card.Rarity = GetRarity(entity);
            card.CardType = GetValue<CardType>(entity.GetTag("CardType"));
            card.Race = GetValue<Race>(entity.GetTag("Race"));
            card.Cost = GetOptionalValue(entity.GetTag("Cost"));
            card.Attack = GetOptionalValue(entity.GetTag("Atk"));
            card.Health = GetOptionalValue(entity.GetTag("Health"));
            card.Durability = GetOptionalValue(entity.GetTag("Durability"));
            card.CardLanguages = GetCardLanguages(entity);
            this.ProcessHowToGet(card, entity.GetTag("HowToGetThisCard"), howToGets);
            this.ProcessHowToGet(card, entity.GetTag("HowToGetThisGoldCard"), howToGetGolds);
            if (card.CardId == 0) {
                context.Cards.Add(card);
            }
            logger(code);
        }

        private Rarity GetRarity(Entity entity) {
            Rarity rarity = GetValue<Rarity>(entity.GetTag("Rarity"));
            if (rarity == null) {
                rarity = rarities.SingleOrDefault(r => r.RarityId == 0);
            }
            return rarity;
        }

        private Card GetCard(string code) {
            Card card = cards.SingleOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            if (card == null) {
                card = new Card() {
                    Code = code,
                };
            }
            return card;
        }

        private T GetValue<T>(Tag tag) where T : class {
            if (tag == null) {
                return null;
            }
            int entityId = GetValue(tag);
            T entity = context.Set<T>().Find(entityId);
            if (entity == null) {
                throw new KeyNotFoundException(String.Format("Unknown {0} (id = {1})", entity.GetType().Name, entityId));
            }
            return entity;
        }
        private int GetValue(Tag tag) {
            int tagValue;
            if (!int.TryParse(tag.Value, out tagValue)) {
                throw new ArgumentException(String.Format("tag.Value {0} must be an integer (tag.Name = {1})", tag.Value, tag.Name));
            }
            return tagValue;
        }
        private int? GetOptionalValue(Tag tag) {
            if (tag == null) {
                return null;
            }
            return GetValue(tag);
        }

        private ICollection<CardLanguage> GetCardLanguages(Entity entity) {
            ICollection<CardLanguage> cardLanguages = new List<CardLanguage>();
            Tag cardName = entity.GetTag("CardName");
            Tag cardText = entity.GetTag("CardTextInHand");
            foreach (Language language in languages) {
                string name = cardName.GetLanguageValue(language.Name);
                if (name != null) {
                    CardLanguage cardLanguage = new CardLanguage();
                    cardLanguage.Language = language;
                    cardLanguage.Name = name;
                    if (cardText != null) {
                        cardLanguage.Description = CleanDescription(cardText.GetLanguageValue(language.Name));
                    }
                    cardLanguages.Add(cardLanguage);
                }
            }
            return cardLanguages;
        }
        private string CleanDescription(string description) {
            return description.Replace("#", String.Empty).Replace("$", String.Empty);
        }

        private void ProcessHowToGet(Card card, Tag tag, Func<Card, string, bool>[] howToGets) {
            if (tag == null) {
                return;
            }
            string howToGet = tag.enUS;
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
                AddRaceCardSetCard(card, raceLanguage, cardSetLanguage);
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetByLevel(Card card, string howToGet) {
            return ProcessHowToGetByLevel(card, howToGet, false);
        }
        private bool ProcessHowToGetByAdventure(Card card, string howToGet) {
            const string unlockedAdventure = @"^Unlocked by defeating every boss in (?<" + regexLevel + @">\w+)\!$";
            Match match = Regex.Match(howToGet, unlockedAdventure);
            if (match.Success) {
                AdventureLanguage adventureLanguage = ExtractAdventure(match, card.Code);
                if (!adventureLanguage.Adventure.Cards.Contains(card)) {
                    adventureLanguage.Adventure.Cards.Add(card);
                }
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetByBoss(Card card, string howToGet) {
            const string unlockedBoss = @"^Unlocked by defeating (?<" + regexBoss + @">\w+) in the (?<" + regexWing + @">\w+)\.$";
            Match match = Regex.Match(howToGet, unlockedBoss);
            if (match.Success) {
                BossLanguage bossLanguage = ExtractBoss(match, card.Code);
                if (!bossLanguage.Boss.Cards.Contains(card)) {
                    bossLanguage.Boss.Cards.Add(card);
                }
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetByChallenge(Card card, string howToGet) {
            const string unlockedChallenge = @"^Unlocked by completing the (?<" + regexPlayerClass + @">\w+) Class Challenge in (?<" + regexAdventure + @">\w+)\.$";
            Match match = Regex.Match(howToGet, unlockedChallenge);
            if (match.Success) {
                PlayerClassLanguage playerClassLanguage = ExtractPlayerClass(match, card.Code);
                AdventureLanguage adventureLanguage = ExtractAdventure(match, card.Code);
                BossLanguage bossLanguage = bosses.Where(bl => bl.Boss.Wing.Adventure.AdventureId == adventureLanguage.AdventureId)
                    .SingleOrDefault(bl => bl.Boss.PlayerClass.PlayerClassId == playerClassLanguage.PlayerClassId);
                if (bossLanguage == null) {
                    throw new ArgumentException(String.Format("How to get boss for playerClass {0} and adventure {1} not found (Card.Code = {2})", playerClassLanguage.Name, adventureLanguage.Name, card.Code));
                }
                if (!bossLanguage.Boss.PlayerClassCards.Contains(card)) {
                    bossLanguage.Boss.PlayerClassCards.Add(card);
                }
                return true;
            }
            return false;
        }
        private bool ProcessHowToGetByWing(Card card, string howToGet) {
            const string unlockedWing = @"^Unlocked by completing the (?<" + regexWing + @">\w+)\.$";
            Match match = Regex.Match(howToGet, unlockedWing);
            if (match.Success) {
                WingLanguage wingLanguage = ExtractWing(match, card.Code);
                if (!wingLanguage.Wing.Cards.Contains(card)) {
                    wingLanguage.Wing.Cards.Add(card);
                }
                return true;
            }
            return false;
        }
        #endregion
        private const string regexLevel = "level";
        private const string regexCardSet = "cardSet";
        private const string regexRace = "race";
        private const string regexPlayerClass = "playerClass";
        private const string regexBoss = "Boss";
        private const string regexWing = "wing";
        private const string regexAdventure = "adventure";

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
        private PlayerClassLanguage ExtractPlayerClass(Match match, string cardCode) {
            string playerClassValue = match.Groups[regexPlayerClass].Value;
            PlayerClassLanguage playerClassLanguage = playerClasses.SingleOrDefault(pcl => pcl.Name.Equals(playerClassValue, StringComparison.InvariantCultureIgnoreCase));
            if (playerClassLanguage == null) {
                throw new ArgumentException(String.Format("How to get playerClass {0} not found (Card.Code = {1})", playerClassValue, cardCode));
            }
            return playerClassLanguage;
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
            string bossValue = match.Groups[regexBoss].Value;
            BossLanguage bossLanguage = bosses.SingleOrDefault(bl => bl.Name.Equals(bossValue, StringComparison.InvariantCultureIgnoreCase));
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
                PlayerClassCard playerClassCard = card.PlayerClassCards
                    .SingleOrDefault(pcc => pcc.PlayerClass.PlayerClassId == card.PlayerClass.PlayerClassId && pcc.Golden == golden);
                if (playerClassCard == null) {
                    playerClassCard = new PlayerClassCard() {
                        PlayerClass = card.PlayerClass,
                        Golden = golden,
                    };
                    card.PlayerClassCards.Add(playerClassCard);
                }
                playerClassCard.Level = level;
                return true;
            }
            return false;
        }
        private static void AddRaceCardSetCard(Card card, RaceLanguage raceLanguage, CardSetLanguage cardSetLanguage) {
            RaceCardSetCard raceCardSetCard = card.RaceCardSetCards
                .SingleOrDefault(rcsc => rcsc.Race.RaceId == raceLanguage.RaceId && rcsc.CardSet.CardSetId == cardSetLanguage.CardSetId);
            if (raceCardSetCard == null) {
                raceCardSetCard = new RaceCardSetCard() {
                    Race = raceLanguage.Race,
                    CardSet = cardSetLanguage.CardSet,
                };
                card.RaceCardSetCards.Add(raceCardSetCard);
            }
        }
        #region Gold
        private bool ProcessHowToGetGoldByLevel(Card card, string howToGet) {
            return ProcessHowToGetByLevel(card, howToGet, true);
        }
        private bool ProcessHowToGetGoldByClassLevel(Card card, string howToGet) {
            const string unlockedLevel = @"^Unlocked at (?<" + regexPlayerClass + @">\w+) Level (?<" + regexLevel + @">\d+)\.$";
            Match match = Regex.Match(howToGet, unlockedLevel);
            if (match.Success) {
                int level = ExtractLevel(match, card.Code);
                PlayerClassLanguage playerClassLanguage = ExtractPlayerClass(match, card.Code);
                PlayerClassCard playerClassCard = card.PlayerClassCards
                    .SingleOrDefault(pcc => pcc.PlayerClass.PlayerClassId == playerClassLanguage.PlayerClassId && pcc.Golden);
                if (playerClassCard == null) {
                    playerClassCard = new PlayerClassCard() {
                        PlayerClass = playerClassLanguage.PlayerClass,
                        Golden = true,
                    };
                    card.PlayerClassCards.Add(playerClassCard);
                }
                playerClassCard.Level = level;
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
                AddRaceCardSetCard(card, raceLanguage, cardSetLanguageFirst);
                CardSetLanguage cardSetLanguageSecond = ExtractCardSet(match, card.Code, "cardSet2");
                AddRaceCardSetCard(card, raceLanguage, cardSetLanguageSecond);
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
