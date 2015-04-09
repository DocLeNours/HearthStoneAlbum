using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Adventure {
        public Adventure() {
            this.Wings = new List<Wing>();
            this.AdventureLanguages = new List<AdventureLanguage>();
        }
        public int AdventureId { get; set; }
        public CardSet CardSet { get; set; }
        public ICollection<Wing> Wings { get; set; }
        public ICollection<AdventureLanguage> AdventureLanguages { get; set; }
    }
}
