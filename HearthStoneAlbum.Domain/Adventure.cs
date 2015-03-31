using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Adventure {
        public int AdventureId { get; set; }
        public CardSet CardSet { get; set; }
        public ICollection<Wing> Wings { get; set; }
        public ICollection<AdventureLanguage> AdventureLanguages { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
