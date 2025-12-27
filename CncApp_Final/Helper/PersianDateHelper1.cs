using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncApp_Final.Helper
{
    public static class PersianDateHelper1
    {
        // ─── متدهای کمکی تبدیل تاریخ (فقط عددی yyyy/MM/dd) ─────────────────
        public static string ToPersianDateString(DateTime date)
        {
            var pc = new PersianCalendar();
            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);
            return $"{year:0000}/{month:00}/{day:00}";
        }

        public static DateTime ParsePersianDate(string persianDate)
        {
            string cleaned = persianDate.Replace('-', '/').Replace('\\', '/').Trim();
            var parts = cleaned.Split('/');
            if (parts.Length != 3 ||
                !int.TryParse(parts[0], out int year) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int day))
            {
                throw new ArgumentException($"فرمت تاریخ شمسی صحیح نیست: '{persianDate}' — فرمت مورد قبول: yyyy/MM/dd (مثال: 1404/09/11)");
            }

            if (year < 1300 || year > 1500 || month < 1 || month > 12 || day < 1 || day > 31)
                throw new ArgumentException($"تاریخ شمسی خارج از محدوده معتبر است: {persianDate}");

            var pc = new PersianCalendar();
            return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
        }
    }
}
