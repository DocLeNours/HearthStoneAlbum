using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class PlayerClassMap : EntityTypeConfiguration<PlayerClass> {
        public PlayerClassMap() {
            this.HasKey(pc => pc.PlayerClassId);
            this.Property(pc => pc.Name)
                .HasMaxLength(PlayerClass.NameMaxLength)
                .IsRequired();
        }
    }
}
