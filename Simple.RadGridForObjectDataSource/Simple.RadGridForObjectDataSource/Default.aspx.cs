using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private string _filterExpression;

    protected void Master_ObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        var radGrid = this.Master_RadGrid;

        this._filterExpression = radGrid.MasterTableView.FilterExpression;
        e.InputParameters["filterExpressions"] = this._filterExpression;
    }
}