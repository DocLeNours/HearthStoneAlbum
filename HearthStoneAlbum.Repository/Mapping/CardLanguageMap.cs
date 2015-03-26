using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class CardLanguageMap : EntityTypeConfiguration<CardLanguage> {
        public CardLanguageMap() {
            this.HasKey(cl => new { cl.CardId, cl.LanguageId });
            this.Property(cl => cl.Name)
                .HasMaxLength(CardLanguage.NameMaxLength)
                .IsRequired();
        }
    }
}
