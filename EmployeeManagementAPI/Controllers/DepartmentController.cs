using EmployeeManagementAPI.BL;
using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagementAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        DepartmentBL oDepBL = new DepartmentBL();

        [HttpPost]
        public bool CreateNewDep(DepartmentDTO oDepDTO)
        {
            bool result = oDepBL.CreateNewDep(oDepDTO);
            return result;
        }

        [Route("api/Department/GetAllDepartments")]
        [HttpGet]
        public List<DepartmentDTO> GetAllDepartments()
        {
            return oDepBL.GetAllDepartments();
        }

        [HttpPut]
        public bool UpdateDepartment(DepartmentDTO oDepDTO)
        {
            bool result = oDepBL.UpdateDepartment(oDepDTO);
            return result;
        }

        [HttpDelete]
        public bool DeleteDepartment(int dep_id)
        {
            bool result = oDepBL.DeleteDepartment(dep_id);
            return result;
        }
    }
}
