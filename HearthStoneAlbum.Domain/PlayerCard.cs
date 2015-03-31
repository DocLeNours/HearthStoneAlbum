using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerCard {
        public int PlayerId { get; set; }
        public int CardId { get; set; }
        public Player Player { get; set; }
        public Card Card { get; set; }
        public int CopyNumber { get; set; }
        public int GoldenCopyNumber { get; set; }
    }
}
