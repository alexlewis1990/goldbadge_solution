using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Poco
{
    public class Badge
    {
        public int ID { get; set; }

        public List<string> DoorNames { get; set; } = new List<string>();

        public Badge(List<string> doornames)
        {
            DoorNames = doornames;
        }
    }
}
