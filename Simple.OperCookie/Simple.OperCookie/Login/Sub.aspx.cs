using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.OperCookie
{
    public partial class Sub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ReadCookie_Click(object sender, EventArgs e)
        {
            Core.ReadCookie();
        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Login/Main.aspx");
        }
    }
}