using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    class Floor
    {
        public List<Spot> Spots { get; set; }
        public int Free { get; set; }
    }
}
