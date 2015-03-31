using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class PlayerClassLanguage {
        public const int NameMaxLength = 20;

        public int PlayerClassId { get; set; }
        public int LanguageId { get; set; }
        public PlayerClass PlayerClass { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
