using Simple.BindingSourceEF.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Simple.BindingSourceEF.DAL
{
    public class ThreeLayerDropCreateDatabaseAlways : DropCreateDatabaseAlways<ThreeLayerDbContext>
    {
        public override void InitializeDatabase(ThreeLayerDbContext context)
        {
            //base.InitializeDatabase(context);
            Account account1 = new Account() { UserId = "yao1", Password = "1234" };
            Account account2 = new Account() { UserId = "yao2", Password = RandomPassword() };
            Account account3 = new Account() { UserId = "yao3", Password = RandomPassword() };
            Account account4 = new Account() { UserId = "yao4", Password = RandomPassword() };

            context.Accounts.Add(account1);
            context.Accounts.Add(account2);
            context.Accounts.Add(account3);
            context.Accounts.Add(account4);

            context.AccountLogs.AddRange(RandomAccountLog(account1, 6));
            context.AccountLogs.AddRange(RandomAccountLog(account2, 5));
            context.AccountLogs.AddRange(RandomAccountLog(account3, 2));
            context.AccountLogs.AddRange(RandomAccountLog(account4, 4));
            context.SaveChanges();
        }

        private IEnumerable<AccountLog> RandomAccountLog(Account account, int counter)
        {
            List<AccountLog> accountLogs = new List<AccountLog>();
            for (int i = 0; i < counter; i++)
            {
                AccountLog log = new AccountLog() { CurrentAccount = account, LastLoginTime = RandomDay() };
                accountLogs.Add(log);
            }
            return accountLogs;
        }

        private string RandomPassword()
        {
            return Guid.NewGuid().ToString("d").Substring(1, 8);
        }

        private DateTime RandomDay()
        {
            DateTime startTime = new DateTime(1995, 1, 1);
            DateTime resulTime;
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int day = (DateTime.Today - startTime).Days;
            resulTime = startTime.AddDays(random.Next(day));
            //resulTime = startTime.AddMinutes(random.Next());
            resulTime = resulTime.AddMilliseconds(random.Next());
            return resulTime;
            ;
        }
    }
}