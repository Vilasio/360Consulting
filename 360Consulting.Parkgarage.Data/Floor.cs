using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Floor
    {
        //------------------------------------
        //Property
        //------------------------------------
        private NpgsqlConnection connection = null;

        private Garage garage = null;

        public long? Spot { get; set; }
        public long? FloorId { get; set; }
        public long? FloorNumber { get; set; }
        public List<Spot> Spots { get; set; }
        public int Free { get; set; }

        //------------------------------------
        //Constructor
        //------------------------------------
        public Floor()
        {

        }

        public Floor(NpgsqlConnection connection, Garage garage)
        {
            this.connection = connection;
            this.garage = garage;
            this.Spot = garage.SpotPerFloor;

        }

        public Floor(NpgsqlConnection connection, Garage garage, int floornumber, int spot)
        {
            this.connection = connection;
            this.garage = garage;
            this.FloorNumber = (long?)floornumber;
            this.Spot = (long?)spot;
        }

        private void CreateSpots()
        {
            
            
        }

        //------------------------------------
        //Public Methods
        //------------------------------------
        public int Save()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            if (this.FloorId.HasValue)
            {

                command.CommandText =
                $"update Parkgarage.floors set floor = :vid";


            }
            else
            {
                command.CommandText = $"select nextval('Parkgarage.floor_seq')";
                this.FloorId = (long?)command.ExecuteScalar();

                command.CommandText = $" insert into Parkgarage.floors ( floor_id, garage_id, floors )" +
                    $" values(:fid, :gid, :fl)";
            }
            command.Parameters.AddWithValue("fid", this.FloorId.Value);
            command.Parameters.AddWithValue("gid", this.garage.GarageId.Value);
            command.Parameters.AddWithValue("fl", this.FloorNumber.HasValue ? (object)this.FloorNumber.Value : 0);


            int result = command.ExecuteNonQuery();

            if (this.Spots != null)
            {
                foreach (Spot spot in this.Spots)
                {
                    result += spot.Save();
                }
            }


            return result;
        }



        //------------------------------------
        //Static Methods
        //------------------------------------
        public static List<Floor> GetAllFloors(NpgsqlConnection connection, Garage garage)
        {
            List<Floor> allFloors = new List<Floor>();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select Distinct floors, floors_id from Parkgarage.spot where garage_id = id;";
            command.Parameters.AddWithValue("id", garage.GarageId.Value);
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    allFloors.Add(new Floor(connection, garage)
                    {
                        FloorNumber = reader.IsDBNull(0) ? 0 : (long?)reader.GetInt64(0),
                        FloorId = reader.IsDBNull(1) ? null : (long?)reader.GetInt64(1)
                    }
                    );
                }
                reader.Close();
            }
            
            return allFloors;
        }

        public static List<Floor> GetAllFloorsWithSpots(NpgsqlConnection connection, Garage garage)
        {
            List<Floor> allFloors = new List<Floor>();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select Distinct floors, floor_id from Parkgarage.floors where garage_id = :id order by floors;";
            command.Parameters.AddWithValue("id", garage.GarageId.Value);
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    allFloors.Add(new Floor(connection, garage)
                    {
                        FloorNumber = reader.IsDBNull(0) ? 0 : (long?)reader.GetInt64(0),
                        FloorId = reader.IsDBNull(1) ? null : (long?)reader.GetInt64(1)
                    }
                    );
                }
                reader.Close();
            }

            foreach (Floor floor in allFloors)
            {
                floor.Spots = _360Consulting.Parkgarage.Data.Spot.GetAllSpotsPerFloor(connection, floor) ;
            }

            return allFloors;
        }

        public int Delete()
        {
            foreach (Spot spot in this.Spots)
            {
                spot.Delete();
            }

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            int result = 0;
            if (this.FloorId.HasValue)
            {

                command.CommandText =
                $"delete from Parkgarage.floors  where floor_id = :fid";
                command.Parameters.AddWithValue("fid", this.FloorId.Value);
                result = command.ExecuteNonQuery();
            }
            return result;
        }
    }
}
