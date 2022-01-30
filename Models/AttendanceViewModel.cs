using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class AttendanceViewModel
    {
        [Key]
        public int Attendance_Id { get; set; }
        public DateTime Turn_in { get; set; }
        public DateTime Turn_out { get; set; }
        public bool IsTurnIn { get; set; }
        public bool IsTurnOut { get; set; }
        public string Type { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        public int? Employee_Id { get; set; }
        public string EmployeeName { get; set; }
        public List<AttendanceViewModel> AttendanceList { get; set; }
        public AttendanceViewModel()
        {
            AttendanceList = new List<AttendanceViewModel>();
        }
    }
}
