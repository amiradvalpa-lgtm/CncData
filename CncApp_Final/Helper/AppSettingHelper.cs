using CncApp_Final.Data;      // DbContext پروژه تو
using CncApp_Final.Entities;  // کلاس AppSetting
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CncApp_Final.Helper
{
    #region ENUM
    public enum AppSettingKey
    {

        [DefaultValue("1")]
        [Description ("ورق پیشفرض در فرم سفارش جدید و انبار")]
        DefoultSheetId = 0
    }
    #endregion

    #region SETTINGS MANAGER
    public static class AppSettingsHelper
    {
        public static T Get<T>(AppSettingKey key)
        {
            var keyName = key.ToString();

            using (var db = new AppDbContext()) // <-- جایگزین کن با DbContext واقعی پروژه
            {
                var setting = db.AppSettings.FirstOrDefault(x => x.Key == keyName);

                if (setting == null)
                {
                    var defaultValue = GetEnumDefaultValue(key);
                    Set(key, defaultValue);
                    return (T)Convert.ChangeType(defaultValue, typeof(T), CultureInfo.InvariantCulture);
                }

                return (T)Convert.ChangeType(setting.Value, typeof(T), CultureInfo.InvariantCulture);
            }
        }

        public static void Set(AppSettingKey key, object value)
        {
            var keyName = key.ToString();

            using (var db = new AppDbContext()) // <-- جایگزین کن با DbContext واقعی پروژه
            {
                var setting = db.AppSettings.FirstOrDefault(x => x.Key == keyName);

                if (setting == null)
                {
                    setting = new AppSetting
                    {
                        Key = keyName
                    };
                    db.AppSettings.Add(setting);
                }

                setting.Value = value?.ToString();
                setting.UpdatedAt = DateTime.Now;
                setting.Description = key.GetType()
                         .GetField(key.ToString())
                         .GetCustomAttribute<DescriptionAttribute>()
                         ?.Description;
                db.SaveChanges();
            }
        }

        private static object GetEnumDefaultValue(AppSettingKey key)
        {
            var field = key.GetType().GetField(key.ToString());
            var attr = (DefaultValueAttribute)Attribute.GetCustomAttribute(field, typeof(DefaultValueAttribute));
            return attr?.Value;
        }
    }
    #endregion
}
