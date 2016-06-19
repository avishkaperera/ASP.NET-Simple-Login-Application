<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DemoLoginApplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>
        Welcome <asp:LoginName ID="LoginName1" runat="server" />
    </h3>
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </div>
    </form>
</body>
</html>
