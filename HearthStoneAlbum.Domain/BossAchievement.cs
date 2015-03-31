using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class BossAchievement {
        public int PlayerId { get; set; }
        public int BossId { get; set; }
        public Player Player { get; set; }
        public Boss Boss { get; set; }
        public bool ClassChallenge { get; set; }
    }
}
