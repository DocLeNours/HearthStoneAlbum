using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HearthStoneAlbum.DataImport.XmlDomain;

namespace HearthStoneAlbum.DataImport {
    class Program {
        static void Main(string[] args) {
            try {
                DirectoryInfo di = new DirectoryInfo(@"D:\Users\DocLeNours\Documents\Jeux\MPQEditor\Work\Data\Win\cardxml0\CAB-cardxml0\TextAsset");
                IList<Entity> entities = new List<Entity>();
                foreach (FileInfo fi in di.GetFiles()) {
                    XmlSerializer ser = new XmlSerializer(typeof(Entity));
                    Entity entity;
                    using (XmlReader reader = XmlReader.Create(fi.FullName)) {
                        entity = (Entity)ser.Deserialize(reader);
                        entities.Add(entity);
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
