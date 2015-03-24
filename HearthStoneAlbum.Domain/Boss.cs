using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain
{
    public class Boss
    {
        public int BossId { get; private set; }
        public string Name { get; private set; }
        public Wing Wing { get; private set; }
    }
}
