using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class BossLanguageMap : EntityTypeConfiguration<BossLanguage> {
        public BossLanguageMap() {
            this.HasKey(b => new { b.BossId, b.LanguageId });
            this.Property(b => b.Name)
                .HasMaxLength(BossLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(bl => bl.Boss)
                .WithMany(b => b.BossLanguages);
            this.HasRequired(bl => bl.Language)
                .WithMany();
        }
    }
}
