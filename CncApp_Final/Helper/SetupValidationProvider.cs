using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CncApp_Final.Helper
{
    /// <summary>
    /// کلاس کمکی برای تنظیم خودکار DXValidationProvider بر اساس Data Annotations.
    /// این کلاس برای اجرای اعتبارسنجی در زمان کلیک دکمه Save/OK استفاده می‌شود.
    /// </summary>
    public static class DxValidationHelper
    {
        /// <summary>
        /// به صورت بازگشتی تمام کنترل‌های روی فرم را بازیابی می‌کند.
        /// </summary>
        private static IEnumerable<Control> GetAllControls(Control container)
        {
            yield return container;
            foreach (Control c in container.Controls)
            {
                foreach (Control child in GetAllControls(c))
                {
                    yield return child;
                }
            }
        }

        /// <summary>
        /// DXValidationProvider را برای تمام کنترل‌های بایند شده به یک نوع Model (Entity/ViewModel) خاص تنظیم می‌کند.
        /// </summary>
        /// <typeparam name="TModel">نوع کلاس Entity یا ViewModel (مانند Order یا OrderDetails)</typeparam>
        /// <param name="form">فرم فعال که حاوی کنترل‌ها است (معمولاً this)</param>
        /// <param name="validationProvider">نمونه DXValidationProvider روی فرم</param>
        /// <param name="bindingSource">BindingSource که به TModel بایند شده است.</param>
        public static void SetupValidation<TModel>(
            Form form,
            DXValidationProvider validationProvider,
            BindingSource bindingSource) where TModel : class
        {
            if (validationProvider == null || bindingSource == null) return;

            //validationProvider.ClearValidations();
            Type modelType = typeof(TModel);

            // بازیابی تمام کنترل‌های بایند شده از فرم
            var boundControls = GetAllControls(form)
                                .OfType<BaseEdit>()
                                .Where(c => c.DataBindings.Count > 0);

            
            foreach (BaseEdit control in boundControls)
            {
                // یافتن Binding مرتبط با Model Type
                Binding binding = control.DataBindings.Cast<Binding>()
                                                    .FirstOrDefault(b => b.BindingMemberInfo.BindingField != null &&
                                                                         b.DataSource == bindingSource);

                if (binding == null) continue;

                string propertyName = binding.BindingMemberInfo.BindingField;
                PropertyInfo property = modelType.GetProperty(propertyName);

                if (property == null) continue;

                // استخراج نام نمایشی (DisplayName) برای پیام‌های خطا
                string displayName = property.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? propertyName;


                // 1. اعمال قوانین Required (اجباری)
                var requiredAttr = property.GetCustomAttribute<RequiredAttribute>();
                if (requiredAttr != null)
                {
                    string errorMessage = requiredAttr.ErrorMessage.Replace("{0}", displayName);

                    // الف) قانون برای کلیدهای خارجی (Id)
                    if (property.PropertyType == typeof(int) && propertyName.EndsWith("Id"))
                    {
                        // چک کردن برای مقدار 0 (انتخاب نشده)
                        ConditionValidationRule fkRule = new ConditionValidationRule
                        {
                            ConditionOperator = ConditionOperator.Greater,
                            Value1 = 0,
                            ErrorText = $"انتخاب {displayName} الزامی است.",
                            ErrorType = ErrorType.Critical
                        };
                        validationProvider.SetValidationRule(control, fkRule);
                    }
                    // ب) قانون برای رشته‌ها و سایر انواع
                    else
                    {
                        ConditionValidationRule requiredRule = new ConditionValidationRule
                        {
                            ConditionOperator = ConditionOperator.IsNotBlank,
                            ErrorText = errorMessage,
                            ErrorType = ErrorType.Critical
                        };
                        validationProvider.SetValidationRule(control, requiredRule);
                    }
                }

                // 2. اعمال قوانین Range (محدوده عددی)
                var rangeAttr = property.GetCustomAttribute<RangeAttribute>();
                if (rangeAttr != null)
                {
                    // اگر Range برای Non-Negative (مثلاً >= 0) استفاده شده باشد
                    if (rangeAttr.Minimum is double minVal && (minVal.Equals(0.0) || minVal.Equals(0.001)))
                    {
                        ConditionValidationRule nonNegativeRule = new ConditionValidationRule
                        {
                            ConditionOperator = (minVal.Equals(0.0)) ? ConditionOperator.GreaterOrEqual : ConditionOperator.Greater,
                            Value1 = minVal,
                            ErrorText = $"مقدار {displayName} نمی‌تواند منفی باشد.",
                            ErrorType = ErrorType.Warning
                        };
                        // باید اطمینان حاصل کنیم که قانون قبلی (Required) را بازنویسی نمی‌کنیم، بلکه آن را اضافه می‌کنیم.
                        validationProvider.SetValidationRule(control, nonNegativeRule);
                    }
                    // Note: اگر Range پیچیده‌تری نیاز بود، باید ConditionOperator را گسترش داد.
                }

                
            }

            // اضافه کردن قانون مخصوص PersianDateTextEdit
            var persianDateTextEditBoundControls = GetAllControls(form)
                                .OfType<PersianDateTextEdit>()
                                .Where(c => c.DataBindings.Count > 0);


            foreach (var control in persianDateTextEditBoundControls)
            {
                validationProvider.SetValidationRule(control.InnerTextEdit, new PersianDateValidationRule());
            }

        }
    }
}