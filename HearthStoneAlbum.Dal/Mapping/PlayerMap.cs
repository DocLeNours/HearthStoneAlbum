using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.Dal.Mapping {
    public class PlayerMap : EntityTypeConfiguration<Player> {
        public PlayerMap() {
            this.HasKey(p => p.PlayerId);
        }
    }
}
