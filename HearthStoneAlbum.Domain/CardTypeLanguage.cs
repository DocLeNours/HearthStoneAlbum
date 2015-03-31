using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardTypeLanguage {
        public const int NameMaxLength = 20;

        public int CardTypeId { get; set; }
        public int LanguageId { get; set; }
        public CardType CardType { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
