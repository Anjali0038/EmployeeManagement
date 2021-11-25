using EmployeeManagement.Areas.Identity.Data;
using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(EmployeeManagementDbContext context) : base(context)
        {

        }
    }
}
