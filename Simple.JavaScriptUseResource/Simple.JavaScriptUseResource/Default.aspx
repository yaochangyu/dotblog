<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Simple.JavaScriptUseResource.Default" %>

<%@ Import Namespace="System.Globalization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="JavaScriptGlobalResourceHandler.ashx?ResourceKey=SystemConfig&UICulture=<%= CultureInfo.CurrentUICulture %>"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="English_Button" runat="server" Text="英文" OnClick="English_Button_Click" meta:resourceKey="English_Button" />
            <asp:Button ID="Chinese_Button" runat="server" Text="中文" OnClick="Chinese_Button_Click" meta:resourceKey="Chinese_Button" />
            <br />
            <br />

            <br />
            <asp:Button ID="Button1" runat="server" Text="<%$ Resources:SystemConfig,Love %>" OnClientClick="clicked();" />
            <br />

            <button type="button" onclick="alert(Resources.SystemConfig.Love)">
                <%= HttpContext.GetGlobalResourceObject("SystemConfig", "Love") %>1
            </button>
        </div>
    </form>
    <script type="text/javascript">
        function clicked(sender, args) {
            var msg = Resources.SystemConfig.Love;
            alert(msg);
        }
    </script>
</body>
</html>