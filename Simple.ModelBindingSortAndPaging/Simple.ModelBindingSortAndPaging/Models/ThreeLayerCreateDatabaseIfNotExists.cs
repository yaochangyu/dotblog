using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Simple.ModelBindingSortAndPaging.Models
{
    public class ThreeLayerCreateDatabaseIfNotExists : CreateDatabaseIfNotExists<ThreeLayerDbContext>
    {
        protected override void Seed(ThreeLayerDbContext context)
        {
            base.Seed(context);
            Account account1 = new Account() { UserId = "yao1", Age = 19, Phone = "8825251", NickName = "小狗1", Password = "1234" };
            Account account2 = new Account() { UserId = "yao2", Age = 26, Phone = "8825252", NickName = "小狗2", Password = RandomPassword() };
            Account account3 = new Account() { UserId = "yao3", Age = 16, Phone = "8825253", NickName = "小狗3", Password = RandomPassword() };
            Account account4 = new Account() { UserId = "yao4", Age = 33, Phone = "8825254", NickName = "小狗4", Password = RandomPassword() };
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