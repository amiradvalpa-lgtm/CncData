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
    public class BankAccount
    {
        [DisplayName("شناسه حساب بانکی")]
        [Description("شناسه یکتا حساب بانکی")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[DisplayName("نام حساب بانکی")]
        //[Description("نام نمایشی حساب بانکی")]
        //public string AccountName { get; set; }

        [DisplayName("نام")]
        [Description("نام")]
        public string Account_F_Name { get; set; }

        [DisplayName("نام خانوادگی")]
        [Description("نام خانوادگی")]
        public string Account_L_Name { get; set; }

        [DisplayName("نام بانک")]
        [Description("نام بانک")]
        public string BankName { get; set; }

        [DisplayName("شماره کارت")]
        [Description("شماره کارت")]
        public string CardNumber { get; set; }

        [DisplayName("شماره شبا")]
        [Description("شماره شبا")]
        public string ShebaNumber { get; set; }


        [DisplayName("رسیدها")]
        [Description("لیست رسیدهای مربوط به این حساب بانکی")]
        public virtual ICollection<Receipt> Receipts { get; set; }
    }

}
