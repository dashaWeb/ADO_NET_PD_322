﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _10_Code_first
{
    public class Country
    {
        public Country()
        {
            Workers = new HashSet<Worker>();
        }
<<<<<<< HEAD
        // Id, id, ID / EntityName+Id --> primary key
=======
>>>>>>> 9d70941b8987c138c022c483c902d382951db970
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