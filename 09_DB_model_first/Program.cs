using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_DB_model_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityContainer container = new UniversityContainer();
            //container.Groups.Add(new Group() { Name = "PD321" });
            //container.SaveChanges();
            container.Students.Add(new Student()
            {
                FirstName = "Pavlo",
                Mark = 11,
                BirthDate = new DateTime(2001, 02, 25),
                GroupId = 1
            }
                );
            container.SaveChanges();

            var res = container.Students.Select(s => s);
            foreach (var item in res)
            {
                Console.WriteLine($"{item.FirstName,10} {item.BirthDate.ToShortDateString(),10} {item.Mark}");
            }

            foreach (var item in container.Students.Include(nameof(Student.Group)).Where(s=>s.Group != null))
            {
                Console.WriteLine($"{item.Group.Name} --- {item.FirstName} {item.BirthDate.ToShortDateString(),10} {item.Mark}");
            }
        }
    }
}
