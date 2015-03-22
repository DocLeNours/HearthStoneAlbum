using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class ClassChallenge {
        public int ClassChallengeId { get; set; }
        public PlayerClass Class { get; set; }
        public Boss BossAchieved { get; set; }
    }
}
