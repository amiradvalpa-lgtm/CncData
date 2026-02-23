using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CncData.Entities
{
    public class CustomerWarehouse
    {
        [DisplayName("شناسه ثبت انبار مشتری")]
        [Description("شناسه ثبت انبار مشتری")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شناسه ورق")]
        [Description("ورق انتخاب شده برای انبار مشتری")]
        public int SheetId { get; set; }

        [DisplayName("ورق")]
        [Description("ورق مربوط به انبار مشتری")]
        public virtual Sheet Sheet { get; set; }

        [DisplayName("تعداد ورق")]
        [Description("تعداد ورق تحویل گرفته")]
        public double Count { get; set; }

        [DisplayName("تاریخ ورود")]
        [Description("تاریخ انبار ورود")]
        public DateTime EntryDate { get; set; }

        
        [DisplayName("توضیحات")]
        [Description("توضیحات مربوط به خرید ورق")]
        public string Description { get; set; }
    }
}
