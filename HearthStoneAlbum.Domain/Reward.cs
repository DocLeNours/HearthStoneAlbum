using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public abstract class Reward {
        public int CardId { get; set; }
        public bool Golden { get; set; }
        public Card Card { get; set; }
    }
}
