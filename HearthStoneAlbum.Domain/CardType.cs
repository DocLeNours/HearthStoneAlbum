using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardType {
        public int CardTypeId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<CardTypeLanguage> CardTypeLanguages { get; set; }
    }
}
