﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class CardTypeLanguage {
        public const int NameMaxLength = 20;

        public int CardTypeId { get; private set; }
        public int LanguageId { get; private set; }
        public CardType CardType { get; private set; }
        public Language Language { get; private set; }
        public string Name { get; private set; }
    }
}