using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class HeroClassChallengeMap : EntityTypeConfiguration<HeroClassChallenge> {
        public HeroClassChallengeMap() {
            this.HasKey(hcc => hcc.HeroClassChallengeId);
            this.HasRequired(hcc => hcc.Wing)
                .WithMany(w => w.HeroClassChallenges);
            this.HasRequired(hcc => hcc.HeroClass)
                .WithMany();
        }
    }
}
