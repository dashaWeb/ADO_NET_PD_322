using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _15_Dapper.Model;

namespace _15_Dapper.DBContext
{
    public interface ICarRepository
    {
        Car Create(Car car);
        void Delete(int id);
        Car GetCar(int id);
        List<Car> GetCars();
        void Update(Car car);
    }
}
