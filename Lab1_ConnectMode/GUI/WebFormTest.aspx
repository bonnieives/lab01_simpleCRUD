<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest.aspx.cs" Inherits="Lab1_ConnectMode.GUI.WebFormTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Button ID="ButtonConnectDatabase" runat="server" OnClick="ButtonConnectDatabase_Click" Text="Connect Database" />
        </div>
    </form>
</body>
</html>
