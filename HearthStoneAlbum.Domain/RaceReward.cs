using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class RaceReward : Reward {
        public RaceReward() {
            this.CardSetRaceRewards = new List<CardSetRaceReward>();
        }
        public Race Race { get; set; }
        public ICollection<CardSetRaceReward> CardSetRaceRewards { get; set; }
    }
}
