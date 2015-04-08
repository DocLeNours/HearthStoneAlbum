﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Wing {
        public Wing() {
            this.Bosses = new List<Boss>();
            this.WingLanguages = new List<WingLanguage>();
            this.Cards = new List<Card>();
            this.HeroClassChallenges = new List<HeroClassChallenge>();
        }

        public int WingId { get; set; }
        public int Order { get; set; }
        public Adventure Adventure { get; set; }
        public ICollection<Boss> Bosses { get; set; }
        public ICollection<WingLanguage> WingLanguages { get; set; }
        public ICollection<Card> Cards { get; set; }
        public ICollection<HeroClassChallenge> HeroClassChallenges { get; set; }
    }
}
