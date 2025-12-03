// CncData.SeedRunner/Program.cs
using CncData.Context;
using CncData.Seed;
using Microsoft.EntityFrameworkCore;
using System;

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlite("Data Source=CncData.db");

using var context = new AppDbContext(optionsBuilder.Options);

context.Database.Migrate();
DatabaseSeeder.Seed(context);

Console.WriteLine();
Console.WriteLine("==============================================");
Console.WriteLine("دیتابیس با موفقیت ساخته و پر شد");
Console.WriteLine($"فایل: {Path.GetFullPath("CncData.db")}");
Console.WriteLine("==============================================");
Console.WriteLine("هر کلیدی بزن تا بسته بشه...");
Console.ReadKey();