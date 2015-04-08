using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Domain.Interface;

namespace HearthStoneAlbum.Dal {
    public class PlayerRepository : IPlayerRepository {
        public Player GetPlayer(int playerId) {
            throw new NotImplementedException();
        }

        public IList<HeroClass> GetHeroClasses() {
            throw new NotImplementedException();
        }

        public IList<Boss> GetBosses() {
            throw new NotImplementedException();
        }
    }
}
