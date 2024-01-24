<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab1_ConnectMode.GUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Maintenance</title>
    <style type="text/css">
        .auto-style1 {
            width: 38%;
        }
        .auto-style5 {
            width: 263px;
            text-align: center;
        }
        .auto-style9 {
            
        }
        .auto-style10 {
            width: 52px;
        }
        .auto-style11 {
            height: 31px;
            width: 52px;
            text-align: center;
        }
        .auto-style12 {
            height: 29px;
            width: 52px;
            text-align: center;
        }
        .auto-style14 {
            width: 200px;
        }
        .auto-style15 {
            height: 31px;
            width: 200px;
            text-align: right;
        }
        .auto-style16 {
            height: 29px;
            width: 200px;
            text-align: right;
        }
        .auto-style18 {
            width: 246px;
        }
        .auto-style19 {
            height: 31px;
            width: 246px;
        }
        .auto-style20 {
            height: 29px;
            width: 246px;
        }
        .auto-style23 {
            width: 52px;
            height: 38px;
            text-align: center;
        }
        .auto-style24 {
            width: 200px;
            height: 38px;
            text-align: right;
        }
        .auto-style25 {
            width: 246px;
            height: 38px;
        }
        .auto-style26 {
            width: 87px;
            height: 38px;
        }
        .auto-style27 {
            height: 31px;
            width: 87px;
        }
        .auto-style28 {
            height: 29px;
            width: 87px;
        }
        .auto-style30 {
            width: 87px;
        }
        .auto-style32 {
            width: 52px;
            height: 39px;
        }
        .auto-style33 {
            width: 200px;
            height: 39px;
            text-align: right;
        }
        .auto-style34 {
            width: 246px;
            height: 39px;
        }
        .auto-style35 {
            width: 87px;
            height: 39px;
        }
        .auto-style36 {
            width: 263px;
            text-align: center;
            height: 57px;
        }
        .auto-style37 {
            width: 52px;
            height: 57px;
            text-align: center;
        }
        .auto-style40 {
            width: 87px;
            height: 57px;
            text-align: center;
        }
        .auto-style41 {
            margin-left: 0px;
        }
        .auto-style42 {
            height: 38px;
            text-align: center;
            font-weight: bolder;
            font-size: 40px;
            color: saddlebrown;
        }
        .auto-style43 {
            text-align: left;
            color: #0066FF;
        }
        .auto-style44 {
            width: 246px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style9">
            <table class="auto-style1">
            <tr>
                <td class="auto-style42" colspan="3">Employee Maintenance</td>
                <td class="auto-style25">
                    &nbsp;</td>
                <td class="auto-style26">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style24">Employee ID:</td>
                <td class="auto-style23">
                    <asp:TextBox ID="idTextBox" runat="server" Width="286px"></asp:TextBox>
                </td>
                <td class="auto-style24">
                    <asp:Button ID="ButtonSaveEmployee" runat="server" OnClick="ButtonSaveEmployee_Click" Text="Save" CssClass="auto-style41" Height="50px" Width="134px" />
                </td>
                <td class="auto-style25">
                </td>
                <td class="auto-style26">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">First Name: </td>
                <td class="auto-style11">
                    <asp:TextBox ID="firstNameTextBox" runat="server" Width="288px"></asp:TextBox>
                </td>
                <td class="auto-style15">
                    <asp:Button ID="updateButton" runat="server" Text="Update" Height="50px" Width="135px" />
                </td>
                <td class="auto-style19">
                </td>
                <td class="auto-style27">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">Last Name:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="lastNameTextBox" runat="server" Width="290px"></asp:TextBox>
                </td>
                <td class="auto-style16">
                    <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click" Height="50px" Width="135px" />
                </td>
                <td class="auto-style20">
                    &nbsp;</td>
                <td class="auto-style28">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style33">Job Title:</td>
                <td class="auto-style32">
                    <asp:TextBox ID="jobDescriptionTextBox" runat="server" Width="288px"></asp:TextBox>
                </td>
                <td class="auto-style33">
                    <asp:Button ID="listAllButton" runat="server" Text="List All" OnClick="listAllButton_Click" Height="50px" Width="135px" />
                </td>
                <td class="auto-style34">
                    &nbsp;</td>
                <td class="auto-style35"></td>
            </tr>
            <tr>
                <td class="auto-style36">
                    &nbsp;</td>
                <td class="auto-style37">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create DB" />
                </td>
                <td class="auto-style40">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style18">
                    &nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    Search by:</td>
                <td class="auto-style10">
                    <asp:DropDownList ID="DropDownList" runat="server" Width="291px">
                        <asp:ListItem Value="EmployeeId">Employee ID</asp:ListItem>
                        <asp:ListItem Value="FirstName">First Name</asp:ListItem>
                        <asp:ListItem Value="LastName">Last Name</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style14">
                    <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style44">
                    <asp:Button ID="searchButtonFirstName" runat="server" OnClick="searchButton_Click" Text="Search" Height="50px" Width="135px" />
                </td>
                <td class="auto-style30">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style43" colspan="4">
                    <strong>Employees List</strong></td>
                <td class="auto-style30">&nbsp;</td>
            </tr>
        </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="652px">
        </asp:GridView>
    </form>
</body>
</html>
