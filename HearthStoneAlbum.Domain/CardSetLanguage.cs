using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardSetLanguage {
        public const int NameMaxLength = 50;

        public int CardSetId { get; set; }
        public int LanguageId { get; set; }
        public CardSet CardSet { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
