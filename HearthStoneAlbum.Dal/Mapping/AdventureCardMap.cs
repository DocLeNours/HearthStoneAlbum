using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class AdventureCardMap : EntityTypeConfiguration<AdventureCard> {
        public AdventureCardMap() {
            this.HasKey(ac => ac.AdventureCardId);
            this.HasRequired(ac => ac.Card)
                .WithOptional(c => c.AdventureCard);
            this.HasOptional(ac => ac.Wing)
                .WithMany(w => w.AdventureCards)
                .Map(m => {
                    m.MapKey("WingId");
                });
            this.HasOptional(ac => ac.Boss)
                .WithMany(b => b.AdventureCards)
                .Map(m => {
                    m.MapKey("BossId");
                });
            this.HasOptional(ac => ac.HeroClassChallenge)
                .WithMany(hcc => hcc.AdventureCards)
                .Map(m => {
                    m.MapKey("HeroClassChallengeId");
                });
        }
    }
}
