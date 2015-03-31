using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Boss {
        public int BossId { get; set; }
        public Wing Wing { get; set; }
        public PlayerClass PlayerClass { get; set; }
        public ICollection<BossLanguage> BossLanguages { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<Card> PlayerClassCards { get; set; }
    }
}
