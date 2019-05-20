using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Spot
    {
        private Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        public Floor Floor { get; set; }
        public int SpotId { get; set; }

        public Spot()
        {

        }

        public Spot(int spotId, Floor floor)
        {
            this.SpotId = spotId;
            this.Floor = floor;
        }

    }
}
