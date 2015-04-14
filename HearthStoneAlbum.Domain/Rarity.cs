using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Rarity {
        private const int RegularCopyNumber = 2;
        private const int LegendaryCopyNumber = 1;
        private const int LegendaryRarity = 5;

        public Rarity() {
            this.Cards = new List<Card>();
            this.RarityLanguages = new List<RarityLanguage>();
        }

        public int RarityId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<RarityLanguage> RarityLanguages { get; set; }
        public int CopyNumber {
            get {
                switch (this.RarityId) {
                    case LegendaryRarity:
                        return LegendaryCopyNumber;
                    default:
                        return RegularCopyNumber;
                }
            }
        }
    }
}
