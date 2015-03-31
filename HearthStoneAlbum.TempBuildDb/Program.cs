using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthStoneAlbum.Domain;
using HearthStoneAlbum.Dal;

namespace HearthStoneAlbum.TempBuildDb {
    class Program {
        static void Main(string[] args) {
            using (TextWriter tw = new StreamWriter(@"C:\Users\CPE13709\Documents\Visual Studio 2013\Projects\HearthStoneAlbum\logDb.txt")) {
                using (HearthStoneAlbumDbContext context = new HearthStoneAlbumDbContext(ConfigurationManager.ConnectionStrings["HearthStoneAlbumDbContext"].ConnectionString)) {
                    context.Database.Log = tw.Write;
                    IEnumerable<Card> cards = context.Cards.ToList();
                }
                
            } 
            Console.ReadLine();
        }
    }
}
