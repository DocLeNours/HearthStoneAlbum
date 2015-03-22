using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain
{
    public class Boss
    {
        public int BossId { get; set; }
        public string Name { get; set; }
        public Wing Wing { get; set; }
    }
}
