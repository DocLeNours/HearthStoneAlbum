using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerCard {
        public int PlayerId { get; private set; }
        public int CardId { get; private set; }
        public Player Player { get; private set; }
        public Card Card { get; private set; }
        public int CopyNumber { get; private set; }
        public int GoldenCopyNumber { get; private set; }
    }
}
