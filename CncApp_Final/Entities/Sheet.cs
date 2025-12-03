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
    public class Sheet
    {
        [DisplayName("شناسه ورق")]
        [Description("شناسه یکتا ورق")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("جنس ورق")]
        [Description("جنس یا نوع ماده ورق")]
        public string Material { get; set; }

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
        [Description("قیمت ورق")]
        public double SheetPrice { get; set; }

        [DisplayName("قیمت تکه")]
        [Description("قیمت تکه")]
        public double PicesPrice { get; set; }



        [DisplayName("سفارش‌ها")]
        [Description("لیست سفارش‌هایی که از این ورق استفاده کرده‌اند")]
        public virtual ICollection<Order> Orders { get; set; }

        [DisplayName("حساب بانکی")]
        [Description("حساب بانکی مربوط به رسید")]
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
