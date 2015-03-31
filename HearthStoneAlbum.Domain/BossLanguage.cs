using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class BossLanguage {
        public const int NameMaxLength = 50;

        public int BossId { get; set; }
        public int LanguageId { get; set; }
        public Boss Boss { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
