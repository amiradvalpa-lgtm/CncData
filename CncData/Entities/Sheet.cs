using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CncData.Entities
{
    public class Sheet
    {
        [DisplayName("شناسه ورق")]
        [Description("شناسه یکتا ورق")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("جنس ورق")]
        [Description("جنس یا نوع ماده ورق")]
        public string Material { get; set; } = null!;

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

        [DisplayName("قیمت تکه")]
        [Description("قیمت هر تکه برش‌خورده از ورق")]
        public double PicesPrice { get; set; }

        [DisplayName("قیمت خدمات CNC")]
        [Description("هزینه خدمات CNC به ازای متر یا واحد")]
        public double CNCPrice { get; set; }

        // تغییر مهم: قبلاً به Order بود، حالا به OrderDetails است
        [DisplayName("جزئیات سفارش‌هایی که از این ورق استفاده کرده‌اند")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        // این رابطه همچنان درست است (انبار ← ورق)
        [DisplayName("موجودی در انبار")]
        [Description("لیست موجودی این ورق در انبار")]
        public virtual ICollection<Warehouse> Warehouse { get; set; } = new List<Warehouse>();
    }
}