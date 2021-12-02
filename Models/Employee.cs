using EmployeeManagement.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Dob { get; set; }
        public String UserName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string  Email { get; set; }
        public int? Gender_Id { get; set; }
        [ForeignKey(nameof(Gender_Id))]
        public virtual Gender Gender{ get; set; }
        public int? Attendance_Id { get; set; }

        [ForeignKey(nameof(Attendance_Id))]
        public virtual Attendance Attendance { get; set; }
        public DateTime Turn_in { get; set; }
        public DateTime Turn_out { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        public int? Designation_Id { get; set; }

        [ForeignKey(nameof(Designation_Id))]
        public virtual Designation Designation { get; set; }
        public string Designation_Name { get; set; }
        public double Salary { get; set; }
        public double Contact_No { get; set; }
        [ForeignKey (nameof(Id))]
        public string Id { get; set; }
        public ICollection<ApplicationUser> ApplicationUser { get; set; }

    }
}
