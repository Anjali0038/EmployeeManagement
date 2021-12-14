using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {

        public LeaveRepository(EmployeeManagementDbContext context) : base(context)
        {
        }
    }
}
