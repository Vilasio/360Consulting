using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Search
    {
        private NpgsqlConnection connection = null;
        private Garage garage = null;
        public string numberplate = null;
        public string GarageName { get; set; }
        public long? FloorNr { get; set; }
        public long? SpotNr { get; set; }
        public long? SpotId { get; set; }

        public Spot spot = null;


        public Search()
        {

        }

        public Search(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public Search(NpgsqlConnection connection, string numberplate)
        {
            this.connection = connection;
            this.numberplate = numberplate;
        }

        public Search(NpgsqlConnection connection, string numberplate, Garage garage)
        {
            this.connection = connection;
            this.numberplate = numberplate;
            this.garage = garage;
        }

        public void SearchVehicle()
        {
            foreach (Floor floor in this.garage.Floors)
            {
                foreach (Spot spot in floor.Spots)
                {
                    if (spot.Vehicle != null)
                    {
                        if (spot.Vehicle.NumberPlate == this.numberplate)
                        {
                            this.spot = spot;
                            this.SpotId = spot.SpotId;
                            this.SpotNr = spot.SpotNr;
                            this.FloorNr = spot.Floor.FloorNumber;
                            this.GarageName = this.garage.Name;
                            return;
                        }
                    }
                }
            }

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select g.name, f.floors, s.spot, s.spot_id  from Parkgarage.garage as g " +
                $" inner join Parkgarage.floors as f on f.garage_id = g.garage_id" +
                $" inner join Parkgarage.spot as s on s.floor_id = f.floor_id" +
                $" inner join Parkgarage.vehicle as v on v.vehicle_id = s.vehicle_id where v.numberplate = :np;";
            command.Parameters.AddWithValue("np", this.numberplate);

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    this.GarageName = reader.IsDBNull(0) ? null : reader.GetString(0);
                    this.FloorNr = reader.IsDBNull(1) ? null : (long?)reader.GetInt64(1);
                    this.SpotNr = reader.IsDBNull(2) ? null : (long?)reader.GetInt64(2);
                    this.SpotId = reader.IsDBNull(3) ? null : (long?)reader.GetInt64(3);
                   
                }
            }

            reader.Close();

            if (this.SpotId.HasValue)
            {
                this.spot = Spot.GetSpecificSpot(this.connection, this.SpotId);
            }
        }

        public void Reset()
        {
            this.numberplate = string.Empty;
            this.GarageName = string.Empty;
            this.FloorNr = null;
            this.SpotNr = null;
            this.SpotId = null;
            this.spot = null;
        }
    }
}
