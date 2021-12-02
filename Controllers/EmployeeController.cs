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
        public IActionResult Delete(int id)
        {
             _iEmployeeProvider.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
       
    }
}
