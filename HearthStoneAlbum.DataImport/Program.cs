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
using HearthStoneAlbum.Domain;

namespace HearthStoneAlbum.DataImport {
    class Program {
        static void Main(string[] args) {
            try {
                DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["dirAssets"]);
                IList<Entity> entities = new List<Entity>();
                foreach (FileInfo fi in di.GetFiles()) {
                    XmlSerializer ser = new XmlSerializer(typeof(Entity));
                    using (XmlReader reader = XmlReader.Create(fi.FullName)) {
                        Entity entity = (Entity)ser.Deserialize(reader);
                        entities.Add(entity);
                    }
                }
                using (ImportService service = new ImportService(ConfigurationManager.ConnectionStrings["HearthStoneAlbumDbContext"].ConnectionString, Console.WriteLine)) {
                    service.Import(entities);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
