using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncData.Entities
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace CncData.Entities
    {
        /// <summary>
        /// ذخیره تنظیمات کلی و کلید-مقدار (Key-Value) برنامه.
        /// </summary>
        public class AppOption
        {
            [DisplayName("شناسه")]
            [Description("شناسه یکتا")]
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [DisplayName("کلید تنظیمات")]
            [Description("کلید یکتا برای شناسایی تنظیم (مثلاً: DefaultVatRate)")]
            [Required]
            [StringLength(100)]
            public string OptionKey { get; set; }

            [DisplayName("مقدار تنظیمات")]
            [Description("مقدار تنظیم (به صورت متنی، باید در کد تبدیل شود)")]
            public string OptionValue { get; set; }

            [DisplayName("توضیحات")]
            [Description("توضیحات و کاربرد تنظیم")]
            public string Description { get; set; }
        }
    }
}
