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
        [Required]
        public string UserName { get; set; }
        public string Image { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", 
        ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string PasswordHash { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("PasswordHash", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
        public string Designation { get; set; }
        [Required]
        [EmailAddress]
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
