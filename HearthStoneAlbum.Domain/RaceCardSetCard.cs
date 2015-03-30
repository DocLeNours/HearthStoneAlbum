using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class RaceCardSetCard {
        public int RaceId { get; private set; }
        public int CardSetId { get; private set; }
        public int CardId { get; private set; }
        public Race Race { get; private set; }
        public CardSet CardSet { get; private set; }
        public Card Card { get; private set; }
    }
}
