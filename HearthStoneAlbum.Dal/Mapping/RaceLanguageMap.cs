using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class RaceLanguageMap : EntityTypeConfiguration<RaceLanguage> {
        public RaceLanguageMap() {
            this.HasKey(r => new { r.RaceId, r.LanguageId });
            this.Property(r => r.Name)
                .HasMaxLength(RaceLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(rl => rl.Race)
                .WithMany(r => r.RaceLanguages);
            this.HasRequired(rl => rl.Language)
                .WithMany();
        }
    }
}
