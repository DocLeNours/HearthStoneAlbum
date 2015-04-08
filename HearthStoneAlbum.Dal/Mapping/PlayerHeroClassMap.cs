using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class PlayerHeroClassMap : EntityTypeConfiguration<PlayerHeroClass> {
        public PlayerHeroClassMap() {
            this.HasKey(cl => new { cl.PlayerId, cl.HeroClassId });
            this.HasRequired(cl => cl.Player)
                .WithMany(p => p.PlayerHeroClasses);
            this.HasRequired(cl => cl.HeroClass)
                .WithMany();
        }
    }
}
