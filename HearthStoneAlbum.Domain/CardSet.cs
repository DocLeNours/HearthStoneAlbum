using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardSet {
        public const int NameMaxLength = 50;
        public int CardSetId { get; private set; }
        public string Name { get; private set; }
        public Adventure Adventure { get; private set; }
        public ICollection<Card> Cards { get; private set; }
    }
}
