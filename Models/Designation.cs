using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Designation
    {
        [Key]
        public int Designation_Id { get; set; }
        public string Designation_Name { get; set; }
    }
}
