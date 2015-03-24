using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Repository {
    public class HearthStoneAlbumDbContext : DbContext {
        public HearthStoneAlbumDbContext(string connectionString) : base(connectionString) { }

        #region DbSets
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //Database.SetInitializer<HearthStoneAlbumDbContext>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Configurations.Add(new CertificationMap());
        }
    }
}
