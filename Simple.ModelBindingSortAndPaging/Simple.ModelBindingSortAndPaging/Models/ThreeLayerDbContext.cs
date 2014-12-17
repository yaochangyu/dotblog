using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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