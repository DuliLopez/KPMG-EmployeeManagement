using EmployeeManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagementAPI.BL
{
    public class DepartmentBL
    {
        public bool CreateNewDep(DepartmentDTO oDepDTO)
        {
            try
            {
                bool result=false;
                string mainCon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(mainCon);
                string sqlQuery = "INSERT INTO Department(dep_id, dep_name, location) VALUES(@dep_id, @dep_name, @location)";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@dep_id", oDepDTO.dep_id);
                cmd.Parameters.AddWithValue("@dep_name", oDepDTO.dep_name);
                cmd.Parameters.AddWithValue("@location", oDepDTO.location);

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
        public bool DeleteDepartment(int dep_id)
        {
            bool result = false;
            var mainCon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(mainCon);
            string sqlQuery = "DELETE FROM Department WHERE dep_id = @dep_id";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.Parameters.AddWithValue("@dep_id", dep_id);
            if (cmd.ExecuteNonQuery() > 0)
            {
                result = true;
            }
            con.Close();
            return result;
        }

        public bool UpdateDepartment(DepartmentDTO oDepDTO)
        {
            try
            {
                bool result = false;
                string mainCon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(mainCon);
                string sqlQuery = "UPDATE Department SET dep_id=@dep_id,dep_name=@dep_name,location=@location WHERE dep_id=@dep_id";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@dep_id", oDepDTO.dep_id);
                cmd.Parameters.AddWithValue("@dep_name", oDepDTO.dep_name);
                cmd.Parameters.AddWithValue("@location", oDepDTO.location);

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

        public List<DepartmentDTO> GetAllDepartments()
        {
            List<DepartmentDTO> depList = new List<DepartmentDTO>();
            var mainCon = ConfigurationManager.ConnectionStrings["EmployeeConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(mainCon);
            string sqlQuery = "SELECT * FROM Department";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DepartmentDTO oDepDTO = new DepartmentDTO();
                oDepDTO.dep_id = Convert.ToInt32(dr["dep_id"]);
                oDepDTO.dep_name = dr["dep_name"].ToString();
                oDepDTO.location = dr["location"].ToString();
                depList.Add(oDepDTO);
            }
            con.Close();
            return depList;
        }
    }
}