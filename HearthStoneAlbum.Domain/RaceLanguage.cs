using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class RaceLanguage {
        public const int NameMaxLength = 20;

        public int RaceId { get; set; }
        public int LanguageId { get; set; }
        public Race Race { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
