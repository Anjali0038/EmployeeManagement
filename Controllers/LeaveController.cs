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
            return View();
        }
        [HttpPost]
        public IActionResult Index(LeaveViewModel model)
        {
            try
            {
                _iLeaveProvider.SaveLeave(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
