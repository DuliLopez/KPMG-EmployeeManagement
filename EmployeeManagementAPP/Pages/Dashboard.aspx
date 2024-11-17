<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EmployeeManagementAPP.Pages.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management Dashboard</title>
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
            padding: 40px;
        }
        h1 {
            font-size: 28px;
            color: #343a40;
            text-align: center;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-2 sidebar">
                    <h2>Dashboard</h2>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="link-button" OnClick="LinkButtonEmployeeForm_Click1">Employee Form</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="link-button" OnClick="LinkButtonDepartmentForm_Click">Department Form</asp:LinkButton>
                </div>
                <div class="col-md-10 content">
                    <h1>Employee Management System</h1>
                    <p>Welcome to the Employee Management System dashboard. Use the navigation on the left to access forms and manage data.</p>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
