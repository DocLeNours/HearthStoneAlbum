using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerClass {
        public const int NameMaxLength = 20;
        public int PlayerClassId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Card> Cards { get; private set; }
        public ICollection<PlayerClassLanguage> PlayerClassLanguages { get; set; }
        public ICollection<PlayerClassCard> PlayerClassCards { get; private set; }
    }
}
