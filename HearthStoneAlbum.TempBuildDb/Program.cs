using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Repository;

namespace HearthStoneAlbum.TempBuildDb {
    class Program {
        static void Main(string[] args) {
            using (HearthStoneAlbumDbContext context = new HearthStoneAlbumDbContext(ConfigurationManager.ConnectionStrings["HearthStoneAlbumDbContext"].ConnectionString)) {
                IEnumerable<Card> cards = context.Cards.ToList();
            }
            Console.ReadLine();
        }
    }
}
