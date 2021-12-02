using AutoMapper;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public interface IEmployeeProvider
    {
        int SaveEmployee(EmployeeViewModel model);
        void DeleteEmployee(int id);
       // EmployeeViewModel EditEmployee(EmployeeViewModel model);
        EmployeeViewModel GetList();
        EmployeeViewModel GetById(int id);
        //EmployeeViewModel SearchValue(string value);

    }
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        private readonly IMapper _mapper;

        public EmployeeProvider(IEmployeeRepository iEmployeeRepository, IMapper mapper)
        {
            _iEmployeeRepository = iEmployeeRepository;
            _mapper = mapper;

        }
        public int SaveEmployee(EmployeeViewModel model)
        {
            Employee employee = new Employee();
            employee = _mapper.Map<Employee>(model);
            if (employee.Employee_Id > 0)
            {
                _iEmployeeRepository.Update(employee);
                return 200;
            }
            else
            {
                _iEmployeeRepository.Add(employee);
                return 200;
            }
        }
        public void DeleteEmployee(int id)
        {
            var item = _iEmployeeRepository.GetSingle(x => x.Employee_Id == id);
            _iEmployeeRepository.Delete(item);
        }
        public EmployeeViewModel GetById(int id)
        {
            var item = _iEmployeeRepository.GetSingle(x => x.Employee_Id == id);
            EmployeeViewModel data = _mapper.Map<EmployeeViewModel>(item);
            return data;
        }
        public EmployeeViewModel GetList()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var list = new List<EmployeeViewModel>();
            List<Employee> data = _iEmployeeRepository.GetAll().ToList();
            list = _mapper.Map<List<Employee>, List<EmployeeViewModel>>(data);
            model.EmployeeList = list;
            return model;
        }
    }


}
