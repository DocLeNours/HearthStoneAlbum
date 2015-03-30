using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class PlayerCardMap : EntityTypeConfiguration<PlayerCard> {
        public PlayerCardMap() {
            this.HasKey(pc => new { pc.PlayerId, pc.CardId });
            this.HasRequired(pc => pc.Player)
                .WithMany(p => p.PlayerCards);
            this.HasRequired(pc => pc.Card)
                .WithMany();
        }
    }
}
