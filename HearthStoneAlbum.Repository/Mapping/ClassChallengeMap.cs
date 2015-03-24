using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class ClassChallengeMap : EntityTypeConfiguration<ClassChallenge> {
        public ClassChallengeMap() {
            this.HasKey(cc => cc.ClassChallengeId);
            this.HasRequired(cc => cc.Boss)
                .WithOptional(b => b.ClassChallenge);
            this.HasRequired(cc => cc.PlayerClass)
                .WithMany()
                .Map(m => {
                    m.MapKey("PlayerClassId");
                });
        }
    }
}
