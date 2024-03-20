using _15_Dapper.DBContext;
using _15_Dapper.Model;
using System.Diagnostics;

internal class Program
{
    static Stat TestProvider(ICarRepository repos)
    {
        var stat = new Stat();
        Stopwatch sw;

        // Read
        sw = Stopwatch.StartNew();
        repos.GetCar(86);
        sw.Stop();
        stat.ReadByIdTime = sw.ElapsedMilliseconds;

        // Read all
        sw = Stopwatch.StartNew();
        repos.GetCars();
        sw.Stop();
        stat.ReadAllTime = sw.ElapsedMilliseconds;

        //Create
        sw = Stopwatch.StartNew();
        Car car = repos.Create(new Car()
        {
            Make = "Lada",
            Model = "Semirka",
            ModelYear = 2005
        });
        sw.Stop();
        stat.CreateTime = sw.ElapsedMilliseconds;
        //Update
        car.Model = "new Model";
        sw = Stopwatch.StartNew();
        repos.Update(car);
        sw.Stop();
        stat.UpdateTime = sw.ElapsedMilliseconds;
        // Delete
        sw = Stopwatch.StartNew();
        repos.Delete(car.Id);
        sw.Stop();
        stat.DeleteTime = sw.ElapsedMilliseconds;

        foreach (var prop in stat.GetType().GetProperties()) {
            Console.WriteLine($"{prop.Name} : {prop.GetValue(stat)}ms");
        }
        return stat;
    }
    private static void Main(string[] args)
    {
        string connStr = "data source = DESKTOP-83U7DVV\\SQLEXPRESS; Initial Catalog = CarSalon; Integrated security = True; Connect Timeout = 2";
        Console.WriteLine("\n---------- Entity Framework Core ------------");
        TestProvider(new CarRepositoryEF(connStr));
        Console.WriteLine("\n------------------ ADO.NET ------------------");
        TestProvider(new CarRepositoryADO_NET(connStr));
        Console.WriteLine("\n----------------- Dapper --------------------");
        TestProvider(new CarRepositoryDapper(connStr));
    }
}