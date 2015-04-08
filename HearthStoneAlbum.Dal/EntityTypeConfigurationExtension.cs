using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Dal {
    public static class EntityTypeConfigurationExtension {
        public static PrimitivePropertyConfiguration HasUniqueIndexAnnotation(this PrimitivePropertyConfiguration property, string indexName, int columnOrder) {
            IndexAttribute indexAttribute = new IndexAttribute(indexName, columnOrder);
            return property.HasUniqueIndexAnnotation(indexAttribute);
        }
        public static PrimitivePropertyConfiguration HasUniqueIndexAnnotation(this PrimitivePropertyConfiguration property, string indexName) {
            IndexAttribute indexAttribute = new IndexAttribute(indexName);
            return property.HasUniqueIndexAnnotation(indexAttribute);
        }
        private static PrimitivePropertyConfiguration HasUniqueIndexAnnotation(this PrimitivePropertyConfiguration property, IndexAttribute indexAttribute) {
            indexAttribute.IsUnique = true;
            IndexAnnotation indexAnnotation = new IndexAnnotation(indexAttribute);
            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}
