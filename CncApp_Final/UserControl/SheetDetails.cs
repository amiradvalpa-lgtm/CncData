using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.DataAccess.Native.Json;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.UserControl
{
    public partial class SheetDetails : DevExpress.XtraEditors.XtraUserControl
    {


        [Browsable(true)]
        [Bindable(true)]
        [DefaultValue(null)]
        public object Material
        {
            get
            {
                // چک می‌کنیم که آیا کنترل لود شده است یا نه تا از خطا جلوگیری شود
                return lkpMaterial != null ? lkpMaterial.EditValue : null;
            }
            set
            {
                if (lkpMaterial != null)
                {
                    lkpMaterial.EditValue = value;
                }
            }
        }

        [Browsable(true)]
        [Bindable(true)]
        [DefaultValue(null)]
        public object Thickness
        {
            get
            {
                // چک می‌کنیم که آیا کنترل لود شده است یا نه تا از خطا جلوگیری شود
                return txbThickness != null ? txbThickness.EditValue : null;
            }
            set
            {
                if (txbThickness != null)
                {
                    txbThickness.EditValue = value;
                }
            }
        }


        [Browsable(true)]
        [Bindable(true)]
        [DefaultValue(null)]
        public object Width
        {
            get
            {
                // چک می‌کنیم که آیا کنترل لود شده است یا نه تا از خطا جلوگیری شود
                return txbWidth != null ? txbWidth.EditValue : null;
            }
            set
            {
                if (txbWidth != null)
                {
                    txbWidth.EditValue = value;
                }
            }
        }


        [Browsable(true)]
        [Bindable(true)]
        [DefaultValue(null)]
        public object Length
        {
            get
            {
                // چک می‌کنیم که آیا کنترل لود شده است یا نه تا از خطا جلوگیری شود
                return txbLength != null ? txbLength.EditValue : null;
            }
            set
            {
                if (txbLength != null)
                {
                    txbLength.EditValue = value;
                }
            }
        }


        AppDbContext context;
        List<Sheet> sheets;


        public SheetDetails()
        {
            InitializeComponent();
        }

        private void SheetDetails_Load(object sender, EventArgs e)
        {
            context = new AppDbContext();
            ControlExraInit.InitLookupEdit(lkpMaterial);
        }

        public void LoadDataBaseSheet()
        {
            sheets = context.Sheets.ToList();
            LoadMaterials();
        }

        void LoadMaterials()
        {
            var materials = sheets
                .Select(x => x.Material)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            lkpMaterial.Properties.DataSource = materials;
        }

        bool ExistsSame(Sheet Sheet, bool ShowAlert)
        {
            bool isSame = context.Sheets.Any(x =>
                x.Material == Sheet.Material &&
                x.Thickness == Sheet.Thickness &&
                x.Length == Sheet.Length &&
                x.Width == Sheet.Width &&
                x.Id != Sheet.Id
            );
            if (isSame && ShowAlert)
            {
                XtraMessageBox.Show(
                    "ورق دیگری با همین   ( مشخصات ورق )   وجود دارد.\n\n" +
                    "داشتن دو رکورد مشابه مجاز نیست.  لطفاً مشخصات ورق را اصلاح کنید.",
                    "ورق تکراری",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            }
            return  isSame;
        }


        private void SheetDetails_Leave(object sender, EventArgs e)
        {
            var bs = this.DataBindings[0].BindingManagerBase;
            Sheet currentSheet = bs?.Current as Sheet;
            if (currentSheet == null)
                return;

            Sheet currentSheetDetails = new Sheet
            {
                Material = lkpMaterial.EditValue.ToString(),
                Thickness = (double)txbThickness.EditValue,
                Width = (double)txbWidth.EditValue,
                Length = (double)txbLength.EditValue,
                Id = currentSheet.Id
            };
            if (ExistsSame(currentSheetDetails, true))
            {
                groupControl5.Appearance.BorderColor = Color.Red;
                groupControl5.Appearance.Options.UseBorderColor = true;
                lkpMaterial.Focus();
                return;
            }
            else
            {
                groupControl5.Appearance.BorderColor = Color.FromName("0");
                groupControl5.Appearance.Options.UseBorderColor = false;
            }




            // مرحله ۱: غیرفعال کردن بروزرسانی خودکار کنترل‌ها از سمت دیتاسورس
            // این کار باعث می‌شود وقتی دیتاسورس تغییر کرد، مقادیر قدیمی روی کنترل‌های دیگر بازنویسی نشوند
            foreach (System.Windows.Forms.Binding binding in this.DataBindings)
            {
                binding.ControlUpdateMode = ControlUpdateMode.Never;
            }

            // مرحله ۲: ثبت تمام مقادیر از کنترل‌ها به دیتاسورس
            foreach (System.Windows.Forms.Binding binding in this.DataBindings)
            {
                binding.WriteValue();
            }

            // مرحله ۳: فعال کردن مجدد بروزرسانی خودکار
            // این مرحله ضروری است تا بعداً اگر دیتاسورس از جای دیگری تغییر کرد، کنترل‌ها آپدیت شوند
            foreach (System.Windows.Forms.Binding binding in this.DataBindings)
            {
                binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            }
        }
    }
}
