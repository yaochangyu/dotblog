using AutoMapper;
using Simple.ModelBindingSortAndPaging.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Simple.ModelBindingSortAndPaging
{
    [DataObject]
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private ThreeLayerDbContext _db = new ThreeLayerDbContext();

        public IQueryable<AccountViewModel> GetAllAccounts()
        {
            var accounts = this._db.Accounts;
            var accountViewModels = Mapper.Map<IEnumerable<AccountViewModel>>(accounts);
            return accountViewModels.AsQueryable();
        }

        public void UpdateAccount(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            var account = Mapper.Map<Account>(accountViewModel);
            var query = this._db.Accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (query == null)
            {
                return;
            }

            query.Age = account.Age;
            query.NickName = account.NickName;
            query.Phone = account.Phone;

            this._db.SaveChanges();
        }

        public void DeleteAccount(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return;
            }
            var account = Mapper.Map<Account>(accountViewModel);
            var query = this._db.Accounts.FirstOrDefault(a => a.UserId == account.UserId);
            if (query == null)
            {
                return;
            }
            this._db.Accounts.Remove(query);
            this._db.SaveChanges();
        }

        public void InsertAccount(AccountViewModel accountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return;
            }

            var account = Mapper.Map<Account>(accountViewModel);
            account.Password = "11122";
            this._db.Accounts.Add(account);
            try
            {
                this._db.SaveChanges();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}