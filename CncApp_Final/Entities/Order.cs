using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string InvoiceNumber { get; set; }

        [DisplayName("شناسه مشتری")]
        [Description("شناسه مشتری مربوط به سفارش")]
        public int CustomerId { get; set; }

        [DisplayName("مشتری")]
        [Description("مشتری مربوط به سفارش")]
        public virtual Customer Customer { get; set; }

        [DisplayName("تاریخ سفارش")]
        [Description("تاریخ ثبت سفارش")]
        public DateTime OrderDate { get; set; }

        [DisplayName("تاریخ تحویل")]
        [Description("تاریخ تحویل سفارش")]
        public DateTime? DeliveryDate { get; set; }

        [DisplayName("مسیر فایل")]
        [Description("مسیر فایل مربوط به سفارش")]
        public string FilePath { get; set; }

        [DisplayName("شناسه ورق")]
        [Description("ورق انتخاب شده برای سفارش")]
        public int SheetId { get; set; }

        [DisplayName("ورق")]
        [Description("ورق مربوط به سفارش")]
        public virtual Sheet Sheet { get; set; }

        [DisplayName("تامین‌کننده")]
        [Description("نوع تامین‌کننده سفارش")]
        public SupplierType Supplier { get; set; }

        [DisplayName("طول برش")]
        [Description("طول برش ورق بر حسب میلی‌متر")]
        public double CutLength { get; set; }

        [DisplayName("عرض برش")]
        [Description("عرض برش ورق بر حسب میلی‌متر")]
        public double CutWidth { get; set; }

        [DisplayName("هزینه نهایی ورق")]
        [Description("هزینه نهایی ورق بعد از برش")]
        public double FinalSheetCost { get; set; }

        [DisplayName("طول شیار")]
        [Description("مجموع طول شیارهای ایجاد شده بر روی ورق")]
        public double GrooveLength { get; set; }

        [DisplayName("هزینه CNC")]
        [Description("هزینه ماشینکاری CNC")]
        public double CncCost { get; set; }

        [DisplayName("هزینه حمل و نقل")]
        [Description("هزینه حمل و نقل سفارش")]
        public double TransportCost { get; set; }

        [DisplayName("هزینه‌های جانبی")]
        [Description("هزینه‌های متفرقه سفارش")]
        public double MiscCost { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات اضافی سفارش")]
        public string Description { get; set; }


        // داخل کلاس Order اضافه کن (در انتهای کلاس، قبل از آخرین })

        // نام مشتری (به جای نمایش CustomerId)
        [NotMapped]
        [DisplayName("نام مشتری")]
        public string CustomerName => Customer?.CustomerName ?? "نامشخص";

        // مشخصات کامل ورق: جنس + ضخامت + ابعاد (مثال: ST52 10mm 2000*4000)
        [NotMapped]
        [DisplayName("مشخصات ورق")]
        public string SheetDetails => Sheet != null
            ? $"{Sheet.Material} {Sheet.Thickness}mm {Sheet.Length}*{Sheet.Width}"
            : "ورق انتخاب نشده";

        // قیمت ورق
        [NotMapped]
        [DisplayName("قیمت ورق")]
        public double? SheetPrice => Sheet?.SheetPrice;

        // قیمت تکه
        [NotMapped]
        [DisplayName("قیمت تکه")]
        public double? PicesPrice => Sheet?.PicesPrice;

        // اختیاری: اگر می‌خوای Description اتریبیوت رو هم از enum بخونی (روش حرفه‌ای‌تر)
        [NotMapped]
        [DisplayName("تامین‌کننده")]
        public string SupplierTypeDescription => GetEnumDescription(Supplier);


        /// متد کمکی برای خوندن Description از enum (یک بار در کلاس بنویس)
        private static string GetEnumDescription(SupplierType value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description ?? value.ToString();
        }
    }

}
