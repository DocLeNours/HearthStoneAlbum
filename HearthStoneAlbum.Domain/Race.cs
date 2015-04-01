﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Race {
        public Race() {
            this.Cards = new List<Card>();
            this.RaceLanguages = new List<RaceLanguage>();
        }

        public int RaceId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<RaceLanguage> RaceLanguages { get; set; }
    }
}
