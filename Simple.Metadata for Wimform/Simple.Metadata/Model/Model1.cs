namespace Simple.Metadata.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.UserId)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
