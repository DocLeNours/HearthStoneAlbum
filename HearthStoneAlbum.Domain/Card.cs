using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Card {
        public const int CodeMaxLength = 10;

        public int CardId { get; set; }
        public string Code { get; set; }
        public CardSet CardSet { get; set; }
        public PlayerClass PlayerClass { get; set; }
        public Rarity Rarity { get; set; }
        public CardType CardType { get; set; }
        public Race Race { get; set; }
        public int Cost { get; set; }
        public int? Attack { get; set; }
        public int? Health { get; set; }
        public int? Durability { get; set; }
        public ICollection<CardLanguage> CardLanguages { get; set; }
        public ICollection<PlayerClassCard> PlayerClassCards { get; set; }
        public Adventure Adventure { get; set; }
        public Wing Wing { get; set; }
        public Boss Boss { get; set; }
        public Boss PlayerClassBoss { get; set; }
    }
}
