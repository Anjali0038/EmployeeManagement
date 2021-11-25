using EmployeeManagement.Areas.Identity.Data;
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
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserProvider _iApplicationUserProvider;
        private EmployeeManagementDbContext _context;

        public ApplicationUserController(IApplicationUserProvider iApplicationUserProvider, EmployeeManagementDbContext context)
        {
            _iApplicationUserProvider = iApplicationUserProvider;
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _iApplicationUserProvider.GetList();
            var Emp = _context.Employees.ToList();
            List<SelectListItem> emp = new List<SelectListItem>();
            foreach(var item in Emp)
            {
                string data1 = item.FirstName + item.MiddleName + item.LastName;
                SelectListItem items = new SelectListItem { Value = data1, Text = data1 };
                emp.Add(items);
            }
            ViewBag.Emp = emp;
            return View(data);
        }
        [HttpGet]
        public IActionResult CreateOrEdit(string id)
        {
            ApplicationUserViewModel usr = _iApplicationUserProvider.GetById(id);
            return View(usr);

        }
        [HttpPost]
        public IActionResult CreateOrEdit(ApplicationUserViewModel model)
        {
            try
            {
                _iApplicationUserProvider.SaveUser(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Update(string id)
        {
            ApplicationUserViewModel emp = _iApplicationUserProvider.GetById(id);
            return Json(emp);
        }
        public IActionResult Delete(string id)
        {
            _iApplicationUserProvider.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
