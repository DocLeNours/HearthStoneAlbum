using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class CardLanguageMap : EntityTypeConfiguration<CardLanguage> {
        public CardLanguageMap() {
            this.HasKey(cl => new { cl.CardId, cl.LanguageId });
            this.Property(cl => cl.Name)
                .HasMaxLength(CardLanguage.NameMaxLength)
                .IsRequired();
            this.HasRequired(cl => cl.Card)
                .WithMany(c => c.CardLanguages);
            this.HasRequired(cl => cl.Language)
                .WithMany();
        }
    }
}
