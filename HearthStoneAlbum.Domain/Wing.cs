using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain
{
    public class Wing
    {
        public int WingId { get; set; }
        public string Name { get; set; }
        public Adventure Adventure { get; set; }
    }
}
