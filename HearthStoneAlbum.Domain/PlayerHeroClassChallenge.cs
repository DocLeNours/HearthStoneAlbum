using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerHeroClassChallenge {
        public int PlayerId { get; set; }
        public int HeroClassChallengeId { get; set; }
        public Player Player { get; set; }
        public HeroClassChallenge HeroClassChallenge { get; set; }
    }
}
