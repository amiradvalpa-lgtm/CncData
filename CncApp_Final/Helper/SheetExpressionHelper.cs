using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using System;
using CncApp_Final.Entities;

namespace CncApp_Final.Helper
{

    public static class SheetCalculator
    {
        /// <summary>
        /// محاسبه قیمت ورق کامل و قیمت تکه بر اساس فرمول‌های ذخیره‌شده
        /// </summary>
        /// <param name="sheet">شیء Sheet</param>
        public static void Calculate(Sheet sheet)
        {
            if (sheet == null) throw new ArgumentNullException(nameof(sheet));

            // محاسبه SheetPrice
            if (!string.IsNullOrWhiteSpace(sheet.SheetPriceFormula))
            {
                sheet.SheetPrice = EvaluateFormula<double>(sheet.SheetPriceFormula, sheet);
            }
            else
            {
                sheet.SheetPrice = 0;
            }

            // محاسبه PicesPrice (بعد از اولی، چون ممکنه وابسته باشه)
            if (!string.IsNullOrWhiteSpace(sheet.PicesPriceFormula))
            {
                sheet.PicesPrice = EvaluateFormula<double>(sheet.PicesPriceFormula, sheet);
            }
            else
            {
                sheet.PicesPrice = 0;
            }
        }

        private static T EvaluateFormula<T>(string formula, object source)
        {
            try
            {
                CriteriaOperator op = CriteriaOperator.Parse(formula);

                // دقیقاً همون روشی که خودت گفتی و در داکیومنت توصیه شده
                var contextDescriptor = new EvaluatorContextDescriptorDefault(source.GetType());
                var evaluator = new ExpressionEvaluator(contextDescriptor, op);

                object result = evaluator.Evaluate(source);

                if (result is T typedResult)
                    return typedResult;

                // اگر نتیجه string یا چیز دیگه باشه، سعی در تبدیل کن
                if (typeof(T) == typeof(double) && double.TryParse(result?.ToString(), out double d))
                    return (T)(object)d;

                return default(T);
            }
            catch
            {
                // در صورت خطا در فرمول (سینتکس اشتباه، تقسیم بر صفر و ...)
                return default(T);
            }
        }
    }
}
////using System;
////using System.ComponentModel;
////using System.Linq;
////using System.Reflection;
////using System.Windows.Forms;
////using DevExpress.Data.Filtering;
////using DevExpress.Data.Filtering.Helpers;
////using DevExpress.Data.Controls.ExpressionEditor;
////using CncApp_Final.Entities;

////namespace CncApp_Final.Helper
////{
////    public enum SheetFormulaType
////    {
////        SheetPrice,
////        PiecePrice
////    }

////    public static class SheetExpressionHelper
////    {
////        public static void ShowExpressionEditor(Sheet sheet, SheetFormulaType type)
////        {
////            // ۱. استخراج فرمول فعلی
////            string formula = string.Empty;
////            if (type == SheetFormulaType.SheetPrice)
////            {
////                formula = sheet.SheetPriceFormula ?? string.Empty;
////            }
////            else
////            {
////                formula = sheet.PicesPriceFormula ?? string.Empty;
////            }

////            // ۲. ایجاد کانتکست (ستون‌ها)
////            var context = CreateContext();

////            // ۳. ایجاد کنترل بصری برای حل مشکل عدم نمایش
////            // در نسخه 25.1، این کنترل اینترفیس IExpressionEditorView را پیاده‌سازی می‌کند
////            using (var editorControl = new DevExpress.XtraEditors.Design.ExpressionEditorFormEx()
////            {
////                // اختصاص کانتکست به کنترل
////                editorControl.Context = context;

////                // ۴. فراخوانی متد اصلی با پاس دادن کنترل به عنوان View
////                // حالا دِواکسپرس یک "ظرف" برای رندر کردن فرم دارد
////                bool isOk = ExpressionEditorUIHelper.RunExpressionEditor(ref formula, editorControl, context);

////                // ۵. ذخیره در صورت تایید (OK)
////                if (isOk)
////                {
////                    if (type == SheetFormulaType.SheetPrice)
////                        sheet.SheetPriceFormula = formula;
////                    else
////                        sheet.PicesPriceFormula = formula;
////                }
////            }
////        }

////        public static double? Evaluate(Sheet sheet, SheetFormulaType type)
////        {
////            string formula = string.Empty;
////            if (type == SheetFormulaType.SheetPrice)
////            {
////                formula = sheet.SheetPriceFormula;
////            }
////            else
////            {
////                formula = sheet.PicesPriceFormula;
////            }

////            if (string.IsNullOrWhiteSpace(formula))
////                return null;

////            try
////            {
////                CriteriaOperator op = CriteriaOperator.Parse(formula);
////                var descriptor = new EvaluatorContextDescriptorDefault(typeof(Sheet));
////                var evaluator = new ExpressionEvaluator(descriptor, op);

////                object result = evaluator.Evaluate(sheet);

////                // رفع خطای CS8957: تبدیل صریح برای سازگاری با C# 7.3
////                if (result == null || result == DBNull.Value)
////                {
////                    return (double?)null;
////                }

////                return Convert.ToDouble(result);
////            }
////            catch
////            {
////                return (double?)null;
////            }
////        }

////        private static ExpressionEditorContext CreateContext()
////        {
////            var context = new ExpressionEditorContext();
////            var props = typeof(Sheet).GetProperties()
////                .Where(p => p.PropertyType == typeof(double) ||
////                            p.PropertyType == typeof(int) ||
////                            p.PropertyType == typeof(decimal));

////            foreach (var p in props)
////            {
////                var col = new ColumnInfo();
////                col.Name = p.Name;

////                var attr = p.GetCustomAttribute<DisplayNameAttribute>();
////                if (attr != null)
////                {
////                    // در نسخه 25.1 برای نمایش نام فارسی در لیست درختی
////                    col.Description = attr.DisplayName;
////                }
////                context.Columns.Add(col);
////            }
////            return context;
////        }
////    }
////}


//////using System;
//////using System.ComponentModel;
//////using System.Linq;
//////using System.Reflection;
//////using System.Windows.Forms;
//////using DevExpress.Data.Filtering;
//////using DevExpress.Data.Filtering.Helpers;
//////using DevExpress.Data.Controls.ExpressionEditor;
//////using DevExpress.XtraEditors.Design;
//////using CncApp_Final.Entities;

//////namespace CncApp_Final.Helper
//////{
//////    public enum SheetFormulaType
//////    {
//////        SheetPrice,
//////        PiecePrice
//////    }

//////    public static class SheetExpressionHelper
//////    {
//////        public static void ShowExpressionEditor(Sheet sheet, SheetFormulaType type)
//////        {
//////            // ۱. تعیین فرمول فعلی
//////            string currentFormula = type == SheetFormulaType.SheetPrice
//////                ? (sheet.SheetPriceFormula ?? string.Empty)
//////                : (sheet.PicesPriceFormula ?? string.Empty);

//////            // ۲. ساخت کانتکست
//////            var context = CreateContext();

//////            // ۳. استفاده از Launcher (روش استاندارد Standalone در نسخه های جدید)
//////            // پارامتر اول: Owner (می‌تواند null باشد یا Form.ActiveForm)
//////            // پارامتر دوم: کانتکست شامل ستون‌ها
//////            // پارامتر سوم: فرمول فعلی
//////            var result = ExpressionEditorLauncher.Show(null, context, currentFormula);

//////            // ۴. اگر نتیجه null نباشد یعنی کاربر OK زده است
//////            if (result != null)
//////            {
//////                if (type == SheetFormulaType.SheetPrice)
//////                    sheet.SheetPriceFormula = result;
//////                else
//////                    sheet.PicesPriceFormula = result;
//////            }
//////        }

//////        public static double? Evaluate(Sheet sheet, SheetFormulaType type)
//////        {
//////            string formula = type == SheetFormulaType.SheetPrice
//////                ? sheet.SheetPriceFormula
//////                : sheet.PicesPriceFormula;

//////            if (string.IsNullOrWhiteSpace(formula)) return null;

//////            try
//////            {
//////                CriteriaOperator op = CriteriaOperator.Parse(formula);
//////                var descriptor = new EvaluatorContextDescriptorDefault(typeof(Sheet));
//////                var evaluator = new ExpressionEvaluator(descriptor, op);

//////                object result = evaluator.Evaluate(sheet);
//////                return result != null ? Convert.ToDouble(result) : null;
//////            }
//////            catch
//////            {
//////                return null;
//////            }
//////        }

//////        private static ExpressionEditorContext CreateContext()
//////        {
//////            var context = new ExpressionEditorContext();

//////            var props = typeof(Sheet).GetProperties()
//////                .Where(p => p.PropertyType == typeof(double) ||
//////                            p.PropertyType == typeof(int) ||
//////                            p.PropertyType == typeof(decimal));

//////            foreach (var p in props)
//////            {
//////                var col = new ColumnInfo();
//////                col.Name = p.Name;

//////                // برای نمایش نام فارسی در لیست ادیتور
//////                var attr = p.GetCustomAttribute<DisplayNameAttribute>();
//////                if (attr != null)
//////                {
//////                    // در نسخه 25.1 معمولاً از Name برای نگاشت استفاده می‌شود
//////                    // اما اگر می‌خواهید کپشن متفاوتی داشته باشید:
//////                    // col.Description = attr.DisplayName;
//////                }

//////                context.Columns.Add(col);
//////            }

//////            return context;
//////        }
//////    }
//////}

////////using CncApp_Final.Entities;
////////using DevExpress.Data.Controls.ExpressionEditor;
////////using DevExpress.Data.Filtering;
////////using DevExpress.Data.Filtering.Helpers;
////////using DevExpress.XtraEditors.Design;
////////using DevExpress.XtraEditors.ExpressionEditor;
////////using System;
////////using System.ComponentModel;
////////using System.Linq;
////////using System.Reflection;
////////using System.Windows.Forms;

////////namespace CncApp_Final.Helper
////////{
////////    public enum SheetFormulaType
////////    {
////////        SheetPrice,
////////        PiecePrice
////////    }

////////    public static class SheetExpressionHelper
////////    {
////////        /// <summary>
////////        /// نمایش Expression Editor به صورت مستقل طبق تیکت T479782
////////        /// </summary>
////////        public static void ShowExpressionEditor(Sheet sheet, SheetFormulaType type)
////////        {
////////            // ۱. تعیین فرمول فعلی
////////            string currentFormula = type == SheetFormulaType.SheetPrice
////////                ? (sheet.SheetPriceFormula ?? string.Empty)
////////                : (sheet.PicesPriceFormula ?? string.Empty);

////////            // ۲. ساخت کانتکست (این بخش حیاتی است)
////////            var context = CreateContext();

////////            // ۳. استفاده از کلاس کمکی برای اجرای ادیتور (متد صحیح در نسخه های جدید)
////////            // این متد تمام پیچیدگی های نمایش فرم را مدیریت می کند
////////            string result = ExpressionEditorHelper.RunExpressionEditor(ref currentFormula, context);

////////            // ۴. اگر کاربر تایید کرد، مقدار ذخیره شود
////////            if (result != null)
////////            {
////////                if (type == SheetFormulaType.SheetPrice)
////////                    sheet.SheetPriceFormula = result;
////////                else
////////                    sheet.PicesPriceFormula = result;
////////            }
////////        }

////////        /// <summary>
////////        /// ارزیابی فرمول بر اساس مقادیر موجود در کلاس Sheet
////////        /// </summary>
////////        public static double? Evaluate(Sheet sheet, SheetFormulaType type)
////////        {
////////            string formula = type == SheetFormulaType.SheetPrice
////////                ? sheet.SheetPriceFormula
////////                : sheet.PicesPriceFormula;

////////            if (string.IsNullOrWhiteSpace(formula)) return null;

////////            try
////////            {
////////                // استفاده از موتور داخلی برای محاسبه
////////                CriteriaOperator op = CriteriaOperator.Parse(formula);
////////                var descriptor = new EvaluatorContextDescriptorDefault(typeof(Sheet));
////////                var evaluator = new ExpressionEvaluator(descriptor, op);

////////                object result = evaluator.Evaluate(sheet);
////////                return result != null ? Convert.ToDouble(result) : null;
////////            }
////////            catch
////////            {
////////                return null; // در صورت خطا در فرمول
////////            }
////////        }

////////        private static ExpressionEditorContext CreateContext()
////////        {
////////            // ایجاد کانتکست برای معرفی فیلدها به ادیتور
////////            var context = new ExpressionEditorContext();

////////            // گرفتن پراپرتی های عددی کلاس Sheet
////////            var props = typeof(Sheet).GetProperties()
////////                .Where(p => p.PropertyType == typeof(double) ||
////////                            p.PropertyType == typeof(int) ||
////////                            p.PropertyType == typeof(decimal));

////////            foreach (var p in props)
////////            {
////////                // ساخت ستون اطلاعاتی برای ادیتور
////////                var col = new ColumnInfo();
////////                col.Name = p.Name;

////////                // خواندن DisplayName برای نمایش نام فارسی در لیست ادیتور
////////                var attr = p.GetCustomAttribute<DisplayNameAttribute>();
////////                // در ورژن های جدید کپشن از طریق فیلد Description یا سیستم کانتکست هندل می شود
////////                // اما Name برای موتور محاسبه گر الزامی است

////////                context.Columns.Add(col);
////////            }

////////            return context;
////////        }
////////    }
////////}

//////////using CncApp_Final.Entities;
//////////using DevExpress.Data.Controls.ExpressionEditor;
//////////using DevExpress.Data.Filtering;
//////////using DevExpress.Data.Filtering.Helpers;
//////////using DevExpress.XtraEditors.Design;
//////////using DevExpress.XtraEditors.ExpressionEditor;
//////////using System;
//////////using System.Collections.Generic;
//////////using System.ComponentModel;
//////////using System.Linq;
//////////using System.Reflection;
//////////using System.Windows.Forms;

//////////namespace CncApp_Final.Helper
//////////{
//////////    public enum SheetFormulaType
//////////    {
//////////        SheetPrice,
//////////        PiecePrice
//////////    }

//////////    public static class SheetExpressionHelper
//////////    {
//////////        /// <summary>
//////////        /// نمایش Expression Editor بدون نیاز به فرم‌های پیچیده
//////////        /// </summary>
//////////        public static void ShowExpressionEditor(Sheet sheet, SheetFormulaType type)
//////////        {
//////////            // ۱. دریافت فرمول فعلی
//////////            string currentFormula = type == SheetFormulaType.SheetPrice
//////////                ? (sheet.SheetPriceFormula ?? string.Empty)
//////////                : (sheet.PicesPriceFormula ?? string.Empty);

//////////            // ۲. ساخت کانتکست برای شناسایی ستون‌ها
//////////            var context = CreateContext();

//////////            // ۳. فراخوانی متد استاندارد DevExpress برای نمایش فرم
//////////            // این متد در نسخه 25.1 به خوبی کار می‌کند و خودش فرم را مدیریت می‌کند
//////////            var result = ExpressionEditorHelper.ShowExpressionEditor(currentFormula, context);

//////////            // ۴. اگر کاربر OK زد و فرمول تغییر کرد، ذخیره شود
//////////            if (result != null)
//////////            {
//////////                if (type == SheetFormulaType.SheetPrice)
//////////                    sheet.SheetPriceFormula = result;
//////////                else
//////////                    sheet.PicesPriceFormula = result;
//////////            }
//////////        }

//////////        /// <summary>
//////////        /// ارزیابی فرمول و بازگرداندن مقدار عددی
//////////        /// </summary>
//////////        public static double? Evaluate(Sheet sheet, SheetFormulaType type)
//////////        {
//////////            string formula = type == SheetFormulaType.SheetPrice
//////////                ? sheet.SheetPriceFormula
//////////                : sheet.PicesPriceFormula;

//////////            if (string.IsNullOrWhiteSpace(formula)) return null;

//////////            try
//////////            {
//////////                // پارس کردن فرمول به اپراتور
//////////                CriteriaOperator op = CriteriaOperator.Parse(formula);

//////////                // استفاده از دیسکریپتور کلاس Sheet برای شناسایی فیلدها
//////////                var descriptor = new EvaluatorContextDescriptorDefault(typeof(Sheet));
//////////                var evaluator = new ExpressionEvaluator(descriptor, op);

//////////                // اجرای محاسبه روی نمونه (Instance) فعلی شیت
//////////                object result = evaluator.Evaluate(sheet);
//////////                return result != null ? Convert.ToDouble(result) : null;
//////////            }
//////////            catch
//////////            {
//////////                // در صورت خطا در فرمول نویسی توسط کاربر، null برمی‌گرداند
//////////                return null;
//////////            }
//////////        }

//////////        private static ExpressionEditorContext CreateContext()
//////////        {
//////////            var context = new ExpressionEditorContext();

//////////            // استخراج ویژگی‌های عددی کلاس Sheet
//////////            var props = typeof(Sheet).GetProperties()
//////////                .Where(p => p.PropertyType == typeof(double) ||
//////////                            p.PropertyType == typeof(int) ||
//////////                            p.PropertyType == typeof(decimal));

//////////            foreach (var p in props)
//////////            {
//////////                // استخراج نام فارسی از DisplayNameAttribute
//////////                var displayNameAttr = p.GetCustomAttribute<DisplayNameAttribute>();
//////////                string caption = displayNameAttr != null ? displayNameAttr.DisplayName : p.Name;

//////////                // در نسخه 25.1، ColumnInfo سازنده ندارد و باید از این روش ست شود
//////////                var col = new ColumnInfo();
//////////                col.Name = p.Name;
//////////                // نکته: در نسخه‌های جدید کپشن مستقیماً از دیتا سورس یا کانتکست هندل می‌شود

//////////                context.Columns.Add(col);
//////////            }

//////////            return context;
//////////        }
//////////    }
//////////}




//////////using System;
//////////using System.Collections.Generic;
//////////using System.ComponentModel;
//////////using System.Linq;
//////////using System.Linq.Expressions;
//////////using System.Reflection;
//////////using DevExpress.Data.Controls.ExpressionEditor;
//////////using CncApp_Final.Entities;
//////////using System;
//////////using System.Windows.Forms;
//////////using DevExpress.Data.Controls.ExpressionEditor;


//////////namespace CncApp_Final.Helper
//////////{

//////////    //public class ExpressionEditorForm : Form
//////////    //{
//////////    //    private ExpressionEditorControl editorControl;
//////////    //    public string Expression { get; private set; }

//////////    //    public ExpressionEditorForm(ExpressionEditorContext context, string initialExpression)
//////////    //    {
//////////    //        this.Text = "ویرایش فرمول";
//////////    //        this.Width = 600;
//////////    //        this.Height = 400;

//////////    //        editorControl = new ExpressionEditorControl();
//////////    //        editorControl.Dock = DockStyle.Fill;
//////////    //        editorControl.Context = context;
//////////    //        editorControl.Expression = initialExpression;

//////////    //        var btnOk = new Button { Text = "OK", Dock = DockStyle.Bottom, Height = 30 };
//////////    //        btnOk.Click += (s, e) => { this.Expression = editorControl.Expression; this.DialogResult = DialogResult.OK; };

//////////    //        var btnCancel = new Button { Text = "Cancel", Dock = DockStyle.Bottom, Height = 30 };
//////////    //        btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; };

//////////    //        this.Controls.Add(editorControl);
//////////    //        this.Controls.Add(btnOk);
//////////    //        this.Controls.Add(btnCancel);
//////////    //    }
//////////    //}

//////////    public enum SheetFormulaType
//////////    {
//////////        SheetPrice,
//////////        PicesPrice
//////////    }

//////////    public static class SheetExpressionHelper
//////////    {
//////////        // نمایش Expression Editor DevExpress
//////////        public static void ShowExpressionEditor(Sheet sheet, SheetFormulaType type)
//////////        {
//////////            string formula = type == SheetFormulaType.SheetPrice
//////////                ? sheet.SheetPriceFormula
//////////                : sheet.PicesPriceFormula;

//////////            var context = CreateExpressionEditorContext();

//////////            var parent = System.Windows.Forms.Form.ActiveForm;
//////////            if (ExpressionEditorUIHelper.RunExpressionEditor(ref formula, null, context))
//////////            {
//////////                if (type == SheetFormulaType.SheetPrice)
//////////                    sheet.SheetPriceFormula = formula;
//////////                else
//////////                    sheet.PicesPriceFormula = formula;
//////////            }
//////////        }

//////////        // Evaluate با C# Expression
//////////        public static double? Evaluate(Sheet sheet, SheetFormulaType type)
//////////        {
//////////            string formula = type == SheetFormulaType.SheetPrice
//////////                ? sheet.SheetPriceFormula
//////////                : sheet.PicesPriceFormula;

//////////            if (string.IsNullOrWhiteSpace(formula))
//////////                return null;

//////////            try
//////////            {
//////////                var values = sheet.GetType().GetProperties()
//////////                    .Where(p => p.PropertyType == typeof(double))
//////////                    .ToDictionary(p => p.Name, p => (double)p.GetValue(sheet));

//////////                var lambda = CompileFormula(formula, values.Keys.ToArray());
//////////                return lambda(values);
//////////            }
//////////            catch
//////////            {
//////////                return null;
//////////            }
//////////        }


//////////        // ==== Helpers ====

//////////        //private static ExpressionEditorContext CreateExpressionEditorContext()
//////////        //{
//////////        //    var ctx = new ExpressionEditorContext();

//////////        //    foreach (var p in typeof(Sheet).GetProperties())
//////////        //    {
//////////        //        if (p.PropertyType == typeof(double))
//////////        //        {
//////////        //            var name = p.Name;
//////////        //            var caption = p.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? name;

//////////        //            ctx.Columns.Add(new ColumnInfo(name));
//////////        //            ctx.CustomColumnDisplayName[name] = caption;
//////////        //        }
//////////        //    }

//////////        //    return ctx;
//////////        //}
//////////        private static ExpressionEditorContext CreateExpressionEditorContext()
//////////        {
//////////            var ctx = new ExpressionEditorContext();

//////////            foreach (var p in typeof(Sheet).GetProperties())
//////////            {
//////////                if (p.PropertyType == typeof(double))
//////////                {
//////////                    ctx.Columns.Add(new ColumnInfo(p.Name));
//////////                }
//////////            }

//////////            return ctx;
//////////        }



//////////        // Compile C# expression
//////////        private static Func<Dictionary<string, double>, double> CompileFormula(string expr, string[] vars)
//////////        {
//////////            var param = Expression.Parameter(typeof(Dictionary<string, double>), "v");
//////////            Expression body = null;

//////////            foreach (var token in expr.Split(new[] { '+', '-', '*', '/', '(', ')' }))
//////////            {
//////////                if (vars.Contains(token.Trim()))
//////////                {
//////////                    var keyExpr = Expression.Property(param, "Item", Expression.Constant(token.Trim()));
//////////                    body = body == null ? keyExpr : body;
//////////                }
//////////            }

//////////            var lambda = Expression.Lambda<Func<Dictionary<string, double>, double>>(body, param);
//////////            return lambda.Compile();
//////////        }
//////////    }
//////////}
