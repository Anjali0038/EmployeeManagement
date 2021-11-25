using EmployeeManagement.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }
}
