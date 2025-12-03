// Program.cs   ← فقط برای توسعه‌دهنده (کاربر نهایی اینو نمی‌بینه)
using CncData.Context;
using CncData.Seed;
using Microsoft.EntityFrameworkCore;

namespace CncData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=CncData.db");

            using var context = new AppDbContext(optionsBuilder.Options);

            // این دو خط مهم هستن
            context.Database.Migrate();           // میگریشن‌ها اعمال میشن
            DatabaseSeeder.Seed(context);         // ← دیتای نمونه وارد میشه

            Console.WriteLine("دیتابیس با موفقیت ساخته شد و دیتای اولیه وارد شد.");
            Console.WriteLine("فایل CncData.db آماده است — می‌تونی کپی کنی کنار برنامه اصلی");
            Console.ReadKey();
        }
    }
}