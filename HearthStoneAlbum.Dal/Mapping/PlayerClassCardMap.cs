using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class PlayerClassCardMap : EntityTypeConfiguration<PlayerClassCard> {
        public PlayerClassCardMap() {
            this.HasKey(pcc => new { pcc.PlayerClassId, pcc.CardId, pcc.Golden });
            this.HasRequired(pcc => pcc.PlayerClass)
                .WithMany(pc => pc.PlayerClassCards);
            this.HasRequired(pc => pc.Card)
                .WithMany(c => c.PlayerClassCards);
        }
    }
}
