using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;


namespace CncApp_Final.Frms
{
    /// ============================================================
    /// فرم اصلی وارد کردن اطلاعات از CorelDRAW
    /// شامل لیست اسناد، لیست گروه‌های CNC، پیش‌نمایش و جدول OrderDetail
    /// ============================================================
    /// 




    public partial class FrmCorelDataImporter : XtraForm
    {
        // ============================================================
        // لیست زنده OrderDetail که به gridControl متصل است
        // یک بار ساخته می‌شود و همیشه به grid وصل است
        // ============================================================
        public readonly BindingList<OrderDetails> _orderDetails = new BindingList<OrderDetails>();




        // لود یک‌باره تمام ورق‌ها از DB
        List<Sheet> _allSheets;

        AppDbContext _dbContext;

        public VGCore.Document SelectedDocument { get; set; }





        /// ============================================================
        /// سازنده فرم - مقداردهی اولیه کنترل‌ها
        /// ============================================================
        public FrmCorelDataImporter()
        {
            InitializeComponent();
        }



        /// ============================================================
        /// سازنده فرم - مقداردهی اولیه کنترل‌ها
        /// ============================================================
        public FrmCorelDataImporter(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }





        /// ============================================================
        /// رویداد Load فرم
        /// اتصال BindingList به gridControl و بارگذاری اولیه سندها
        /// ============================================================
        private void FrmCorelDataImporter_Load(object sender, EventArgs e)
        {
            // یک‌بار برای همیشه BindingList را به grid وصل می‌کنیم
            gridControl.DataSource = _orderDetails;
            LoadAllSheets();
            LoadDocuments();
        }



        /// ============================================================
        /// بارگذاری لیست اسناد دارای لایه CNC از کورل
        /// ============================================================
        private void LoadDocuments()
        {
            try
            {
                var docs = CorelHelper.GetDocumentsWithCNC();
                listBoxDocuments.DataSource = docs;

                if (docs.Count == 0)
                    MessageBox.Show("هیچ سندی با لایه CNC یافت نشد.", "اطلاعات",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در اتصال به CorelDRAW:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// ============================================================
        /// رویداد تغییر انتخاب در لیست اسناد
        /// گروه‌های معتبر لایه CNC سند انتخابی را از تمام صفحات بارگذاری می‌کند
        /// تیک‌های قبلی و BindingList پاک می‌شوند
        /// ============================================================
        private void listBoxDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDocuments.SelectedItem == null) return;

            var selectedDoc = (VGCore.Document)listBoxDocuments.SelectedItem;
            SelectedDocument = selectedDoc;

            // پاک کردن وضعیت قبلی
            checkedListBoxGroups.DataSource = null;
            _orderDetails.Clear();
            pictureEdit1.Image = null;

            // بارگذاری گروه‌های معتبر از تمام صفحات
            try
            {
                var groups = CorelHelper.GetAllCNCGroups(selectedDoc);
                checkedListBoxGroups.DataSource = groups;
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در بارگذاری گروه‌ها:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// ============================================================
        /// رویداد تغییر آیتم انتخابی در لیست گروه‌ها
        /// تصویر پیش‌نمایش گروه انتخابی را در pictureEdit1 نمایش می‌دهد
        /// ============================================================
        private void checkedListBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxGroups.SelectedItem == null)
            {
                pictureEdit1.Image = null;
                return;
            }

            var selectedGroup = (VGCore.Shape)checkedListBoxGroups.SelectedItem;

            try
            {
                var preview = CorelHelper.GetGroupPreviewByClipboard(selectedGroup);
                pictureEdit1.Image = preview;
            }
            catch
            {
                pictureEdit1.Image = null;
            }
        }




        /// ============================================================
        /// رویداد تغییر وضعیت تیک در لیست گروه‌ها
        /// هر بار کل BindingList از نو از گروه‌های تیک‌خورده ساخته می‌شود
        /// نکته: ItemCheck قبل از تغییر واقعی تیک فایر می‌شود
        ///       پس آیتم جاری با NewValue مدیریت می‌شود
        /// ============================================================
        private void checkedListBoxGroups_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var checkedGroups = new List<VGCore.Shape>();
            for (int i = 0; i < checkedListBoxGroups.CheckedItemsCount; i++)
            {
                checkedGroups.Add((VGCore.Shape)checkedListBoxGroups.CheckedItems[i]);
            }

            // پارس تمام گروه‌های تیک‌خورده به SheetInfo
            var sheetInfoList = checkedGroups
                .Select(g => CorelHelper.ParseGroupToSheetInfo(g))
                .Where(info => info != null)
                .ToList();

            // تبدیل به OrderDetails و آپدیت BindingList
            var newOrderDetails = CorelHelper.ConvertSheetInfoListToOrderDetails(sheetInfoList, _dbContext);

            _orderDetails.Clear();
            foreach (var od in newOrderDetails)
                _orderDetails.Add(od);

            gridControl.RefreshDataSource();
        }




        /// ============================================================
        /// رویداد نمایش متن سفارشی برای آیتم‌های listBoxDocuments
        /// نام سند کورل را نمایش می‌دهد
        /// ============================================================
        private void listBoxDocuments_CustomItemDisplayText(object sender, CustomItemDisplayTextEventArgs e)
        {
            if (e.Item is VGCore.Document doc)
                e.DisplayText = doc.Name;
        }




        /// ============================================================
        /// رویداد نمایش متن سفارشی برای آیتم‌های checkedListBoxGroups
        /// نام گروه کورل را نمایش می‌دهد
        /// ============================================================
        private void checkedListBoxGroups_CustomItemDisplayText(object sender, CustomItemDisplayTextEventArgs e)
        {
            try
            {
                if (e.Item is VGCore.Shape shape)
                    e.DisplayText = shape.Name;
            }
            catch
            {
                XtraMessageBox.Show("در فایل های کورل تغییراتی ایجاد شده.لطفا کلید بروزرسانی رو دوباره  بزنید");
            }

            
        }




        /// ============================================================
        /// رویداد کلیک دکمه Refresh
        /// لیست اسناد را دوباره از کورل بارگذاری می‌کند
        /// ============================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDocuments();
        }




        /// ============================================================
        /// رویداد کلیک دکمه Ok
        /// فرم را با نتیجه OK می‌بندد
        /// ============================================================
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ForceValidateAllDetailName()) return;
            DialogResult = DialogResult.OK;
        }



        ///====================================================================================================
        /// متدهای مربوط به CncCost کمتر از حد مجاز
        ///====================================================================================================

        #region متدهای مربوط به CncCost کمتر از حد مجاز


        /// ============================================================
        ///  نمایش رنگ قرمز CncCost کمتر از حد مجاز
        /// ============================================================
        private void grdvOrderDetails_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column == colCncCost)
            {
                if(IsCncCostSmaller(e.RowHandle) < 0)
                {
                    int index = grdvOrderDetails.GetDataSourceRowIndex(e.RowHandle);
                    OrderDetails orderDetails = (OrderDetails)grdvOrderDetails.GetListSourceRow(index);
                    if (orderDetails.IsCncCostEdited)
                        e.Appearance.ForeColor = Color.ForestGreen;
                    else
                        e.Appearance.ForeColor = Color.Red;
                }
            }
        }
        
        
        
        /// ============================================================
        ///  نمایش ToolTip برای CncCost کمتر از حد مجاز
        /// ============================================================
        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            var view = gridControl.FocusedView as GridView;
            if (view == null) return;

            var hi = view.CalcHitInfo(e.ControlMousePosition);
            if (!hi.InRowCell || hi.Column != colCncCost) return;

            int tolerance = 100000;
            int howMuchCncCostSmaller = Convert.ToInt32(IsCncCostSmaller(hi.RowHandle)/ tolerance);
            if (howMuchCncCostSmaller < 0)   // همون شرط خودت
            {
                string msg = $"مقدار: {view.GetRowCellDisplayText(hi.RowHandle, colCncCost)} هزینه CNC\n" +
                             $"{-howMuchCncCostSmaller*tolerance:n0}  کمتر از مقدار مجاز است";

                e.Info = new DevExpress.Utils.ToolTipControlInfo(hi.HitTest, msg);
                // برای ظاهر حرفه‌ای‌تر:
                // var stt = new SuperToolTip();
                // stt.Items.Add("هشدار", true);
                // stt.Items.Add(msg);
                // e.Info = new ToolTipControlInfo(hi.HitTest, stt);
            }
        }





        /// ============================================================
        ///  مقایسه CncCost کمتر از حد مجاز
        /// ============================================================
        private double IsCncCostSmaller(int RowHandle)
        {
            int index = grdvOrderDetails.GetDataSourceRowIndex(RowHandle);
            OrderDetails orderDetails = (OrderDetails)grdvOrderDetails.GetListSourceRow(index);
            Sheet sheet = null;
            if (_allSheets != null)
            {
                sheet = _allSheets.FirstOrDefault(s => s.Id == orderDetails.SheetId);
            }

            if (orderDetails != null && sheet != null)
            {
                return orderDetails.CncCost - (orderDetails.GrooveLength * sheet.CNCPriceByMeter);
                //if (orderDetails.CncCost < orderDetails.GrooveLength * sheet.CNCPriceByMeter)
                //    return true;
            }

            return 0;
        }


        /// ============================================================
        ///  ویرایش CncCost کمتر از حد مجاز
        /// ============================================================
        private void grdvOrderDetails_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            if (ea == null) return;

            GridView view = sender as GridView;
            if (view == null) return;

            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (!info.InRowCell) return;

            if (info.Column != colCncCost) return;

            // حالا دابل‌کلیک روی سلول ستون CNC Cost اتفاق افتاده
            // اینجا کد دلخواهت رو بنویس

            int rowIndex = view.GetDataSourceRowIndex( info.RowHandle);

            OrderDetails orderDetails = (OrderDetails)view.GetListSourceRow(rowIndex);

            // یا باز کردن فرم جزئیات
            FrmCncCostDetails frmCncCostDetails = new FrmCncCostDetails(orderDetails);
            frmCncCostDetails.ShowDialog();
            if(frmCncCostDetails.DialogResult == DialogResult.OK)
            {
                orderDetails.CncCost = frmCncCostDetails.CncCost;
                orderDetails.IsCncCostEdited = true;
                _orderDetails.ResetBindings();
            }
        }


        /// ============================================================
        ///  بارگزاری ورق ها برای عملیات CncCost کمتر از حد مجاز
        /// ============================================================
        private void LoadAllSheets()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    _allSheets = context.Sheets.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در لود ورق‌ها از پایگاه داده:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion






        ///====================================================================================================
        /// اعتبار سنجی ستون عنوان سغارش
        ///====================================================================================================

        #region اعتبار سنجی ستون عنوان سغارش

        private void grdvOrderDetails_HiddenEditor(object sender, EventArgs e)
        {
            ForceValidateAllDetailName();
        }

        private void grdvOrderDetails_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            grdvOrderDetails.ClearColumnErrors();
        }

        public bool ForceValidateAllDetailName()
        {
            bool isValid = true;
            if (grdvOrderDetails == null) return isValid;


            int originalFocusedRow = grdvOrderDetails.FocusedRowHandle;  // ذخیره فوکوس فعلی

            try
            {
                for (int rowHandle = 0; rowHandle < grdvOrderDetails.DataRowCount; rowHandle++)
                {
                    if (!grdvOrderDetails.IsDataRow(rowHandle)) continue;

                    var value = grdvOrderDetails.GetRowCellValue(rowHandle, colDetailName);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        grdvOrderDetails.FocusedRowHandle = rowHandle;
                        grdvOrderDetails.SetColumnError(colDetailName, "عنوان سفارش نمیتواند خالی باشد!", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                        grdvOrderDetails.FocusedColumn = colDetailName;
                        grdvOrderDetails.ShowEditor();
                        isValid = false;
                        break;
                    }

                }
            }
            finally
            {

            }

            if (isValid)
            {
                grdvOrderDetails.FocusedRowHandle = originalFocusedRow;
                grdvOrderDetails.RefreshData();
            }
            return isValid;
        }







        #endregion

        private void listBoxDocuments_DoubleClick(object sender, EventArgs e)
        {
            // 1️⃣ چک کنیم لیست خالی نباشه
            if (_orderDetails == null || _orderDetails.Count == 0)
            {
                return;
            }

            var list = sender as DevExpress.XtraEditors.ListBoxControl;
            if (list == null) return;

            // 2️⃣ چک کنیم آیتمی انتخاب شده باشه
            if (list.SelectedItem == null)
                return;

            // 3️⃣ گرفتن شیء واقعی از DataSource
            var selectedDetail = list.SelectedItem as VGCore.Document;

            if (selectedDetail == null)
                return;


            string filename = selectedDetail.FileName;
            string name = Path.GetFileNameWithoutExtension(filename);

            foreach ( OrderDetails od in _orderDetails)
            {
                od.DetailName = name;
            }

            grdvOrderDetails.RefreshData();
        }
    }
}