using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILeaveProvider _iLeaveProvider;
        private readonly IHolidayProvider _iHolidayProvider;

        public HomeController(ILogger<HomeController> logger, ILeaveProvider iLeaveProvider, IHolidayProvider iHolidayProvider)
        {
            _logger = logger;
            _iLeaveProvider = iLeaveProvider;
            _iHolidayProvider = iHolidayProvider;
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
