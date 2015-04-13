using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class RaceRewardMap : EntityTypeConfiguration<RaceReward> {
        public RaceRewardMap() {
            this.ToTable("RaceReward");
            this.HasRequired(rr=>rr.Race)
                .WithMany(r=>r.RaceRewards)
                .Map(m => {
                    m.MapKey("RaceId");
                });
        }
    }
}
