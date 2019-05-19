using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    class Spot
    {
        private Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        public string SpotId { get; set; }
    }
}
