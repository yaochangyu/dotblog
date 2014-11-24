<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Simple.ObjectDataSourceBinding.Default" %>

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
                UpdateMethod="Update">

                <UpdateParameters>
                    <asp:Parameter Name="Birthday" Type="DateTime" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="Birthday" Type="DateTime" />
                </InsertParameters>
            </asp:ObjectDataSource>

            <br />
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                DataSourceID="ObjectDataSource1"
                DataKeyNames="Id">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" DataFormatString="{0:yyyy/MM/dd}" />
                </Columns>
            </asp:GridView>

            <br />
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" BorderStyle="None"
                CellSpacing="5" DataSourceID="ObjectDataSource1" DefaultMode="Insert" GridLines="None">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" />
                    <asp:CommandField ShowInsertButton="True" ShowCancelButton="False" ButtonType="Button" />
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>