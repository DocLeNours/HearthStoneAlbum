using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class HeroClassRewardMap: EntityTypeConfiguration<HeroClassReward> {
        public HeroClassRewardMap() {
            this.ToTable("HeroClassReward");
            this.HasRequired(hcr=>hcr.HeroClass)
                .WithMany(hc=>hc.HeroClassRewards)
                .Map(m => {
                    m.MapKey("HeroClassId");
                });
        }
    }
}
