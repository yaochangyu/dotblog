using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.JavaScriptUseResource
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void English_Button_Click(object sender, EventArgs e)
        {
            Utility.WriteLanguage("en-US");
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void Chinese_Button_Click(object sender, EventArgs e)
        {
            Utility.WriteLanguage("zh-TW");
            this.Response.Redirect(this.Request.RawUrl);
        }
    }
}