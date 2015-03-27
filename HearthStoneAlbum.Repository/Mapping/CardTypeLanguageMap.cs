using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class CardTypeLanguageMap : EntityTypeConfiguration<CardTypeLanguage> {
        public CardTypeLanguageMap() {
            this.HasKey(ct => new { ct.CardTypeId, ct.LanguageId });
            this.Property(ct => ct.Name)
                .HasMaxLength(CardTypeLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(ctl => ctl.CardType)
                .WithMany(ct => ct.CardTypeLanguages);
            this.HasRequired(ctl => ctl.Language)
                .WithMany();
        }
    }
}
