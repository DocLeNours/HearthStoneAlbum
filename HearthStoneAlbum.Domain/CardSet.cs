using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardSet {
        public int CardSetId { get; set; }
        public Adventure Adventure { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<CardSetLanguage> CardSetLanguages { get; set; }
    }
}
