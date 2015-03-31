using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Dal;
using HearthStoneAlbum.DataImport.XmlDomain;
using HearthStoneAlbum.Domain;
using System.Data.Entity;

namespace HearthStoneAlbum.DataImport.Service {
    public class ImportService {
        private HearthStoneAlbumDbContext context;
        private IList<Card> cards;
        private IList<CardSet> cardSets;
        private IList<Rarity> rarities;
        private IList<Race> races;
        private IList<CardType> cardTypes;
        private IList<PlayerClass> playerClasses;
        
        public ImportService(HearthStoneAlbumDbContext context) {
            this.context = context;
            cards = context.Cards.ToList();
            cardSets = context.CardSets.ToList();
            rarities = context.Rarities.ToList();
            races = context.Races.ToList();
            cardTypes = context.CardTypes.ToList();
            playerClasses = context.PlayerClasses.ToList();
        }

        public void Import(IList<Entity> entities) {
            foreach (Entity entity in entities) {
                Card card = new Card();
                card.Code = entity.CardId;
                card.CardSet = GetValue<CardSet>(entity.GetTag("CardSet"));
                card.PlayerClass = GetValue<PlayerClass>(entity.GetTag("Class"));
                card.Rarity = GetValue<Rarity>(entity.GetTag("Rarity"));
                card.CardType = GetValue<CardType>(entity.GetTag("CardType"));
                card.Race = GetValue<Race>(entity.GetTag("Race"));
                card.Cost = GetValue(entity.GetTag("Cost"));
                card.Attack = GetOptionalValue(entity.GetTag("Atk"));
                card.Health = GetOptionalValue(entity.GetTag("Health"));
                card.Durability = GetOptionalValue(entity.GetTag("Durability"));

            }
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
    }
}
