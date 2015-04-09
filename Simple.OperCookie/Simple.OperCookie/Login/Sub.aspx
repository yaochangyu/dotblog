<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sub.aspx.cs" Inherits="Simple.OperCookie.Sub" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Text="Read Cookie" OnClick="ReadCookie_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Redirect main.aspx" OnClick="Redirect_Click" />
        </div>
    </form>
</body>
</html>