using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class PlayerClassLanguageMap : EntityTypeConfiguration<PlayerClassLanguage> {
        public PlayerClassLanguageMap() {
            this.HasKey(pc => new { pc.PlayerClassId, pc.LanguageId });
            this.Property(pc => pc.Name)
                .HasMaxLength(PlayerClassLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(pcl => pcl.PlayerClass)
                .WithMany(pc => pc.PlayerClassLanguages);
            this.HasRequired(pcl => pcl.Language)
                .WithMany();
        }
    }
}
