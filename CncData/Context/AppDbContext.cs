using Microsoft.EntityFrameworkCore;
using CncData.Entities;

namespace CncData.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }  // اضافه شد
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // رابطه مشتری با سفارش‌ها
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // رابطه سفارش با جزئیات (یک به چند)
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // وقتی سفارش حذف شد، جزئیات هم حذف بشن

            // رابطه جزئیات با ورق
            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Sheet)
                .WithMany(s => s.OrderDetails) // اگر در Sheet هم بخوای ناوبری داشته باشی (اختیاری)
                .HasForeignKey(od => od.SheetId)
                .OnDelete(DeleteBehavior.Restrict);

            // روابط قبلی بدون تغییر
            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Receipts)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.BankAccount)
                .WithMany(b => b.Receipts)
                .HasForeignKey(r => r.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Sheet)
                .WithMany(s => s.Warehouse)
                .HasForeignKey(w => w.SheetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}