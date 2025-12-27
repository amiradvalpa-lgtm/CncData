using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Forms;

namespace CncApp_Final.Helper
{
    // ================= PersianDate TYPE ======================
    [TypeConverter(typeof(PersianDateConverter))]
    public struct PersianDate
    {
        private static readonly PersianCalendar pc = new PersianCalendar();
        private readonly DateTime _gregorian;


        public PersianDate(DateTime dateTime)
        {
            _gregorian = dateTime;
        }

        public DateTime GregorianDate { get { return _gregorian; } }

        public int Year { get { return pc.GetYear(_gregorian); } }
        public int Month { get { return pc.GetMonth(_gregorian); } }
        public int Day { get { return pc.GetDayOfMonth(_gregorian); } }

        public override string ToString()
        {
            return string.Format("{0:0000}/{1:00}/{2:00}", Year, Month, Day);
        }

        // ---------------- Parse ----------------
        public static PersianDate Parse(string persianDate)
        {
            DateTime dt;
            string error;

            if (!TryParse(persianDate, out dt, out error))
                throw new ValidationException(error);

            return new PersianDate(dt);
        }

        public static bool TryParse(string persianDate, out PersianDate result)
        {
            DateTime dt;
            string err;

            if (TryParse(persianDate, out dt, out err))
            {
                result = new PersianDate(dt);
                return true;
            }

            result = default(PersianDate);
            return false;
        }

        public static bool TryParse(string persianDate,
                                    out DateTime result,
                                    out string errorMessage)
        {
            result = default(DateTime);
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(persianDate))
            {
                errorMessage = "تاریخ وارد نشده است";
                return false;
            }

            string cleaned = persianDate
                .Replace('-', '/')
                .Replace('\\', '/')
                .Trim();

            var parts = cleaned.Split('/');
            int year, month, day;

            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out year) ||
                !int.TryParse(parts[1], out month) ||
                !int.TryParse(parts[2], out day))
            {
                errorMessage = "فرمت تاریخ صحیح نیست. فرمت معتبر: yyyy/MM/dd مثال: 1404/07/05";
                return false;
            }

            if (year < 1300 || year > 1500)
            {
                errorMessage = "سال باید بین 1300 تا 1500 باشد.";
                return false;
            }

            if (month < 1 || month > 12)
            {
                errorMessage = "ماه باید بین 1 تا 12 باشد.";
                return false;
            }

            int maxDay =
                month <= 6 ? 31 :
                month <= 11 ? 30 :
                pc.IsLeapYear(year) ? 30 : 29;

            if (day < 1 || day > maxDay)
            {
                errorMessage = string.Format(
                    "روز '{0}' برای ماه '{1:00}' معتبر نیست. حداکثر روز این ماه {2} است.",
                    day, month, maxDay);
                return false;
            }

            result = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            return true;
        }

        // implicit کنارش می‌ذاریم تا راحت به DateTime تبدیل شه
        public static implicit operator DateTime(PersianDate p)
        {
            return p._gregorian;
        }

        public static implicit operator PersianDate(DateTime d)
        {
            return new PersianDate(d);
        }
    }

    // ================= TYPE CONVERTER ======================
    public class PersianDateConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
                                           CultureInfo culture,
                                           object value)
        {
            if (value is string)
                return PersianDate.Parse((string)value);

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context,
                                         CultureInfo culture,
                                         object value,
                                         Type destinationType)
        {
            if (destinationType == typeof(string) && value is PersianDate)
                return value.ToString();

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    // ================= DATA ANNOTATION ======================
    public class PersianDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (value is string)
            {
                DateTime dt;
                string err;

                if (PersianDate.TryParse((string)value, out dt, out err))
                    return ValidationResult.Success;

                return new ValidationResult(err);
            }

            return new ValidationResult("فرمت ورودی تاریخ صحیح نیست");
        }
    }

    //public class PersianDateValidationRule : ValidationRule
    //{
    //    public override bool Validate(Control control, object value)
    //    {
    //        string text = Convert.ToString(value);
    //        DateTime dt;
    //        string error;

    //        bool ok = PersianDate.TryParse(text, out dt, out error);

    //        if (!ok)
    //            this.ErrorText = error;

    //        return ok;
    //    }
    //}

    //public class PersianDateValidationRule : ValidationRule
    //{
    //    public override bool Validate(Control control, object value)
    //    {
    //        string text = Convert.ToString(value);

    //        if (string.IsNullOrWhiteSpace(text))
    //        {
    //            // اجازه می‌دهد خالی باشد، Required جداگانه تعریف شود
    //            return true;
    //        }

    //        DateTime dt;
    //        string err;

    //        bool ok = PersianDate.TryParse(text, out dt, out err);

    //        if (!ok)
    //        {
    //            this.ErrorText = err; // پیام دقیق فارسی
    //        }
    //        else
    //        {
    //            this.ErrorText = null; // پاک کردن پیام وقتی درست شد
    //        }

    //        return ok;
    //    }
    //}

    public class PersianDateValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            string text = Convert.ToString(value);

            if (string.IsNullOrWhiteSpace(text))
            {
                // اجازه می‌دهد خالی باشد، Required جداگانه تعریف شود
                this.ErrorText = null; // پاک کردن پیام قبلی
                this.ErrorType = ErrorType.None;     // <--- مهم
                return true;
            }

            DateTime dt;
            string err;

            bool ok = PersianDate.TryParse(text, out dt, out err);

            if (!ok)
            {
                this.ErrorText = err; // پیام دقیق فارسی
                this.ErrorType = ErrorType.Critical; // یا Warning/User طبق سلیقه
            }
            else
            {
                this.ErrorText = null; // پاک کردن پیام و آیکن وقتی درست شد
                this.ErrorType = ErrorType.None;     // <--- خیلی مهم برای پاک شدن آیکن
            }

            return ok;
        }
    }




}

