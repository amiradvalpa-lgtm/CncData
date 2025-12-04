// مسیر: Data/AppDbContext.cs
using System.Data.Entity;
using CncApp_Final.Entities;

namespace CncApp_Final.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public AppDbContext() : base("name=CncConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // روابط Order
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetails>()
                .HasRequired(o => o.Sheet)
                .WithMany(s => s.OrderDetails)
                .HasForeignKey(o => o.SheetId)
                .WillCascadeOnDelete(false);

            // روابط Receipt
            modelBuilder.Entity<Receipt>()
                .HasRequired(r => r.Customer)
                .WithMany(c => c.Receipts)
                .HasForeignKey(r => r.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receipt>()
                .HasRequired(r => r.BankAccount)
                .WithMany(b => b.Receipts)
                .HasForeignKey(r => r.BankAccountId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasRequired(r => r.Sheet)
                .WithMany(b => b.Warehouse)
                .HasForeignKey(r => r.SheetId)
                .WillCascadeOnDelete(false);

            // اگر SupplierType enum داری (مثلازم نیست چیزی بزنی، خودش int میشه)

            base.OnModelCreating(modelBuilder);




        }
    }
}