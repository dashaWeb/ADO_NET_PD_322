using _15_Dapper.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Dapper.DBContext
{
    public class CarRepositoryDapper : ICarRepository
    {
        string connectionString;
        public CarRepositoryDapper(string conn)
        {
            connectionString = conn;
        }
        public Car Create(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                /*var sqlQuery = "insert into Cars (Make,Model,ModelYear) values(@Make,@Model,@ModelYear)";
                db.Execute(sqlQuery, car);*/

                // якщо нам потрібно отримати id доданого авто
                var sqlQuery = "insert into Cars (Make,Model,ModelYear) values(@Make,@Model,@ModelYear); select cast(SCOPE_IDENTITY() as int)";
                int carId = db.Query<int>(sqlQuery, car).FirstOrDefault();
                car.Id = carId;
                return car;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "delete from Cars where Id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Car GetCar(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //return db.Query<Car>("select * from Cars where Id = @id", new {id}).FirstOrDefault();
                return db.QueryFirstOrDefault<Car>("select * from Cars where Id = @id", new { id }) /*?? new Car()*/;
            }
        }

        public List<Car> GetCars()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>("select * from Cars").ToList();
            }
        }

        public void Update(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "update Cars set Make = @Make,Model = @Model,ModelYear = @ModelYear where Id = @id";
                db.Execute(sqlQuery, car);
            }
        }
    }
}
