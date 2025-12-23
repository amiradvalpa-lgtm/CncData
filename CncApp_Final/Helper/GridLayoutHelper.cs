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
        /// بارگذاری Layout گرید از دیتابیس
        /// </summary>
        public static void LoadLayout(
            AppDbContext db,
            GridView gridView,
            int userId,
            string formName)
        {
            if (gridView == null) return;

            string gridName = formName; // طبق خواسته شما

            var layout = db.UserGridLayouts
                .FirstOrDefault(x =>
                    x.UserId == userId &&
                    x.GridName == gridName);

            if (layout == null || string.IsNullOrWhiteSpace(layout.LayoutXml))
                return;

            try
            {
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(layout.LayoutXml)))
                {
                    gridView.RestoreLayoutFromStream(stream);
                }
            }
            catch
            {
                // اگر XML خراب بود، بی‌صدا رد می‌شیم
            }
        }

        /// <summary>
        /// ذخیره Layout گرید در دیتابیس
        /// </summary>
        public static void SaveLayout(
            AppDbContext db,
            GridView gridView,
            int userId,
            string formName)
        {
            if (gridView == null) return;

            string gridName = formName;

            string layoutXml;
            using (var stream = new MemoryStream())
            {
                gridView.SaveLayoutToStream(stream);
                layoutXml = Encoding.UTF8.GetString(stream.ToArray());
            }

            var entity = db.UserGridLayouts
                .FirstOrDefault(x =>
                    x.UserId == userId &&
                    x.GridName == gridName);

            if (entity == null)
            {
                entity = new UserGridLayout
                {
                    UserId = userId,
                    GridName = gridName,
                    LayoutXml = layoutXml,
                    LastUpdated = DateTime.Now
                };
                db.UserGridLayouts.Add(entity);
            }
            else
            {
                entity.LayoutXml = layoutXml;
                entity.LastUpdated = DateTime.Now;
            }

            db.SaveChanges();
        }
    }
}
