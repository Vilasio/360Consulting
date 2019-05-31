using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Spot
    {

        //------------------------------------
        //Property
        //------------------------------------
        private NpgsqlConnection connection = null;
        private Vehicle vehicle = null;

        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        public Floor Floor { get; set; }
        public long?  FloorId { get; set; }
        public long? SpotId { get; set; }
        public long? SpotNr { get; set; }
        public long? VehicleId { get; set; }

        //------------------------------------
        //Constructor
        //------------------------------------

        public Spot()
        {

        }

        public Spot(NpgsqlConnection connection, Floor floor)
        {
            this.connection = connection;
            this.Floor = floor;
            this.FloorId = floor.FloorId;
        }

        public Spot(NpgsqlConnection connection, Floor floor, int spotnr)
        {
            this.connection = connection;
            this.Floor = floor;
            this.SpotNr = (long?)spotnr;
        }

        //------------------------------------
        //Static Methods
        //------------------------------------



        //------------------------------------
        //Public Methods
        //------------------------------------
        public static int SpotPerFloor(NpgsqlConnection connection, Garage garage, Floor floor)
        {
            int spotPerFloor = 0;
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select Count(*) from Parkgarage.spot where garage_id = id and floors = fl;";
            command.Parameters.AddWithValue("id", garage.GarageId.Value);
            command.Parameters.AddWithValue("fl", floor.FloorNumber);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                spotPerFloor = (int)reader.GetInt64(0);
            }
            reader.Close();
            return spotPerFloor;
        }

        public static List<Spot> GetAllSpotsPerFloor(NpgsqlConnection connection, Floor floor)
        {
            List<Spot> allSpots= new List<Spot>();

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select * from Parkgarage.spot;";
            command.Parameters.AddWithValue("fl", floor.FloorId);

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    allSpots.Add(new Spot(connection, floor)
                    {
                        SpotId = reader.GetInt64(0),
                        FloorId = reader.GetInt64(1),
                        VehicleId = reader.IsDBNull(2) ? null : (long?)reader.GetInt64(2),
                        SpotNr = reader.IsDBNull(3) ? null : (long?)reader.GetInt64(3)
                    }
                    );
                }
            }
            
            reader.Close();
            foreach (Spot spot in allSpots)
            {
                if (spot.VehicleId != null)
                {
                    spot.Vehicle = Vehicle.GetVehicle(connection, spot);
                }
            }

            return allSpots;
        }

        public int Save()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            if (this.SpotId.HasValue)
            {

                command.CommandText =
                $"update Parkgarage.spot set vehicle_Id = :vid";


            }
            else
            {
                command.CommandText = $"select nextval('Parkgarage.spot_seq')";
                this.SpotId = (long?)command.ExecuteScalar();

                command.CommandText = $" insert into Parkgarage.spot ( spot_id, floor_id, vehicle_id, spot )" +
                    $" values(:sid,:fid, :vid, :sp)";
            }
            command.Parameters.AddWithValue("sid", this.SpotId.Value);
            command.Parameters.AddWithValue("fid", this.Floor.FloorId.Value);
            command.Parameters.AddWithValue("vid", this.vehicle == null ? (object)DBNull.Value : this.vehicle.VehicleId);
            command.Parameters.AddWithValue("sp", this.SpotNr.HasValue ? (object)this.SpotNr.Value : 0);


            int result = command.ExecuteNonQuery();

            if (this.vehicle != null)
            {
                result += this.vehicle.Save();
            }


            return result;
        }

        //DriveIn Prüfung ob das Vehicle bereits in der Datenbank ist und wenn nicht dann neues anlegen


        //DriveOut
    }
}
