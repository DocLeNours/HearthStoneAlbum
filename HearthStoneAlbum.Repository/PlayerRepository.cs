using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Domain.Interface;

namespace HearthStoneAlbum.Repository {
    public class PlayerRepository : IPlayerRepository {
        public Player GetPlayer(int playerId) {
            throw new NotImplementedException();
        }

        public IList<PlayerClass> GetPlayerClasses() {
            throw new NotImplementedException();
        }

        public IList<Boss> GetBosses() {
            throw new NotImplementedException();
        }

        public IList<ClassChallenge> GetClassChallenges() {
            throw new NotImplementedException();
        }
    }
}
