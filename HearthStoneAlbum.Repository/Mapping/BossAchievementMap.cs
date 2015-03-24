using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class BossAchievementMap : EntityTypeConfiguration<BossAchievement> {
        public BossAchievementMap() {
            this.HasKey(ba => new { ba.PlayerId, ba.BossId });
            this.HasRequired(ba => ba.Player)
                .WithMany(p => p.BossAchievements);
            this.HasRequired(ba => ba.Boss)
                .WithMany();
        }
    }
}
