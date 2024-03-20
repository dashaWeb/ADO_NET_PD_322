using _15_Dapper.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Dapper.DBContext
{
    public class CarDbModel : DbContext
    {
        string connectionString;
        public CarDbModel(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@$"{connectionString};Encrypt=False;
                                         Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public virtual DbSet<Car> Cars { get; set; }
    }
    // EF
    public class CarRepositoryEF : ICarRepository
    {
        CarDbModel context = null;
        public CarRepositoryEF(string conn)
        {
            context = new CarDbModel(conn);
        }

        public Car Create(Car car)
        {
            var added = context.Cars.Add(car);
            context.SaveChanges();
            return added.Entity;
        }

        public void Delete(int id)
        {
            var car = context.Cars.Find(id);
            if (car != null)
            {
                context.Cars.Remove(car);
                context.SaveChanges();
            }
        }

        public Car GetCar(int id)
        {
            return context.Cars.Find(id);
        }

        public List<Car> GetCars()
        {
            return context.Cars.ToList();
        }

        public void Update(Car car)
        {
            context.Entry(car).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
