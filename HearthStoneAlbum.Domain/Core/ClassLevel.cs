using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class ClassLevel {
        public readonly int MinPlayerClassLevel = 0;
        public readonly int MaxPlayerClassLevel = 60;

        public ClassLevel(PlayerClass playerClass, int level) {
            if (level < MinPlayerClassLevel || level > MaxPlayerClassLevel) {
                throw new ArgumentException("Level must be at least 0 and at most 60", "level");
            }
            if (playerClass == null) {
                throw new ArgumentNullException("playerClass");
            }
            this.PlayerClass = playerClass;
            this.Level = level;
        }
        public PlayerClass PlayerClass { get; private set; }
        public int Level { get; private set; }
    }
}
