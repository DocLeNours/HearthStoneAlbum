using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardLanguage {
        public const int NameMaxLength = 50;

        public int CardId { get; set; }
        public int LanguageId { get; set; }
        public Card Card { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
