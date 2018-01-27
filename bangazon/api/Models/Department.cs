using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }
        public double Budget { get; set; }

        public ICollection<Employee> Employees;
    }
}