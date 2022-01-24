using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EmployeeManagement.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserProvider _iApplicationUserProvider;
        private EmployeeManagementDbContext _context;
        private readonly SignInManager<ApplicationUser> _signManager;
        public ApplicationUserController(
            IApplicationUserProvider iApplicationUserProvider,
            EmployeeManagementDbContext context, SignInManager<ApplicationUser> signManager,
            UserManager<ApplicationUser> userManager)
        {
            _signManager = signManager;
            _iApplicationUserProvider = iApplicationUserProvider;
            _context = context;
        }
        public IActionResult Index(string searchText="")
        {
            //var userName= HttpContext.Session.GetString("UserName");
            //HttpContext.Session.GetString("UserName");
            ApplicationUserViewModel user = new ApplicationUserViewModel();
            if (searchText!= ""&& searchText!=null)
            {
                user.UsersList = (from s in _context.Users
                                   where s.UserName.Contains(searchText)
                                   select new ApplicationUserViewModel
                                   {
                                       Id = s.Id,
                                       FullName = s.FullName,
                                       UserName = s.UserName,
                                       Email = s.Email,
                                       Designation = s.Designation,
                                   }).ToList();
            }
            else
            user.UsersList = _iApplicationUserProvider.GetList();
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(string id)
        {
            var EmpList = _iApplicationUserProvider.GetEmployeesWithNoUsers();           
            List<SelectListItem> emp = new List<SelectListItem>();
            foreach (var item in EmpList)
            {
                string data1 = item.FirstName +" "+ item.MiddleName +" "+ item.LastName;
                int id1 = item.Employee_Id;
                SelectListItem items = new SelectListItem { Value = id1.ToString(), Text = data1 };
                emp.Add(items);
            }
            ViewBag.Emp = emp;
            ApplicationUserViewModel user = new ApplicationUserViewModel();
            if (id != null)
            {
                user = await  _iApplicationUserProvider.GetById(id);
            }
            return PartialView(user);
        }
        [HttpPost]
        public async  Task<IActionResult> CreateOrEdit(ApplicationUserViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    var user = _context.Employees.Where(x => x.Employee_Id == Convert.ToInt32(model.Employee_Id)).FirstOrDefault();
                    model.Email = user.Email;
                    model.Designation = user.Designation_Name;
                    model.FullName = user.FirstName +" "+ user.MiddleName +" "+ user.LastName;
                    var res = await _iApplicationUserProvider.SaveUser(model);
                    TempData["Success"] = "Success";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            //}
            ////ModelState.AddModelError(nameof(model.ConfirmPassword), "Password doesn't matched");
            //return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await _iApplicationUserProvider.DeleteUser(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task Logout()
        {
            await _signManager.SignOutAsync();
        }
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var users = (from user in this._context.Users
                             where user.UserName.StartsWith(prefix)
                             select new
                             {
                                 label = user.UserName,
                                 val = user.EId
                             }).ToList();
            return Json(users);
        }
    }
}
