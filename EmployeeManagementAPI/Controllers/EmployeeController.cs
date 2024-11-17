using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.BL;

namespace EmployeeManagementAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeBL oEmployeeBL = new EmployeeBL();

        [HttpPost]
        public bool CreateNewEmployee(EmployeeDTO oEmployeeDTO)
        {
            bool result = oEmployeeBL.CreateNewEmployee(oEmployeeDTO);
            return result;
        }

        [HttpPut]
        public bool UpdateEmployee(EmployeeDTO oEmployeeDTO)
        {
            bool result = oEmployeeBL.UpdateEmployee(oEmployeeDTO);
            return result;
        }

        [Route("api/Employee/GetEmployeeList")]
        [HttpGet]
        public List<EmployeeDTO> GetEmployeeList()
        {
            return oEmployeeBL.GetEmployeeList();
        }

        [HttpDelete]
        public bool DeleteEmployee(int emp_id)
        {
            bool result = oEmployeeBL.DeleteEmployee(emp_id);
            return result;
        }

        [Route("api/Employee/GetDepIdList")]
        [HttpGet]
        public List<DepartmentDTO> GetDepIdList()
        {
            return oEmployeeBL.GetDepIdList();
        }
    }
}
