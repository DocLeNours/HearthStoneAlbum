using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Language {
        public const int NameMaxLength = 6;
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public override string ToString() {
            return this.Name;
        }
    }
}
