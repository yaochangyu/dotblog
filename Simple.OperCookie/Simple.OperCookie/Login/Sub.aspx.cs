using System;

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