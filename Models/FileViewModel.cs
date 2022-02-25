using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class FileViewModel
    {
        public IFormFile File { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
