using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CncApp_Final.Helper
{
    public partial class PersianDateTextEdit : XtraUserControl
    {
        private static readonly PersianCalendar pc = new PersianCalendar();
        private DateTime? _value;

        public TextEdit InnerTextEdit
        {
            get { return textEdit1; }
        }

        //public Font Font
        //{
        //    get { return textEdit1.Font; }
        //    set { textEdit1.Font = value; }
        //}

        public PersianDateTextEdit()
        {
            InitializeComponent();

            textEdit1.EditValueChanged += TextEdit1_EditValueChanged;
            textEdit1.ErrorImageOptions.Alignment = ErrorIconAlignment.MiddleRight;
        }

        // ===================== EditValue =====================
        [Bindable(true)]
        public DateTime? EditValue
        {
            get { return _value; }
            set
            {
                _value = value;
                UpdateTextFromValue();
                OnEditValueChanged(EventArgs.Empty);
            }
        }

        public event EventHandler EditValueChanged;

        protected virtual void OnEditValueChanged(EventArgs e)
        {
            if (EditValueChanged != null)
                EditValueChanged(this, e);
        }

        // ===================== MASK =====================
        private bool _useMask = true;

        [DefaultValue(true)]
        public bool UseMask
        {
            get { return _useMask; }
            set
            {
                _useMask = value;
                ApplyMask();
            }
        }

        private void ApplyMask()
        {
            if (_useMask)
            {
                textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
                textEdit1.Properties.Mask.EditMask = "0000/00/00";
                textEdit1.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
            else
            {
                textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            }
        }

        // ===================== TEXT HANDLING =====================
        private void UpdateTextFromValue()
        {
            if (_value == null)
            {
                textEdit1.EditValue = "";
                return;
            }

            var d = _value.Value;
            textEdit1.EditValue =
                string.Format("{0:0000}/{1:00}/{2:00}",
                    pc.GetYear(d),
                    pc.GetMonth(d),
                    pc.GetDayOfMonth(d));
        }

        private void TextEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string txt = Convert.ToString(textEdit1.EditValue);

            if (string.IsNullOrWhiteSpace(txt))
            {
                _value = null;
                OnEditValueChanged(EventArgs.Empty);
                return;
            }

            DateTime dt;
            string err;

            if (TryParsePersian(txt, out dt, out err))
            {
                _value = dt;
                OnEditValueChanged(EventArgs.Empty);
            }
            else
            {
                // مقدار اشتباه وارد شده ولی Exception نده
                // فقط همون متن بمونه و Value تغییر نکنه
            }
        }

        // ===================== PARSE =====================
        private bool TryParsePersian(string persianDate,
                                     out DateTime result,
                                     out string error)
        {
            result = default(DateTime);
            error = null;

            persianDate = persianDate.Replace('-', '/').Replace('\\', '/').Trim();

            var parts = persianDate.Split('/');
            int y, m, d;

            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out y) ||
                !int.TryParse(parts[1], out m) ||
                !int.TryParse(parts[2], out d))
            {
                error = "فرمت صحیح نیست. مثال: 1403/07/05";
                return false;
            }

            if (y < 1300 || y > 1500)
            {
                error = "سال معتبر نیست.";
                return false;
            }

            if (m < 1 || m > 12)
            {
                error = "ماه بین 1 تا 12 باشد.";
                return false;
            }

            int maxDay =
                m <= 6 ? 31 :
                m <= 11 ? 30 :
                pc.IsLeapYear(y) ? 30 : 29;

            if (d < 1 || d > maxDay)
            {
                error = string.Format("روز {0} برای ماه {1} معتبر نیست. حداکثر {2}", d, m, maxDay);
                return false;
            }

            result = pc.ToDateTime(y, m, d, 0, 0, 0, 0);
            return true;
        }

        private void PersianDateTextEdit_FontChanged(object sender, EventArgs e)
        {
            textEdit1.Font = Font;
        }

        private void textEdit1_SizeChanged(object sender, EventArgs e)
        {
            Size = textEdit1.Size;
        }

        private void textEdit1_RightToLeftChanged(object sender, EventArgs e)
        {

        }
    }
}
