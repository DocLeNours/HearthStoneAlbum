using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class RarityLanguage {
        public const int NameMaxLength = 20;

        public int RarityId { get; set; }
        public int LanguageId { get; set; }
        public Rarity Rarity { get; set; }
        public Language Language { get; set; }
        public string Name { get; set; }
    }
}
