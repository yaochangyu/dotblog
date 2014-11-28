<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Simple.ODS.MultiParameterPaging.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ObjectDataSource ID="Location_ObjectDataSource" runat="server"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetLocations"
            TypeName="Simple.ODS.MultiParameterPaging.EmployeeDataAccess"></asp:ObjectDataSource>
        <div>

            <asp:Label ID="Label1" runat="server" Text="位置"></asp:Label>
            <asp:DropDownList ID="Location_DropDownList" runat="server" AutoPostBack="True"
                DataSourceID="Location_ObjectDataSource">
            </asp:DropDownList>
            &nbsp;

            <br />
            <asp:ObjectDataSource ID="Employee_ObjectDataSource" runat="server"
                OldValuesParameterFormatString="original_{0}"
                DataObjectTypeName="Simple.ODS.MultiParameterPaging.Employee"
                TypeName="Simple.ODS.MultiParameterPaging.EmployeeDataAccess"
                InsertMethod="Insert"
                DeleteMethod="Delete"
                UpdateMethod="Update"
                SelectCountMethod="GetEmployeeCount"
                SelectMethod="GetEmployees"
                SortParameterName="orderBy"
                EnablePaging="True">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Location_DropDownList" Name="location" Type="String" />
                    <asp:Parameter Name="maximumRows" Type="Int32" />
                    <asp:Parameter Name="startRowIndex" Type="Int32" />
                    <asp:Parameter Name="orderBy" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:GridView ID="Employee_GridView" runat="server" AutoGenerateColumns="False" DataSourceID="Employee_ObjectDataSource"
                ForeColor="#333333" CellPadding="4"
                AllowPaging="True"
                PageSize="3"
                AllowSorting="True">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" />
                </Columns>
                <%--<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />--%>
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>