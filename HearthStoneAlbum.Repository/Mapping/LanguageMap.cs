using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class LanguageMap : EntityTypeConfiguration<Language> {
        public LanguageMap() {
            this.HasKey(l => l.LanguageId);
            this.Property(l => l.Code)
                .HasMaxLength(Language.CodeMaxLength)
                .IsRequired();
        }
    }
}
