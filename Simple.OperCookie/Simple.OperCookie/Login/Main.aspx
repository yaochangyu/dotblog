<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Simple.OperCookie.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button3" runat="server" Text="Create Cookie" OnClick="CreateCookie_Click" />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Read cookie" OnClick="ReadCookie_Click" />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Delete Cookie" OnClick="DeleteCookie_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Redirect Sub.aspx" OnClick="Redirect_Click" />
        </div>
    </form>
</body>
</html>