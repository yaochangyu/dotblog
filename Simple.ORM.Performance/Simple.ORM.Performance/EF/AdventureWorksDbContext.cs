namespace Simple.ORM.Performance
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext()
            : base("name=AdventureWorksDW2012DbContext")
        {
        }

        public virtual DbSet<FactProductInventory> FactProductInventories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FactProductInventory>()
                .Property(e => e.UnitCost)
                .HasPrecision(19, 4);
        }
    }
}
