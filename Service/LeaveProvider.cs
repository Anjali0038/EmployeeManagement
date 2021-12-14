using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
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
    }
    public class LeaveProvider : ILeaveProvider
    {
        private readonly ILeaveRepository _iLeaveRepository;
        private readonly IMapper _mapper;
        public LeaveProvider(ILeaveRepository iLeaveRepository, IMapper mapper)
        {
            _iLeaveRepository = iLeaveRepository;
            _mapper = mapper;
        }
        public int SaveLeave(LeaveViewModel model)
        {
            Leave leave = new Leave();
            leave = _mapper.Map<Leave>(model);
            _iLeaveRepository.Add(leave);
            return 200;
        }
        public LeaveViewModel GetById(int id)
        {
            var item = _iLeaveRepository.GetSingle(x => x.Leave_Id == id);
            LeaveViewModel data = _mapper.Map<LeaveViewModel>(item);
            return data;
        }
    }
}
