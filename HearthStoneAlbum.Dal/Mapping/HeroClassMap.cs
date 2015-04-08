using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class HeroClassMap : EntityTypeConfiguration<HeroClass> {
        public HeroClassMap() {
            this.HasKey(pc => pc.HeroClassId);
            this.Property(pc => pc.HeroClassId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); 
        }
    }
}
