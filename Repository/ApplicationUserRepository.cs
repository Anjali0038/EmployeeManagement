using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Data;
using EmployeeManagement.Areas.Identity.Data;

namespace EmployeeManagement.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(EmployeeManagementDbContext context) : base(context)
        {
        }
    }
}
