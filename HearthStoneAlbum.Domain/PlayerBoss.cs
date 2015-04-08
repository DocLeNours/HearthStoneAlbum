using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerBoss {
        public int PlayerId { get; set; }
        public int BossId { get; set; }
        public Player Player { get; set; }
        public Boss Boss { get; set; }
    }
}
