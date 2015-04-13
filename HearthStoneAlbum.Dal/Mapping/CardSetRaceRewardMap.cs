using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class CardSetRaceRewardMap : EntityTypeConfiguration<CardSetRaceReward> {
        public CardSetRaceRewardMap() {
            this.HasKey(csrr => new { csrr.CardId, csrr.Golden, csrr.CardSetId });
            this.HasRequired(csrr => csrr.RaceReward)
                .WithMany(rr => rr.CardSetRaceRewards);
            this.HasRequired(csrr => csrr.CardSet)
                .WithMany();
        }
    }
}
