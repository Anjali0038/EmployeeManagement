using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public class AttendanceRepository :Repository<Attendance>,IAttendanceRepository
    {
        public AttendanceRepository(EmployeeManagementDbContext context) : base(context)
        {
        }
    }

}
