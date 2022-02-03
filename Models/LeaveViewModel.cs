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
        public DateTime LeaveDate { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string LeaveReason { get; set; }
        public string FirstName { get; set; }
        public string Designation_Name { get; set; }
        public int EId { get; set; }
        public Employee Employee { get; set; }
        public string UserId { get; set; }
        public List<LeaveViewModel> LeaveList { get; set; }
        public LeaveViewModel()
        {
            LeaveList = new List<LeaveViewModel>();
        }
    }
}
