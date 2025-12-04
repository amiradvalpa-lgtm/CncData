using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CncApp_Final.Entities
{
    public class Warehouse
    {
        [DisplayName("شناسه ورود به انبار")]
        [Description("شناسه ورود به انبار")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شناسه ورق")]
        [Description("ورق انتخاب شده برای سفارش")]
        public int SheetId { get; set; }

        [DisplayName("ورق")]
        [Description("ورق مربوط به سفارش")]
        public virtual Sheet Sheet { get; set; }

        [DisplayName("تاریخ خرید")]
        [Description("تاریخ خرید")]
        public DateTime OrderDate { get; set; }

        [DisplayName("قیمت پایه کامل")]
        [Description("قیمت پایه ورق")]
        public double SheetBasePrice { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات مربوط به خرید ورق")]
        public string Description { get; set; }
    }
}
