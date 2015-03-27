using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardSet {
        public int CardSetId { get; private set; }
        public Adventure Adventure { get; private set; }
        public ICollection<Card> Cards { get; private set; }
        public ICollection<CardSetLanguage> CardSetLanguages { get; set; }
    }
}
