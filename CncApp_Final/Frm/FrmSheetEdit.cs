using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Frm
{
    public partial class FrmSheetEdit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private bool _Save_SuccesFull = false;

        //**********************************************************************
        public int _Record_Id { get; private set; } = 0; // 0 for new Sheet
        public int _NewCreatedRecordtId { get; private set; } = 0; // برای نگهداری شناسه جدید پس از ذخیره
        private readonly bool _IsRecordReadonly = false;

        private AppDbContext _dbContext = new CncApp_Final.Data.AppDbContext();
        private Sheet _currentRecord;

        private readonly Action<int> _reloadCallback;
        //**********************************************************************


        public FrmSheetEdit(int SheetId, bool IsSheetReadonly, Action<int> reloadCallback)
        {
            InitializeComponent();
            _Record_Id = SheetId;
            _IsRecordReadonly = IsSheetReadonly;
            _reloadCallback = reloadCallback;
        }

        private void FrmSheetEdit_Load(object sender, EventArgs e)
        {
            InitData();
            //InitFillMaterial();
            //DxValidationHelper.SetupValidation<Warehouse>(this, dxValidationProvider1, warehousesBindingSource);
            ControlExraInit.ApplyFocusColor(this);
            sheetDetails.LoadDataBaseSheet();
        }


 
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************





        /// <summary>
        /// متد اعتبارسنجی ساده (همیشه True)
        /// </summary>
        private bool IsValid()
        {
            bool isvalid = true;
            
            if (_IsRecordReadonly) // 🆕 جلوگیری از ذخیره در حالت ReadOnly
            {
                XtraMessageBox.Show("فرم در حالت فقط خواندنی است و امکان ذخیره وجود ندارد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isvalid =  false;
            }

            //else if (!dxValidationProvider1.Validate())
            //{
            //    XtraMessageBox.Show("لطفاً اطلاعات ورودی را به درستی تکمیل کنید.", "خطای اعتبارسنجی", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    isvalid =  false;
            //}

            return isvalid;
        }

        /// <summary>
        /// ذخیره اطلاعات Warehouse و به‌روزرسانی Sheet
        /// </summary>
        private bool Save()
        {
            if (IsValid())
            {
                sheetsBindingSource.EndEdit();

                //try
                //{
                //    //dxValidationProvider1.Validate();
                //    sheetsBindingSource.EndEdit();

                //    Sheet currentSheet = sheetsBindingSource.Current as Sheet;
                //    if (currentSheet == null) return false;

                //    bool isNewRecord = currentSheet.Id == 0; //

                    

                //    // 2. اگر رکورد جدید است، آن را به DbSet اضافه کنید
                //    if (currentSheet.Id == 0)
                //    {
                //        _dbContext.Sheets.Add(currentSheet);
                //    }

                //    // 3. ذخیره تغییرات در Database
                //    int affectedRows = _dbContext.SaveChanges();
                //    if (affectedRows > 0)
                //    {
                //        //_New_Row_Id = currentSheet.Id;
                //    }
                //    _Save_SuccesFull = true;
                //    return true;
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show($"خطا در ذخیره‌سازی داده‌ها: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return false;
                //}


                try
                {
                    bool isNew = (_Record_Id == 0);   // 👈 تشخیص جدید/ویرایش
                    _dbContext.SaveChanges();
                    _NewCreatedRecordtId = isNew ? _currentRecord.Id : 0;   // 👈 همین خط مشکل را حل می‌کند
                    _Save_SuccesFull = true;
                    return true;
                }
                catch (DbEntityValidationException dbEx)
                {
                    var errorMessages = dbEx.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");

                    var fullErrorMessage = string.Join(Environment.NewLine, errorMessages);
                    XtraMessageBox.Show($"خطای اعتبارسنجی در هنگام ذخیره:{Environment.NewLine}{fullErrorMessage}", "خطای ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"خطا در هنگام ذخیره سازی: {ex.Message}", "خطای ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return false;
        }

        

        // ─── Event Handlers دکمه‌ها ────────────────────────────────────────────────────────

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                _reloadCallback?.Invoke(_NewCreatedRecordtId);

                XtraMessageBox.Show("ذخیره سازی با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                _reloadCallback?.Invoke(_NewCreatedRecordtId);

                XtraMessageBox.Show("ذخیره سازی با موفقیت انجام شد.", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // آماده سازی برای رسید جدید
                // 1. Detach کردن نمونه قدیمی
                if (_currentRecord != null)
                {
                    _dbContext.Entry(_currentRecord).State = EntityState.Detached;
                    _currentRecord = null;
                }

                _Record_Id = 0; // تنظیم مجدد شناسه به حالت جدید
                InitData();      // بارگذاری داده‌های جدید
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_Record_Id > 0)
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    $"آیا از حذف ورق به مشخصات ( {_currentRecord.SheetName} ) مطمئن هستید؟",
                    "تأیید حذف",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        _dbContext.Sheets.Remove(_currentRecord);
                        _dbContext.SaveChanges();
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"خطا در حذف ورق: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                DialogResult dialogResult = XtraMessageBox.Show(
                    "تغییراتی اعمال شده است. آیا مایل به ذخیره هستید؟",
                    "ذخیره تغییرات",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    if (Save())
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_Record_Id == 0)
            {
                // اگر در حالت ثبت رسید جدید هستیم
                DialogResult dr = XtraMessageBox.Show(
                    "اطلاعات وارد شده پاک شود و فرم به حالت جدید برگردد؟",
                    "بازنشانی",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    // Detach موجودیت فعلی
                    if (_currentRecord != null)
                    {
                        _dbContext.Entry(_currentRecord).State = EntityState.Detached;
                        _currentRecord = null;
                    }

                    InitData();   // فرم را دوباره در حالت New آماده می‌کند
                }

                return;
            }

            // ---- حالت ویرایش (Edit) ----
            DialogResult result = XtraMessageBox.Show(
                "تغییرات انجام شده حذف و اطلاعات اصلی دوباره بارگذاری شود؟",
                "بازنشانی تغییرات",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // موجودیت فعلی را از ردیابی خارج کن
                if (_currentRecord != null)
                {
                    _dbContext.Entry(_currentRecord).State = EntityState.Detached;
                    _currentRecord = null;
                }

                // دوباره لود کن
                _currentRecord = _dbContext.Sheets
                                            .FirstOrDefault(r => r.Id == _Record_Id);

                if (_currentRecord == null)
                {
                    XtraMessageBox.Show("رسید در دیتابیس یافت نشد.",
                        "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sheetsBindingSource.DataSource = _currentRecord;

                XtraMessageBox.Show("تغییرات لغو و اطلاعات اصلی بازیابی شد.",
                    "بازنشانی",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"خطا در بازنشانی: {ex.Message}",
                    "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void FrmWareHouseEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Save_SuccesFull)
            {
                DialogResult = DialogResult.OK;
            }
        }


        //private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    // 1. Detach کردن نمونه فعلی از ردیابی
        //    if (_currentRecord != null)
        //    {
        //        _dbContext.Entry(_currentRecord).State = EntityState.Detached;
        //        _currentRecord = null;
        //    }

        //    // 2. بارگذاری مجدد فرم
        //    InitData();
        //    XtraMessageBox.Show("تغییرات لغو و مقادیر اصلی بازیابی شدند.", "بازنشانی", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //}


        //private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (_IsRecordReadonly)
        //    {
        //        XtraMessageBox.Show("فرم در حالت فقط خواندنی است و امکان حذف وجود ندارد.", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    //Sheet currentSheet = sheetsBindingSource.Current as Sheet;

        //    if (_currentRecord != null && _currentRecord.Id > 0)
        //    {
        //        if (XtraMessageBox.Show("آیا مطمئن هستید که می‌خواهید این مورد را حذف کنید؟", "تأیید حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //        {
        //            // از Local حذف نکنید، مستقیماً از DbContext حذف کنید
        //            _dbContext.Sheets.Remove(_currentRecord);
        //            _dbContext.SaveChanges();

        //            this.DialogResult = DialogResult.OK;
        //            this.Close();
        //        }
        //    }
        //}
        
        //private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    this.Close();
        //}



        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************






        


        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************



        //private void InitFillMaterial()
        //{
        //    this.lkpMaterial.EditValueChanged += new System.EventHandler(this.lkpMaterial_EditValueChanged);
        //    this.lkpThickness.EditValueChanged += new System.EventHandler(this.lkpThickness_EditValueChanged);
        //    this.lkpSheetSize.EditValueChanged += new System.EventHandler(this.lkpSheetSize_EditValueChanged);

        //    FillMaterial();

        //    _sheet = GetSheetInfo(_currentSheet.Id);
        //    lkpMaterial.EditValue = _sheet.Material;
        //    lkpThickness.EditValue = _sheet.Thickness;
        //    lkpSheetSize.EditValue = _sheet.SheetSize;
        //}

        //private Sheet _sheet;
        //private Sheet GetSheetInfo(int sheetId)
        //{
        //    _sheet = _dbContext.Sheets
        //        .FirstOrDefault(s => s.Id == sheetId);
        //    return _sheet;
        //}

        private void InitData()
        {
            ControlExraInit.InitRibonControl(mainRibbonControl, _Record_Id == 0 ? "ورق جدید" : "ویرایش ورق");
            

            _dbContext.Sheets.Load();

            if (_Record_Id > 0)
            {

                // بارگذاری رسید موجود از دیتابیس
                _currentRecord = _dbContext.Sheets.FirstOrDefault(r => r.Id == _Record_Id);

                if (_currentRecord == null)
                {
                    XtraMessageBox.Show("ورق مورد نظر یافت نشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            else
            {
                // ایجاد یک نمونه جدید و اضافه کردن آن به DBContext برای ردیابی (Track)
                _currentRecord = _dbContext.Sheets.Create();
                _dbContext.Sheets.Add(_currentRecord);

                bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never; // حذف برای مورد جدید نمایش داده نشود

                sheetDetails.Focus();
            }
            sheetsBindingSource.DataSource = _currentRecord;

            // 🆕 اعمال تنظیمات ReadOnly
            SetReadOnly(_IsRecordReadonly);

            //lkpSheetId.EditValueChanged += SheetIdLookUpEdit_EditValueChanged;
        }

        /// <summary>
        /// 🆕 تنظیم حالت فقط خواندنی برای تمام کنترل‌ها و دکمه‌های ریبون
        /// </summary>
        private void SetReadOnly(bool readOnly)
        {
            //dataLayoutControl1.OptionsView.IsReadOnly = readOnly;

            // غیرفعال کردن دکمه‌های عملیاتی در ریبون
            bbiSave.Enabled = !readOnly;
            bbiSaveAndClose.Enabled = !readOnly;
            bbiSaveAndNew.Enabled = !readOnly;
            bbiDelete.Enabled = !readOnly;

            // مخفی کردن دکمه‌های مربوط به ذخیره و حذف
            bbiSave.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            bbiSaveAndClose.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            bbiSaveAndNew.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;
            bbiDelete.Visibility = readOnly ? DevExpress.XtraBars.BarItemVisibility.Never : DevExpress.XtraBars.BarItemVisibility.Always;

            // ⚠️ نکته: اگرچه ستون‌های NewSheetPrice و NewPicesPrice در Warehouse.cs به صورت NotMapped هستند، 
            // اما چون در حالت فقط خواندنی (ReadOnly) نباید قابلیت ویرایش داشته باشند، بهتر است ReadOnly بودن را به صورت
            // کلی روی dataLayoutControl1 اعمال کنیم که شامل آن‌ها نیز می‌شود.
        }



        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************



        //**********************************************************************************************************************
        //**********************************************************************************************************************

        
        private void btneSheetPriceFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit btne = sender as ButtonEdit;
            string expression = btne.EditValue.ToString();
            string expressionName = GetDisplayName(btne);
            //expression = "[طول ورق]";

            FrmSheetFormulaEditor frmSheetFormulaEditor = new FrmSheetFormulaEditor(expression, expressionName);
            frmSheetFormulaEditor.ShowDialog(this);
            btne.EditValue = frmSheetFormulaEditor.ExpressionText;
        }

        private void btnePicesPriceFormula_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit btne = sender as ButtonEdit;
            string expression = btne.EditValue.ToString();
            string expressionName = GetDisplayName(btne);
            //expression = "[طول ورق]";

            FrmSheetFormulaEditor frmSheetFormulaEditor = new FrmSheetFormulaEditor(expression, expressionName);
            frmSheetFormulaEditor.ShowDialog(this);
            btne.EditValue = frmSheetFormulaEditor.ExpressionText;
        }

        private string GetDisplayName(ButtonEdit be)
        {
            // گرفتن اولین بایند (مثلاً EditValue)
            var binding = be.DataBindings["EditValue"];
            if (binding == null)
                return null;

            var bs = binding.DataSource as BindingSource;
            if (bs == null) return null;

            // نام پراپرتی بایند شده
            var propertyName = binding.BindingMemberInfo.BindingField;
            var prop = TypeDescriptor.GetProperties(bs.Current)[propertyName];
            var displayName = prop?.DisplayName;


            // اگر DisplayNameAttribute داشت
            return prop.DisplayName;
        }

        


        //**********************************************************************************************************************
        //**********************************************************************************************************************
        //**********************************************************************************************************************



    }
}
