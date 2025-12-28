using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection; // برای GetEnumDescription

namespace CncApp_Final.Entities
{
    // کلاس باید از ICloneable ارث ببرد تا بتواند در Sandbox (فرم‌های مودال) استفاده شود
    public class OrderDetails : ICloneable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شناسه سفارش")]
        public int OrderId { get; set; }

        [DisplayName("سفارش")]
        // توجه: در Deep Clone، این شیء مرجع نباید کپی شود تا ارجاع به Order اصلی حفظ شود.
        public virtual Order Order { get; set; }

        [DisplayName("نام سفارش")]
        // اعتبارسنجی: Required و پیام خطای مرتبط
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Description("نام سفارش")]
        public string DetailName { get; set; }

        [DisplayName("مسیر فایل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = " {0} را مشخص کنید.")]
        [Description("مسیر فایل مربوط به این جزئیات سفارش")]
        public string FilePath { get; set; }

        [DisplayName("شناسه ورق")]
        [Description("ورق انتخاب شده برای این جزئیات")]
        public int SheetId { get; set; }

        [DisplayName("تعداد ورق")]
        [Description("تعداد ورق انتخاب شده برای این جزئیات")]
        public double SheetCount { get; set; }

        [DisplayName("ورق")]
        [Description("ورق مربوط به این جزئیات سفارش")]
        // توجه: این شیء مرجع نباید در Clone کپی شود تا ارجاع به Sheet اصلی حفظ شود.
        public virtual Sheet Sheet { get; set; }

        [DisplayName("تامین‌کننده")]
        // اعتبارسنجی: Required برای Enum (Enumها به طور پیش‌فرض Required هستند، اما برای اطمینان و پیام خطا اضافه می‌شود)
        [Required(ErrorMessage = "نوع {0} باید انتخاب شود.")]
        [Description("نوع تامین‌کننده این جزئیات سفارش")]
        public SupplierType Supplier { get; set; }

        // --- فیلدهای عددی و اعمال Range Validation برای مقادیر مثبت (بزرگتر از 0) ──

        [DisplayName("طول برش")]
        //[Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        //[Range(0.001, double.MaxValue, ErrorMessage = "{0} باید عددی مثبت باشد.")]
        [Description("طول برش ورق بر حسب سانتیمتر")]
        public double CutLength { get; set; }

        [DisplayName("عرض برش")]
        //[Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        //[Range(0.001, double.MaxValue, ErrorMessage = "{0} باید عددی مثبت باشد.")]
        [Description("عرض برش ورق بر حسب سانتیمتر")]
        public double CutWidth { get; set; }

        [DisplayName("هزینه نهایی ورق")]
        [Required(ErrorMessage = "محاسبه {0} الزامی است.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        [Description("هزینه نهایی ورق بعد از برش")]
        public double FinalSheetCost { get; set; }

        [DisplayName("طول شیار")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        [Description("مجموع طول شیارهای ایجاد شده بر روی ورق")]
        public double GrooveLength { get; set; }

        [DisplayName("هزینه CNC")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        [Description("هزینه ماشینکاری CNC این جزئیات")]
        public double CncCost { get; set; }

        [DisplayName("توضیحات جزئیات")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "{0} را وارد کنید.")] // توضیحات می‌تواند خالی باشد
        [Description("توضیحات اضافی برای این جزئیات سفارش")]
        public string Description { get; set; }

        // ─── فیلدهای محاسباتی (NotMapped) ─────────────────────────────────────
        // (این بخش بدون تغییر باقی می‌ماند)

        [NotMapped]
        [DisplayName("مشخصات ورق")]
        public string SheetDetails => Sheet != null
            ? $"{Sheet.Material} {Sheet.Thickness}mm {Sheet.Width}*{Sheet.Length}"
            : "ورق انتخاب نشده";

        [NotMapped]
        [DisplayName("مساحت ورق")]
        public double CutSheetArea => CutLength * CutWidth / 10000;

        //[NotMapped]
        //[DisplayName("مساحت ورق")]
        //public double CutSheetArea =>
        //                             (
        //                                 SheetCount * ((Sheet?.Width ?? 0) * (Sheet?.Length ?? 0))
        //                                 + (CutLength * CutWidth)
        //                             ) / 10000;


        //[NotMapped]
        //[DisplayName("مساحت ورق")]
        //public double CutSheetArea => (SheetCount * (Sheet.Width * Sheet.Length) + (CutLength * CutWidth)) / 10000;


        //public double CutSheetArea => Sheet != null
        //    ? (SheetCount * (Sheet.Width * Sheet.Length) + (CutLength * CutWidth)) / 10000
        //    : 0;

        //[NotMapped]
        //[DisplayName("مساحت ورق")]
        //public double CutSheetArea
        //{
        //    get
        //    {
        //        var sheet = Sheet;
        //        if (sheet == null)
        //            return (CutLength * CutWidth) / 10000;

        //        return
        //            (SheetCount * (sheet.Width * sheet.Length)
        //            + (CutLength * CutWidth)) / 10000;
        //    }
        //}







        //[NotMapped]
        //[DisplayName("مشخصات ورق برشی")]
        //public string CutSheetDetails => Sheet != null
        //    ? $"{Sheet.Material} {Sheet.Thickness}mm {Sheet.Width}*{Sheet.Length}  ا  {SheetCount} عدد"
        //    : "ورق انتخاب نشده";



        [NotMapped]
        [DisplayName("مشخصات ورق برشی")]
        public string CutSheetDetails
        {
            get
            {
                if (Sheet == null)
                    return "ورق انتخاب نشده";

                var baseInfo = $"{Sheet.Material} {Sheet.Thickness}mm";

                bool hasSheetCount = SheetCount > 0;
                bool hasCutSize = (CutWidth > 0 && CutLength > 0);

                // فقط SheetCount
                if (hasSheetCount && !hasCutSize)
                    return $"{baseInfo} {Sheet.Width}*{Sheet.Length} - {SheetCount} pcs";

                // فقط Cut Size
                if (!hasSheetCount && hasCutSize)
                    return $"{baseInfo} {CutWidth}*{CutLength} Cm";

                // هر دو برقرار → دو خط
                if (hasSheetCount && hasCutSize)
                {
                    string line1 = $"{baseInfo} {Sheet.Width}*{Sheet.Length} - {SheetCount} pcs";
                    string line2 = $"{baseInfo} {CutWidth}*{CutLength} Cm";
                    return line1 + Environment.NewLine + line2;
                }

                // اگر هیچ‌کدام برقرار نبود
                return $"{baseInfo} {Sheet.Width}*{Sheet.Length}";
            }
        }


        [NotMapped]
        [DisplayName("قیمت ورق")]
        public double? SheetPrice => Sheet?.SheetPrice;

        [NotMapped]
        [DisplayName("قیمت تکه")]
        public double? PicesPrice => Sheet?.PicesPrice;

        [NotMapped]
        [DisplayName("قیمت ورق")]
        public string FinalSheetCostDisplay => Supplier == SupplierType.Warehouse
            ? $"{FinalSheetCost:N0} تومان"
            : "ورق مشتری";

        [NotMapped]
        [DisplayName("تامین‌کننده")]
        public string SupplierTypeDescription => GetEnumDescription(Supplier);

        // ─── متد کمکی برای Enum ─────────────────────────────────────

        private static string GetEnumDescription(SupplierType value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description ?? value.ToString();
        }

        // ─── پیاده‌سازی ICloneable برای Sandbox ─────────────────────────────────

        public object Clone()
        {
            // ۱. کپی سطحی (Shallow Copy) برای تمام Value Typeها (int, double, decimal) و رشته‌ها
            // و همچنین آدرس اشیاء مرجع (Order, Sheet) را کپی می‌کند.
            OrderDetails clone = (OrderDetails)this.MemberwiseClone();
            //clone.Sheet = (Sheet)this.Sheet.Clone();


            // ۲. تنظیم Id بر روی صفر یا پیش‌فرض
            // این تضمین می‌کند که این کپی به عنوان یک Entity جدید در نظر گرفته شود، نه Entity اصلی.
            // این مورد برای ویرایش لازم نیست اما برای افزودن یک Clone جدید به Collection جزئیات الزامی است.
            //clone.Id = 0;

            // ۳. کپی عمیق (Deep Copy) برای اشیاء مرجع قابل تغییر (در این کلاس، اشیاء مرجع فقط Navigation Properties EF هستند)
            // نکته: برای حفظ رابطه با Order و Sheet اصلی، نیازی به کپی کردن Order و Sheet نیست،
            // بلکه کافی است ارجاع آن‌ها در Clone حفظ شود.
            // اگر در این کلاس، شیء مرجع دیگری غیر از Order و Sheet داشتید، باید اینجا آن را کپی می‌کردید.

            // اگر OrderDetails شامل یک شیء مرجع داخلی (مانند List<string> Tags) بود، باید اینجا کپی می‌شد:
            // if (this.Tags != null) clone.Tags = new List<string>(this.Tags);

            return clone;
        }

    }
    
}