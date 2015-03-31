using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class RaceCardSetCard {
        public int RaceId { get; set; }
        public int CardSetId { get; set; }
        public int CardId { get; set; }
        public Race Race { get; set; }
        public CardSet CardSet { get; set; }
        public Card Card { get; set; }
    }
}
