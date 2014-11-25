<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Simple.ObjectDataSourcePaging.Views.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
            OldValuesParameterFormatString="original_{0}"
            DataObjectTypeName="Simple.ObjectDataSourcePaging.Models.Employee"
            TypeName="Simple.ObjectDataSourcePaging.DataAccess.EmployeeDataAccess"
            InsertMethod="Insert"
            DeleteMethod="Delete"
            UpdateMethod="Update"
            SelectCountMethod="GetEmployeeCount"
            SelectMethod="GetEmployees"
            MaximumRowsParameterName="maximumRows"
            StartRowIndexParameterName="startRowIndex"
            SortParameterName="orderBy"
            EnablePaging="True">
            <UpdateParameters>
                <asp:Parameter Name="Birthday" Type="DateTime" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Birthday" Type="DateTime" />
            </InsertParameters>
        </asp:ObjectDataSource>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1"
                ForeColor="#333333" CellPadding="4"
                DataKeyNames="Id"
                AllowPaging="True"
                PageSize="3"
                AllowSorting="True">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="流水號" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="年齡" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="信箱" SortExpression="Email" />
                    <asp:BoundField DataField="Birthday" HeaderText="生日" SortExpression="Birthday" />
                </Columns>
                <%--<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />--%>
            </asp:GridView>
            <br />
            <asp:DetailsView ID="DetailsView1" runat="server"
                Height="50px"
                Width="125px"
                AutoGenerateRows="False"
                DataSourceID="ObjectDataSource1"
                DefaultMode="Insert">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" />
                    <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" ButtonType="Button" />
                </Fields>
            </asp:DetailsView>
            <br />
        </div>
    </form>
</body>
</html>