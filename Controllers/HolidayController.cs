using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HolidayController : Controller
    {
        private readonly IHolidayProvider _iHolidayProvider;
        private EmployeeManagementDbContext _context;

        public HolidayController(IHolidayProvider iHolidayProvider, EmployeeManagementDbContext context)
        {
            _iHolidayProvider = iHolidayProvider;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(HolidayViewModel model)
        {
            try
            {
                _iHolidayProvider.SaveHoliday(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
