using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15_Dapper.Model;

namespace _15_Dapper.DBContext
{
    // ADO.NET
    public class CarRepositoryADO_NET : ICarRepository
    {
        string connectionString = null;
        public CarRepositoryADO_NET(string conn)
        {
            connectionString = conn;
        }
        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string cmdText = "SELECT * FROM Cars";
                SqlCommand command = new SqlCommand(cmdText, conn);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cars.Add(new Car()
                    {
                        Make = reader.GetString(1),
                        Model = reader.GetString(2),
                        ModelYear = reader.GetInt32(3)
                    });
                }
                reader.Close();
                return cars;
            }
        }

        public Car GetCar(int id)
        {
            Car car = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string cmdText = $@"SELECT * FROM Cars WHERE Id = @Id";

                SqlCommand command = new SqlCommand(cmdText, conn);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    car = new Car()
                    {
                        Make = reader.GetString(1),
                        Model = reader.GetString(2),
                        ModelYear = reader.GetInt32(3)
                    };
                }

                reader.Close();

                return car;
            }
        }

        public Car Create(Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var cmdText = "INSERT INTO Cars (Make, Model, ModelYear) VALUES(@Make, @Model, @ModelYear); SELECT CAST(SCOPE_IDENTITY() as int)";
                SqlCommand command = new SqlCommand(cmdText, conn);

                command.Parameters.Add("@Make", SqlDbType.NVarChar).Value = car.Make;
                command.Parameters.Add("@Model", SqlDbType.NVarChar).Value = car.Model;
                command.Parameters.Add("@ModelYear", SqlDbType.Int).Value = car.ModelYear;

                int? carId = (int)command.ExecuteScalar();
                car.Id = carId.Value;
                return car;
            }
        }

        public void Update(Car car)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var sqlQuery = "UPDATE Cars SET Make = @Make, Model = @Model, ModelYear = @ModelYear WHERE Id = @Id";
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                command.Parameters.Add("@Id", SqlDbType.Int).Value = car.Id;
                command.Parameters.Add("@Make", SqlDbType.NVarChar).Value = car.Make;
                command.Parameters.Add("@Model", SqlDbType.NVarChar).Value = car.Model;
                command.Parameters.Add("@ModelYear", SqlDbType.Int).Value = car.ModelYear;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var sqlQuery = "DELETE FROM Cars WHERE Id = @Id";
                SqlCommand command = new SqlCommand(sqlQuery, conn);

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }
    }
}
