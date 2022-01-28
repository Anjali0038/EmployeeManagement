﻿using AutoMapper;
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
        AttendanceViewModel GetById(int id);
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
            var today2 = DateTime.Today;
            if (model.Type == "TurnIn")
            {
                var attendance1 = _iAttendanceRepository.GetSingle(x => x.Turn_in >today2 && x.Employee_Id==model.Employee_Id);
                if(attendance1==null)
                {
                    attendance1.Turn_in = DateTime.Now;
                    _iAttendanceRepository.Add(attendance1);
                }
            }
            else
            {
                var attendance1 = _iAttendanceRepository.GetSingle(x => x.Turn_in > today2 && x.Employee_Id == model.Employee_Id);
                if(attendance1==null)
                { }
                else
                {
                    attendance1.Turn_out = DateTime.Now;
                    _iAttendanceRepository.Update(attendance1);
                }

            }
            return 200;
        }
        //public int Save (Attendance attendance)
        //{
        //    var att = _context.Attendances.Where(x => x.Attendance_Id == attendance.Attendance_Id).FirstOrDefault();
        //    att.Turn_out = attendance.Turn_out;
        //    _context.SaveChanges();
        //    return 200;
        //}
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
        public AttendanceViewModel GetById(int id)
        {
            var item = _iAttendanceRepository.GetSingle(x => x.Attendance_Id == id);
            AttendanceViewModel data = _mapper.Map<AttendanceViewModel>(item);
            return data;
        }
    }
}
