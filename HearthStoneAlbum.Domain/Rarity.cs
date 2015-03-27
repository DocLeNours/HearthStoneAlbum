using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Rarity {
        public int RarityId { get; private set; }
        public ICollection<Card> Cards { get; private set; }
        public ICollection<RarityLanguage> RarityLanguages { get; set; }
    }
}
