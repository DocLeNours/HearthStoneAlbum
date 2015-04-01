using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using HearthStoneAlbum.Dal;
using HearthStoneAlbum.DataImport.XmlDomain;
using HearthStoneAlbum.Domain;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace HearthStoneAlbum.DataImport.Service {
    public class ImportService : IDisposable {
        private const int defaultLanguageId = 1;
        private const string unlockedLevel = @"^Unlocked at Level (?<level>\d+)\.$";
        private const string unlockedWing = @"^Unlocked by completing the (?<wing>\w+)\.$";
        private const string unlockedBoss = @"^Unlocked by defeating (?<boss>\w+) in the (?<wing>\w+)\.$";
        private const string unlockedChallenge = @"^Unlocked by completing the (?<playerClass>\w+) Class Challenge in (?<adventure>\w+)\.$";
        private const string unlockedAdventure = @"^Unlocked by defeating every boss in (?<adventure>\w+)\!$";
        private const string unlockedRace = @"^Unlocked when you have all the (?<race>\w+)s from the (?<cardSet>\w+) Set\.$";

        private HearthStoneAlbumDbContext context;
        Action<string> logger;
        private IList<Card> cards;
        private IList<CardSet> cardSets;
        private IList<Rarity> rarities;
        private IList<Race> races;
        private IList<CardType> cardTypes;
        private IList<PlayerClass> playerClasses;
        private IList<Language> languages;
        private IList<AdventureLanguage> adventures;
        private IList<WingLanguage> wings;
        private IList<BossLanguage> bosses;

        public ImportService(string connectionString, Action<string> logger) {
            this.context = new HearthStoneAlbumDbContext(connectionString);
            this.logger = logger;
            cards = context.Cards.ToList();
            cardSets = context.CardSets.ToList();
            rarities = context.Rarities.ToList();
            races = context.Races.ToList();
            cardTypes = context.CardTypes.ToList();
            playerClasses = context.PlayerClasses.ToList();
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
                .Where(bl => bl.LanguageId == defaultLanguageId)
                .ToList();
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
            ProcessHowToGet(card, entity.GetTag("HowToGetThisCard"));
            ProcessHowToGetGold(card, entity.GetTag("HowToGetThisGoldCard"));
            context.Cards.AddOrUpdate(card);
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

        public void Dispose() {
            if (context != null) {
                context.Dispose();
                GC.SuppressFinalize(context);
            }
        }

        private void ProcessHowToGet(Card card, Tag tag) {
            if (tag == null) {
                return;
            }
            string howToGet = tag.enUS;
            Match match = Regex.Match(howToGet, unlockedLevel);
            if (match.Success) {
                string level = match.Groups["level"].Value;
            }
        }
        private void ProcessHowToGetGold(Card card, Tag tag) {
            if (tag == null) {
                return;
            }

        }
    }
}
