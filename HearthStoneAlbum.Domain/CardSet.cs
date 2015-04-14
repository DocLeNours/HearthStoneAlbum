using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardSet {
        public const int BasicCardSetId = 2;

        public CardSet() {
            this.Cards = new List<Card>();
            this.CardSetLanguages = new List<CardSetLanguage>();
        }

        public int CardSetId { get; set; }
        public Adventure Adventure { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<CardSetLanguage> CardSetLanguages { get; set; }
    }
}
