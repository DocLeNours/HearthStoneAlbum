using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class CardSetMap : EntityTypeConfiguration<CardSet> {
        public CardSetMap() {
            this.HasKey(cs => cs.CardSetId);
        }
    }
}
