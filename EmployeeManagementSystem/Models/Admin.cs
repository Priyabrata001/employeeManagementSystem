using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Admin
    {
        [Key]
        [Required]
        public int AdminId { get; set; }
        [Required]
        public string AdminName { get; set; }
        [Required]
        public string AdminEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
