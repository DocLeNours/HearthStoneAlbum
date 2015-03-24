using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain
{
    public class Adventure
    {
        public int AdventureId { get; private set; }
        public string Name { get; private set; }
        public CardSet CardSet { get; private set; }
    }
}
