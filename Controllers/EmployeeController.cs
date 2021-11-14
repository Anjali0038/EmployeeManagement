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
        /*
        private EmployeeManagementDbContext db;
        public EmployeeController(EmployeeManagementDbContext _db)
        {
            db = _db;
        }
        
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }
        [Authorize]
        public ActionResult Create()
        {
            List<SelectListItem> gender = new List<SelectListItem>
            {
                new SelectListItem {Value="M", Text="Male"},
                new SelectListItem {Value="F", Text="Female"},
                new SelectListItem {Value="O", Text="Others"},
            };
            ViewBag.Gender = gender; 
                return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employees)
        {

            db.Employees.Add(employees);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Update(int id)
        {
            var employee = db.Employees.Find(id);
            List<SelectListItem> gender = new List<SelectListItem>
            {
                new SelectListItem {Value="M", Text="Male"},
                new SelectListItem {Value="F", Text="Female"},
                new SelectListItem {Value="O", Text="Others"},
            };
            ViewBag.Gender = gender;
            return View(employee);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Employees.Update(employee);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            var employee = db.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            db.Employees.Attach(employee);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        */
        private readonly IEmployeeProvider _iEmployeeProvider;

        public EmployeeController(IEmployeeProvider iEmployeeProvider)
        {
            _iEmployeeProvider = iEmployeeProvider;

        }
        [Authorize]
        public IActionResult Index()
        {
            var data = _iEmployeeProvider.GetList();
            return View(data);

        }
        public IActionResult Create()
        {
            List<SelectListItem> gender = new List<SelectListItem>
                {
                    new SelectListItem {Value="M", Text="Male"},
                    new SelectListItem {Value="F", Text="Female"},
                    new SelectListItem {Value="O", Text="Others"},
                };
            ViewBag.Gender = gender;
            return PartialView("Add");
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            try
            {
                _iEmployeeProvider.SaveEmployee(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            EmployeeViewModel emp = _iEmployeeProvider.GetById(id);
            List<SelectListItem> gender = new List<SelectListItem>
                {
                    new SelectListItem {Value="M", Text="Male"},
                    new SelectListItem {Value="F", Text="Female"},
                    new SelectListItem {Value="O", Text="Others"},
                };
            ViewBag.Gender = gender;            
            return View(emp);
        }
        [HttpPost]
        public IActionResult Update(EmployeeViewModel model)
        {
            _iEmployeeProvider.SaveEmployee(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _iEmployeeProvider.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
