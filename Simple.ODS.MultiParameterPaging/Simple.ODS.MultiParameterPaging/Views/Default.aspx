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
                DataSourceID="Location_ObjectDataSource"
                OnDataBound="Location_DropDownList_DataBound">
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
                <UpdateParameters>
                    <asp:Parameter Name="Birthday" Type="DateTime" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="Birthday" Type="DateTime" />
                </InsertParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:GridView ID="Employee_GridView" runat="server" AutoGenerateColumns="False" DataSourceID="Employee_ObjectDataSource"
                ForeColor="#333333" CellPadding="4"
                AllowPaging="True"
                PageSize="3"
                AllowSorting="True"
                DataKeyNames="Id">

                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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

            <asp:DetailsView ID="DetailsView1" runat="server"
                Height="50px"
                Width="125px"
                AutoGenerateRows="False"
                DataSourceID="Employee_ObjectDataSource"
                DefaultMode="Insert">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" />
                    <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" ButtonType="Button" />
                </Fields>
            </asp:DetailsView>
            <br />
        </div>
    </form>
</body>
</html>