using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardSetLanguage {
        public const int NameMaxLength = 50;

        public int CardSetId { get; private set; }
        public int LanguageId { get; private set; }
        public CardSet CardSet { get; private set; }
        public Language Language { get; private set; }
        public string Name { get; private set; }
    }
}
