using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Language {
        public const int CodeMaxLength = 4;
        public int LanguageId { get; private set; }
        public string Code { get; private set; }
    }
}
