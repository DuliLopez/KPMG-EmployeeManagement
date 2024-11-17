using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace EmployeeManagementAPI.BL
{
    public class EmployeeBL
    {
        public bool CreateNewEmployee(EmployeeDTO oEmployeeDTO)
        {
            try
            {
                bool result = false;
                var maincon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(maincon);
                string sqlquery = "INSERT INTO Employee(emp_id, emp_name, emp_address, dep_id, emp_salary) VALUES(@emp_id, @emp_name, @emp_address, @dep_id, @emp_salary)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.Parameters.AddWithValue("@emp_id", oEmployeeDTO.emp_id);
                cmd.Parameters.AddWithValue("@emp_name", oEmployeeDTO.emp_name);
                cmd.Parameters.AddWithValue("@emp_address", oEmployeeDTO.emp_address);
                cmd.Parameters.AddWithValue("@dep_id", oEmployeeDTO.dep_id);
                cmd.Parameters.AddWithValue("@emp_salary", oEmployeeDTO.emp_salary);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool DeleteEmployee(int emp_id)
        {
            bool result = false;
            var maincon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            string sql = "DELETE FROM Employee WHERE emp_id=@emp_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@emp_id", emp_id);

            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public List<EmployeeDTO> GetEmployeeList()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            var maincon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(maincon))
            {
                string query = "SELECT * FROM Employee e, Department d WHERE e.dep_id = d.dep_id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            EmployeeDTO oEmployeeDTO = new EmployeeDTO
                            {
                                emp_id = Convert.ToInt32(dr["emp_id"]),
                                emp_name = dr["emp_name"].ToString(),
                                emp_address = dr["emp_address"].ToString(),
                                dep_id = Convert.ToInt32(dr["dep_id"]),
                                dep_name = dr["dep_name"].ToString(),
                                emp_salary = Convert.ToDouble(dr["emp_salary"])
                            };
                            list.Add(oEmployeeDTO);
                        }
                    }
                }
            }
            return list;
        }

        public bool UpdateEmployee(EmployeeDTO oEmployeeDTO)
        {
            try
            {
                bool result = false;
                var maincon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(maincon);
                string sqlquery = "UPDATE Employee SET emp_name = @emp_name,emp_address = @emp_address, dep_id = @dep_id, emp_salary = @emp_salary WHERE emp_id = @emp_id";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                cmd.Parameters.AddWithValue("@emp_id", oEmployeeDTO.emp_id);
                cmd.Parameters.AddWithValue("@emp_name", oEmployeeDTO.emp_name);
                cmd.Parameters.AddWithValue("@emp_address", oEmployeeDTO.emp_address);
                cmd.Parameters.AddWithValue("@dep_id", oEmployeeDTO.dep_id);
                cmd.Parameters.AddWithValue("@emp_salary", oEmployeeDTO.emp_salary);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                con.Close();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DepartmentDTO> GetDepIdList()
        {
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            var maincon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(maincon);
            string allDepqlQuery = "SELECT dep_id, dep_name FROM Department";
            SqlCommand cmd = new SqlCommand(allDepqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DepartmentDTO oDepDTO = new DepartmentDTO();
                oDepDTO.dep_id = Convert.ToInt32(dr["dep_id"]);
                oDepDTO.dep_name = dr["dep_name"].ToString();

                list.Add(oDepDTO);
            }
            con.Close();
            return list;
        }
    }
}