using Simple.ModelBindingSortAndPaging.Models;
using System;
using System.Linq;

namespace Simple.ModelBindingSortAndPaging
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private ThreeLayerDbContext _db = null;

        public WebForm2()
        {
            if (this._db == null)
            {
                _db = new ThreeLayerDbContext();
            }
        }
        public IQueryable<Account> GetAllAccounts()
        {
            var accounts = this._db.Accounts;
            return accounts;
        }

        public void UpdateAccount(Account account)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            var query = this._db.Accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (query == null)
            {
                return;
            }
            this._db.Entry(query).CurrentValues.SetValues(account);
            this._db.SaveChanges();
        }

        public void DeleteAccount(string userId)
        {
            var query = this._db.Accounts.FirstOrDefault(a => a.UserId == userId);
            if (query == null)
            {
                return;
            }
            this._db.Accounts.Remove(query);
            this._db.SaveChanges();
        }


    }
}