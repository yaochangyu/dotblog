namespace DAL.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public partial class DalDbContext : DbContext
    {
        public DalDbContext()
            : base("name=DAL")
        {
        }

        public virtual DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.Account)
                .IsFixedLength();

            modelBuilder.Entity<Member>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}