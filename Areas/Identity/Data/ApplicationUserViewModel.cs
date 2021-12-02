using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Areas.Identity.Data
{
    public class ApplicationUserViewModel
    {

        public string Id { get; set; }
        public string FullName { get; set; }
        //public string MiddleName { get; set; }
        //public string LastName { get; set; }
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string PasswordHash { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("PasswordHash", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        public string Designation { get; set; }
        public string  Email { get; set; }
        public int Employee_Id { get; set; }
        public List<ApplicationUserViewModel> UsersList { get; set; }
        public ApplicationUserViewModel()
        {
            UsersList = new List<ApplicationUserViewModel>();
        }
        public IEnumerable<Employee> EmployeeList { get; set; }
    }
}
