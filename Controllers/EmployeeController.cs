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
        public IActionResult CreateOrEdit( int id)
        {
            ViewBag.Gender = _context.Genders.ToList();           
            EmployeeViewModel emp = _iEmployeeProvider.GetById(id);
            return View(emp);
            //    Gender gen = new Gender();
            //    ViewBag.Gender = new SelectList(_context.Genders.ToList(), "Gender_Id", "Gender_Name");
            //    var data = _context.Genders.ToList();
            //    List<SelectListItem> gender = new List<SelectListItem>
            //        {
            //            new SelectListItem {Value="M",  Text="Male"},
            //            new SelectListItem {Value="F", Text="Female"},
            //            new SelectListItem {Value="O", Text="Others"},
            //        };
            //    ViewBag.Gender = gender;
            //return PartialView();
        }
        [HttpPost]
        public IActionResult CreateOrEdit(EmployeeViewModel model)
        {
            try
            {
                _iEmployeeProvider.SaveEmployee(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex ;
            }
        }
        public JsonResult Update(int id)
        {
            EmployeeViewModel emp = _iEmployeeProvider.GetById(id);
            return Json(emp);
        }
        //[HttpPost]
        //public IActionResult Update(EmployeeViewModel model)
        //{
        //    _iEmployeeProvider.SaveEmployee(model);
        //    return RedirectToAction("Index");
        //}
        public IActionResult Delete(int id)
        {
            _iEmployeeProvider.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public ActionResult _PartialEmployees(string val)
        {
            EmployeeViewModel model = new EmployeeViewModel();

            model.EmployeeList = (from s in _context.Employees
                               where s.FirstName.Contains(val)|| s.MiddleName.Contains(val) || s.LastName.Contains(val) || s.Address.Contains(val) || s.Email.Contains(val)
                                  select new EmployeeViewModel
                               {
                                   Employee_Id = s.Employee_Id,
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   MiddleName = s.MiddleName,
                                   Email = s.Email,
                                   Designation_Name = s.Designation_Name,
                                   Dob = s.Dob,
                                   Address = s.Address
                               }).ToList();
            return View(model);
        }
        public JsonResult BindDataInDropDownList()
        {
            var list = new List<EmployeeViewModel>();
            var data = _context.Employees.ToList();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    EmployeeViewModel objModel = new EmployeeViewModel();
                    objModel.Employee_Id = item.Employee_Id;
                    objModel.FirstName = item.FirstName;
                    objModel.MiddleName = item.MiddleName;
                    objModel.LastName = item.LastName;
                    objModel.Address = item.Address;
                    objModel.Dob = item.Dob;
                    objModel.Designation_Name = item.Designation_Name;
                    objModel.Email = item.Email;
                    objModel.UserName = item.UserName;
                    list.Add(objModel);
                }
            }
            return Json(data);
        }
    }
}
