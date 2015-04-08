using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class HeroClassCard {
        public int HeroClassId { get; set; }
        public int CardId { get; set; }
        public bool Golden { get; set; }
        public HeroClass HeroClass { get; set; }
        public Card Card { get; set; }
        public int Level { get; set; }
    }
}
