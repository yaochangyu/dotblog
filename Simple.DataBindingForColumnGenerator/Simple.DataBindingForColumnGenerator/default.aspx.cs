using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Simple.DataBindingForColumnGenerator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.ColumnsGenerator = new CustomColumnGenerator<Employee>();
            this.DetailsView1.RowsGenerator = new CustomColumnGenerator<Employee>();
        }
    }
}