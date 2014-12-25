namespace Simple.Utility
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
            : base("name=NorthwindDbContext")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                   .Property(e => e.UnitPrice)
                   .HasPrecision(19, 4);
        }
    }
}
