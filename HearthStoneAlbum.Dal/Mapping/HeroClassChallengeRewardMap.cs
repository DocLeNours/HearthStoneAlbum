using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class HeroClassChallengeRewardMap : EntityTypeConfiguration<HeroClassChallengeReward> {
        public HeroClassChallengeRewardMap() {
            this.ToTable("HeroClassChallengeReward");
            this.HasRequired(hccr => hccr.HeroClassChallenge)
                .WithMany(hcc => hcc.HeroClassChallengeRewards)
                .Map(m => {
                    m.MapKey("HeroClassChallengeId");
                });
        }
    }
}
