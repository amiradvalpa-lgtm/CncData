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

        [DisplayName("مانده اول دوره")]
        [Description("مانده اول دوره")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Range(0.001, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        public double Beginning_Balance { get; set; }

        [DisplayName("ماهیت اول دوره")]
        [Description("ماهیت اول دوره - بدهکار،بی حساب،بستانکار")]

        public double BalanceType { get; set; }

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



        [NotMapped]
        [DisplayName("-+مانده حساب")]
        [Description("مانده حساب مشتری")]
        public decimal Balance
        {
            get
            {
                decimal ordersTotal = Orders?.Sum(x => (decimal?)x.TotalAmount) ?? 0m;
                decimal receiptsTotal = Receipts?.Sum(x => (decimal?)x.Amount) ?? 0m;
                decimal beginning = (decimal)Beginning_Balance*(decimal)BalanceType;

                return (receiptsTotal + beginning) - ordersTotal;
            }
        }

        [NotMapped]
        [DisplayName("ماهیت حساب")]
        [Description("ماهیت حساب مشتری")]
        public string BalanceStatus
        {
            get
            {
                if (Balance == 0) return "بی حساب";
                if (Balance < 0) return "بدهکار";
                return "بستانکار";
            }
        }

        // اگر می‌خوای مقدار قابل نمایش هم آماده داشته باشی
        [NotMapped]
        [DisplayName("مانده حساب")]
        [Description("مانده حساب مشتری")]
        public decimal DisplayBalance => Math.Abs(Balance);

        public Customer() 
        {
            Hint = string.Empty;
            Description = string.Empty;
            MhkCustomerId = string.Empty;
        }
    }

}
