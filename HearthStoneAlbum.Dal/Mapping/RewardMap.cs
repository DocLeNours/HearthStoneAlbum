using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class RewardMap : EntityTypeConfiguration<Reward> {
        public RewardMap() {
            this.HasKey(r => new { r.CardId, r.Golden });
            this.HasRequired(r => r.Card)
                .WithMany(c => c.Rewards);
        }
    }
}
