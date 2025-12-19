    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

namespace CncApp_Final.Entities
{
    /// <summary>
    /// ذخیره طرح‌بندی (Layout) شخصی‌سازی شده گریدها برای هر کاربر.
    /// </summary>
    public class UserGridLayout
    {
        [DisplayName("شناسه طرح‌بندی")]
        [Description("شناسه یکتا طرح‌بندی گرید")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شناسه کاربر")]
        [Description("شناسه کاربر مرتبط با طرح‌بندی")]
        public int UserId { get; set; }

        [DisplayName("نام گرید")]
        [Description("نام یا کلید گرید (جدول) که طرح‌بندی برای آن ذخیره شده")]
        [Required]
        [StringLength(100)]
        public string GridName { get; set; }

        [DisplayName("XML طرح‌بندی")]
        [Description("داده‌های XML/JSON طرح‌بندی گرید")]
        public string LayoutXml { get; set; }

        [DisplayName("آخرین به‌روزرسانی")]
        [Description("تاریخ و زمان آخرین به‌روزرسانی طرح‌بندی")]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}

