using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Code_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HoneyDb context = new HoneyDb();
            //Countries
            /* context.Countries.Add(new Country() { Name = "Ukraine" });
             context.Countries.Add(new Country() { Name = "Poland" });
             context.Countries.Add(new Country() { Name = "USA" });
             context.SaveChanges();*/

            // Departments
            /*context.Departments.Add(new Department() { Name = "Management", Phone = "25-69-85" });
            context.Departments.Add(new Department() { Name = "Programming", Phone = "48-87-85" });
            context.Departments.Add(new Department() { Name = "Design", Phone = "25-87-45" });
            context.SaveChanges();*/

            //Workers
            /* context.Workers.Add(new Worker()
             {
                 Name = "Bill",
                 SurName = "Gates",
                 Salary = 2700,
                 BirthDate = new DateTime(2003,2,2),
                 DepartmentId = (context.Departments.Where(s => s.Name == "Programming")).First().Id,
                 CountryId = (context.Countries.Where(c => c.Name == "USA")).First().Id
             });*/
            /* context.Workers.Add(new Worker()
             {
                 Name = "Tomm",
                 SurName = "Page",
                 Salary = 4300,
                 BirthDate = new DateTime(2002, 3, 12),
                 DepartmentId = (context.Departments.Where(s => s.Name == "Design")).First().Id,
                 CountryId = (context.Countries.Where(c => c.Name == "Ukraine")).First().Id
             });
             context.Workers.Add(new Worker()
             {
                 Name = "Emma",
                 SurName = "Miller",
                 Salary = 5500,
                 BirthDate = new DateTime(2000, 12, 12),
                 DepartmentId = (context.Departments.Where(s => s.Name == "Programming")).First().Id,
                 CountryId = (context.Countries.Where(c => c.Name == "Poland")).First().Id
             });
             context.Workers.Add(new Worker()
             {
                 Name = "Oleg",
                 SurName = "King",
                 Salary = 3300,
                 BirthDate = new DateTime(2003, 11, 24),
                 DepartmentId = (context.Departments.Where(s => s.Name == "Management")).First().Id,
                 CountryId = (context.Countries.Where(c => c.Name == "Ukraine")).First().Id
             });
             context.SaveChanges();*/

            //Projects
            /*context.Projects.Add(new Project() { 
                Name = "Tetris",LaunchDate = new DateTime(1982,12,12),
            });
            context.Projects.Add(new Project()
            {
                Name = "PacMan",
                LaunchDate = new DateTime(2003, 12, 12),
            });
            context.Projects.Add(new Project()
            {
                Name = "CS",
                LaunchDate = new DateTime(2000, 01, 01),
            });
            context.SaveChanges();*/


            /*Worker worker1 = context.Workers.FirstOrDefault(w=>w.Name == "Bill" && w.SurName == "Gates");
            Project pr1 = context.Projects.FirstOrDefault(w => w.Name == "Tetris");
            Project pr2 = context.Projects.FirstOrDefault(w => w.Name == "PacMan");
            worker1.Projects.Add(pr1);
            worker1.Projects.Add(pr2);
            Worker worker2 = context.Workers.FirstOrDefault(w=>w.Name == "Emma" && w.SurName == "Miller");
            Project pr3 = context.Projects.FirstOrDefault(w => w.Name == "CS");
            worker2.Projects.Add(pr3);
            context.SaveChanges();*/




<<<<<<< HEAD
           /* foreach (var worker in context.Workers)
=======
            foreach (var worker in context.Workers)
>>>>>>> 9d70941b8987c138c022c483c902d382951db970
            {
                Console.WriteLine($"\n\n{new string('-',50)}");
                Console.WriteLine($"--------- User [{worker.Id}] {worker.FullName} \n Department : {worker.Department.Name} {worker.Salary}\n  Birthdate : {(worker.BirthDate.HasValue ? (worker.BirthDate.Value.ToShortDateString()) : "No Birth Date")}");
                Console.WriteLine($"Country :: {(worker.Country == null ? "Empty Field" : worker.Country.Name)}");
                foreach (var pr in worker.Projects)
                {
                    Console.WriteLine($"\t Project {pr.Name} from {pr.LaunchDate.ToShortDateString()}");
                }
<<<<<<< HEAD
            }*/
=======
            }
>>>>>>> 9d70941b8987c138c022c483c902d382951db970


        }
    }
}
