<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Simple.ObjectDataSourceSession.Views.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ObjectDataSource ID="Order_ObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetAllOrders"
                TypeName="Simple.ObjectDataSourceSession.Controls.OrderUseCase"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OrderItem_ObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
                TypeName="Simple.ObjectDataSourceSession.Controls.OrderUseCase" SelectMethod="GetAllOrderItems">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Order_GridView" DbType="Guid" Name="orderNo" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="Order_GridView" Name="SupplierName" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <asp:GridView ID="Order_GridView" runat="server" AutoGenerateColumns="False" DataSourceID="Order_ObjectDataSource">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" SortExpression="OrderNo" />
                    <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                    <asp:BoundField DataField="SupplierId" HeaderText="SupplierId" SortExpression="SupplierId" />
                    <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" SortExpression="SupplierName" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="OrderItem_GridView" runat="server" AutoGenerateColumns="False" DataSourceID="OrderItem_ObjectDataSource">
                <Columns>
                    <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" SortExpression="OrderNo" />
                    <asp:BoundField DataField="ProductId" HeaderText="ProductId" SortExpression="ProductId" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>