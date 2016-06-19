<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DemoLoginApplication.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">

                <div class="row" style="margin-top:100px;">

                    <div class="col-md-4"></div>                    

                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Username</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required" ForeColor="Red" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label>Confirm Password</label>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password do not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:CompareValidator>
                        </div>

                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email Required" ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email" Display="Dynamic" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </div>

                        <asp:Button ID="Button1" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="RegisterUser"/>
                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="col-md-4"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
