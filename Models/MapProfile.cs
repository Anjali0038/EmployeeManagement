using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Models;

namespace EmployeeManagement.Models
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
            .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.MiddleName, o => o.MapFrom(src => src.MiddleName))
            .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Address, o => o.MapFrom(src => src.Address))
            .ForMember(dest => dest.Designation_Name, o => o.MapFrom(src => src.Designation_Name))
            .ForMember(dest => dest.Dob, o => o.MapFrom(src => src.Dob))
            .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
            .ForMember(dest => dest.Salary, o => o.MapFrom(src => src.Salary))
            .ForMember(dest => dest.Gender_Id, o => o.MapFrom(src => src.Gender_Id))
            .ForMember(dest => dest.Contact_No, o => o.MapFrom(src => src.Contact_No));
            CreateMap<EmployeeViewModel, Employee>();

            CreateMap<ApplicationUser, ApplicationUserViewModel>()
            .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.MiddleName, o => o.MapFrom(src => src.MiddleName))
            .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Designation, o => o.MapFrom(src => src.Designation))
            .ForMember(dest => dest.EmployeeList, o => o.MapFrom(src => src.EmployeeList))
            .ForMember(dest => dest.Email, o => o.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, o => o.MapFrom(src => src.PasswordHash));
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
        }
    }
}