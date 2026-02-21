using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CncApp_Final.Helper;

namespace CncApp_Final.Entities
{
    public class Receipt
    {
        [DisplayName("شناسه رسید")]
        [Description("شناسه یکتا رسید")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شناسه مشتری")]
        [Description("مشتری مربوط به رسید")]
        [Required(ErrorMessage = "انتخاب مشتری الزامی است.")]
        public int CustomerId { get; set; }

        [DisplayName("مشتری")]
        [Description("مشتری مربوط به رسید")]
        public virtual Customer Customer { get; set; }

        [DisplayName("تاریخ")]
        [Description("تاریخ صدور رسید")]
        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayName("مبلغ")]
        [Description("مقدار وجه پرداختی یا دریافت شده")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است.")]
        [Range(0.001, double.MaxValue, ErrorMessage = "{0} نمی‌تواند منفی باشد.")]
        public double Amount { get; set; }

        [DisplayName("شناسه حساب بانکی")]
        [Description("حساب بانکی مربوط به رسید")]
        [Required(ErrorMessage = "انتخاب حساب بانکی الزامی است.")]
        public int BankAccountId { get; set; }

        [DisplayName("توضیحات")]
        [Description("توضیحات دریافت")]
        public string Description { get; set; } = string.Empty;


        [DisplayName("حساب بانکی")]
        [Description("حساب بانکی مربوط به رسید")]
        public virtual BankAccount BankAccount { get; set; }

        // ─── نام مشتری (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("نام مشتری")]
        public string CustomerName => Customer?.CustomerName ?? "نامشخص";

        // ─── نام حساب بانکی (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("حساب بانکی")]
        public string BankName => $"{BankAccount?.Account_L_Name} - {BankAccount?.BankName}" ?? "نامشخص";

        /// <summary>
        /// تاریخ سفارش شمسی - فرمت دقیق: yyyy/MM/dd (مثال: 1404/09/11)
        /// </summary>
        [NotMapped]
        [DisplayName("تاریخ واریز")]
        public string FaReceiptDate
        {
            get => PersianDateHelper1.ToPersianDateString(Date);
            set => Date = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("تاریخ سفارش الزامی است")
                : PersianDateHelper1.ParsePersianDate(value);
        }

    }


}
