﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Gender
    {
        [Key]
        public int Gender_Id { get; set; }
        public char Gender_Name { get; set; }
    }
}
