using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CncApp_Final.Helper;

namespace CncApp_Final.Entities
{
    public class Warehouse
    {
        [DisplayName("شناسه ورود به انبار")]
        [Description("شناسه ورود به انبار")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("شناسه ورق"),Display(Order = 1)]
        [Required(ErrorMessage = "انتخاب ورق الزامی است.")]
        [Description("ورق انتخاب شده برای سفارش")]
        public int SheetId { get; set; }

        [DisplayName("ورق")]
        [Description("ورق مربوط به سفارش")]
        public virtual Sheet Sheet { get; set; }

        [DisplayName("تاریخ خرید")]
        [Description("تاریخ خرید")]
        public DateTime OrderDate { get; set; }
            

        [DisplayName("قیمت پایه کامل"),
            Required(ErrorMessage = "وارد کردن {0} الزامی است."), Display(Order = 3),
            Range(0.001, 1000000000)]
        [Description("قیمت پایه ورق")]
        public double SheetBasePrice { get; set; }

        [DisplayName("توضیحات"), Display(Order = 4),] 
        [Description("توضیحات مربوط به خرید ورق")]
        public string Description { get; set; } = string.Empty;

        // ─── نام ورق (NotMapped) ─────────────────────────────────────
        [NotMapped]
        [DisplayName("نام ورق")]
        public string SheetName => Sheet.SheetName;

        

        /// <summary>
        /// تاریخ سفارش شمسی - فرمت دقیق: yyyy/MM/dd (مثال: 1404/09/11)
        /// </summary>
        [NotMapped]
        [DisplayName("تاریخ خرید"), Required, Display(Order = 2)]
        public string FaOrderDate
        {
            get => PersianDateHelper1.ToPersianDateString(OrderDate);
            set => OrderDate = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("تاریخ سفارش الزامی است")
                : PersianDateHelper1.ParsePersianDate(value);
        }




        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



        // 🆕 ─── ستون‌های نمایشی (Pre...) که از جدول Sheet خوانده می‌شوند (NotMapped) ─────
        // اینها قیمت‌های مرجع فعلی هستند که در جدول Sheet ذخیره شده‌اند

        [NotMapped]
        [DisplayName("کامل قبلی"),
            Display(Order = 6),
            ReadOnly(true),
            DisplayFormat(DataFormatString = "n0"),
            Range(1, 999999999)]
        [Description("Sheet.SheetPrice")]
        // خواندن از شیء مرتبط Sheet
        public double PreSheetPrice => Sheet?.SheetPrice ?? 0;

        [NotMapped]
        [DisplayName("تکه قبلی"),
            Display(Order = 8),
            ReadOnly(true),
            DisplayFormat(DataFormatString = "n0"),
            Range(1, 999999999)]
        [Description("Sheet.PicesPrice")]
        // خواندن از شیء مرتبط Sheet
        public double PrePicesPrice => Sheet?.PicesPrice ?? 0;




        // ────────────────────────────────────────────────────────────────────────────

        // 🆕 ─── ستون‌های محاسباتی جدید (NotMapped) ────────────────────────────────────

        [NotMapped]
        [DisplayName("کامل جدید"),
            Required(ErrorMessage = "وارد کردن {0} الزامی است."), Display(Order = 5),
            DisplayFormat(DataFormatString = "n0", ApplyFormatInEditMode = true),
            Range(1, 999999999)]
        [Description("SheetBasePrice * 1.25")]
        public double NewSheetPrice => SheetBasePrice * 1.15;

        [NotMapped]
        [DisplayName("تکه جدید"),
            Required(ErrorMessage = "وارد کردن {0} الزامی است."), Display(Order = 7),
            DisplayFormat(DataFormatString = "n0", ApplyFormatInEditMode = true),
            Range(1, 999999999)]
        [Description("SheetBasePrice * 1.25")]
        public double NewPicesPrice => SheetBasePrice * 1.25;
        // ────────────────────────────────────────────────────────────────────────────


        [NotMapped]
        [DisplayName("کامل جدید"),
            Required(ErrorMessage = "وارد کردن {0} الزامی است."), Display(Order = 5),
            DisplayFormat(DataFormatString = "n0", ApplyFormatInEditMode = true),
            Range(1, 999999999)]
        [Description("SheetBasePrice * 1.25")]
        public double NewSheetPrice1
        {
            get => Sheet?.SheetPrice ?? 0;
            set
            {
                if (Sheet != null)
                    Sheet.SheetPrice = value;
            }
        }


        
    }
}
