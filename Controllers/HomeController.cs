using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILeaveProvider _iLeaveProvider;
        private readonly IHolidayProvider _iHolidayProvider;
        private EmployeeManagementDbContext _context;

        public HomeController(ILogger<HomeController> logger, ILeaveProvider iLeaveProvider, IHolidayProvider iHolidayProvider, EmployeeManagementDbContext context)
        {
            _logger = logger;
            _iLeaveProvider = iLeaveProvider;
            _iHolidayProvider = iHolidayProvider;
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _iLeaveProvider.GetList();
            return View(data);
        }
        public IActionResult HolidayList()
        {
            var data = _iHolidayProvider.GetList();
            return View(data);
        }
        public JsonResult HolidayCalender(string year, string month)
        {
            string EId = HttpContext.Session.GetInt32("EId").ToString();

            var leavedata = _iLeaveProvider.GetCalendarDataByYearAndMonth(EId,year,month);
            //var data2 = _iHolidayProvider.GetList();
            //CalenderViewModel model = new CalenderViewModel
            //{
            //    Status = leavedata.LeaveReason,
            //    Day = leavedata.LeaveDate
            //};
            return Json(true);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
