using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Index(HolidayViewModel model)
        {
            try
            {
                _iHolidayProvider.SaveHoliday(model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize(Roles = "Employee,Admin")]
        [HttpGet]
        public IActionResult List(string searchText = "")
        {
            //var data = _iHolidayProvider.GetList();
            //return View(data);
            HolidayViewModel holiday = new HolidayViewModel();
            if (searchText != "" && searchText != null)
            {
                holiday.HolidayList = (from s in _context.Holidays
                                         where s.HolidayName.Contains(searchText)
                                         select new HolidayViewModel
                                         {
                                             Holiday_Id = s.Holiday_Id,
                                             HolidayName = s.HolidayName,
                                             HolidayDate = s.HolidayDate,
                                             HolidayDays = s.HolidayDays,
                                         }).ToList();
            }
            else
                holiday = _iHolidayProvider.GetList();
            return View(holiday);
        }
        public ActionResult HolidaySearch(string val)
        {
            HolidayViewModel model = new HolidayViewModel();

            model.HolidayList = (from s in _context.Holidays
                                 where s.HolidayName.Contains(val)
                                 select new HolidayViewModel
                                 {
                                     Holiday_Id = s.Holiday_Id,
                                     HolidayName = s.HolidayName,
                                     HolidayDate = s.HolidayDate,
                                     HolidayDays = s.HolidayDays,
                                 }).ToList();
            return PartialView(model);
        }
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var holidays = (from holiday in this._context.Holidays
                         where holiday.HolidayName.StartsWith(prefix)
                         select new
                         {
                             label = holiday.HolidayName,
                             val = holiday.Holiday_Id
                         }).ToList();

            return Json(holidays);
        }
    }
}
