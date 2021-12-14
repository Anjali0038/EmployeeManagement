using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
namespace EmployeeManagemnt.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeProvider _iEmployeeProvider;
        private EmployeeManagementDbContext _context;

        public EmployeeController(IEmployeeProvider iEmployeeProvider, EmployeeManagementDbContext context)
        {
            _iEmployeeProvider = iEmployeeProvider;
            _context = context;

        }
        public IActionResult Index(string searchText = "")
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            if (searchText != "" && searchText != null)
            {
                employee.EmployeeList = (from s in _context.Employees
                                         where s.UserName.Contains(searchText)
                                         select new EmployeeViewModel
                                         {
                                             Employee_Id = s.Employee_Id,
                                             Designation_Name = s.Designation_Name,
                                             FirstName = s.FirstName,
                                             UserName = s.UserName,
                                             Email = s.Email,
                                             Address = s.Address,
                                         }).ToList();
            }
            else
                employee = _iEmployeeProvider.GetList();
            ViewBag.Gender = _context.Genders.ToList();
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateOrEdit(EmployeeViewModel model)
        {
            //    if (ModelState.IsValid)
            //    {
            try
            {
                _iEmployeeProvider.SaveEmployee(model);
                TempData["Success"] = "Success";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}
            //return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _iEmployeeProvider.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeSearch(string val)
        {
            EmployeeViewModel model = new EmployeeViewModel();

            model.EmployeeList = (from s in _context.Employees
                                  where s.UserName.Contains(val)
                                  select new EmployeeViewModel
                                  {
                                      Employee_Id = s.Employee_Id,
                                      FirstName = s.FirstName,
                                      Email = s.Email,
                                      Designation_Name = s.Designation_Name
                                  }).ToList();
            return PartialView(model);
        }
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var users = (from user in this._context.Employees
                         where user.UserName.StartsWith(prefix)
                         select new
                         {
                             label = user.UserName,
                             val = user.Employee_Id
                         }).ToList();

            return Json(users);
        }

        //private EmployeeViewModel GetEmployees(int currentPage)
        //{
        //    int maxRows = 10;
        //    EmployeeViewModel model = new EmployeeViewModel();

        //    model.EmployeeList = (from employee in this._context.Employees
        //                          select employee)
        //                .OrderBy(employee => employee.Employee_Id)
        //                .Skip((currentPage - 1) * maxRows)
        //                .Take(maxRows).ToList();

        //    double pageCount = (double)((decimal)this._context.Employees.Count() / Convert.ToDecimal(maxRows));
        //    employeeModel.PageCount = (int)Math.Ceiling(pageCount);

        //    employeeModel.CurrentPageIndex = currentPage;

        //    return employeeModel;
        //}

    }
}
