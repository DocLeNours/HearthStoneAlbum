using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class HeroClassLanguageMap : EntityTypeConfiguration<HeroClassLanguage> {
        public HeroClassLanguageMap() {
            this.HasKey(pc => new { pc.HeroClassId, pc.LanguageId });
            this.Property(pc => pc.Name)
                .HasMaxLength(HeroClassLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(pcl => pcl.HeroClass)
                .WithMany(pc => pc.HeroClassLanguages);
            this.HasRequired(pcl => pcl.Language)
                .WithMany();
        }
    }
}
