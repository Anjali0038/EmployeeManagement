using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [ForeignKey ("Employee")]
        public Employee employee { get; set; }

    }
}
