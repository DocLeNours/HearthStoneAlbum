using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class BossMap : EntityTypeConfiguration<Boss> {
        public BossMap() {
            this.HasKey(b => b.BossId);
            this.Property(b => b.BossId);
            this.HasRequired(b => b.Wing)
                .WithMany(w => w.Bosses)
                .Map(m => {
                    m.MapKey("WingId");
                });
            this.Property(b => b.Wing.WingId)
                .HasUniqueIndexAnnotation("UQWingOrder", 0);
            this.Property(b=>b.Order)
                .HasUniqueIndexAnnotation("UQWingOrder", 1);
        }
    }
}
