using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public interface ILeaveProvider
    {
        int SaveLeave(LeaveViewModel model);
        LeaveViewModel GetById(int id);
        List<Employee> GetEmployees();
        List<ApplicationUser> GetUsers();
        LeaveViewModel GetList();
        LeaveViewModel GetApprovedLeave();
        int EditLeave(LeaveViewModel model);
        List<CalenderViewModel> GetCalendarDataByYearAndMonth(string eid,string year, string month);

    }
    public class LeaveProvider : ILeaveProvider
    {
        private readonly ILeaveRepository _iLeaveRepository;
        private readonly IHolidayRepository _iHolidayRepository;
        private readonly IAttendanceRepository _iAttendanceRepository;

        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LeaveProvider(IAttendanceRepository iAttendanceRepository, IHolidayRepository iHolidayRepository,UserManager<ApplicationUser> userManager, ILeaveRepository iLeaveRepository, IMapper mapper, EmployeeManagementDbContext context)
        {
            _userManager = userManager;
            _iLeaveRepository = iLeaveRepository;
            _iHolidayRepository = iHolidayRepository;
            _iAttendanceRepository = iAttendanceRepository;
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
        public LeaveViewModel GetList()
        {
            LeaveViewModel model = new LeaveViewModel();
            var list = new List<LeaveViewModel>();
            List<Leave> data = _iLeaveRepository.GetAll().ToList();
            list = _mapper.Map<List<Leave>, List<LeaveViewModel>>(data);
            model.LeaveList = list;
            return model;
        }
        public LeaveViewModel GetApprovedLeave()
        {
            LeaveViewModel model = new LeaveViewModel();
            var list = new List<LeaveViewModel>();
            List<Leave> data = _iLeaveRepository.GetAll().ToList();
            foreach( var item in data)
            {
                if(item.LeaveStatus==true)
                {
                    list = _mapper.Map<List<Leave>, List<LeaveViewModel>>(data);
                    model.LeaveList = list;
                }
            }
            return model;

            //var leaveList = new List<Leave>();
            //var leave = _context.Leave.ToList();
            //foreach (var item in leave)
            //{
            //    if (item.LeaveStatus == true)
            //    {
            //        leaveList.Add(item);
            //    }
            //}
            //return leaveList;
        }
        public int EditLeave(LeaveViewModel model)
        {
            Leave leave = new Leave();
            leave = _mapper.Map<Leave>(model);
            _iLeaveRepository.Update(leave);
            return 200;
        }
        public List<CalenderViewModel> GetCalendarDataByYearAndMonth(string eid, string year, string month)
        {

            //var users = _context.Users.Find();
            int EmpId = Convert.ToInt32(eid);
            int monthInt = 0;
            if(month == "0")            
                monthInt = 1;            
            else if(month=="1")            
                monthInt = 2;            
            //else 

            DateTime firstDate = Convert.ToDateTime(monthInt+"/01/" + year);
            DateTime lastDate = Convert.ToDateTime( monthInt +"/28/" + year);


            List<CalenderViewModel> model = new();
            List<Attendance> attendance = _iAttendanceRepository.GetAll(x=>x.Employee_Id == EmpId).Where(x=>x.Date <= lastDate && x.Date >= firstDate).ToList();
            
            //List<Leave> leave = _iLeaveRepository.GetAll(x=>x.EId ==users.EId ).ToList();

            //foreach (var item in data)
            //{
            //    if (item.LeaveStatus == true)s
            //    {
            //        list = _mapper.Map<List<Leave>, List<LeaveViewModel>>(data);
            //        model.LeaveList = list;
            //    }
            //}
            //return model;s
            return model;
        }
    }
}
