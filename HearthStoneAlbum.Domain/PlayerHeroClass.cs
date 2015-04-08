using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerHeroClass {
        public readonly int LevelMin = 0;
        public readonly int LevelMax = 60;

        public int PlayerId { get; set; }
        public int HeroClassId { get; set; }
        public Player Player { get; set; }
        public HeroClass HeroClass { get; set; }
        public int Level { get; set; }
    }
}
