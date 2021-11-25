using AutoMapper;
using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public interface IApplicationUserProvider
    {
        int SaveUser(ApplicationUserViewModel model);
        void DeleteUser(string id);
        ApplicationUserViewModel GetList();
        ApplicationUserViewModel GetById(string id);

    }
    public class ApplicationUserProvider : IApplicationUserProvider
    {
        private readonly IApplicationUserRepository _iApplicationUserRepository;
        private readonly IMapper _mapper;
        public ApplicationUserProvider(IMapper mapper, IApplicationUserRepository iApplicationUserRepository)
        {
            _iApplicationUserRepository = iApplicationUserRepository;
            _mapper = mapper;

        }
        public int SaveUser(ApplicationUserViewModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user = _mapper.Map<ApplicationUser>(model);
            if (user.Id ==null)
            {
                _iApplicationUserRepository.Add(user);
                return 200;             
            }
            else
            {
                _iApplicationUserRepository.Update(user);
                return 200;
            }
        }
        public void DeleteUser(string id)
        {
            var item = _iApplicationUserRepository.GetSingle(x => x.Id == id);
            _iApplicationUserRepository.Delete(item);
        }
  
        public ApplicationUserViewModel GetById(string id)
        {
            var item = _iApplicationUserRepository.GetSingle(x => x.Id == id);
            ApplicationUserViewModel data = _mapper.Map<ApplicationUserViewModel>(item);
            return data;
        }
        public ApplicationUserViewModel GetList()
        {
            ApplicationUserViewModel model = new ApplicationUserViewModel();
            var list = new List<ApplicationUserViewModel>();
            List<ApplicationUser> data = _iApplicationUserRepository.GetAll().ToList();
            list = _mapper.Map<List<ApplicationUser>, List<ApplicationUserViewModel>>(data);
            model.UsersList = list;
            return model;
        }

    }
}
