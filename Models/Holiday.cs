using System;
using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class Holiday
    {
        [Key]
        public int Holiday_Id { get; set; }
        [Required]
        public string HolidayName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime HolidayDate { get; set; }
        public int HolidayDays { get; set; }
    }
}
