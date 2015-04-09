using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class AdventureCard {
        public int AdventureCardId { get; set; }
        public Card Card { get; set; }
        public Wing Wing { get; set; }
        public Boss Boss { get; set; }
        public HeroClassChallenge HeroClassChallenge { get; set; }
    }
}
