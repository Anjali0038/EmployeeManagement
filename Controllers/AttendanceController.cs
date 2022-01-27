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
    public class AttendanceController : Controller
    {
        private readonly IAttendanceProvider _iAttendanceProvider;
        private EmployeeManagementDbContext _context;

        public AttendanceController(IAttendanceProvider iAttendanceProvider, EmployeeManagementDbContext context)
        {
            _iAttendanceProvider = iAttendanceProvider;
            _context = context;

        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Index(AttendanceViewModel model)
        //{
        //    model.Turn_in = DateTime.Now;
        //    model.Turn_out = DateTime.Now;
        //    try
        //    {
        //        var user = _context.Employees.Where(x => x.Employee_Id== model.Employee_Id).FirstOrDefault();
        //        model.EmployeeName = user.FirstName + " " + user.MiddleName + " " + user.LastName;
        //        model.Employee_Id = user.Employee_Id;
        //        _iAttendanceProvider.SaveAttendance(model);
        //        return RedirectToAction("List");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        [HttpGet]
        public IActionResult Turn_in()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Turn_in(AttendanceViewModel model)
        {
            model.Turn_in = DateTime.Now;
            model.Turn_out = DateTime.MinValue;
            try
            {
                var user = _context.Employees.Where(x => x.Employee_Id == model.Employee_Id).FirstOrDefault();
                model.EmployeeName = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                model.Employee_Id = user.Employee_Id;
                _iAttendanceProvider.SaveAttendance(model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult Turn_out()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Turn_out(AttendanceViewModel model)
        {
            model.Turn_in = DateTime.MinValue;
            model.Turn_out = DateTime.Now;
            try
            {
                var user = _context.Employees.Where(x => x.Employee_Id == model.Employee_Id).FirstOrDefault();
                model.EmployeeName = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                model.Employee_Id = user.Employee_Id;
                _iAttendanceProvider.SaveAttendance(model);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Check(DateTime button)
        {
            if (button == DateTime.MinValue)
            {
                TempData["ButtonValue"] = DateTime.Now;
            }
            else
            {
                TempData["ButtonValue"] = DateTime.Now;
                //TempData["ButtonValue"] = "No button click!";
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult List()
        {
            var data = _iAttendanceProvider.GetList();
            return View(data);
        }
    }
}
