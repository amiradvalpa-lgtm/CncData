using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncApp_Final.Helper
{
    public static class TextEditHelper
    {
        /// <summary>
        /// هر TextEdit رو به فیلد مبلغ با جداکننده هزارگان و کلمه "تومان" تبدیل می‌کنه
        /// استفاده: textEdit1.AsToman();
        /// </summary>
        public static void AsToman(this TextEdit textEdit)
        {
            // اگر قبلاً اعمال شده، دوباره اعمال نکن
            if (textEdit.Tag is true) return;
            textEdit.Tag = true;

            // تنظیمات فرمت نمایش و ویرایش
            textEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            textEdit.Properties.DisplayFormat.FormatString = "n0";

            textEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            textEdit.Properties.EditFormat.FormatString = "n0";

            // راست‌چین و فارسی (خیلی مهم برای ظاهر زیبا)
            textEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            textEdit.Properties.Appearance.Options.UseTextOptions = true;
            textEdit.Properties.Appearance.TextOptions.RightToLeft = true;

            // وقتی وارد کنترل می‌شه → فقط عدد خالی نشون بده
            textEdit.Enter += (s, e) =>
            {
                var txt = (TextEdit)s;
                txt.Text = GetOnlyNumber(txt.Text);
                txt.SelectionStart = txt.Text.Length; // کرسر آخر
            };

            // وقتی خارج می‌شه → فرمت کامل با کاما و تومان
            textEdit.Leave += (s, e) =>
            {
                var txt = (TextEdit)s;
                txt.Text = GetWithToman(txt.Text);
                txt.SelectionStart = txt.Text.IndexOf(" تومان");
            };

            // اولین بار هم فرمت کن (اگر مقدار اولیه داره)
            textEdit.Text = GetWithToman(textEdit.Text);
        }

        private static string GetOnlyNumber(string text)
        {
            return string.IsNullOrWhiteSpace(text)
                ? ""
                : new string(text.Where(char.IsDigit).ToArray());
        }

        private static string GetWithToman(string text)
        {
            var clean = GetOnlyNumber(text);
            if (string.IsNullOrEmpty(clean)) return "0 تومان";

            if (long.TryParse(clean, out long number))
                return $"{number:N0} تومان";

            return "0 تومان";
        }
    }
}
