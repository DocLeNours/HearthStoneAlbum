using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class BossMap : EntityTypeConfiguration<Boss> {
        public BossMap() {
            this.HasKey(b => b.BossId);
            this.Property(b => b.Name)
                .HasMaxLength(Boss.NameMaxLength)
                .IsRequired();
            this.HasRequired(b => b.Wing)
                .WithMany(w => w.Bosses)
                .Map(m => {
                    m.MapKey("WingId");
                });
        }
    }
}
