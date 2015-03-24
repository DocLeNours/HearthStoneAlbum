﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain
{
    public class CardType
    {
        public const int NameMaxLength = 20;
        public int CardTypeId { get; private set; }
        public string Name { get; private set; }
        public ICollection<Card> Cards { get; private set; }
    }
}
