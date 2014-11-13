<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Simple.ObjectDataSourceBinding.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                TypeName="Simple.ObjectDataSourceBinding.EmployeeDataAccess"
                DataObjectTypeName="Simple.ObjectDataSourceBinding.Employee"
                OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetEmployees"
                DeleteMethod="Delete"
                InsertMethod="Insert"
                UpdateMethod="Update"></asp:ObjectDataSource>

            <br />
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="True"
                DataSourceID="ObjectDataSource1"
                DataKeyNames="Id,Name,Age,Email">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BorderStyle="None"
                CellSpacing="5" DataSourceID="ObjectDataSource1" DefaultMode="Insert" GridLines="None">
                <Fields>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:CommandField ButtonType="Button" ShowInsertButton="True" ShowCancelButton="False" />
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>