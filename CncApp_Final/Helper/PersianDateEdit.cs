using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.ComponentModel;
using System.Globalization;

namespace CncApp_Final.Helper
{
    [UserRepositoryItem("Register")]
    public class RepositoryItemPersianDateEdit : RepositoryItemTextEdit
    {
        public const string EditorName = "PersianDateEdit";

        static RepositoryItemPersianDateEdit() { Register(); }

        public RepositoryItemPersianDateEdit()
        {
            // 1. تنظیم ماسک برای ورودی عددی
            this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.Mask.EditMask = "1300/00/00";
            this.Mask.UseMaskAsDisplayFormat = false;

            // 2. استفاده از رویدادها برای تبدیل دوطرفه
            this.FormatEditValue += OnFormatEditValue;
            this.ParseEditValue += OnParseEditValue;

            // جلوگیری از به هم ریختگی راست به چپ
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
        }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName,
                typeof(PersianDateEdit), typeof(RepositoryItemPersianDateEdit),
                typeof(TextEditViewInfo), new TextEditPainter(), true));
        }

        public override string EditorTypeName => EditorName;

        // موقع نمایش: DateTime میلادی -> String شمسی
        private void OnFormatEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is DateTime dt && dt != DateTime.MinValue)
            {
                PersianCalendar pc = new PersianCalendar();
                e.Value = $"{pc.GetYear(dt):0000}/{pc.GetMonth(dt):00}/{pc.GetDayOfMonth(dt):00}";
                e.Handled = true;
            }
        }

        // موقع ذخیره/تغییر: String شمسی -> DateTime میلادی
        private void OnParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value == null || string.IsNullOrWhiteSpace(e.Value.ToString()))
            {
                e.Value = DBNull.Value;
                e.Handled = true;
                return;
            }

            string val = e.Value.ToString().Replace("_", "");
            if (val.Length < 10) return; // هنوز تاریخ کامل نشده

            try
            {
                var parts = val.Split('/');
                if (parts.Length == 3)
                {
                    PersianCalendar pc = new PersianCalendar();
                    int y = int.Parse(parts[0]);
                    int m = int.Parse(parts[1]);
                    int d = int.Parse(parts[2]);
                    e.Value = pc.ToDateTime(y, m, d, 0, 0, 0, 0);
                    e.Handled = true;
                }
            }
            catch
            {
                // اگر تاریخ نامعتبر بود (مثلا 31 فوریه)
                e.Value = DBNull.Value;
                e.Handled = true;
            }
        }
    }

    [ToolboxItem(true)]
    public class PersianDateEdit : TextEdit
    {
        static PersianDateEdit() { RepositoryItemPersianDateEdit.Register(); }
        public override string EditorTypeName => RepositoryItemPersianDateEdit.EditorName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemPersianDateEdit Properties => base.Properties as RepositoryItemPersianDateEdit;
    }
}