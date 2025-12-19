using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using CncApp_Final.Helper;

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
        [Required(ErrorMessage = "انتخاب مشتری الزامی است.")]
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
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        public double TransportCost { get; set; }

        [DisplayName("هزینه‌های جانبی")]
        [Description("هزینه‌های متفرقه سفارش")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        public double MiscCost { get; set; }

        [DisplayName("تخفیف")]
        [Description("تخفیف فاکتور")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        public double Discount { get; set; }


        [DisplayName("توضیحات")]
        [Description("توضیحات اضافی سفارش")]
        public string Description { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();


        // ──────────────────────────────────────────────────────────────
        // فیلدهای محاسباتی جدید (NotMapped)
        // ──────────────────────────────────────────────────────────────

        /// <summary>
        /// مجموع هزینه نهایی ورق‌ها (FinalSheetCost) از تمام جزئیات سفارش
        /// </summary>
        [NotMapped]
        [DisplayName("مبلغ کل ورق")]
        [Description("مجموع هزینه ورق‌های استفاده شده در سفارش")]
        public double TotalSheetCost => OrderDetails?.Sum(d => d.FinalSheetCost) ?? 0;

        /// <summary>
        /// مجموع هزینه CNC از تمام جزئیات سفارش
        /// </summary>
        [NotMapped]
        [DisplayName("مبلغ کل CNC")]
        [Description("مجموع هزینه ماشینکاری CNC تمام قطعات سفارش")]
        public double TotalCncCost => OrderDetails?.Sum(d => d.CncCost) ?? 0;

        /// <summary>
        /// مبلغ کل سفارش = مجموع ورق + مجموع CNC + حمل و نقل + هزینه‌های جانبی
        /// </summary>
        [NotMapped]
        [DisplayName("مبلغ کل سفارش")]
        [Description("جمع کل هزینه‌های سفارش شامل ورق، CNC، حمل و نقل و هزینه‌های جانبی")]
        public double TotalAmount => TotalSheetCost + TotalCncCost + TransportCost + MiscCost - Discount;

        /// <summary>
        /// عنوان ترکیبی از نام جزئیات سفارش (مثلاً: "کابینت بالا + درب کمد + کشو")
        /// اگر بیش از 4 مورد بود، بقیه با "و ..." نمایش داده می‌شود
        /// </summary>
        [NotMapped]
        [DisplayName("عنوان سفارش")]
        [Description("ترکیب نام تمام قطعات سفارش")]
        public string OrderTitle
        {
            get
            {
                if (OrderDetails == null || !OrderDetails.Any())
                    return "بدون جزئیات";

                var names = OrderDetails
                    .Where(d => !string.IsNullOrWhiteSpace(d.DetailName))
                    .Select(d => d.DetailName.Trim())
                    .Distinct()
                    .ToList();

                if (names.Count == 0) return "بدون نام";
                if (names.Count == 1) return names[0];
                if (names.Count <= 4)
                    return string.Join(" + ", names);

                // اگر بیشتر از 4 تا بود، فقط 3 تا اول + "و ..."
                return string.Join(" + ", names.Take(3)) + " و ...";
            }
        }



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
            get => PersianDateHelper.ToPersianDateString(OrderDate);
            set => OrderDate = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("تاریخ سفارش الزامی است")
                : PersianDateHelper.ParsePersianDate(value);
        }

        [NotMapped]
        [DisplayName("تاریخ تحویل")]
        public string FaDeliveryDate
        {
            get => DeliveryDate.HasValue ? PersianDateHelper.ToPersianDateString(DeliveryDate.Value) : "تحویل نشده";
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
                    DeliveryDate = PersianDateHelper.ParsePersianDate(v);
                }
            }
        }

        
    }
}