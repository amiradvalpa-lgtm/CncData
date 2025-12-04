using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace CncApp_Final.Entities
{
    public class Order
    {
        [DisplayName("شناسه سفارش")]
        [Description("شناسه یکتا سفارش")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شماره فاکتور")]
        [Description("شماره فاکتور مرتبط با سفارش")]
        public string InvoiceNumber { get; set; } = null;

        [DisplayName("شناسه مشتری")]
        [Description("شناسه مشتری مربوط به سفارش")]
        public int CustomerId { get; set; }

        [DisplayName("مشتری")]
        [Description("مشتری مربوط به سفارش")]
        public virtual Customer Customer { get; set; } = null;

        [DisplayName("تاریخ سفارش")]
        [Description("تاریخ ثبت سفارش (میلادی - در دیتابیس)")]
        public DateTime OrderDate { get; set; }

        [DisplayName("تاریخ تحویل")]
        [Description("تاریخ تحویل سفارش (میلادی - در دیتابیس)")]
        public DateTime? DeliveryDate { get; set; }

        [DisplayName("هزینه حمل و نقل")]
        [Description("هزینه حمل و نقل سفارش")]
        public double TransportCost { get; set; }

        [DisplayName("هزینه‌های جانبی")]
        [Description("هزینه‌های متفرقه سفارش")]
        public double MiscCost { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات اضافی سفارش")]
        public string Description { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();






        // ─── نام مشتری (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("نام مشتری")]
        public string CustomerName => Customer?.CustomerName ?? "نامشخص";

        // ─── تاریخ‌های شمسی با فرمت yyyy/MM/dd ─────────────────────────────

        /// <summary>
        /// تاریخ سفارش شمسی - فرمت دقیق: yyyy/MM/dd (مثال: 1404/09/11)
        /// </summary>
        [NotMapped]
        [DisplayName("تاریخ سفارش")]
        public string FaOrderDate
        {
            get => ToPersianDateString(OrderDate);
            set => OrderDate = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("تاریخ سفارش الزامی است")
                : ParsePersianDate(value);
        }

        [NotMapped]
        [DisplayName("تاریخ تحویل")]
        public string FaDeliveryDate
        {
            get => DeliveryDate.HasValue ? ToPersianDateString(DeliveryDate.Value) : "تحویل نشده";
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    DeliveryDate = null;
                    return;
                }

                string v = value.Trim();
                if (v == "تحویل نشده" || v == "-" || v == "")
                {
                    DeliveryDate = null;
                }
                else
                {
                    DeliveryDate = ParsePersianDate(v);
                }
            }
        }

        // ─── متدهای کمکی تبدیل تاریخ (فقط عددی yyyy/MM/dd) ─────────────────
        private static string ToPersianDateString(DateTime date)
        {
            var pc = new PersianCalendar();
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);
            return $"{year:0000}/{month:00}/{day:00}";
        }

        private static DateTime ParsePersianDate(string persianDate)
        {
            string cleaned = persianDate.Replace('-', '/').Replace('\\', '/').Trim();
            var parts = cleaned.Split('/');
            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out int year) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int day))
            {
                throw new ArgumentException($"فرمت تاریخ شمسی صحیح نیست: '{persianDate}' — فرمت مورد قبول: yyyy/MM/dd (مثال: 1404/09/11)");
            }

            if (year < 1300 || year > 1500 || month < 1 || month > 12 || day < 1 || day > 31)
                throw new ArgumentException($"تاریخ شمسی خارج از محدوده معتبر است: {persianDate}");

            var pc = new PersianCalendar();
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
    }
}