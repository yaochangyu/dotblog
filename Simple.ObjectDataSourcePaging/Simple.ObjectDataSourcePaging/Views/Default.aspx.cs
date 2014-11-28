using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.ObjectDataSourcePaging.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            var gv = (GridView)sender;
            if (gv.PageCount <= 0)
            {
                this.Response.Cookies.Add(new HttpCookie("COOKIE_GridView_CURRENT_INDEX")
                {
                    Value = gv.PageIndex.ToString()
                });
                //gv.PageIndex = gv.PageIndex - 1;
                //gv.Sort("Id", SortDirection.Ascending);
                gv.PageIndex = 0;
            }
            //else
            //{
            //    var cookie = this.Response.Cookies["COOKIE_GridView_CURRENT_INDEX"];
            //    if (cookie != null && !string.IsNullOrWhiteSpace(cookie.Value))
            //    {
            //        var httpCookie = this.Response.Cookies["COOKIE_GridView_CURRENT_INDEX"];
            //        if (httpCookie != null)
            //            gv.PageIndex = int.Parse(httpCookie.Value);
            //        cookie.Value = null;
            //        Response.Cookies.Remove("COOKIE_GridView_CURRENT_INDEX");
            //    }
            //}
        }
    }
}