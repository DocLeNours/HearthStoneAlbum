using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerClassCard {
        public int PlayerClassId { get; set; }
        public int CardId { get; set; }
        public bool Golden { get; set; }
        public PlayerClass PlayerClass { get; set; }
        public Card Card { get; set; }
        public int Level { get; set; }
    }
}
