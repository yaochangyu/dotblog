using Simple.BindingSourceEF.DAL.Model;
using System.Data.Entity;

namespace Simple.BindingSourceEF.DAL
{
    public class ThreeLayerDbContext : DbContext
    {
        public ThreeLayerDbContext()
            : base("localdb")
        {


        }

        public ThreeLayerDbContext(string connectString)
            : base(connectString)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountLog> AccountLogs { get; set; }


    }
}