using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class HeroClassLanguage {
        public const int NameMaxLength = 20;

        public int HeroClassId { get; set; }
        public int LanguageId { get; set; }
        public HeroClass HeroClass { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
        public string HeroName { get; set; }
    }
}
