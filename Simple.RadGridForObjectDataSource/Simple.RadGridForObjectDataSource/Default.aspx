<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
            </Scripts>
        </telerik:RadScriptManager>
        <script type="text/javascript">
            //Put your JavaScript code here.
        </script>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <asp:ObjectDataSource ID="Master_ObjectDataSource" runat="server"
            DataObjectTypeName="Simple.RadGridForObjectDataSOurce.Employee"
            TypeName="Simple.RadGridForObjectDataSOurce.EmployeeDataSourceManager"
            SelectCountMethod="GetEmployeeCount"
            SelectMethod="GetEmployees"
            StartRowIndexParameterName="startRowIndex"
            MaximumRowsParameterName="maximumRows"
            SortParameterName="sortExpressions"
            OldValuesParameterFormatString="original_{0}"
            OnSelecting="Master_ObjectDataSource_Selecting"
            EnablePaging="True">
            <SelectParameters>
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
                <asp:Parameter Name="sortExpressions" Type="String" ConvertEmptyStringToNull="true" />
                <asp:Parameter Name="filterExpressions" Type="String" ConvertEmptyStringToNull="true" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <div>
            <telerik:RadGrid ID="Master_RadGrid" runat="server"
                DataSourceID="Master_ObjectDataSource"
                AllowFilteringByColumn="True"
                AllowPaging="True"
                AllowSorting="True">

                <MasterTableView CommandItemDisplay="None"
                    ClientDataKeyNames="Id"
                    AutoGenerateColumns="False"
                    AllowCustomPaging="true"
                    AllowCustomSorting="true"
                    ItemType="Simple.RadGridForObjectDataSOurce.Employee" DataSourceID="Master_ObjectDataSource">

                    <Columns>
                        <telerik:GridBoundColumn DataField="Id" DataType="System.Int32" FilterControlAltText="Filter Id column" HeaderText="Id" SortExpression="Id" UniqueName="Id">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Name" FilterControlAltText="Filter Name column" HeaderText="Name" SortExpression="Name" UniqueName="Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Age" DataType="System.Int32" FilterControlAltText="Filter Age column" HeaderText="Age" SortExpression="Age" UniqueName="Age">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Email" FilterControlAltText="Filter Email column" HeaderText="Email" SortExpression="Email" UniqueName="Email">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Location" FilterControlAltText="Filter Location column" HeaderText="Location" SortExpression="Location" UniqueName="Location">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Birthday" DataType="System.DateTime" FilterControlAltText="Filter Birthday column" HeaderText="Birthday" SortExpression="Birthday" UniqueName="Birthday">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <PagerStyle PageSizes="5,10"></PagerStyle>
                    <CommandItemSettings ShowRefreshButton="False"></CommandItemSettings>
                    <NoRecordsTemplate>找不到資料！！</NoRecordsTemplate>
                </MasterTableView>

                <ClientSettings EnableRowHoverStyle="true">
                </ClientSettings>
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>