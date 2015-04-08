using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class PlayerBossMap : EntityTypeConfiguration<PlayerBoss> {
        public PlayerBossMap() {
            this.HasKey(ba => new { ba.PlayerId, ba.BossId });
            this.HasRequired(ba => ba.Player)
                .WithMany(p => p.PlayerBosses);
            this.HasRequired(ba => ba.Boss)
                .WithMany();
        }
    }
}
