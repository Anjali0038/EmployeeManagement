using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceProvider _iAttendanceProvider;
        private EmployeeManagementDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AttendanceController(UserManager<ApplicationUser> userManager, IAttendanceProvider iAttendanceProvider, EmployeeManagementDbContext context)
        {
            _iAttendanceProvider = iAttendanceProvider;
            _context = context;
            _userManager = userManager;

        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _iAttendanceProvider.GetList();
            return View(data);
        }
        
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            AttendanceViewModel att = new AttendanceViewModel();
            string emp = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var employee = await _userManager.FindByIdAsync(emp);
            int eid = employee.EId;

            string currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
            var attendenceList = _iAttendanceProvider.GetList();
            var attendence = attendenceList.AttendanceList.Where(x => x.Date == DateTime.Parse(currentDate) && x.Employee_Id == eid).FirstOrDefault();
            if (attendence == null)
            {
                att.IsTurnIn = false;
                att.IsTurnOut = false;
            }
            else
            {
                att.IsTurnIn = true;
                att.Attendance_Id = attendence.Attendance_Id;
                att.Turn_in = attendence.Turn_in;
            }
            return View(att);
        }
        [HttpPost]
        public IActionResult Save(AttendanceViewModel model)
        {
            try
            {
                _iAttendanceProvider.SaveAttendance(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
