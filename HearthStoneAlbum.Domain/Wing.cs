using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Wing {
        public int WingId { get; private set; }
        public Adventure Adventure { get; private set; }
        public ICollection<Boss> Bosses { get; private set; }
        public ICollection<WingLanguage> WingLanguages { get; set; }
    }
}
