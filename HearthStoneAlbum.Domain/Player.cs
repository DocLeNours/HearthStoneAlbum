using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Player {
        public int PlayerId { get; private set; }
        public ICollection<ClassLevel> ClassLevels { get; private set; }
        public ICollection<BossAchievement> BossAchievements { get; private set; }
        public ICollection<ChallengeAchievement> ChallengeAchievements { get; private set; }
    }
}
