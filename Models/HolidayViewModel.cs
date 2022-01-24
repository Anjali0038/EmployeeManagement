using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class HolidayViewModel
    {
        [Key]
        public int Holiday_Id { get; set; }
        [Required]
        public string HolidayName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime HolidayDate { get; set; }
        public int HolidayDays { get; set; }
        public List<HolidayViewModel> HolidayList { get; set; }
        public HolidayViewModel()
        {
            HolidayList = new List<HolidayViewModel>();
        }
    }
}
