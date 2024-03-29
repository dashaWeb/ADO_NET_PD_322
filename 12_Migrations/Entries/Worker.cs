﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12_Migrations.EF
{
    [Table("Employees")]
    public class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }
        [Key] // primary key
        public int Id { get; set; }
        [Required] // Not Null
        [MaxLength(100)]
        [Column("FirstName")]
        public string Name { get; set; }
        [Required, Column("LastName")] // Not Null
        public string SurName { get; set; }
        [NotMapped] 
        public string FullName => $"{Name} {SurName}";
        public decimal Salary { get; set; }
        public DateTime? BirthDate { get; set; }
        //Foreign Keys

        // 0/1...(Zero to one to Many)
        //[ForeignKey("Country")]
        public int? CountryId { get; set; }
        // 1... (One to Many)
        public int DepartmentId { get; set; }

        // Navigation Property
        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
        // many to many
        public virtual ICollection<Project> Projects { get; set; }
    }
}

// Worker
// Project
// Department
// Country