using AutoMapper;
using EmployeeManagement.Models;

namespace EmployeeManagement.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();

        }
    }
}