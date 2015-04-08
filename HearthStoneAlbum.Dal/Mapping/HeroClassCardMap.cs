using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class HeroClassCardMap : EntityTypeConfiguration<HeroClassCard> {
        public HeroClassCardMap() {
            this.HasKey(pcc => new { pcc.HeroClassId, pcc.CardId, pcc.Golden });
            this.HasRequired(pcc => pcc.HeroClass)
                .WithMany(pc => pc.HeroClassCards);
            this.HasRequired(pc => pc.Card)
                .WithMany(c => c.HeroClassCards);
        }
    }
}
