using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.ODS.MultiParameterPaging
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Location_DropDownList_DataBound(object sender, EventArgs e)
        {
            var ddl = (DropDownList)sender;
            var isExists = false;
            foreach (ListItem item in ddl.Items)
            {
                if (item.Value == "ALL")
                {
                    isExists = true;
                    break;
                }
            }
            if (!isExists)
            {
                ddl.Items.Insert(0, "ALL");
                ddl.Items[0].Value = "ALL";
                ddl.SelectedIndex = 0;
            }
        }

        protected void Employee_GridView_DataBound(object sender, EventArgs e)
        {
            var gv = (GridView)sender;
            if (gv.PageCount <= 0)
            {
                gv.PageIndex = 0;
            }
        }
    }
}