using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class AdventureMap : EntityTypeConfiguration<Adventure> {
        public AdventureMap() {
            this.HasKey(a => a.AdventureId);
            this.HasRequired(a => a.CardSet)
                .WithOptional(cs => cs.Adventure);
            this.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(Adventure.NameMaxLength);
        }
    }
}
