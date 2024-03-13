using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _12_Migrations.EF
{
    public class Country
    {
        public Country()
        {
            Workers = new HashSet<Worker>();
        }
        // Id, id, ID / EntityName+Id --> primary key
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Navigation Property
        public virtual ICollection<Worker> Workers { get; set;}
    }
}

// Worker
// Project
// Department
// Country