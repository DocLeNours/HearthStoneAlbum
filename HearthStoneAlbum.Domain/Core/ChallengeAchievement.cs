using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class ChallengeAchievement {
        public ChallengeAchievement(ClassChallenge challenge, bool achieved) {
            this.ClassChallenge = challenge;
            this.Achieved = achieved;
        }

        public ClassChallenge ClassChallenge { get; private set; }
        public bool Achieved { get; private set; }
    }
}
