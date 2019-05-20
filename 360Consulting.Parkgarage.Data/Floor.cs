using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Floor
    {
        public int Spot { get; set; }
        public int FloorNumber { get; set; }
        public List<Spot> Spots { get; set; }
        public int Free { get; set; }

        public Floor()
        {

        }

        public Floor(int spot, int floorNumber)
        {
            this.Spot = spot;
            this.FloorNumber = floorNumber;
            CreateSpots();
        }

        private void CreateSpots()
        {
            this.Spots = new List<Spot>();
            for (int i = 0; i < Spot; i++)
            {
                Spot spot = new Spot((i + 1), this);
                this.Spots.Add(spot);
            }
        }
    }
}
