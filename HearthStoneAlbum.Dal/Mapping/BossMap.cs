using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class BossMap : EntityTypeConfiguration<Boss> {
        public BossMap() {
            this.HasKey(b => b.BossId);
            this.Property(b => b.BossId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasRequired(b => b.Wing)
                .WithMany(w => w.Bosses)
                .Map(m => {
                    m.MapKey("WingId");
                });
            this.HasOptional(b => b.PlayerClass)
                .WithMany()
                .Map(m => {
                    m.MapKey("PlayerClassId");
                });
        }
    }
}
