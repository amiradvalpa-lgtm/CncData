using CncApp_Final.Data;
using CncApp_Final.Entities;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CncApp_Final.Helpers
{
    public static class GridLayoutHelper
    {
        /// <summary>
        /// بارگذاری Layout گرید با استفاده از یک Context ایزوله
        /// </summary>
        public static void LoadLayout(
            GridView gridView,
            int userId,
            string formName)
        {
            if (gridView == null) return;

            try
            {
                // استفاده از using برای بستن خودکار اتصال و پاکسازی حافظه
                using (var db = new AppDbContext())
                {
                    var layout = db.UserGridLayouts
                        .AsNoTracking() // برای سرعت بیشتر و عدم اشغال حافظه کش
                        .FirstOrDefault(x => x.UserId == userId && x.GridName == formName);

                    if (layout != null && !string.IsNullOrWhiteSpace(layout.LayoutXml))
                    {
                        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(layout.LayoutXml)))
                        {
                            gridView.RestoreLayoutFromStream(stream);
                        }
                    }
                }
            }
            catch
            {
                // لود نشدن لایوت نباید مانع باز شدن فرم شود
            }
        }

        /// <summary>
        /// ذخیره Layout گرید بدون تاثیر روی اطلاعات ذخیره نشده فرم
        /// </summary>
        public static void SaveLayout(
            GridView gridView,
            int userId,
            string formName)
        {
            if (gridView == null) return;

            try
            {
                string layoutXml;
                using (var stream = new MemoryStream())
                {
                    // تنظیمات اختیاری برای سبک‌تر شدن فایل XML
                    gridView.OptionsLayout.StoreAllOptions = false;
                    gridView.SaveLayoutToStream(stream);
                    layoutXml = Encoding.UTF8.GetString(stream.ToArray());
                }

                using (var db = new AppDbContext())
                {
                    var entity = db.UserGridLayouts
                        .FirstOrDefault(x => x.UserId == userId && x.GridName == formName);

                    if (entity == null)
                    {
                        db.UserGridLayouts.Add(new UserGridLayout
                        {
                            UserId = userId,
                            GridName = formName,
                            LayoutXml = layoutXml,
                            LastUpdated = DateTime.Now
                        });
                    }
                    else
                    {
                        entity.LayoutXml = layoutXml;
                        entity.LastUpdated = DateTime.Now;
                    }

                    db.SaveChanges(); // فقط لایوت ذخیره می‌شود چون Context اختصاصی است
                }
            }
            catch
            {
                // خطا در ذخیره لایوت نباید مانع بسته شدن فرم شود
            }
        }
    }
}