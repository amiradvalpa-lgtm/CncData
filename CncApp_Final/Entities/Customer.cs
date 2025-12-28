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
    public class Customer
    {
        [DisplayName("شناسه مشتری")]
        [Description("شناسه یکتا مشتری")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("نام مشتری")]
        [Description("نام کامل مشتری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string CustomerName { get; set; }

        [DisplayName("راهنما")]
        [Description("راهنما در مورد نام مشتری")]
        public string Hint { get; set; } = string.Empty;


        [DisplayName("تلفن")]
        [Description("شماره تماس مشتری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string Phone { get; set; }

        [DisplayName("آدرس")]
        [Description("آدرس کامل مشتری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "وارد کردن {0} الزامی است.")]
        public string Address { get; set; }

        [DisplayName("حساب اول دوره")]
        [Description("حساب اول دوره")]
        public double Beginning_Balance { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات مربوط به مشتری")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("کد مشتری محک")]
        [Description("کد مشتری در حسابداری مجک")]
        public string MhkCustomerId { get; set; } =string.Empty;


        [DisplayName("سفارش‌ها")]
        [Description("لیست سفارش‌های مشتری")]
        public virtual ICollection<Order> Orders { get; set; }

        [DisplayName("رسیدها")]
        [Description("لیست رسیدهای مشتری")]
        public virtual ICollection<Receipt> Receipts { get; set; }

        [NotMapped]
        public string CustomerFullName
        {
            get
            {
                return string.IsNullOrWhiteSpace(Hint)
                    ? CustomerName
                    : $"{CustomerName} - {Hint}";
            }
        }

        public Customer() 
        {
            Hint = string.Empty;
            Description = string.Empty;
            MhkCustomerId = string.Empty;
        }
    }

}
