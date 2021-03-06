﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain {
    public class Boss {
        public Boss() {
            this.BossLanguages = new List<BossLanguage>();
            this.BossRewards = new List<BossReward>();
        }
        public int BossId { get; set; }
        public int Order { get; set; }
        public Wing Wing { get; set; }
        public ICollection<BossLanguage> BossLanguages { get; set; }
        public ICollection<BossReward> BossRewards { get; set; }
    }
}
