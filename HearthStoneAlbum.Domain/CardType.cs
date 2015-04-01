using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardType {
        public CardType() {
            this.Cards = new List<Card>();
            this.CardTypeLanguages = new List<CardTypeLanguage>();
        }

        public int CardTypeId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<CardTypeLanguage> CardTypeLanguages { get; set; }
    }
}
