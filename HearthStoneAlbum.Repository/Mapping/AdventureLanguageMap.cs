using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class AdventureLanguageMap : EntityTypeConfiguration<AdventureLanguage> {
        public AdventureLanguageMap() {
            this.HasKey(a => new { a.AdventureId, a.LanguageId });
            this.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(AdventureLanguage.NameMaxLength);
            this.HasRequired(al => al.Adventure)
                .WithMany(a => a.AdventureLanguages);
            this.HasRequired(al => al.Language)
                .WithMany();
        }
    }
}
