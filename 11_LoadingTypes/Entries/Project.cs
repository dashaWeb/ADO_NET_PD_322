using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _11_LoadingTypes
{
    public class Project 
    {
        public Project()
        {
            Workers = new HashSet<Worker>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime LaunchDate { get; set; }
        // Navigation Property
        // many to many
        public virtual ICollection<Worker> Workers { get; set; }
    }
}

// Worker
// Project
// Department
// Country