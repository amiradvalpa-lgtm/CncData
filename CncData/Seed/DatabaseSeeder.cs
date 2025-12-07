using CncData.Context;
using CncData.Entities;
using Microsoft.EntityFrameworkCore;

namespace CncData.Seed
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { CustomerName = "آقای عباسی", Phone = "0914000000", Address = "باکری", Beginning_Balance = 50000 ,Description = ""},
                    new Customer { CustomerName = "آقای گلستان", Phone = "0912000000", Address = "فلکه بازارباش",Description = "" }
                );
            }

            if (!context.BankAccounts.Any())
            {
                context.BankAccounts.AddRange(
                    new BankAccount { Account_F_Name = "امیرحسین", Account_L_Name = "حسنخانی", BankName = "ملی", CardNumber = "6037 XXXX XXXX XXXX", ShebaNumber = "IRXXXXXXXXXXXX" },
                    new BankAccount { Account_F_Name = "رسول", Account_L_Name = "صحرانورد", BankName = "ملت", CardNumber = "6104 XXXX XXXX XXXX", ShebaNumber = "IRXXXXXXXXXXXX" }
                );
            }

            if (!context.Sheets.Any())
            {
                context.Sheets.AddRange(
                    new Sheet { Material = "ACM", Thickness = 4, Width = 125, Length = 320, SheetPrice = 50_000_000, PicesPrice = 1_500_000, CNCPrice = 85_000 },
                    new Sheet { Material = "MDF", Thickness = 8, Width = 122, Length = 244, SheetPrice = 13_000_000, PicesPrice = 4_500_000, CNCPrice = 75_000 }
                );
            }

            context.SaveChanges();

            // از اینجا به بعد فقط یک بار اجرا بشه (جلوگیری از duplicate)
            if (context.Orders.Any())
                return;

            // ─── سفارش اول ───
            var order1 = new Order
            {
                InvoiceNumber = "F1404-00125",
                CustomerId = 1,
                OrderDate = new DateTime(2025, 11, 15),
                DeliveryDate = new DateTime(2025, 11, 25),
                TransportCost = 350_000,
                MiscCost = 120_000,
                Description = "برش ۴ گوشه + شیار V برای مخزن تحت فشار", // توضیحات کلی سفارش (در Order نگه داشتم)
                OrderDetails = new List<OrderDetails>
                {
                    new OrderDetails
                    {
                        FilePath = @"C:\Orders\1404-00125.dxf",
                        SheetId = 2,                              // MDF
                        Supplier = SupplierType.Customer,         // از انبار خودمون
                        CutLength = 2800,
                        CutWidth = 1200,
                        FinalSheetCost = 2_850_000,
                        GrooveLength = 12.5,
                        CncCost = 980_000,
                        Description = "برش ۴ گوشه + شیار V" ,    // اگر بخوای جزئیات فنی رو اینجا هم بذاری (اختیاری)
                        DetailName = "order 2"
                    }
                }
            };

            // ─── سفارش دوم ───
            var order2 = new Order
            {
                InvoiceNumber = "F1404-00126",
                CustomerId = 2,
                OrderDate = new DateTime(2025, 11, 28),
                DeliveryDate = null, // هنوز تحویل نشده
                TransportCost = 1_200_000,
                MiscCost = 450_000,
                Description = "برش دایره‌ای برای فلنج + شیارهای عمیق 20mm",
                OrderDetails = new List<OrderDetails>
                {
                    new OrderDetails
                    {
                        FilePath = @"C:\Orders\1404-00126.dxf",
                        SheetId = 1, // یا SheetId = 1
                        Supplier = SupplierType.Warehouse,        // خرید از بیرون
                        CutLength = 5000,
                        CutWidth = 2000,
                        FinalSheetCost = 8_400_000,
                        GrooveLength = 28.0,
                        CncCost = 2_850_000,
                        Description = "برش دایره‌ای + شیار عمیق 20mm",
                        DetailName = "order 2"
                        
                    }
                }
            };

            context.Orders.AddRange(order1, order2);

            // رسیدها (به مشتری وصل می‌شن، نه به سفارش)
            var receipt1 = new Receipt
            {
                CustomerId = 1,
                Date = new DateTime(2025, 11, 20),
                Amount = 4_300_000,
                BankAccountId = 1
            };

            var receipt2 = new Receipt
            {
                CustomerId = 2,
                Date = new DateTime(2025, 11, 29),
                Amount = 5_000_000,
                BankAccountId = 1
            };

            context.Receipts.AddRange(receipt1, receipt2);

            context.SaveChanges();
        }
    }
}