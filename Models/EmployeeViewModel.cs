﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeViewModel
    {
        public int Employee_Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Turn_in { get; set; }
        public DateTime Turn_out { get; set; }
        public DateTime Date { get; set; }
        public DateTime Dob { get; set; }
        public List<EmployeeViewModel> EmployeeList { get; set; }
        public EmployeeViewModel()
        {
            EmployeeList = new List<EmployeeViewModel>();
        }
        public String UserName { get; set; }
        public string Designation_Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public double Contact_No { get; set; }
        public int Gender_Id { get; set; }


    }
}