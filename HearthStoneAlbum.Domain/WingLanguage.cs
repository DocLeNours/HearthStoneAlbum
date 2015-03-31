using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class WingLanguage {
        public const int NameMaxLength = 50;

        public int WingId { get; set; }
        public int LanguageId { get; set; }
        public Wing Wing { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
