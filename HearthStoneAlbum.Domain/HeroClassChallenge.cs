using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class HeroClassChallenge {
        public HeroClassChallenge() {
            this.AdventureCards = new List<AdventureCard>();
        }
        public int HeroClassChallengeId { get; set; }
        public int WingId { get; set; }
        public int HeroClassId { get; set; }
        public Wing Wing { get; set; }
        public HeroClass HeroClass { get; set; }
        public ICollection<AdventureCard> AdventureCards { get; set; }
    }
}
