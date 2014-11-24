using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.ObjectDataSourceBinding
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ObjectDataSource1.InsertParameters.Add(new Parameter("Birthday", TypeCode.DateTime));
            this.ObjectDataSource1.UpdateParameters.Add(new Parameter("Birthday", TypeCode.DateTime));
        }
    }
}