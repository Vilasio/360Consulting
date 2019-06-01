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

        public Spot(NpgsqlConnection connection)
        {
            this.connection = connection;
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
            command.CommandText = $"Select * from Parkgarage.spot where floor_id = :fl order by spot_id;";
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

        public static Spot GetSpecificSpot(NpgsqlConnection connection, long? spotId)
        {
            Spot spot = new Spot(connection);

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select * from Parkgarage.spot where spot_id = :id;";
            command.Parameters.AddWithValue("id", spotId);

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    spot.SpotId = reader.GetInt64(0);
                    spot.FloorId = reader.GetInt64(1);
                    spot.VehicleId = reader.IsDBNull(2) ? null : (long?)reader.GetInt64(2);
                    spot.SpotNr = reader.IsDBNull(3) ? null : (long?)reader.GetInt64(3);
                    
                    
                }
            }

            reader.Close();
            
            if (spot.VehicleId != null)
            {
                spot.Vehicle = Vehicle.GetVehicle(connection, spot);
            }
            

            return spot;
        }

        public int Save()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            if (this.SpotId.HasValue)
            {

                command.CommandText =
                $"update Parkgarage.spot set vehicle_Id = :vid where spot_id = :sid";


            }
            else
            {
                command.CommandText = $"select nextval('Parkgarage.spot_seq')";
                this.SpotId = (long?)command.ExecuteScalar();

                command.CommandText = $" insert into Parkgarage.spot ( spot_id, floor_id, vehicle_id, spot )" +
                    $" values(:sid,:fid, :vid, :sp)";
            }
            command.Parameters.AddWithValue("sid", this.SpotId.Value);
            if(this.Floor != null) command.Parameters.AddWithValue("fid", this.Floor.FloorId.Value);
            else command.Parameters.AddWithValue("fid", this.FloorId.Value);
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
        public bool DriveIn( string numberplate, string kind)
        {
            Vehicle vehicle = null;
            bool result = false;
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            command.CommandText = $"Select * from Parkgarage.vehicle where numberplate = :np;";
            command.Parameters.AddWithValue("np", numberplate);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                vehicle = new Vehicle(this.connection);
                vehicle.VehicleId = reader.IsDBNull(0) ? null : (long?)reader.GetInt64(0);
                vehicle.NumberPlate = reader.IsDBNull(1) ? null : reader.GetString(1);
                vehicle.SpotNr = reader.IsDBNull(2) ? null : (long?)reader.GetInt64(2);
                vehicle.FloorNr = reader.IsDBNull(3) ? null : (long?)reader.GetInt64(3);
                vehicle.Kind = reader.IsDBNull(4) ? null : reader.GetString(4);
                reader.Close();
                result = true;
                if (vehicle.SpotNr != null)
                {
                    result = false;
                }

            }
            else
            {
                reader.Close();
                vehicle = new Vehicle(this.connection);
                vehicle.Spot = this;
                vehicle.Floor = this.Floor;
                vehicle.Kind = kind;
                vehicle.NumberPlate = numberplate;
                vehicle.SpotNr = this.SpotNr;
                vehicle.FloorNr = this.Floor.FloorNumber;
                vehicle.Save();
                result = true;
            }

            if (result)
            {
                this.vehicle = vehicle;
                this.Save();
            }
            

            return result;
        }

        //DriveOut
        public bool DriveOut()
        {
            bool result = false;
            if (this.Vehicle != null)
            {
                this.Vehicle.SpotNr = null;
                this.Vehicle.FloorNr = null;
                this.Vehicle.Floor = null;
                this.Vehicle.Spot = null;
                this.Vehicle.Save();
                this.Vehicle = null;
                this.Save();
                result = true;
            }
            return result;
        }

        public int Delete()
        {
            
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            int result = 0;
            if (this.SpotId.HasValue)
            {

                command.CommandText =
                $"delete from Parkgarage.spot  where spot_id = :sid";
                command.Parameters.AddWithValue("sid", this.SpotId.Value);
                result = command.ExecuteNonQuery();
            }
            return result;
        }
    }
}
