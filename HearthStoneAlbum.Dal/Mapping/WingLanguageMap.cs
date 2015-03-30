using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class WingLanguageMap : EntityTypeConfiguration<WingLanguage> {
        public WingLanguageMap() {
            this.HasKey(w => new { w.WingId, w.LanguageId });
            this.Property(w => w.Name)
                .HasMaxLength(WingLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(wl => wl.Wing)
                .WithMany(w => w.WingLanguages);
            this.HasRequired(wl => wl.Language)
                .WithMany();
        }
    }
}
