using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CncApp_Final.Entities
{
    public class Sheet : ICloneable
    {
        [DisplayName("شناسه ورق")]
        [Description("شناسه یکتا ورق")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("جنس ورق")]
        [Description("جنس یا نوع ماده ورق")]
        public string Material { get; set; } = null;

        [DisplayName("ضخامت")]
        [Description("ضخامت ورق بر حسب میلی‌متر")]
        public double Thickness { get; set; }

        [DisplayName("عرض")]
        [Description("عرض ورق بر حسب سانتیمتر")]
        public double Width { get; set; }

        [DisplayName("طول")]
        [Description("طول ورق بر حسب سانتیمتر")]
        public double Length { get; set; }

        [DisplayName("قیمت کامل")]
        [Description("قیمت کل ورق کامل")]
        public double SheetPrice { get; set; }

        [DisplayName("فرمول قیمت کامل")]
        [Description("فرمول قیمت ورق کامل")]
        [Required(ErrorMessage = "فرمول قیمت ورق کامل الزامی است.")]
        public string SheetPriceFormula { get; set; }

        [DisplayName("قیمت تکه")]
        [Description("قیمت هر تکه برش‌خورده از ورق")]
        public double PicesPrice { get; set; }

        [DisplayName("فرمول قیمت تکه")]
        [Description("فرمول قیمت ورق تکه")]
        [Required(ErrorMessage = "فرمول قیمت ورق تکه الزامی است.")]
        public string PicesPriceFormula { get; set; }

        [DisplayName("قیمت CNC (متر)")]
        [Description("هزینه خدمات CNC به ازای متر")]
        public double CNCPriceByMeter { get; set; }

        [DisplayName("قیمت CNC (ورق)")]
        [Description("هزینه خدمات CNC به ازای ورق کامل")]
        public double CNCPriceBySheet { get; set; }

        [DisplayName("قیمت CNC (تکه)")]
        [Description("هزینه خدمات CNC به ازای ورق تکه")]
        public double CNCPriceByPice { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات ورق")]
        public string Description { get; set; }

        // تغییر مهم: قبلاً به Order بود، حالا به OrderDetails است
        [DisplayName("جزئیات سفارش‌هایی که از این ورق استفاده کرده‌اند")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        // این رابطه همچنان درست است (انبار ← ورق)
        [DisplayName("موجودی در انبار")]
        [Description("لیست موجودی این ورق در انبار")]
        public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();


        // ─── ضخامت ورق (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("نام ورق")]
        public string SheetName => $"{Material} _ {Thickness}mm _ {Width} * {Length}";

        // ─── ضخامت ورق (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("ضخامت ورق")]
        public string Thickness_mm => $"{Thickness}mm";

        // ─── سایز ورق (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("سایز ورق")]
        public string SheetSize => $"{Length} * {Width}";

        // ─── آخرین قیمت خرید (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("آخرین قیمت خرید")]
        [Description("آخرین قیمت خرید ثبت شده برای این ورق در انبار (بر اساس OrderDate)")]
        public double? LastBuyPrice
        {
            get
            {
                // بررسی وجود داده در لیست انبار
                if (Warehouses == null || !Warehouses.Any())
                    return null;

                // پیدا کردن آخرین رکورد بر اساس تاریخ خرید (OrderDate) و دریافت قیمت پایه (SheetBasePrice)
                var lastWarehouseEntry = Warehouses.OrderByDescending(w => w.OrderDate).FirstOrDefault();

                return lastWarehouseEntry?.SheetBasePrice;
            }
        }


        public object Clone()
        {
            // ۱. کپی سطحی (Shallow Copy) برای تمام Value Typeها (int, double, decimal) و رشته‌ها
            // و همچنین آدرس اشیاء مرجع (Order, Sheet) را کپی می‌کند.
            Sheet clone = (Sheet)this.MemberwiseClone();

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