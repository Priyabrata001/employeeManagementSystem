﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       // public ICollection<Employee> Employee { get; set; }
    }
}
