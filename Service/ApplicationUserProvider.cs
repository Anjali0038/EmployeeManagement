using Abp.Net.Mail;
using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Controllers;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public interface IApplicationUserProvider
    {
        Task<int> SaveUser(ApplicationUserViewModel model);
        Task<bool> DeleteUser(string id);
        List<ApplicationUserViewModel> GetList();
        Task<ApplicationUserViewModel> GetById(string id);
        List<Employee> GetEmployeesWithNoUsers();

    }
    public class ApplicationUserProvider : IApplicationUserProvider
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private EmployeeManagementDbContext _context;
        public ApplicationUserProvider(UserManager<ApplicationUser> userManager,
            IMapper mapper, EmployeeManagementDbContext context)
        {
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }
        public async Task<int> SaveUser(ApplicationUserViewModel model)
        {
            int empId = Convert.ToInt32(model.Employee_Id);
            ApplicationUser applicationuser = _mapper.Map<ApplicationUserViewModel, ApplicationUser>(model);
            var user = await _userManager.Users.Where(x => x.Employee.Employee_Id == empId).FirstOrDefaultAsync();
            IdentityResult result;
            if (user == null)
            {
                var singleEmployee = _context.Employees.Where(x => x.Employee_Id == empId).First();
                applicationuser.Id = Guid.NewGuid().ToString();
                applicationuser.Employee = singleEmployee;
                applicationuser.EId = singleEmployee.Employee_Id;
                result = await _userManager.CreateAsync(applicationuser, model.PasswordHash);
                var newUser = await _userManager.FindByIdAsync(applicationuser.Id);
                singleEmployee.ApplicationUser.Add(newUser);
                _context.Employees.Attach(singleEmployee);
                _context.SaveChanges();
            }
            else
            {
                user.UserName = applicationuser.UserName.ToLower();
                user.Email = applicationuser.Email;
                result = await _userManager.UpdateAsync(user);
            }
            if (result.Succeeded)
            {
                return 200;
            }
            return 500;
        }
        public async Task<bool> DeleteUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                //var usr = await _userManager.FindByEmailAsync("abc@gmail.com");
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<ApplicationUserViewModel> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ApplicationUserViewModel data = _mapper.Map<ApplicationUser, ApplicationUserViewModel>(user);
            return data;
        }
        public List<ApplicationUserViewModel> GetList()
        {
            List<ApplicationUserViewModel> user = new List<ApplicationUserViewModel>();
            List<ApplicationUser> usersList = _userManager.Users.ToList();
            user = _mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(usersList);
            return user;
        }

        public List<Employee> GetEmployeesWithNoUsers()
        {
            var EmpList = new List<Employee>();

            var Emp = _context.Employees.ToList();
            List<ApplicationUser> usersList = _userManager.Users.ToList();

            foreach (var item in Emp)
            {
                bool isExist = false;                

                foreach (var user in usersList)
                {
                    if (user.EId == item.Employee_Id)
                    {
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    EmpList.Add(item);                    
                }
            }
            return EmpList;
        }


    }
}

