using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class ChallengeAchievementMap : EntityTypeConfiguration<ChallengeAchievement> {
        public ChallengeAchievementMap() {
            this.HasKey(ca => new { ca.PlayerId, ca.ClassChallengeId });
            this.HasRequired(ca => ca.Player)
                .WithMany(p => p.ChallengeAchievements);
            this.HasRequired(ca => ca.ClassChallenge)
                .WithMany();
        }
    }
}
