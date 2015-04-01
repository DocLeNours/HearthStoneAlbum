using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class RaceCardSetCardMap : EntityTypeConfiguration<RaceCardSetCard> {
        public RaceCardSetCardMap() {
            this.HasKey(rcsc => new { rcsc.RaceId, rcsc.CardSetId, rcsc.CardId });
            this.HasRequired(rcsc => rcsc.Race)
                .WithMany();
            this.HasRequired(rcsc => rcsc.CardSet)
                .WithMany();
            this.HasRequired(rcsc => rcsc.Card)
                .WithMany(c=>c.RaceCardSetCards);
        }
    }
}
