using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain.Interface;

namespace HearthStoneAlbum.Domain.Factory {
    public class PlayerFactory {
        private IPlayerRepository playerRepository;
        private IAlbumRepository albumRepository;
        public PlayerFactory(IPlayerRepository playerRepository, IAlbumRepository albumRepository) {
            this.playerRepository = playerRepository;
            this.albumRepository = albumRepository;
        }
        public Player CreatePlayer() {
            //TODO
            return null;
        }
    }
}
