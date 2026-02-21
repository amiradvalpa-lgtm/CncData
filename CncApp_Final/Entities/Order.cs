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


        [DisplayName("مسیر فایل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " {0} را مشخص کنید.")]
        [Description("مسیر فایل مربوط به این جزئیات سفارش")]
        public string FilePath { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات اضافی سفارش")]
        public string Description { get; set; } = string.Empty;

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
            get => PersianDateHelper1.ToPersianDateString(OrderDate);
            set => OrderDate = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("تاریخ سفارش الزامی است")
                : PersianDateHelper1.ParsePersianDate(value);
        }

        [NotMapped]
        [DisplayName("تاریخ تحویل")]
        public string FaDeliveryDate
        {
            get => DeliveryDate.HasValue ? PersianDateHelper1.ToPersianDateString(DeliveryDate.Value) : "تحویل نشده";
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
                    DeliveryDate = PersianDateHelper1.ParsePersianDate(v);
                }
            }
        }


        //[NotMapped]
        //[DisplayName("تاریخ تحویل")]
        //[PersianDate]
        //public PersianDate? FaDeliveryDateTest
        //{
        //    get
        //    {
        //        return DeliveryDate.HasValue
        //            ? new PersianDate(DeliveryDate.Value)
        //            : (PersianDate?)null;
        //    }
        //    set
        //    {
        //        DeliveryDate = value.HasValue
        //            ? (DateTime)value.Value
        //            : (DateTime?)null;
        //    }
        //}

        //[NotMapped]
        //[DisplayName("تاریخ تحویل")]
        //[PersianDate] // DataAnnotation برای DXValidation
        //public PersianDate? FaDeliveryDateTest
        //{
        //    get
        //    {
        //        // اگر DeliveryDate مقدار داشته باشد، PersianDate می‌سازد
        //        return DeliveryDate.HasValue
        //            ? new PersianDate(DeliveryDate.Value)
        //            : (PersianDate?)null;
        //    }
        //    set
        //    {
        //        // اگر مقدار null بود، DeliveryDate هم null شود
        //        if (!value.HasValue)
        //        {
        //            DeliveryDate = null;
        //            return;
        //        }

        //        // اگر مقدار معتبر PersianDate باشد، به DateTime تبدیل و نگهداری می‌شود
        //        DeliveryDate = value.Value.GregorianDate;
        //    }
        //}

        //[NotMapped]
        //[DisplayName("تاریخ تحویل")]
        ////[PersianDate] // DataAnnotation برای DXValidation
        //public PersianDate? FaDeliveryDateTest
        //{
        //    get
        //    {
        //        return DeliveryDate.HasValue
        //            ? new PersianDate(DeliveryDate.Value)
        //            : (PersianDate?)null;
        //    }
        //    set
        //    {
        //        // فقط مقدار DateTime را ذخیره می‌کنیم، هیچ Parse یا Exception داخل setter نیست
        //        if (value.HasValue)
        //            DeliveryDate = value.Value.GregorianDate;
        //        else
        //            DeliveryDate = null;
        //    }

        //}

        [NotMapped]
        [DisplayName("تاریخ تحویل")]
        public PersianDate? FaDeliveryDateTest
        {
            get => DeliveryDate.HasValue ? new PersianDate(DeliveryDate.Value) : (PersianDate?)null;
            set => DeliveryDate = value.HasValue ? value.Value.GregorianDate : (DateTime?)null;
        }







    }
}