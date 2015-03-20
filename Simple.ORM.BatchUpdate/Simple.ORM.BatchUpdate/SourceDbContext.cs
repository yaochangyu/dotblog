namespace Simple.ORM.BatchUpdate
{
    using System.Data.Entity;

    public partial class SourceDbContext : DbContext
    {
        public SourceDbContext()
            : base("name=SourceDbContext")
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