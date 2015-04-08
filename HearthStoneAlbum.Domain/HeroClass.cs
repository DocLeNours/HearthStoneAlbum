using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class HeroClass {
        public HeroClass() {
            this.Cards = new List<Card>();
            this.HeroClassLanguages = new List<HeroClassLanguage>();
            this.HeroClassCards = new List<HeroClassCard>();
        }

        public int HeroClassId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<HeroClassLanguage> HeroClassLanguages { get; set; }
        public ICollection<HeroClassCard> HeroClassCards { get; set; }
    }
}
