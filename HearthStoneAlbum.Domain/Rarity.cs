using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Rarity {
        public Rarity() {
            this.Cards = new List<Card>();
            this.RarityLanguages = new List<RarityLanguage>();
        }

        public int RarityId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<RarityLanguage> RarityLanguages { get; set; }
    }
}
