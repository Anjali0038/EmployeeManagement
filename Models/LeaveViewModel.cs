using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class LeaveViewModel
    {
        [Key]
        public int Leave_Id { get; set; }
        public int LeaveDays { get; set; }
        public string FirstName { get; set; }
        public string Designation_Name { get; set; }
        public Employee Employee { get; set; }
    }
}
