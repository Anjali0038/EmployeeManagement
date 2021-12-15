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
<<<<<<< HEAD
        public string EmployeeName { get; set; }
=======
        public string FirstName { get; set; }
>>>>>>> 3b307d4f29bb6e36f70b5f409779c3b28c243fbf
        public string Designation_Name { get; set; }
        public Employee Employee { get; set; }
    }
}
