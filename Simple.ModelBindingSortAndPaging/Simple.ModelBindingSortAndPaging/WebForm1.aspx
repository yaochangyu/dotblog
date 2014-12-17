﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Simple.ModelBindingSortAndPaging.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
            <asp:GridView ID="GridView1" runat="server"
                AllowPaging="True" AllowSorting="True"
                SelectMethod="GetAllAccounts"
                UpdateMethod="UpdateAccount"
                DeleteMethod="DeleteAccount"
                ItemType="Simple.ModelBindingSortAndPaging.Models.AccountViewModel"
                PageSize="2"
                AutoGenerateEditButton="true"
                AutoGenerateDeleteButton="true"
                AutoGenerateColumns="false"
                DataKeyNames="帳號">
                <Columns>
                    <asp:DynamicField DataField="帳號" />
                    <asp:DynamicField DataField="年齡" />
                    <asp:DynamicField DataField="電話" />
                    <asp:DynamicField DataField="外號" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="NickName" HeaderText="NickName" SortExpression="NickName" />
                    <asp:DynamicField DataField="Age" />
                    <asp:DynamicField DataField="Phone" />
                    <asp:DynamicField DataField="Password" />--%>
                    <%--<asp:TemplateField HeaderText="Total Credits">
                        <ItemTemplate>
                            <asp:Label ID="Label1" Text="<%# Item. %>" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px"
                ItemType="Simple.ModelBindingSortAndPaging.Models.AccountViewModel"
                DefaultMode="Insert"
                InsertMethod="InsertAccount"
                GridLines="None"
                AutoGenerateRows="True">
                <Fields>
                    <%-- <asp:BoundField DataField="帳號" HeaderText="帳號" SortExpression="帳號" />
                    <asp:BoundField DataField="年齡" HeaderText="年齡" SortExpression="年齡" />
                    <asp:BoundField DataField="電話" HeaderText="電話" SortExpression="電話" />
                    <asp:BoundField DataField="外號" HeaderText="外號" SortExpression="外號" />--%>
                    <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" ButtonType="Button" />
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>