using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class CardMap : EntityTypeConfiguration<Card> {
        public CardMap() {
            this.HasKey(c => c.CardId);
            this.HasRequired(c => c.CardSet)
                .WithMany(cs => cs.Cards)
                .Map(m => {
                    m.MapKey("CardSetId");
                });
            this.HasOptional(c => c.PlayerClass)
                .WithMany(pc => pc.Cards)
                .Map(m => {
                    m.MapKey("PlayerClassId");
                });
            this.HasRequired(c => c.Rarity)
                .WithMany(r => r.Cards)
                .Map(m => {
                    m.MapKey("RarityId");
                });
            this.HasRequired(c => c.CardType)
                .WithMany(ct => ct.Cards)
                .Map(m => {
                    m.MapKey("CardTypeId");
                });
            this.HasOptional(c => c.Race)
                .WithMany(r => r.Cards)
                .Map(m => {
                    m.MapKey("RaceId");
                });
        }
    }
}
