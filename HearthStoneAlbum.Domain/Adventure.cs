using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain
{
    public class Adventure
    {
        public int AdventureId { get; set; }
        public string Name { get; set; }
        public CardSet CardSet { get; set; }
    }
}
