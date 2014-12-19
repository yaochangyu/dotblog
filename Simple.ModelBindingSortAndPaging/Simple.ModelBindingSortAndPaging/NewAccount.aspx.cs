using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Simple.ModelBindingSortAndPaging.Models;

namespace Simple.ModelBindingSortAndPaging
{
    public partial class NewAccount : System.Web.UI.Page
    {
        private ThreeLayerDbContext _db = new ThreeLayerDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void InsertAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            this._db.Accounts.Add(account);

            this._db.SaveChanges();
            this.Server.Transfer("/WebForm2.aspx");
        }
    }
}