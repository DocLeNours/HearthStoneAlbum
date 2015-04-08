using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain.Interface {
    public interface IPlayerRepository {
        Player GetPlayer(int playerId);
        IList<HeroClass> GetHeroClasses();
        IList<Boss> GetBosses();
    }
}
