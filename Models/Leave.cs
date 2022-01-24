using EmployeeManagement.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Leave
    {
        [Key]
        public int Leave_Id { get; set; }
        public int LeaveDays { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LeaveDate { get; set; }
        public string EmployeeName { get; set; }
        public string Designation_Name { get; set; }
        public int EId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<ApplicationUser> ApplicationUser { get; set; }
        public string UserId { get; set; }
    }
}
