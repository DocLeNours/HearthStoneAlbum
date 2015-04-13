using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardSetRaceReward {
        public int CardId { get; set; }
        public bool Golden { get; set; }
        public int CardSetId { get; set; }
        public RaceReward RaceReward { get; set; }
        public CardSet CardSet { get; set; }
    }
}
