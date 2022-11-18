using DLL.Entity1;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DLL.EF
{
    public partial class DBAquaparkContext : DbContext
    {
        public DBAquaparkContext()
            : base("name=Model1")
        {
            
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<bracelet> bracelet { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<operation> operation { get; set; }
        public virtual DbSet<recreation_area> recreation_area { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bracelet>()
                .HasMany(e => e.operation)
                .WithRequired(e => e.bracelet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.bracelet)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<recreation_area>()
                .HasMany(e => e.operation)
                .WithRequired(e => e.recreation_area)
                .WillCascadeOnDelete(false);
        }
    }
}
