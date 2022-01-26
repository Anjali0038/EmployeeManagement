using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public interface IAttendanceProvider
    {
        int SaveAttendance(AttendanceViewModel model);
        List<Employee> GetEmployees();
        AttendanceViewModel GetList();
    }
    public class AttendanceProvider: IAttendanceProvider
    {
        public readonly IAttendanceRepository _iAttendanceRepository;
        private readonly IMapper _mapper;
        private EmployeeManagementDbContext _context;
        public AttendanceProvider(IAttendanceRepository iAttendanceRepository, IMapper mapper,EmployeeManagementDbContext context)
        {
            _iAttendanceRepository = iAttendanceRepository;
            _mapper = mapper;
            _context = context;
        }
        public int SaveAttendance(AttendanceViewModel model)
        {
            //Attendance attendance = new Attendance();
            Attendance attendance = _mapper.Map<AttendanceViewModel, Attendance>(model);
            _iAttendanceRepository.Add(attendance);
            return 200;
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
        public AttendanceViewModel GetList()
        {
            AttendanceViewModel model = new AttendanceViewModel();
            var list = new List<AttendanceViewModel>();
            List<Attendance> data = _iAttendanceRepository.GetAll().ToList();
            list = _mapper.Map<List<Attendance>, List<AttendanceViewModel>>(data);
            model.AttendanceList = list;
            return model;
        }
    }
}
