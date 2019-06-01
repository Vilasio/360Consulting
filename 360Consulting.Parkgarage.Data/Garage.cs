using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Garage
    {
        //------------------------------------
        //Property
        //------------------------------------
        public long? GarageId { get; set; }
        public long? Floor { get; set; }
        public long? SpotPerFloor { get; set; }
        public string Name { get; set; }
        private NpgsqlConnection connection = null;

        public List<Floor> Floors { get; set; }

        public int FreeSpots
        {
            get {
                int result = 0;
                foreach (Floor floor in this.Floors)
                {
                    foreach (Spot spot in floor.Spots)
                    {
                        if (spot.Vehicle == null)
                        {
                            result++;
                        }
                    }
                }
                return result;
            }

        }


        //------------------------------------
        //Constructor
        //------------------------------------
        public Garage()
        {

        }

        public Garage(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public Garage(int floor, int spotPerFloor)
        {
            this.Floor = floor;
            this.SpotPerFloor = spotPerFloor;
            
        }

        public Garage(int floor, int spotPerFloor, NpgsqlConnection connection)
        {
            this.Floor = floor;
            this.SpotPerFloor = spotPerFloor;
            this.connection = connection;
        }

        //------------------------------------
        //Public Methods
        //------------------------------------
        public int Save()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            if (this.GarageId.HasValue)
            {

                command.CommandText =
                $"update Parkgarage.garage set name = :na, floors = :fl, spots = :sp where garage_id = gid";


            }
            else
            {
                command.CommandText = $"select nextval('Parkgarage.garage_seq')";
                this.GarageId = (long?)command.ExecuteScalar();

                command.CommandText = $" insert into Parkgarage.garage ( garage_id, name, floors, spots )" +
                    $" values(:gid, :na, :fl, :sp)";
            }
            command.Parameters.AddWithValue("gid", this.GarageId.Value);
            command.Parameters.AddWithValue("na", String.IsNullOrEmpty(this.Name) ? (object)DBNull.Value : this.Name);
            command.Parameters.AddWithValue("fl", this.Floor.HasValue ? (object)this.Floor.Value : 0);
            command.Parameters.AddWithValue("sp", this.SpotPerFloor.HasValue ? (object)this.SpotPerFloor.Value : 0);
            




            int result = command.ExecuteNonQuery();

            if (this.Floors != null)
            {
                foreach (Floor floor in this.Floors)
                {
                    result += floor.Save();
                }
            }


            return result;
        }

        public Spot GetFirstFree()
        {
            Spot free = null;
            foreach (Floor floor in this.Floors)
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
            bool result = false;
            foreach (Floor floor in this.Floors)
            {
                foreach (Spot spot in floor.Spots)
                {
                    if (spot.Vehicle != null)
                    {
                        if (spot.Vehicle.NumberPlate == numberplate)
                        {
                            result = true;
                            return result;
                        }
                    }
                   
                }
            }
            return result;
        }

        
        //------------------------------------
        //Static Methods
        //------------------------------------
        public static List<Garage> GetAllGarages(NpgsqlConnection connection)
        {
            List<Garage> allGarages = new List<Garage>();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select * from Parkgarage.garage;";

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    allGarages.Add(new Garage(connection)
                    {
                        GarageId = reader.GetInt64(0),
                        Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Floor = reader.IsDBNull(2) ? 0 : (long?)reader.GetInt64(2),
                        SpotPerFloor = reader.IsDBNull(3) ? null : (long?)reader.GetInt64(3)
                    }
                    );
                }
                
            }
            reader.Close();
            return allGarages;
        }

        public static Garage CreateGarage(NpgsqlConnection connection, int floors, int spots, string name)
        {
            Garage garage = new Garage(connection);
            garage.Name = name;
            garage.Floors = new List<Floor>();
            garage.Floor = floors;
            garage.SpotPerFloor = spots;
            Floor floor = null;
            Spot spot = null;
            for (int i = 1; i <= floors; i++)
            {
                floor = new Floor(connection, garage, i, spots);
                floor.Spots = new List<Spot>();
                garage.Floors.Add(floor);

                for (int x = 1; x <= spots; x++)
                {
                    spot = new Spot(connection, floor, x);
                    floor.Spots.Add(spot);
                }
            }
            garage.Save();


            return garage;
        }
    }
}
