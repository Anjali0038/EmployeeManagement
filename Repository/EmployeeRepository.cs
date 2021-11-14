using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Data;

namespace EmployeeManagement.Repository
{


    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(EmployeeManagementDbContext context) : base(context)
        {
        }
    }

}
