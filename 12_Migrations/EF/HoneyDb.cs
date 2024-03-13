using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace _12_Migrations.EF
{
    public class HoneyDb : DbContext
    {
        public HoneyDb()
            : base("name=HoneyDb")
        {
            Database.SetInitializer(new Initializer());
        }
        // Collections (tables in db)
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    }
}

// Worker
// Project
// Department
// Country