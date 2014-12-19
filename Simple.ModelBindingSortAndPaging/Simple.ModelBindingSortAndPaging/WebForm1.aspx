<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Simple.ModelBindingSortAndPaging.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
            AutoLoadForeignKeys="true" />--%>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            ShowModelStateErrors="true"
            HeaderText="List of validation errors"
            Font-Bold="True" ForeColor="#FF3300" />

        <asp:DynamicValidator runat="server" ID="DynamicValidator1"
            ControlToValidate="GridView1" Display="Static" />

        <asp:LinkButton Text="Add new record.." PostBackUrl="~/NewAccountViewModel.aspx" runat="server" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
            ItemType="Simple.ModelBindingSortAndPaging.Models.AccountViewModel"
            UpdateMethod="UpdateAccount"
            DeleteMethod="DeleteAccount"
            SelectMethod="GetAllAccounts"
            AllowSorting="True"
            AllowPaging="True"
            DataKeyNames="帳號"
            CellPadding="6"
            ForeColor="#333333"
            GridLines="None"
            PageSize="3">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                    <ControlStyle Width="75px" />
                </asp:CommandField>
                <asp:BoundField DataField="帳號" HeaderText="帳號" ReadOnly="True"
                    SortExpression="帳號"></asp:BoundField>

                <asp:DynamicField DataField="電話"></asp:DynamicField>
                <asp:DynamicField DataField="年齡"></asp:DynamicField>
                <asp:BoundField DataField="年齡"></asp:BoundField>
                <asp:TemplateField HeaderText="外號" SortExpression="外號">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" Text="<%# BindItem.外號 %>" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text="<%# Item.外號 %>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--      <asp:TemplateField HeaderText="年齡" SortExpression="年齡" ValidateRequestMode="Enabled">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# BindItem.年齡 %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Item.年齡 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>

                <asp:CommandField ShowDeleteButton="True" ButtonType="Button">
                    <ControlStyle Width="75px" />
                </asp:CommandField>
            </Columns>
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
        <br />
    </form>
</body>
</html>