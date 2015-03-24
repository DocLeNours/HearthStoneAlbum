using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class ClassChallenge {
        public int ClassChallengeId { get; private set; }
        public Boss Boss { get; private set; }
        public PlayerClass PlayerClass { get; private set; }
    }
}
