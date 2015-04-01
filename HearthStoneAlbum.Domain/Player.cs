using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Player {
        public Player() {
            this.ClassLevels = new List<ClassLevel>();
            this.BossAchievements = new List<BossAchievement>();
            this.PlayerCards = new List<PlayerCard>();
        }

        public int PlayerId { get; set; }
        public ICollection<ClassLevel> ClassLevels { get; set; }
        public ICollection<BossAchievement> BossAchievements { get; set; }
        public ICollection<PlayerCard> PlayerCards { get; set; }
    }
}
