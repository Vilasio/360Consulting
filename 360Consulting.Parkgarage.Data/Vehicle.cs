using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Consulting.Parkgarage.Data
{
    public class Vehicle
    {
        private NpgsqlConnection connection = null;

        public long? VehicleId { get; set; }
        public string NumberPlate { get; set; }
        public Floor Floor { get; set; }
        public Spot Spot { get; set; }
        public string Kind { get; set; }

        public Vehicle()
        {

        }
        public Vehicle(NpgsqlConnection connection)
        {
            
            this.connection = connection;
        }

        public int Save()
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = this.connection;
            if (this.VehicleId.HasValue)
            {

                command.CommandText =
                $"update Parkgarage.vehicle set numberplate = :np, position_floor = :pf, position_spot = :ps, kind = :k";


            }
            else
            {
                command.CommandText = $"select nextval('Parkgarage.vehicle_seq')";
                this.VehicleId = (long?)command.ExecuteScalar();

                command.CommandText = $" insert into Parkgarage.vehicle ( vehicle_id, numberplate, position_floor, positon_spot, kind )" +
                    $" values(:vid,:np, :pf, :ps, :k)";
            }
            command.Parameters.AddWithValue("vid", this.VehicleId.Value);
            command.Parameters.AddWithValue("np", String.IsNullOrEmpty(this.NumberPlate) ? (object)DBNull.Value : this.NumberPlate);
            command.Parameters.AddWithValue("pf", this.Floor.FloorNumber.HasValue ? this.Floor.FloorNumber.Value : (object)DBNull.Value);
            command.Parameters.AddWithValue("ps", this.Spot.SpotNr.HasValue ? this.Spot.SpotNr.Value : (object)DBNull.Value);
            command.Parameters.AddWithValue("k", String.IsNullOrEmpty(this.Kind) ? (object)DBNull.Value : this.Kind);


            int result = command.ExecuteNonQuery();


            return result;
        }

        public static Vehicle GetVehicle(NpgsqlConnection connection, Spot spot)
        {
            Vehicle vehicle = null;
            
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select numberplate, kind from Parkgarage.vehicle where vehicle_id = id;";
            command.Parameters.AddWithValue("id", spot.VehicleId.Value);
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                vehicle = new Vehicle(connection);
                vehicle.VehicleId = spot.Vehicle.VehicleId;
                vehicle.Spot = spot;
                vehicle.Floor = spot.Floor;
                vehicle.NumberPlate = reader.IsDBNull(0) ? null : reader.GetString(0);
                vehicle.Kind = reader.IsDBNull(1) ? null : reader.GetString(1);
                reader.Close();
            }

            return vehicle;
        }

        public static bool Exists(NpgsqlConnection connection, string numberplate)
        {
            Vehicle vehicle = null;

            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = connection;
            command.CommandText = $"Select * from Parkgarage.vehicle where numberplate = :np;";
            command.Parameters.AddWithValue("np", numberplate);
            NpgsqlDataReader reader = command.ExecuteReader();
            bool result = reader.HasRows;
            reader.Close();
            return result;
        }
    }
}
