<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentForm.aspx.cs" Inherits="EmployeeManagementAPP.Pages.DepartmentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            margin-left: 2px;
            width: 425px;
        }

        .auto-style3 {
            margin-left: 0px;
        }

        .auto-style4 {
            width: 679px;
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
        <div style="border-style: solid; border-color: inherit; border-width: medium; background-color: #E6EEF3; border-radius: 5px" class="auto-style1">
            <b>
                <h1>
                    <center>Department Form</center>
                </h1>
                <br />
                <div class="auto-style4">
                    Department ID &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;-:
                    <asp:TextBox ID="txtDepId" placeholder="Enter Department ID" runat="server" TextMode="Number" Style="font-size: 20px; width: 417px" CssClass="auto-style3"></asp:TextBox><br />
                    <br />
                    Department Name &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;-:
                    <asp:TextBox ID="txtDepName" placeholder="Enter the Department Name" runat="server" Style="font-size: 20px; width: 417px" CssClass="auto-style2"></asp:TextBox><br />
                    <br />
                    Location &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-:
                    <asp:TextBox ID="txtLocation" placeholder="Enter the Location" runat="server" Style="font-size: 20px; width: 417px"></asp:TextBox><br />
                    <br />

                    <asp:Button Text="ADD" Style="margin-left: 50px; font-size: 15px; height: 35px; width: 100px; border-radius: 5px; background-color: black; color: white" runat="server" OnClick="btnAdd_Click" ID="btnAdd" />
                    <asp:Button Text="UPDATE" runat="server" Style="margin-left: 50px; font-size: 15px; border-radius: 5px; height: 35px; width: 100px; background-color: black; color: white" ID="btnUpdate" OnClick="btnUpdate_Click" />
                    <asp:Button Text="DELETE" runat="server" Style="margin-left: 50px; font-size: 15px; border-radius: 5px; height: 35px; width: 100px; background-color: black; color: white" ID="btnDelete" OnClick="btnDelete_Click" />
                    <asp:Button Text="CLEAR" runat="server" Style="margin-left: 50px; font-size: 15px; border-radius: 5px; height: 35px; width: 100px; background-color: black; color: white" ID="btnCLear" OnClick="btnClear_Click" /><br />
                    <br />
                    <br />
                </div>
            </b>
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="gvDepDetails" AutoGenerateColumns="false" OnRowCommand="gvDepDetails_RowCommand" CssClass="table table-bordered table-hover" Height="184px" Width="100%" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Department ID" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblgvDepId" runat="server" Text='<%# Eval("dep_id") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Department Name" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblgvDepName" runat="server" Text='<%# Eval("dep_name") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Location" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblgvLocation" runat="server" Text='<%# Eval("location") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px" Font-Bold="true" />
                        <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" HeaderStyle-BackColor="#AAB3BA" HeaderStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Button ID="btnSelectedRow" runat="server" CommandName="SelectRecord" CommandArgument="<%# Container.DisplayIndex %>" CssClass="btn btn-success" Text="View" Style="margin-left: 10px" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
            </center>
        <asp:LinkButton ID="LinkButtonDashboard" runat="server" OnClick="LinkButtonDashboard_Click">Back to DashBoard</asp:LinkButton><br />
    </form>
</body>
</html>
