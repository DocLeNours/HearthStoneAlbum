using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class AdventureLanguage {
        public const int NameMaxLength = 50;

        public int AdventureId { get; set; }
        public int LanguageId { get; set; }
        public Adventure Adventure { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
