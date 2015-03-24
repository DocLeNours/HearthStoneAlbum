using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class ClassLevel {
        public readonly int LevelMin = 0;
        public readonly int LevelMax = 60;

        public int PlayerId { get; private set; }
        public int PlayerClassId { get; private set; }
        public Player Player { get; private set; }
        public PlayerClass PlayerClass { get; private set; }
        public int Level { get; private set; }
    }
}
