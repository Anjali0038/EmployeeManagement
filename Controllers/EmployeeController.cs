using EmployeeManagement.Controllers;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagemnt.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeProvider _iEmployeeProvider;
        private EmployeeManagementDbContext _context;

        public EmployeeController(IEmployeeProvider iEmployeeProvider ,EmployeeManagementDbContext context)
        {
            _iEmployeeProvider = iEmployeeProvider;
            _context =context;

        }
        [Authorize]
        public IActionResult Index()
        {
            var data = _iEmployeeProvider.GetList();
            ViewBag.Gender = _context.Genders.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            ViewBag.Gender = _context.Genders.ToList();
            EmployeeViewModel emp = new EmployeeViewModel();
            if (id.HasValue)
            {
                emp = _iEmployeeProvider.GetById(id.Value);
            }
            
            return PartialView(emp);           
        }
        [HttpPost]
        public IActionResult CreateOrEdit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _iEmployeeProvider.SaveEmployee(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
             _iEmployeeProvider.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeSearch(string val)
        {
            EmployeeViewModel model = new EmployeeViewModel();

            model.EmployeeList = (from s in _context.Employees
                                  where s.FirstName.Contains(val) || s.Address.Contains(val)
                                  select new EmployeeViewModel
                                  {
                                      Employee_Id = s.Employee_Id,
                                      FirstName = s.FirstName,
                                      Address = s.Address,
                                      Dob = s.Dob
                                  }).ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var users = (from user in this._context.Employees
                         where user.FirstName.StartsWith(prefix)||user.MiddleName.StartsWith(prefix)|| user.LastName.StartsWith(prefix) || user.UserName.StartsWith(prefix)
                         select new
                         {
                             label = user.FirstName,
                             val = user.Employee_Id
                         }).ToList();

            return Json(users);
        }
    }
}
