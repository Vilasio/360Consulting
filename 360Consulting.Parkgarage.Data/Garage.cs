using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Garage
    {

        public int Floor { get; set; }
        public int SpotPerFloor { get; set; }

        public List<Floor> Floors { get; set; }

        public List<Vehicle> Allvehicles
        {
            get
            {
                if (Allvehicles == null)
                {
                    Allvehicles = new List<Vehicle>();
                    foreach (Floor floor in Floors)
                    {
                        foreach (Spot spot in floor.Spots)
                        {
                            if (spot.Vehicle != null)
                            {
                                Allvehicles.Add(spot.Vehicle);
                            }
                        }
                    }
                }
                return Allvehicles;
            }
            set { Allvehicles = value; }
        }


        public Garage()
        {

        }

        public Garage(int floor, int spotPerFloor)
        {
            this.Floor = floor;
            this.SpotPerFloor = spotPerFloor;
            CreateFloors();
        }

        private void CreateFloors()
        {
            this.Floors = new List<Floor>();
            for (int i = 0; i < this.Floor; i++)
            {
                Floor floor = new Floor(this.SpotPerFloor, (i + 1));
                this.Floors.Add(floor);
            }
        }

        public Spot GetFirstFreeSpot()
        {
            Spot free = null;
            foreach (Floor floor in Floors)
            {
                foreach (Spot spot in floor.Spots)
                {
                    if (spot.Vehicle == null)
                    {
                        free = spot;
                        return free;
                    }
                }
            }
            return free;
        }

        public bool AllreadyIn(string numberplate)
        {
            foreach (Floor floor in Floors)
            {
                foreach (Spot spot in floor.Spots)
                {
                    if (spot.Vehicle != null )
                    {
                        if (spot.Vehicle.NumberPlate == numberplate)
                        {
                            return true;
                        }
                    }
                    
                }
            }
            return false;

            /*List<Vehicle> test = this.Allvehicles;
            var match = test.Where(x => x.NumberPlate.Contains(numberplate));
            if (match.Count() > 0)
            {
                return true;
            }
            return false;*/
        }
        public Spot Search(string numberplate)
        {
            Spot nix = null;
            foreach (Floor floor in Floors)
            {
                foreach (Spot spot in floor.Spots)
                {
                    if (spot.Vehicle != null)
                    {
                        if (spot.Vehicle.NumberPlate == numberplate)
                        {
                            return spot;
                        }
                    }

                }
            }
            return nix;
        }

    }
}
