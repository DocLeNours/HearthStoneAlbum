using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class RarityMap : EntityTypeConfiguration<Rarity> {
        public RarityMap() {
            this.HasKey(r => r.RarityId);
        }
    }
}
