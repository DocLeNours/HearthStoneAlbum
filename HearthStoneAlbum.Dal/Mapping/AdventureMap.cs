using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class AdventureMap : EntityTypeConfiguration<Adventure> {
        public AdventureMap() {
            this.HasKey(a => a.AdventureId);
            this.Property(a => a.AdventureId);
            this.HasRequired(a => a.CardSet)
                .WithOptional(cs => cs.Adventure);
        }
    }
}
