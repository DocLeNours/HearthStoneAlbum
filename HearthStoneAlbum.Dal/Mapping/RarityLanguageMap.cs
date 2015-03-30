using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class RarityLanguageMap : EntityTypeConfiguration<RarityLanguage> {
        public RarityLanguageMap() {
            this.HasKey(r => new { r.RarityId, r.LanguageId });
            this.Property(r => r.Name)
                .HasMaxLength(RarityLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(rl => rl.Rarity)
                .WithMany(r => r.RarityLanguages);
            this.HasRequired(rl => rl.Language)
                .WithMany();
        }
    }
}
