using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStoneAlbum.Domain
{
    public class Wing
    {
        public const int NameMaxLength = 50;
        public int WingId { get; private set; }
        public string Name { get; private set; }
        public Adventure Adventure { get; private set; }
        public ICollection<Boss> Bosses { get; private set; }
    }
}
