using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Card {
        public const int CodeMaxLength = 15;

        public Card() {
            this.CardLanguages = new List<CardLanguage>();
            this.HeroClassCards = new List<HeroClassCard>();
            this.RaceCardSetCards = new List<RaceCardSetCard>();
        }

        public int CardId { get; set; }
        public string Code { get; set; }
        public CardSet CardSet { get; set; }
        public HeroClass HeroClass { get; set; }
        public Rarity Rarity { get; set; }
        public CardType CardType { get; set; }
        public Race Race { get; set; }
        public int? Cost { get; set; }
        public int? Attack { get; set; }
        public int? Health { get; set; }
        public int? Durability { get; set; }
        public ICollection<CardLanguage> CardLanguages { get; set; }
        public ICollection<HeroClassCard> HeroClassCards { get; set; }
        public ICollection<RaceCardSetCard> RaceCardSetCards { get; set; }
        public Adventure Adventure { get; set; }
        public Wing Wing { get; set; }
        public Boss Boss { get; set; }
    }
}
