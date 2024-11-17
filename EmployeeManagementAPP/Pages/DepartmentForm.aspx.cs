using Newtonsoft.Json;
using EmployeeManagementAPP.Common;
using EmployeeManagementAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeManagementAPP.Pages
{
    public partial class DepartmentForm : System.Web.UI.Page
    {
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartmentGrid();
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
            DepartmentDTO oDepDTO = new DepartmentDTO();
            oDepDTO.dep_id = Convert.ToInt32(txtDepId.Text);
            oDepDTO.dep_name = txtDepName.Text;
            oDepDTO.location = txtLocation.Text;

            bool isInserted = InsertDepData(oDepDTO);
            LoadDepartmentGrid();
            ClearFields();
        }
        protected void gvDepDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectRecord")
            {
                ViewState["index"] = e.CommandArgument.ToString();
                GridViewRow row = gvDepDetails.Rows[(Convert.ToInt32(ViewState["index"]))];
                Label DepId = (Label)row.FindControl("lblgvDepId");
                Label DepName = (Label)row.FindControl("lblgvDepName");
                Label Location = (Label)row.FindControl("lblgvLocation");

                txtDepId.Enabled = false;

                DepartmentDTO oDepDTO = new DepartmentDTO();
                oDepDTO.dep_id = Convert.ToInt32(DepId.Text);
                oDepDTO.dep_name = DepName.Text;
                oDepDTO.location = Location.Text;
                SetGridValues(oDepDTO);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DepartmentDTO oDepDTO = new DepartmentDTO();
            oDepDTO.dep_id = Convert.ToInt32(txtDepId.Text);
            oDepDTO.dep_name = txtDepName.Text;
            oDepDTO.location = txtLocation.Text;

            bool isUpdated = UpdateDepData(oDepDTO);
            LoadDepartmentGrid();
            ClearFields();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool isDeleted = DeleteDepartment(Convert.ToInt32(txtDepId.Text));
            LoadDepartmentGrid();
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

        #endregion Event

        #region Methods
        private bool InsertDepData(DepartmentDTO oDepDTO)
        {
            bool result = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Department/CreateNewDep";
                    var json = JsonConvert.SerializeObject(oDepDTO);
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

        private void LoadDepartmentGrid()
        {
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            list = GetAllDepartments();
            gvDepDetails.DataSource = list;
            gvDepDetails.DataBind();
        }
        private void SetGridValues(DepartmentDTO oDepDTO)
        {
            txtDepId.Text = oDepDTO.dep_id.ToString();
            txtDepName.Text = oDepDTO.dep_name;
            txtLocation.Text = oDepDTO.location;
        }
        private bool UpdateDepData(DepartmentDTO oGradeDTO)
        {
            bool result = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Department/UpdateDepartment";
                    var json = JsonConvert.SerializeObject(oGradeDTO);
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
        private bool DeleteDepartment(int dep_id)
        {
            bool result = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Department/DeleteDepartment?dep_id=" + dep_id;
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

        public void ClearFields()
        {
            txtDepId.Enabled = true;
            txtDepId.Text = "";
            txtDepName.Text = "";
            txtLocation.Text = "";
        }
        #endregion Methods

        #region WEBAPI

        private List<DepartmentDTO> GetAllDepartments()
        {
            List<DepartmentDTO> depList = new List<DepartmentDTO>();
            DepartmentDTO oDepDTO = new DepartmentDTO();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalData.BaseUri);
                    string path = GlobalData.BaseUri + "Department/GetAllDepartments";

                    var json = JsonConvert.SerializeObject(oDepDTO);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        String jsnString = response.Content.ReadAsStringAsync().Result;
                        depList = JsonConvert.DeserializeObject<List<DepartmentDTO>>(jsnString);
                    }
                }
                return depList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion WEBAPI
    }
}