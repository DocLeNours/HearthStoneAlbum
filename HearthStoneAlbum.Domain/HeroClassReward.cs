using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class HeroClassReward : Reward {
        public HeroClass HeroClass { get; set; }
        public int Level { get; set; }
    }
}
