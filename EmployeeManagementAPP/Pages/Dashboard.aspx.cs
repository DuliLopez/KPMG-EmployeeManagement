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
    public partial class Dashboard : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

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

        #endregion Events
    }
}