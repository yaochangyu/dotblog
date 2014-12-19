﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Simple.ModelBindingSortAndPaging.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%-- <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            ShowModelStateErrors="true"
            HeaderText="List of validation errors"
            Font-Bold="True" ForeColor="#FF3300" />

        <asp:DynamicValidator runat="server" ID="DynamicValidator1"
            ControlToValidate="GridView1" Display="Static" />--%>

        <div>

            <asp:LinkButton Text="Add new record.." PostBackUrl="~/NewAccount.aspx" runat="server" />
            <asp:GridView ID="GridView1" runat="server"
                SelectMethod="GetAllAccounts"
                UpdateMethod="UpdateAccount"
                DeleteMethod="DeleteAccount"
                AutoGenerateDeleteButton="true"
                AutoGenerateEditButton="true"
                AllowPaging="True"
                AllowSorting="True"
                DataKeyNames="UserId"
                AutoGenerateColumns="True"
                GridLines="None"
                ForeColor="#333333"
                CellPadding="6"
                PageSize="3">

                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Left" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>