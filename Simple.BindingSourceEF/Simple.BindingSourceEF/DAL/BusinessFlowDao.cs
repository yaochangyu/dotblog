using Simple.BindingSourceEF.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Simple.BindingSourceEF.DAL
{
    public class BusinessFlowDao : IBusinessFlowDao
    {
        private ThreeLayerDbContext _db = null;

        public BusinessFlowDao()
        {
            Database.SetInitializer(new DbInitializer());

            if (this._db == null)
            {
                this._db = new ThreeLayerDbContext();
                //this._db.Database.Initialize(true);
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return this._db.Accounts.ToList();
        }

        public IEnumerable<AccountLog> GetAllAccountLogs(Guid id)
        {
            var queryLogs = this._db.AccountLogs.Where(l => l.CurrentAccount.Id == id).ToList();
            return queryLogs;
        }

        public int Commit()
        {
            return this._db.SaveChanges();
        }

        public Account InsertAccount(Account account)
        {
            return this._db.Accounts.Add(account);
        }

        public Account DeleteAccount(Account account)
        {
            var queryAccount = this._db.Accounts.FirstOrDefault(a => a.Id == account.Id);
            if (queryAccount == null)
            {
                return null;
            }
            return this._db.Accounts.Remove(queryAccount);
        }

        public AccountLog InsertAccountLog(Account account, AccountLog accountLog)
        {
            accountLog.CurrentAccount = account;
            return this._db.AccountLogs.Add(accountLog);
        }

        public bool IsValid(string userId, string password)
        {
            throw new NotImplementedException();
        }

        public AccountLog DeleteAccountLog(AccountLog accountLog)
        {
            var queryAccountLog = this._db.AccountLogs.FirstOrDefault(a => a.Id == accountLog.Id);
            if (queryAccountLog == null)
            {
                return null;
            }
            return this._db.AccountLogs.Remove(queryAccountLog);
        }
    }
}