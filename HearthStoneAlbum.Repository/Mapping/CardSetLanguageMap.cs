using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class CardSetLanguageMap : EntityTypeConfiguration<CardSetLanguage> {
        public CardSetLanguageMap() {
            this.HasKey(cs => new { cs.CardSetId, cs.LanguageId });
            this.Property(cs => cs.Name)
                .HasMaxLength(CardSetLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(csl => csl.CardSet)
                .WithMany(cs => cs.CardSetLanguages);
            this.HasRequired(csl => csl.Language)
                .WithMany();
        }
    }
}
