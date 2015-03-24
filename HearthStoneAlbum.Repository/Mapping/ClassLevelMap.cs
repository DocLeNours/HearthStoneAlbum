using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class ClassLevelMap : EntityTypeConfiguration<ClassLevel> {
        public ClassLevelMap() {
            this.HasKey(cl => new { cl.PlayerId, cl.PlayerClassId });
            this.HasRequired(cl => cl.Player)
                .WithMany(p => p.ClassLevels);
            this.HasRequired(cl => cl.PlayerClass)
                .WithMany();
        }
    }
}
