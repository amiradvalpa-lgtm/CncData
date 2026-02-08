using CncApp_Final.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CncApp_Final.TempFrm
{
    public class PersianDateTextEdit : XtraUserControl
    {
        private readonly TextEdit textEdit;
        private readonly DXErrorProvider errorProvider;

        private bool _maskEnabled;
        private bool _isValid;
        private DateTime? _gregorianDate;
        private string _errorText;

        public PersianDateTextEdit()
        {
            textEdit = new TextEdit();
            textEdit.Dock = DockStyle.Fill;

            textEdit.EditValueChanged += TextEdit_EditValueChanged;
            textEdit.Validating += TextEdit_Validating;

            Controls.Add(textEdit);

            errorProvider = new DXErrorProvider();
            errorProvider.ContainerControl = this;
        }

        // -----------------------------
        // PUBLIC PROPERTIES
        // -----------------------------

        [Browsable(true)]
        public override string Text
        {
            get { return Convert.ToString(textEdit.EditValue); }
            set
            {
                textEdit.EditValue = value;
                ValidateInternal();
            }
        }

        [Browsable(false)]
        public bool IsValid
        {
            get { return _isValid; }
        }

        [Browsable(false)]
        public string ErrorText
        {
            get { return _errorText; }
        }

        [Browsable(false)]
        public DateTime? GregorianDate
        {
            get { return _gregorianDate; }
        }

        /// <summary>
        /// فعال/غیرفعال کردن ماسک
        /// </summary>
        public bool MaskEnabled
        {
            get { return _maskEnabled; }
            set
            {
                _maskEnabled = value;

                if (_maskEnabled)
                {
                    textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                    textEdit.Properties.Mask.EditMask = "\\d{4}/\\d{2}/\\d{2}";
                    textEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                else
                {
                    textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                    textEdit.Properties.Mask.EditMask = null;
                }
            }
        }

        // -----------------------------
        // EVENTS
        // -----------------------------

        public event EventHandler ValidationStateChanged;

        private void OnValidationStateChanged()
        {
            if (ValidationStateChanged != null)
                ValidationStateChanged(this, EventArgs.Empty);
        }

        // -----------------------------
        // VALIDATION
        // -----------------------------

        private void TextEdit_EditValueChanged(object sender, EventArgs e)
        {
            ValidateInternal();
        }

        private void TextEdit_Validating(object sender, CancelEventArgs e)
        {
            ValidateInternal();
            e.Cancel = !_isValid;
        }

        private void ValidateInternal()
        {
            string value = Convert.ToString(textEdit.EditValue);

            if (string.IsNullOrWhiteSpace(value))
            {
                _isValid = true;
                _gregorianDate = null;
                _errorText = null;
                errorProvider.SetError(textEdit, null);
                OnValidationStateChanged();
                return;
            }

            DateTime dt;
            string err;

            // 👇 مهم: این تابع قبلاً در پروژه شما هست
            // bool PersianDate.TryParse(string text, out DateTime dt, out string error)

            bool ok = PersianDate.TryParse(value, out dt, out err);

            if (ok)
            {
                _isValid = true;
                _gregorianDate = dt;
                _errorText = null;
                errorProvider.SetError(textEdit, null);
            }
            else
            {
                _isValid = false;
                _gregorianDate = null;
                _errorText = err;
                errorProvider.SetError(textEdit, err);
            }

            OnValidationStateChanged();
        }
    }
}
