using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class CardTypeMap : EntityTypeConfiguration<CardType> {
        public CardTypeMap() {
            this.HasKey(ct => ct.CardTypeId);
        }
    }
}
