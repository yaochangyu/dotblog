using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoMapper;
using Simple.ModelBindingSortAndPaging.Models;

namespace Simple.ModelBindingSortAndPaging
{
    public partial class NewAccountViewModel : System.Web.UI.Page
    {
        ThreeLayerDbContext _db = new ThreeLayerDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void InsertAccount(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var account = Mapper.Map<Account>(accountViewModel);

            this._db.Accounts.Add(account);
            try
            {
                this._db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            this.Server.Transfer("/WebForm1.aspx");

        }
    }
}