using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Card {
        public string CardId { get; private set; }
        public CardSet CardSet { get; private set; }
        public PlayerClass PlayerClass { get; private set; }
        public Rarity Rarity { get; private set; }
        public CardType CardType { get; private set; }
        public Race Race { get; private set; }
        public int Cost { get; private set; }
        public int Attack { get; private set; }
        public int Health { get; private set; }
        public int Durability { get; private set; }
    }
}
