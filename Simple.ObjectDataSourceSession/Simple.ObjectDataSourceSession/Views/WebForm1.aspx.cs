using Simple.ObjectDataSourceSession.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.ObjectDataSourceSession.Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Order_GridView.DataKeyNames = new[] { "OrderNo", "SupplierId" };
            }
        }

        protected void Order_GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is GridView == false)
            {
                return;
            }
            var gridView = (GridView)sender;
            var selectGuid = gridView.SelectedValue;
            this.Session["SESSION_CURRENT_ORDER"] = selectGuid;
        }

        protected void Order_ObjectDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
        }
    }
}