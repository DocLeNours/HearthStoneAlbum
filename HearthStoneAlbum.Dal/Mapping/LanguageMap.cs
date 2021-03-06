﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class LanguageMap : EntityTypeConfiguration<Language> {
        public LanguageMap() {
            this.HasKey(l => l.LanguageId);
            this.Property(l => l.LanguageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(l => l.Name)
                .HasMaxLength(Language.NameMaxLength)
                .IsRequired()
                .HasUniqueIndexAnnotation("UQLanguageName");
        }
    }
}
