using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class BossAchievement {

        public BossAchievement(Boss boss, bool achieved) {
            this.Boss = boss;
            this.Achieved = achieved;
        }

        public Boss Boss { get; private set; }
        public bool Achieved { get; private set; }
    }
}
