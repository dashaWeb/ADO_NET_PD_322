using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DB_first_mode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SportShopContext context = new SportShopContext();
            //select
            var query = context.Products.Where(p=> p.Price > 100 && p.Price < 500);
            Console.OutputEncoding = Encoding.UTF8;
            foreach (var item in query)
            {
                Console.WriteLine($"Product :: {item.Name,-15} {item.Price}$");
            }

            // create
            /*context.Products.Add(new Product { 
                Price = 350,
                Name = "Stanga",
                Quantity = 3,
                CostPrice = 150,
                Producer = "USA",
                TypeProduct = "Sport"
            });
            context.SaveChanges();*/

            //update
            /*Console.WriteLine("Enter Product ID to change :: ");
            int id = int.Parse( Console.ReadLine() );

            var product = context.Products.FirstOrDefault(p => p.Id == id);
            product.Price = (int)(product.Price * 1.1);
            context.SaveChanges();*/

            //delete
            /*Console.WriteLine("Enter Product ID to delete :: ");
            int id = int.Parse(Console.ReadLine());

            var pr = context.Products.Find(id);
            if(pr != null)
            {
                context.Products.Remove(pr);
                context.SaveChanges();
            }*/

            //Console.WriteLine($"Count :: {context.Products.Count(p=>p.Price>300)}");
            //Console.WriteLine(new string('-',50));
            //var res = context.Products.Where(p=>p.Price>300).OrderByDescending(p=>p.Price);
            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Product :: {item.Name,-15} {item.Price}$");
            //}

            var sal = context.Salles.Include(nameof(Salle.Product)).Where(s=>s.Product != null);
            foreach (var item in sal)
            {
                Console.WriteLine($"Sale {item.Price,10}$ {item.Quantity,10} {item.Product.Name,15} {item.Product.TypeProduct}");
            }
        }
    }
}
