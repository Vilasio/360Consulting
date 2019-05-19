using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    class Garage
    {

        public int Floor { get; set; }
        public int SpotPerFloor { get; set; }

        public List<Floor> MyProperty { get; set; }
    }
}
