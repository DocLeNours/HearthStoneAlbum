using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Interface
{
    public interface IPlayerAccountService
    {
        Task<int> CreateAccount(Player player);
    }
}
