using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class BossRewardMap : EntityTypeConfiguration<BossReward> {
        public BossRewardMap() {
            this.ToTable("BossReward");
            this.HasRequired(br => br.Boss)
                .WithMany(b => b.BossRewards)
                .Map(m => {
                    m.MapKey("BossId");
                });
        }
    }
}
