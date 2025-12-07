using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncData.Entities
{
    public class Customer
    {
        [DisplayName("شناسه مشتری")]
        [Description("شناسه یکتا مشتری")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("نام مشتری")]
        [Description("نام کامل مشتری")]
        public string CustomerName { get; set; }

        [DisplayName("تلفن")]
        [Description("شماره تماس مشتری")]
        public string Phone { get; set; }

        [DisplayName("آدرس")]
        [Description("آدرس کامل مشتری")]
        public string Address { get; set; }

        [DisplayName("حساب اول دوره")]
        [Description("حساب اول دوره")]
        public double Beginning_Balance { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات مربوط به مشتری")]
        public string Description { get; set; }



        [DisplayName("سفارش‌ها")]
        [Description("لیست سفارش‌های مشتری")]
        public virtual ICollection<Order> Orders { get; set; }

        [DisplayName("رسیدها")]
        [Description("لیست رسیدهای مشتری")]
        public virtual ICollection<Receipt> Receipts { get; set; }
    }

}
