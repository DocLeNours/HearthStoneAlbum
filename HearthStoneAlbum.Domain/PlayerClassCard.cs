using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerClassCard {
        public int PlayerClassId { get; private set; }
        public int CardId { get; private set; }
        public bool Golden { get; private set; }
        public PlayerClass PlayerClass { get; private set; }
        public Card Card { get; private set; }
        public int Level { get; private set; }
    }
}
