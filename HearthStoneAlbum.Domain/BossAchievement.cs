using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class BossAchievement {
        public int PlayerId { get; private set; }
        public int BossId { get; private set; }
        public Player Player { get; private set; }
        public Boss Boss { get; private set; }
        public bool Achieved { get; private set; }
    }
}
