using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class WingRewardMap  : EntityTypeConfiguration<WingReward> {
        public WingRewardMap() {
            this.ToTable("WingReward");
            this.HasRequired(wr => wr.Wing)
                .WithMany(w => w.WingRewards)
                .Map(m => {
                    m.MapKey("WingId");
                });
        }
    }
}
