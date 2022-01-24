using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public interface ILeaveProvider
    {
        int SaveLeave(LeaveViewModel model);
        LeaveViewModel GetById(int id);
        List<Employee> GetEmployees();
        List<ApplicationUser> GetUsers();

    }
    public class LeaveProvider : ILeaveProvider
    {
        private readonly ILeaveRepository _iLeaveRepository;
        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LeaveProvider(UserManager<ApplicationUser> userManager, ILeaveRepository iLeaveRepository, IMapper mapper,EmployeeManagementDbContext context)
        {
            _userManager = userManager;
            _iLeaveRepository = iLeaveRepository;
            _mapper = mapper;
            _context = context;
        }
        public int SaveLeave(LeaveViewModel model)
        {
            //int empId = Convert.ToInt32(model.EId);
            //Leave leave = _mapper.Map<LeaveViewModel,Leave>(model);
            //var emp = _iLeaveRepository.GetSingle(x => x.Employee.Employee_Id == empId);
            //var singleEmployee = _context.Employees.Where(x => x.Employee_Id == empId).First();
            //leave.Employee = singleEmployee;
            //leave.EId = singleEmployee.Employee_Id;
            //_iLeaveRepository.Add(leave);
            //_context.Employees.Attach(singleEmployee);
            //_context.SaveChanges();
            //return 200;
            string usrId = model.UserId;
            Leave leave = _mapper.Map<LeaveViewModel, Leave>(model);
            var usr = _iLeaveRepository.GetSingle(x => x.UserId == model.UserId);
            var singleUser = _context.Users.Where(x => x.Id == usrId).First();
            leave.UserId = singleUser.Id;
            _iLeaveRepository.Add(leave);
            _context.Users.Attach(singleUser);
            _context.SaveChanges();
            return 200;
        }
        public LeaveViewModel GetById(int id)
        {
            var item = _iLeaveRepository.GetSingle(x => x.Leave_Id == id);
            LeaveViewModel data = _mapper.Map<LeaveViewModel>(item);
            return data;
        }
        public List<Employee> GetEmployees()
        {
            var EmpList = new List<Employee>();
            var Emp = _context.Employees.ToList();
            foreach (var item in Emp)
            {
                EmpList.Add(item);
            }
            return EmpList;
        }
        public List<ApplicationUser> GetUsers()
        {
            var UserList = new List<ApplicationUser>();
            List<ApplicationUser> usersList = _userManager.Users.ToList();
            foreach (var item in usersList)
            {
                UserList.Add(item);
            }
            return UserList;
        }
    }
}
