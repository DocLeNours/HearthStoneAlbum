using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class WingMap : EntityTypeConfiguration<Wing> {
        public WingMap() {
            this.HasKey(w => w.WingId);
            this.HasRequired(w => w.Adventure)
                .WithMany(a => a.Wings)
                .Map(m => {
                    m.MapKey("AdventureId");
                });
            //this.Property(a => a.Adventure.AdventureId)
            //    .HasUniqueIndexAnnotation("UQAdventureOrder", 0);
            //this.Property(a => a.Order)
            //    .HasUniqueIndexAnnotation("UQAdventureOrder", 1);
        }
    }
}
