using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerClass {
        public int PlayerClassId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<PlayerClassLanguage> PlayerClassLanguages { get; set; }
        public ICollection<PlayerClassCard> PlayerClassCards { get; set; }
    }
}
