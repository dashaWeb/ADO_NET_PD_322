using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Migrations.EF
{
    internal class Initializer : DropCreateDatabaseAlways<HoneyDb>
    {
        protected override void Seed(HoneyDb context)
        {
            base.Seed(context);

            //Countries
            Country ukr = context.Countries.Add(new Country() { Name = "Ukraine" });
            Country pol = context.Countries.Add(new Country() { Name = "Poland" });
            Country usa = context.Countries.Add(new Country() { Name = "USA" });
            context.SaveChanges();

            // Departments
            Department depMen = context.Departments.Add(new Department() { Name = "Management", Phone = "25-69-85" });
            Department depPr = context.Departments.Add(new Department() { Name = "Programming", Phone = "48-87-85" });
            Department depDes = context.Departments.Add(new Department() { Name = "Design", Phone = "25-87-45" });
            context.SaveChanges();

            //Workers
            Worker w1 = context.Workers.Add(new Worker()
            {
                Name = "Bill",
                SurName = "Gates",
                Salary = 2700,
                BirthDate = new DateTime(2003, 2, 2),
                DepartmentId = depPr.Id,
                CountryId = usa.Id,
            });
            Worker w2 = context.Workers.Add(new Worker()
            {
                Name = "Tomm",
                SurName = "Page",
                Salary = 4300,
                BirthDate = new DateTime(2002, 3, 12),
                DepartmentId = depDes.Id,
                CountryId = ukr.Id
            });
            Worker w3 = context.Workers.Add(new Worker()
            {
                Name = "Emma",
                SurName = "Miller",
                Salary = 5500,
                BirthDate = new DateTime(2000, 12, 12),
                DepartmentId = depPr.Id,
                CountryId = pol.Id
            });
            Worker w4 = context.Workers.Add(new Worker()
            {
                Name = "Oleg",
                SurName = "King",
                Salary = 3300,
                BirthDate = new DateTime(2003, 11, 24),
                DepartmentId = depMen.Id,
                CountryId = ukr.Id
            });
            context.SaveChanges();

            //Projects
            Project pr1 = context.Projects.Add(new Project()
            {
                Name = "Tetris",
                LaunchDate = new DateTime(1982, 12, 12),
            });
            Project pr2 = context.Projects.Add(new Project()
            {
                Name = "PacMan",
                LaunchDate = new DateTime(2003, 12, 12),
            });
            Project pr3 = context.Projects.Add(new Project()
            {
                Name = "CS",
                LaunchDate = new DateTime(2000, 01, 01),
            });
            context.SaveChanges();

            w1.Projects.Add(pr1);
            w1.Projects.Add(pr2);
            w2.Projects.Add(pr1);
            w2.Projects.Add(pr3);
            w3.Projects.Add(pr1);
            context.SaveChanges();
        }
    }
}
