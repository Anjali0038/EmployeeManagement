using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Areas.Identity.Data
{
    public class ApplicationUser :IdentityUser
    {
        [ForeignKey(nameof(Employee_Id))]
        public int? Employee_Id { get; set; }
        public Employee employee { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public IEnumerable<Employee> EmployeeList { get; set; }
    }
}
