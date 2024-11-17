using Newtonsoft.Json;
using EmployeeManagementAPP.Common;
using EmployeeManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementAPP.Pages
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepIdList();
                LoadEmployeeDatagrid();
            }
        }
        protected void LinkButtonEmployeeForm_Click1(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeForm.aspx");
        }

        protected void LinkButtonDepartmentForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentForm.aspx");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeDTO oEmployeeDTO = new EmployeeDTO();
                oEmployeeDTO.emp_id = Convert.ToInt32(txtEmpId.Text);
                oEmployeeDTO.emp_name = txtName.Text;
                oEmployeeDTO.emp_address = txtAddress.Text;
                oEmployeeDTO.dep_id = Convert.ToInt32(ddlDepId.SelectedValue);
                oEmployeeDTO.emp_salary = Convert.ToDouble(txtSalary.Text);

                bool isInserted = InsertEmployeeData(oEmployeeDTO);
                LoadEmployeeDatagrid();
                ClearFields();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeDTO oEmployeeDTO = new EmployeeDTO();
            oEmployeeDTO.emp_id = Convert.ToInt32(txtEmpId.Text);
            oEmployeeDTO.emp_name = txtName.Text;
            oEmployeeDTO.emp_address = txtAddress.Text;
            oEmployeeDTO.dep_id = Convert.ToInt32(ddlDepId.Text);
            oEmployeeDTO.emp_salary = Convert.ToDouble(txtSalary.Text);

            bool isUpdated = UpdateEmployeeData(oEmployeeDTO);
            LoadEmployeeDatagrid();
            ClearFields();
        }
        protected void gvEmployeeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRecord")
            {
                ViewState["index"] = e.CommandArgument.ToString();
                GridViewRow row = gvEmployeeDetails.Rows[(Convert.ToInt32(ViewState["index"]))];
                Label EmployeeID = (Label)row.FindControl("lblgvEmpId");
                Label EmployeeName = (Label)row.FindControl("lblgvEmpName");
                Label EmployeeAddress = (Label)row.FindControl("lblgvEmpAddress");
                Label DepartmentId = (Label)row.FindControl("lblgvDepId");
                Label DepartmentName = (Label)row.FindControl("lblgvDepName");
                Label EmployeeSalary = (Label)row.FindControl("lblgvEmpSalary");

                txtEmpId.Enabled = false;

                EmployeeDTO oEmployeeDTO = new EmployeeDTO();
                oEmployeeDTO.emp_id = Convert.ToInt32(EmployeeID.Text);
                oEmployeeDTO.emp_name = EmployeeName.Text;
                oEmployeeDTO.emp_address = EmployeeAddress.Text;
                oEmployeeDTO.dep_id = Convert.ToInt32(DepartmentId.Text);
                oEmployeeDTO.dep_name = DepartmentName.Text;
                oEmployeeDTO.emp_salary = Convert.ToDouble(EmployeeSalary.Text);

                SetGridValues(oEmployeeDTO);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            bool isDeleted = DeleteEmployeeData(Convert.ToInt32(txtEmpId.Text));
            LoadEmployeeDatagrid();
            ClearFields();
        }
        protected void LinkButtonDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion Events

        #region Methods
        private void LoadEmployeeDatagrid()
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
            employeeList = GetEmployeeList();
            gvEmployeeDetails.DataSource = employeeList;
            gvEmployeeDetails.DataBind();
        }

        private void LoadDepIdList()
        {
            List<DepartmentDTO> depIdList = new List<DepartmentDTO>();
            depIdList = GetDepIdList();
            ddlDepId.DataSource = depIdList;
            ddlDepId.DataTextField = "dep_name";
            ddlDepId.DataValueField = "dep_id";
            ddlDepId.DataBind();

            ddlDepId.Items.Insert(0, new ListItem("-- Select Department --", "-1"));
        }

        private void ClearFields()
        {
            txtEmpId.Enabled = true;
            txtEmpId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtSalary.Text = "";
            ddlDepId.SelectedIndex = -1;
        }
        private void SetGridValues(EmployeeDTO oEmployeeDTO)
        {
            txtEmpId.Text = oEmployeeDTO.emp_id.ToString();
            txtName.Text = oEmployeeDTO.emp_name;
            txtAddress.Text = oEmployeeDTO.emp_address;
            ddlDepId.SelectedValue = oEmployeeDTO.dep_id.ToString();
            txtSalary.Text = oEmployeeDTO.emp_salary.ToString();
        }
        private bool InsertEmployeeData(EmployeeDTO oEmployeeDTO)
        {
            bool result = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Employee/CreateNewEmployee";

                    var json = JsonConvert.SerializeObject(oEmployeeDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync(path, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = true;
                        Response.Write("<script>alert('Data inserted successfully')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private bool UpdateEmployeeData(EmployeeDTO oEmployeeDTO)
        {
            bool result = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Employee/UpdateEmployee";

                    var json = JsonConvert.SerializeObject(oEmployeeDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PutAsync(path, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        result = true;
                        Response.Write("<script>alert('Data updated successfully')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private bool DeleteEmployeeData(int emp_id)
        {
            bool result = false;
            try
            {
                EmployeeDTO results = new EmployeeDTO();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Employee/DeleteEmployeeData?emp_id=" + emp_id;
                    HttpResponseMessage response = client.DeleteAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        Response.Write("<script>alert('Data deleted successfully')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion Methods

        #region WebAPI
        private List<EmployeeDTO> GetEmployeeList()
        {
            List<EmployeeDTO> results = new List<EmployeeDTO>();
            EmployeeDTO oEmployeeDTO = new EmployeeDTO();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Employee/GetEmployeeList";

                    var json = JsonConvert.SerializeObject(oEmployeeDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        results = JsonConvert.DeserializeObject<List<EmployeeDTO>>(jsnString);
                    }
                }
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<DepartmentDTO> GetDepIdList()
        {
            List<DepartmentDTO> results = new List<DepartmentDTO>();
            DepartmentDTO oSubjectDTO = new DepartmentDTO();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Employee/GetDepIdList";

                    var json = JsonConvert.SerializeObject(oSubjectDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        results = JsonConvert.DeserializeObject<List<DepartmentDTO>>(jsnString);
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion WebAPI
    }    
}