using System.Data.Entity;

namespace Simple.ModelBindingSortAndPaging.Models
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