using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeDTO
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string emp_address { get; set; }
        public int dep_id { get; set; }
        public string dep_name { get; set; }
        public double emp_salary { get; set; }
    }
}