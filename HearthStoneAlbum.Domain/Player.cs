using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Player {
        public Player() {
            this.PlayerHeroClasses = new List<PlayerHeroClass>();
            this.PlayerBosses = new List<PlayerBoss>();
            this.PlayerCards = new List<PlayerCard>();
            this.PlayerHeroClassChallenges = new List<PlayerHeroClassChallenge>();
        }

        public int PlayerId { get; set; }
        public ICollection<PlayerHeroClass> PlayerHeroClasses { get; set; }
        public ICollection<PlayerBoss> PlayerBosses { get; set; }
        public ICollection<PlayerCard> PlayerCards { get; set; }
        public ICollection<PlayerHeroClassChallenge> PlayerHeroClassChallenges { get; set; }
    }
}
