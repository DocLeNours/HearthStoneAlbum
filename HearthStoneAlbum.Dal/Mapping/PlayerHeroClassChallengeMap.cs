using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class PlayerHeroClassChallengeMap : EntityTypeConfiguration<PlayerHeroClassChallenge> {
        public PlayerHeroClassChallengeMap() {
            this.HasKey(phcc => new { phcc.PlayerId, phcc.WingId, phcc.HeroClassId });
            this.HasRequired(phcc => phcc.Player)
                .WithMany(p => p.PlayerHeroClassChallenges);
            this.HasRequired(phcc => phcc.HeroClassChallenge)
                .WithMany();
        }
    }
}
