using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _11_LoadingTypes
{
    public class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        // Navigation Property
        public virtual ICollection<Worker> Workers { get; set; }
    }
}

// Worker
// Project
// Department
// Country