using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HearthStoneAlbum.Dal;
using HearthStoneAlbum.DataImport.Service;
using HearthStoneAlbum.DataImport.XmlDomain;

namespace HearthStoneAlbum.DataImport {
    class Program {
        static void Main(string[] args) {
            try {
                using (ImportService service = new ImportService(ConfigurationManager.AppSettings["dirAssets"], ConfigurationManager.ConnectionStrings["HearthStoneAlbumDbContext"].ConnectionString)) {
                    //service.Import(carDefs);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
