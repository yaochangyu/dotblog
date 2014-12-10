using Simple.BindingSourceEF.DAL.Model;
using System;
using System.Collections.Generic;

namespace Simple.BindingSourceEF.DAL
{
    public interface IBusinessFlowDao
    {
        IEnumerable<Account> GetAllAccounts();

        IEnumerable<AccountLog> GetAllAccountLogs(Guid id);

        int Commit();

        Account InsertAccount(Account account);

        AccountLog InsertAccountLog(Account account, AccountLog accountLog);

        Account DeleteAccount(Account account);

        AccountLog DeleteAccountLog(AccountLog accountLog);

        bool IsValid(string userId, string password);
    }
}