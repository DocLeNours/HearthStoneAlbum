using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Repository.Mapping {
    public class RaceMap : EntityTypeConfiguration<Race> {
        public RaceMap() {
            this.HasKey(r => r.RaceId);
        }
    }
}
