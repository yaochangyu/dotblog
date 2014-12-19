<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAccountViewModel.aspx.cs" Inherits="Simple.ModelBindingSortAndPaging.NewAccountViewModel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="80px" Width="250px"
                ItemType="Simple.ModelBindingSortAndPaging.Models.AccountViewModel"
                DefaultMode="Insert"
                InsertMethod="InsertAccount"
                GridLines="None"
                CellPadding="6"
                AutoGenerateRows="False">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Fields>
                    <asp:DynamicField DataField="帳號" />
                    <asp:DynamicField DataField="密碼" />
                    <asp:DynamicField DataField="電話" />
                    <asp:DynamicField DataField="年齡" />
                    <asp:DynamicField DataField="外號" />
                    <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" ButtonType="Button" />
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>