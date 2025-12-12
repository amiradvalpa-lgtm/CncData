using System;
using System.Globalization;

namespace CncApp_Final.Helper
{
    public static class CalendarHelper
    {
        // نمونه‌های تقویم برای استفاده
        private static readonly PersianCalendar pc = new PersianCalendar();
        private static readonly GregorianCalendar gc = new GregorianCalendar();

        /// <summary>
        /// تبدیل تاریخ میلادی (DateTime) به رشته تاریخ شمسی (YYYY/MM/DD).
        /// </summary>
        /// <param name="dateTime">تاریخ میلادی ورودی.</param>
        /// <returns>رشته تاریخ شمسی در فرمت YYYY/MM/DD.</returns>
        public static string ToPersianDate(DateTime dateTime)
        {
            try
            {
                int year = pc.GetYear(dateTime);
                int month = pc.GetMonth(dateTime);
                int day = pc.GetDayOfMonth(dateTime);

                // فرمت کردن به صورت YYYY/MM/DD
                return $"{year:0000}/{month:00}/{day:00}";
            }
            catch (Exception)
            {
                return ""; // در صورت خطا، رشته خالی برمی‌گرداند
            }
        }

        /// <summary>
        /// تبدیل رشته تاریخ شمسی (YYYY/MM/DD) به تاریخ میلادی (DateTime).
        /// </summary>
        /// <param name="persianDate">رشته تاریخ شمسی ورودی (مثال: 1404/09/11).</param>
        /// <returns>تاریخ میلادی معادل.</returns>
        public static DateTime ToGregorianDate(string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
            {
                return DateTime.MinValue;
            }

            try
            {
                string[] parts = persianDate.Split('/', '-');

                if (parts.Length != 3)
                {
                    // اگر فرمت صحیح نبود، خطا یا تاریخ حداقل برمی‌گردد
                    throw new FormatException("فرمت تاریخ شمسی نامعتبر است. (انتظار YYYY/MM/DD)");
                }

                int year = int.Parse(parts[0]);
                int month = int.Parse(parts[1]);
                int day = int.Parse(parts[2]);

                // تبدیل تاریخ شمسی به میلادی
                // توجه: اگر تاریخ غیرمعتبری وارد شود (مثل 1404/30/15)، این خط استثنا پرتاب می‌کند.
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (Exception)
            {
                // در صورت خطا در تبدیل یا فرمت، تاریخ حداقل برمی‌گردد.
                return DateTime.MinValue;
            }
        }
    }
}