using CncApp_Final.Data;
using CncApp_Final.Entities;
using DevExpress.XtraExport.Implementation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using SD = System.Drawing;
using WF = System.Windows.Forms;

namespace CncApp_Final.Helper
{
    // =================
    // واحدهای اندازه‌گیری طول برای تبدیل از اینچ
    // =================
    public enum LengthUnit
    {
        Meter,       // متر
        Centimeter,  // سانتی‌متر
        Millimeter,  // میلی‌متر
        Inch         // اینچ (برای موارد خاص یا پیش‌فرض)
    }

    /// =================
    /// اطلاعات یک شیت/ورق برش CNC استخراج شده از فایل CorelDRAW
    /// هر گروه در لایه CNC که شامل دو کرو (CutCNC و FrameCnc) است،
    /// به یک نمونه از این کلاس تبدیل می‌شود.
    /// طول‌ها به واحد سانتی‌متر هستند.
    /// =================
    public class CorelSheetInfo
    {
        /// =================
        /// طول مسیر برش (CutCNC) به سانتی‌متر
        /// =================
        [Display(Name = "طول مسیر برش (cm)")]
        [Description("طول کل منحنی/مسیر CutCNC به سانتی‌متر")]
        public double CutLength { get; set; }

        /// =================
        /// طول خارجی فریم/چارچوب قطعه (FrameCnc) به سانتی‌متر
        /// =================
        [Display(Name = "طول فریم (cm)")]
        [Description("طول خارجی ابجکت FrameCnc (طول قطعه) به سانتی‌متر")]
        public double FrameLength { get; set; }

        /// =================
        /// عرض خارجی فریم/چارچوب قطعه (FrameCnc) به سانتی‌متر
        /// =================
        [Display(Name = "عرض فریم (cm)")]
        [Description("عرض خارجی ابجکت FrameCnc (عرض قطعه) به سانتی‌متر")]
        public double FrameWidth { get; set; }

        /// =================
        /// نوع متریال (MDF، پلکسی، فلز و ...)
        /// استخراج شده از قسمت اول نام گروه (قبل از -)
        /// =================
        [Display(Name = "متریال")]
        [Description("نوع متریال ورق (از نام گروه استخراج می‌شود)")]
        public string Material { get; set; } = string.Empty;

        /// =================
        /// ضخامت ورق به میلی‌متر
        /// استخراج شده از قسمت دوم نام گروه
        /// =================
        [Display(Name = "ضخامت (mm)")]
        [Description("ضخامت ورق به میلی‌متر (از نام گروه استخراج می‌شود)")]
        public double Thickness { get; set; }

        /// =================
        /// منبع ورق: انبار شرکت یا متعلق به مشتری
        /// a/A → انبار    m/M → مشتری
        /// استخراج شده از قسمت سوم نام گروه
        /// =================
        [Display(Name = "منبع ورق")]
        [Description("انبار یا مشتری - بر اساس حرف a یا m در نام گروه")]
        public SupplierType Supplier { get; set; }
    }



    /// =================
    /// کلاس کمکی static برای ارتباط با CorelDRAW
    /// شامل تمام عملیات خواندن، پارس و تبدیل داده از کورل
    /// =================
    public static class CorelHelper
    {
        /// =================
        /// اتصال به نمونه در حال اجرای CorelDRAW
        /// به ترتیب اولویت نسخه‌های مختلف را امتحان می‌کند
        /// در صورت عدم یافتن، استثنا پرتاب می‌کند
        /// =================
        /// <returns>نمونه فعال Application کورل</returns>
        /// <exception cref="Exception">اگر هیچ نسخه‌ای از کورل باز نباشد</exception>
        public static VGCore.Application GetRunningCorel()
        {
            string[] progIds =
            {
                "CorelDRAW.Application.25", // 2024
                "CorelDRAW.Application.24", // 2023 ← نسخه اصلی
                "CorelDRAW.Application.23", // 2022
                "CorelDRAW.Application.22", // 2021
                "CorelDRAW.Application"     // fallback عمومی
            };

            foreach (var id in progIds)
            {
                try
                {
                    var app = (VGCore.Application)Interaction.GetObject("", id);
                    if (app != null)
                        return app;
                }
                catch
                {
                    // بی‌صدا برو سراغ بعدی
                }
            }

            throw new Exception(
                "هیچ نمونه فعالی از CorelDRAW پیدا نشد.\n\n" +
                "بررسی کن:\n" +
                "1- کورل واقعاً باز باشد\n" +
                "2- سطح دسترسی برنامه و کورل یکسان باشد (هر دو Admin یا هر دو معمولی)\n" +
                "3- بیت برنامه با کورل یکی باشد (x64/x86)\n" +
                "4- کورل با /automation اجرا نشده باشد"
            );
        }

        /// =================
        /// تبدیل طول از اینچ به واحد دلخواه
        /// مقادیر دریافتی از کورل همیشه بر حسب اینچ هستند
        /// =================
        /// <param name="inches">مقدار به اینچ</param>
        /// <param name="toUnit">واحد مقصد</param>
        /// <returns>مقدار تبدیل شده به واحد درخواستی</returns>
        /// <exception cref="ArgumentException">اگر مقدار ورودی NaN یا Infinity باشد</exception>
        /// <exception cref="ArgumentOutOfRangeException">اگر واحد ناشناخته باشد</exception>
        public static double ConvertFromInch(double inches, LengthUnit toUnit)
        {
            if (double.IsNaN(inches) || double.IsInfinity(inches))
                throw new ArgumentException("مقدار ورودی معتبر نیست (NaN یا Infinity)", nameof(inches));

            switch (toUnit)
            {
                case LengthUnit.Millimeter: return inches * 25.4;
                case LengthUnit.Centimeter: return inches * 2.54;
                case LengthUnit.Meter: return inches * 0.0254;
                case LengthUnit.Inch: return inches;
                default:
                    throw new ArgumentOutOfRangeException(nameof(toUnit),
                        string.Format("واحد ناشناخته: {0}", toUnit));
            }
        }

        /// =================
        /// بازگرداندن لیست نام تمام اسناد باز در کورل
        /// =================
        /// <returns>لیست نام اسناد باز</returns>
        /// <exception cref="Exception">در صورت عدم اتصال به کورل</exception>
        public static List<string> GetOpenDocuments()
        {
            var result = new List<string>();
            var app = GetRunningCorel();

            foreach (VGCore.Document doc in app.Documents)
                result.Add(doc.Name);

            return result;
        }

        /// =================
        /// بازگرداندن تمام اسناد باز که دارای لایه CNC هستند
        /// برای استفاده در listBoxDocuments فرم
        /// =================
        /// <returns>لیست اسناد دارای لایه CNC</returns>
        public static List<VGCore.Document> GetDocumentsWithCNC()
        {
            var result = new List<VGCore.Document>();
            var app = GetRunningCorel();

            foreach (VGCore.Document doc in app.Documents)
            {
                if (DocumentHasCNCLayer(doc))
                    result.Add(doc);
            }

            return result;
        }

        /// =================
        /// بررسی می‌کند آیا سند مورد نظر در هر یک از صفحاتش لایه CNC دارد
        /// =================
        /// <param name="doc">سند کورل برای بررسی</param>
        /// <returns>true اگر حداقل یک صفحه دارای لایه CNC باشد</returns>
        private static bool DocumentHasCNCLayer(VGCore.Document doc)
        {
            try
            {
                foreach (VGCore.Page page in doc.Pages)
                    foreach (VGCore.Layer layer in page.Layers)
                        if (layer.Name.Equals("CNC", StringComparison.OrdinalIgnoreCase))
                            return true;
            }
            catch { }
            return false;
        }

        /// =================
        /// بازگرداندن تمام گروه‌های معتبر لایه CNC از تمام صفحات یک سند
        /// گروه‌هایی که نام نامعتبر دارند در لیست نمی‌آیند
        /// خطاهای نام نامعتبر جمع‌آوری و یک‌جا نمایش داده می‌شوند
        /// =================
        /// <param name="doc">سند کورل برای پردازش</param>
        /// <returns>لیست گروه‌های معتبر از تمام صفحات</returns>
        public static List<VGCore.Shape> GetAllCNCGroups(VGCore.Document doc)
        {
            var result = new List<VGCore.Shape>();
            var invalidNames = new List<string>();

            try
            {
                foreach (VGCore.Page page in doc.Pages)
                {
                    VGCore.Layer cncLayer = null;

                    // پیدا کردن لایه CNC در این صفحه
                    foreach (VGCore.Layer layer in page.Layers)
                    {
                        if (layer.Name.Equals("CNC", StringComparison.OrdinalIgnoreCase))
                        {
                            cncLayer = layer;
                            break;
                        }
                    }

                    if (cncLayer == null) continue;

                    // پیمایش اشکال لایه CNC
                    foreach (VGCore.Shape shape in cncLayer.Shapes)
                    {
                        if (shape.Type != VGCore.cdrShapeType.cdrGroupShape)
                            continue;

                        // بررسی اعتبار نام گروه
                        if (IsGroupNameValid(shape.Name))
                            result.Add(shape);
                        else
                            invalidNames.Add(string.Format("صفحه {0} - {1}", page.Index, shape.Name));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در خواندن گروه‌های CNC: " + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // نمایش یکجای خطاهای نام نامعتبر
            if (invalidNames.Count > 0)
            {
                MessageBox.Show(
                    "گروه‌های زیر نام نامعتبر دارند و نادیده گرفته شدند:\n\n" +
                    string.Join("\n", invalidNames),
                    "نام نامعتبر", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return result;
        }

        /// =================
        /// بررسی اعتبار نام گروه بر اساس قوانین فرمت
        /// باید دقیقاً ۳ بخش با جداکننده - داشته باشد
        /// بخش دوم باید عدد قابل Parse باشد
        /// بخش سوم باید a/A یا m/M باشد
        /// =================
        /// <param name="groupName">نام گروه برای بررسی</param>
        /// <returns>true اگر نام معتبر باشد</returns>
        private static bool IsGroupNameValid(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName)) return false;

            var parts = groupName.Split('-');
            if (parts.Length < 3) return false;

            // Trim هر قسمت
            string material = parts[0].Trim();
            string thickness = parts[1].Trim();
            string supplier = parts[2].Trim();

            if (string.IsNullOrEmpty(material)) return false;
            if (!double.TryParse(thickness, out _)) return false;

            string sup = supplier.ToLowerInvariant();
            if (sup != "a" && sup != "m") return false;

            return true;
        }

        /// =================
        /// پارس گروه کورل به CorelSheetInfo
        /// اطلاعات را از نام گروه و اشکال داخلی (CutCNC و FrameCnc) استخراج می‌کند
        /// در صورت خطا، MessageBox نشان می‌دهد و null برمی‌گرداند
        /// =================
        /// <param name="group">گروه کورل برای پارس</param>
        /// <returns>CorelSheetInfo پر شده یا null در صورت خطا</returns>
        public static CorelSheetInfo ParseGroupToSheetInfo(VGCore.Shape group)
        {
            try
            {
                var parts = group.Name.Split('-');
                if (parts.Length < 3)
                {
                    MessageBox.Show("نام گروه نامعتبر است: " + group.Name, "خطا",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                string material = parts[0].Trim();
                string thicknessStr = parts[1].Trim();
                string supplierStr = parts[2].Trim().ToLowerInvariant();

                if (!double.TryParse(thicknessStr, out double thickness))
                {
                    MessageBox.Show("نام گروه نامعتبر است: " + group.Name, "خطا",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                SupplierType supplier = supplierStr == "m" ? SupplierType.Customer : SupplierType.Warehouse;

                // پیدا کردن اشکال CutCNC و FrameCnc داخل گروه
                VGCore.Shape cutCnc = null;
                VGCore.Shape frameCnc = null;

                foreach (VGCore.Shape shape in group.Shapes.All())
                {
                    if (shape.Name.Equals("CutCNC", StringComparison.OrdinalIgnoreCase))
                        cutCnc = shape;
                    else if (shape.Name.Equals("FrameCnc", StringComparison.OrdinalIgnoreCase))
                        frameCnc = shape;
                }

                // محاسبه مقادیر و تبدیل از اینچ به سانتی‌متر
                double cutLength = 0;
                double frameLen = 0;
                double frameWidth = 0;

                if (cutCnc?.Curve != null)
                    cutLength = ConvertFromInch(cutCnc.Curve.Length, LengthUnit.Meter);

                if (frameCnc != null)
                {
                    frameLen = ConvertFromInch(frameCnc.SizeHeight, LengthUnit.Centimeter);
                    frameWidth = ConvertFromInch(frameCnc.SizeWidth, LengthUnit.Centimeter);
                }

                return new CorelSheetInfo
                {
                    Material = material,
                    Thickness = thickness,
                    Supplier = supplier,
                    CutLength = cutLength,
                    FrameLength = frameLen,
                    FrameWidth = frameWidth
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در پارس گروه " + group.Name + ": " + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// =================
        /// تبدیل لیست CorelSheetInfo به لیست OrderDetails
        /// ورق‌های کامل با کلید SheetId+Supplier ادغام می‌شوند
        /// ورق‌های تکه هر کدام رکورد جداگانه دارند
        /// ورق‌های پیدا نشده نادیده گرفته می‌شوند
        /// =================
        /// <param name="sheetInfoList">لیست اطلاعات شیت‌های استخراج شده از کورل</param>
        /// <param name="tolerance">تولرانس مقایسه سایز به سانتی‌متر (پیش‌فرض ±10)</param>
        /// <returns>لیست OrderDetails آماده شده</returns>
        public static List<OrderDetails> ConvertSheetInfoListToOrderDetails(
            List<CorelSheetInfo> sheetInfoList,
            AppDbContext dbContext,
            double tolerance = 10.0)
        {
            // لیست خروجی نهایی
            var result = new List<OrderDetails>();

            // لیست پیام‌های خطا برای ورق‌های پیدا نشده
            var notFoundMessages = new List<string>();

            // لود یک‌باره تمام ورق‌ها از DB
            List<Sheet> allSheets;
            try
            {
                if(dbContext != null )
                    allSheets = dbContext.Sheets.ToList();
                else
                    using (var context = new AppDbContext())
                    {
                        allSheets = context.Sheets.ToList();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در لود ورق‌ها از پایگاه داده:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }

            foreach (var info in sheetInfoList)
            {
                // ─── مرحله ۱: جستجوی ورق بر اساس متریال + ضخامت (case-insensitive) ───
                var matchedSheets = allSheets
                    .Where(s =>
                        s.Material.Equals(info.Material, StringComparison.OrdinalIgnoreCase) &&
                        s.Thickness == info.Thickness)
                    .ToList();

                // حالت ۴: ورق پیدا نشد
                if (matchedSheets.Count == 0)
                {
                    notFoundMessages.Add(string.Format(
                        "متریال: {0} | ضخامت: {1}mm | سایز: {2:F1}×{3:F1} cm",
                        info.Material, info.Thickness, info.FrameLength, info.FrameWidth));
                    continue;
                }

                // ─── مرحله ۲: بررسی تطابق سایز با تولرانس ───
                var fullSheetMatch = matchedSheets.FirstOrDefault(s =>
                    Math.Abs(s.Length - info.FrameLength) <= tolerance &&
                    Math.Abs(s.Width - info.FrameWidth) <= tolerance);

                if (fullSheetMatch != null)
                {
                    // ─── حالت ۱ و ۳: ورق کامل ───
                    // جستجو برای رکورد موجود با کلید SheetId + Supplier
                    var existing = result.FirstOrDefault(od =>
                        od.SheetId == fullSheetMatch.Id &&
                        od.Supplier == info.Supplier);

                    if (existing != null)
                    {
                        // ادغام: فقط SheetCount و GrooveLength آپدیت می‌شوند
                        existing.SheetCount += 1;
                        existing.GrooveLength += info.CutLength;
                        existing.FinalSheetCost += info.Supplier == SupplierType.Warehouse ? fullSheetMatch.SheetPrice : 0;
                        existing.CncCost += fullSheetMatch.CNCPriceBySheet;
                    }
                    else
                    {
                        // رکورد جدید ورق کامل
                        OrderDetails newRocordByFullSheet =
                            new OrderDetails
                            {
                                SheetId = fullSheetMatch.Id,
                                Sheet = fullSheetMatch,
                                Supplier = info.Supplier,
                                SheetCount = 1,
                                CutLength = 0,   // سایز از Sheet موجود است
                                CutWidth = 0,   // سایز از Sheet موجود است
                                GrooveLength = info.CutLength,
                                FinalSheetCost = info.Supplier == SupplierType.Warehouse ? fullSheetMatch.SheetPrice : 0,
                                CncCost = fullSheetMatch.CNCPriceBySheet,
                                Description = string.Empty,
                            };
                        
                        result.Add(newRocordByFullSheet);
                    }
                }
                else
                {
                    // ─── حالت ۲: ورق تکه ───
                    // اگر چند Sheet با متریال+ضخامت یکسان → فعلاً اولین آیتم
                    // TODO: بعداً بر اساس تنظیمات برنامه استراتژی انتخاب تعیین می‌شود
                    var selectedSheet = SelectSheetByStrategy(matchedSheets);

                    // هر ورق تکه رکورد جداگانه دارد
                    result.Add(new OrderDetails
                    {
                        SheetId = selectedSheet.Id,
                        Sheet = selectedSheet,
                        Supplier = info.Supplier,
                        SheetCount = 0,
                        CutLength = info.FrameLength,  // FrameLength → CutLength
                        CutWidth = info.FrameWidth,   // FrameWidth  → CutWidth
                        GrooveLength = info.CutLength,
                        FinalSheetCost = info.Supplier == SupplierType.Warehouse ? selectedSheet.PicesPrice :0,
                        CncCost = selectedSheet.CNCPriceByPice,
                        Description = string.Empty,
                    });
                }
            }

            // نمایش یک‌جای خطاهای ورق پیدا نشده
            if (notFoundMessages.Count > 0)
            {
                MessageBox.Show(
                    "ورق‌هایی با مشخصات زیر در پایگاه داده یافت نشدند:\n\n" +
                    string.Join("\n", notFoundMessages),
                    "ورق پیدا نشد", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return result;
        }

        /// =================
        /// استراتژی انتخاب ورق در صورت وجود چند ورق با متریال و ضخامت یکسان
        /// فعلاً اولین آیتم برگردانده می‌شود
        /// TODO: بعداً بر اساس تنظیمات برنامه (AppSettings) پیاده‌سازی می‌شود
        /// =================
        /// <param name="sheets">لیست ورق‌های با مشخصات یکسان</param>
        /// <returns>ورق انتخاب شده</returns>
        private static Sheet SelectSheetByStrategy(List<Sheet> sheets)
        {
            // TODO: خواندن استراتژی از AppSettings و اعمال آن
            return sheets.First();
        }

        /// =================
        /// گرفتن تصویر پیش‌نمایش گروه از طریق Clipboard کورل
        /// گروه را انتخاب کرده، Copy می‌کند و تصویر را از Clipboard می‌خواند
        /// =================
        /// <param name="group">گروه کورل برای پیش‌نمایش</param>
        /// <returns>تصویر پیش‌نمایش یا null در صورت خطا</returns>
        public static SD.Image GetGroupPreviewByClipboard(VGCore.Shape group)
        {
            try
            {
                var app = GetRunningCorel();
                var doc = app.ActiveDocument;

                doc.ClearSelection();
                group.CreateSelection();
                app.ActiveSelection.Copy();

                if (WF.Clipboard.ContainsImage())
                    return WF.Clipboard.GetImage();

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}