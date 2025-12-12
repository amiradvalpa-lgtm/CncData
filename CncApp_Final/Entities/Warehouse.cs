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
        [Description("ورق انتخاب شده برای سفارش")]
        public int SheetId { get; set; }

        [DisplayName("ورق")]
        [Description("ورق مربوط به سفارش")]
        public virtual Sheet Sheet { get; set; }

        [DisplayName("تاریخ خرید")]
        [Description("تاریخ خرید")]
        public DateTime OrderDate { get; set; }
            

        [DisplayName("قیمت پایه کامل"),
            Required, Display(Order = 3),
            DataType(DataType.Custom), Range(1, 1000000000)]
        [Description("قیمت پایه ورق")]
        public double SheetBasePrice { get; set; }

        [DisplayName("توضیحات"), Display(Order = 4),Required(AllowEmptyStrings = false)] 
        [Description("توضیحات مربوط به خرید ورق")]
        public string Description { get; set; }

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
            get => PersianDateHelper.ToPersianDateString(OrderDate);
            set => OrderDate = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("تاریخ سفارش الزامی است")
                : PersianDateHelper.ParsePersianDate(value);
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
            DataType(DataType.Custom), Range(1, 1000000000)]
        [Description("Sheet.SheetPrice")]
        // خواندن از شیء مرتبط Sheet
        public double PreSheetPrice => Sheet.SheetPrice;

        [NotMapped]
        [DisplayName("تکه قبلی"),
            Display(Order = 8),
            ReadOnly(true),
            DisplayFormat(DataFormatString = "n0"),
            DataType(DataType.Custom), Range(1, 1000000000)]
        [Description("Sheet.PicesPrice")]
        // خواندن از شیء مرتبط Sheet
        public double PrePicesPrice => Sheet.PicesPrice;




        // ────────────────────────────────────────────────────────────────────────────

        // 🆕 ─── ستون‌های محاسباتی جدید (NotMapped) ────────────────────────────────────

        [NotMapped]
        [DisplayName("کامل جدید"),
            Required, Display(Order = 5),
            DisplayFormat(DataFormatString = "n0", ApplyFormatInEditMode = true),
            DataType(DataType.Custom), Range(1, 1000000000)]
        [Description("SheetBasePrice * 1.25")]
        public double NewSheetPrice => SheetBasePrice * 1.25;

        [NotMapped]
        [DisplayName("تکه جدید"),
            Required, Display(Order = 7),
            DisplayFormat(DataFormatString = "n0", ApplyFormatInEditMode = true),
            DataType(DataType.Custom), Range(1, 1000000000)]
        [Description("SheetBasePrice * 1.15")]
        public double NewPicesPrice => SheetBasePrice * 1.15;
        // ────────────────────────────────────────────────────────────────────────────


        //[Required(AllowEmptyStrings = false)]
    }
}
