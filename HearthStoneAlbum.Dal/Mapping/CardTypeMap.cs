using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class CardTypeMap : EntityTypeConfiguration<CardType> {
        public CardTypeMap() {
            this.HasKey(ct => ct.CardTypeId);
            this.Property(ct => ct.CardTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
