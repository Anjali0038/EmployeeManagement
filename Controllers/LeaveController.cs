using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveProvider _iLeaveProvider;
        private EmployeeManagementDbContext _context;

        public LeaveController(ILeaveProvider iLeaveProvider, EmployeeManagementDbContext context)
        {
            _iLeaveProvider = iLeaveProvider;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var EmpList = _iLeaveProvider.GetEmployees();
            //List<SelectListItem> emp = new List<SelectListItem>();
            //foreach (var item in EmpList)
            //{
            //        string data1 = item.FirstName + " " + item.MiddleName + " " + item.LastName;
            //        int id1 = item.Employee_Id;
            //        SelectListItem items = new SelectListItem { Value = id1.ToString(), Text = data1 };
            //        emp.Add(items);
            //}
            //ViewBag.Emp = emp;
            //return View();
            var UserList = _iLeaveProvider.GetUsers();
            List<SelectListItem> usr = new List<SelectListItem>();
            foreach (var item in UserList)
            {
                string data1 = item.FullName;
                string id1 = item.Id;
                SelectListItem items = new SelectListItem { Value = id1, Text = data1 };
                usr.Add(items);
            }
            ViewBag.Emp = usr;
            return View();
        }
        [HttpPost]
        public IActionResult Index(LeaveViewModel model)
        {
            try
            {
                //var user = _context.Employees.Where(x => x.Employee_Id == Convert.ToInt32(model.EId)).FirstOrDefault();
                //model.EmployeeName = user.FirstName + "" + user.MiddleName + "" + user.LastName;
                //model.Designation_Name = user.Designation_Name;
                //_iLeaveProvider.SaveLeave(model);
                //return RedirectToAction("Index");
                var user = _context.Users.Where(x => x.Id==model.UserId).FirstOrDefault();
                model.EmployeeName = user.FullName;
                model.Designation_Name = user.Designation;
                model.EId = user.EId;
                _iLeaveProvider.SaveLeave(model);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult List()
        {
            var data = _iLeaveProvider.GetList();
            return View(data);
        }
    }
}
