<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeForm.aspx.cs" Inherits="EmployeeManagementAPP.Pages.EmployeeForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .sidebar {
            background-color: #343a40;
            color: white;
            height: 100vh;
            padding: 20px;
            position: fixed;
            width: 250px;
        }

        .sidebar h2 {
            text-align: center;
            margin-bottom: 30px;
        }

        .sidebar .link-button {
            display: block;
            width: 100%;
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px;
            margin: 10px 0;
            font-size: 18px;
            text-align: center;
            border-radius: 5px;
            text-decoration: none;
        }

        .sidebar .link-button:hover {
            background-color: #0056b3;
            color: #fff;
            text-decoration: none;
        }

        .content {
            margin-left: 220px;
            padding: 40px;
        }

        h1 {
            font-size: 28px;
            color: #343a40;
            text-align: center;
            margin-bottom: 20px;
        }

        .auto-style1 {
            width: 844px;
        }

        .auto-style2 {
            margin-left: 4px;
        }

        .auto-style3 {
            margin-left: 0px;
        }

        .auto-style4 {
            width: 707px;
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="sidebar">
            <h2>Dashboard</h2>
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="link-button" OnClick="LinkButtonEmployeeForm_Click1">Employee Form</asp:LinkButton>
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="link-button" OnClick="LinkButtonDepartmentForm_Click">Department Form</asp:LinkButton>
        </div>
        <div class="content">
            <center>          
                <div style="border-style: solid; border-color: inherit; border-width: medium; background-color: #E6EEF3; border-radius: 5px;" class="auto-style1">
                    <b>
                        <h1>
                            <center>Employee Form</center>
                        </h1>
                        <div class="auto-style4">
                            Employee ID &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;-:
                            <asp:TextBox ID="txtEmpId" placeholder="Enter Employee ID" runat="server" TextMode="Number" Style="font-size: 20px;" Width="427px" CssClass="auto-style3" />
                            <asp:RequiredFieldValidator 
                                ID="rfvEmpId" 
                                runat="server" 
                                ControlToValidate="txtEmpId" 
                                ErrorMessage="Please enter Employee ID." 
                                ForeColor="Red" 
                                Display="Dynamic"
                                ValidationGroup="EmployeeForm" />
                            <br /><br />
                            Employee Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;-:<asp:TextBox ID="txtName" placeholder="Enter Employee Name" runat="server" Style="font-size: 20px;" CssClass="auto-style2" Width="425px"/><br />
                            <asp:RequiredFieldValidator 
                                ID="rfvEmpName" 
                                runat="server" 
                                ControlToValidate="txtName" 
                                ErrorMessage="Please enter Employee Name." 
                                ForeColor="Red" 
                                Display="Dynamic"
                                ValidationGroup="EmployeeForm" />
                            <br />
                            Employee Address &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-:
                            <asp:TextBox ID="txtAddress" placeholder="Enter Employee Address" runat="server" Style="font-size: 20px;" Width="425px" /><br />
                            <asp:RequiredFieldValidator 
                                ID="rfvEmpAddress" 
                                runat="server" 
                                ControlToValidate="txtAddress" 
                                ErrorMessage="Please enter Employee Address." 
                                ForeColor="Red" 
                                Display="Dynamic"
                                ValidationGroup="EmployeeForm" />
                            <br />
                            Department &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;-:
                            <asp:DropDownList ID="ddlDepId" runat="server" style="font-size:20px;" Width="432px">
                                    <asp:ListItem Enabled="true" Text="Select Department" Value="-1"></asp:ListItem></asp:DropDownList>
                            <asp:RequiredFieldValidator 
                                ID="rfvDepId" 
                                runat="server" 
                                ControlToValidate="ddlDepId" 
                                InitialValue="-1" 
                                ErrorMessage="Please select Department." 
                                ForeColor="Red" 
                                Display="Dynamic"
                                ValidationGroup="EmployeeForm" />
                            <br /><br />
                            Employee Salary &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;-:
                            <asp:TextBox ID="txtSalary" placeholder="Enter Employee Salary" runat="server" Style="font-size: 20px;" Width="425px" />
                            <asp:RegularExpressionValidator
                                ID="regexSalaryValidator"
                                runat="server"
                                ControlToValidate="txtSalary"
                                ErrorMessage="Please enter a valid salary."
                                ValidationExpression="^\d+(\.\d{1,2})?$"
                                ForeColor="Red"
                                Display="Dynamic" />
                            <asp:RequiredFieldValidator 
                                ID="rfvEmpSalary" 
                                runat="server" 
                                ControlToValidate="txtSalary" 
                                ErrorMessage="Please enter Employee Salary." 
                                ForeColor="Red" 
                                Display="Dynamic"
                                ValidationGroup="EmployeeForm" />
                            <br />
                            <br />
                            <asp:Button Text="ADD" ValidationGroup="EmployeeForm" Style="margin-left: 50px; font-size: 15px; height: 35px; width: 100px; border-radius: 5px; background-color: black; color: white" runat="server" OnClick="btnAdd_Click" ID="btnAdd" />
                            <asp:Button Text="UPDATE" ValidationGroup="EmployeeForm" runat="server" Style="margin-left: 50px; font-size: 15px; border-radius: 5px; height: 35px; width: 100px; background-color: black; color: white" ID="btnUpdate" OnClick="btnUpdate_Click" />
                            <asp:Button Text="DELETE" runat="server" Style="margin-left: 50px; font-size: 15px; border-radius: 5px; height: 35px; width: 100px; background-color: black; color: white" ID="btnDelete" OnClick="btnDelete_Click" />
                            <asp:Button Text="CLEAR" runat="server" Style="margin-left: 50px; font-size: 15px; border-radius: 5px; height: 35px; width: 100px; background-color: black; color: white" ID="btnCLear" OnClick="btnClear_Click" /><br />
                            <br />
                        </div>
                    </b>         
                </div>        
                <br />
                <br />
                <div>
                    <asp:GridView ID="gvEmployeeDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" Height="180px" Width="100%" OnRowCommand="gvEmployeeDetails_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Employee ID" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblgvEmpId" runat="server" Text='<%# Eval("emp_id") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblgvEmpName" runat="server" Text='<%# Eval("emp_name") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Address" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblgvEmpAddress" runat="server" Text='<%# Eval("emp_address") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" Visible="false" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblgvDepId" runat="server" Text='<%# Eval("dep_id") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblgvDepName" runat="server" Text='<%# Eval("dep_name") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Employee Salary" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblgvEmpSalary" runat="server" Text='<%# Eval("emp_salary", "{0:F2}") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Button ID="btnSelectedRow" runat="server" CommandName="SelectRecord" CommandArgument="<%# Container.DisplayIndex %>" CssClass="btn btn-success" Text="View" ValidationGroup="None" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" />
                            </asp:TemplateField>
                        </Columns>
                     </asp:GridView>
                </div>                
            </center>
            <asp:LinkButton ID="LinkButtonDashboard" runat="server" OnClick="LinkButtonDashboard_Click">Back to DashBoard</asp:LinkButton><br />
        </div>
    </form>
</body>
</html>
