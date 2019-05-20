using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Vehicle
    {
        public string NumberPlate { get; set; }
        public Floor Floor { get; set; }
        public Spot Spot { get; set; }
        public string Kind { get; set; }
    }
}
