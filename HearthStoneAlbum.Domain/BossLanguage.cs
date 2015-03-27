using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class BossLanguage {
        public const int NameMaxLength = 50;

        public int BossId { get; private set; }
        public int LanguageId { get; private set; }
        public Boss Boss { get; private set; }
        public Language Language { get; private set; }
        public string Name { get; private set; }
    }
}
