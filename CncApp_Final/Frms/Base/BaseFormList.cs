using CncApp_Final.Helper;
using CncApp_Final.Helpers;
using CncApp_Final.Services;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CncApp_Final.Frms.Base
{
    public abstract class BaseFormList : RibbonForm
    {
        // ======================================================
        // Properties
        // ======================================================

        protected BindingSource EntityBindingSource { get; set; }

        private readonly IListService _listService;

        private int _focusedRowHandle;
        private int _topRowIndex;

        // ======================================================
        // Controls - فرزند معرفی می‌کند
        // ======================================================

        protected abstract GridControl GetGridControl();
        protected abstract GridView GetGridView();

        protected abstract BarButtonItem GetNewButton();
        protected abstract BarButtonItem GetEditButton();
        protected abstract BarButtonItem GetDeleteButton();
        protected abstract BarButtonItem GetRefreshButton();
        protected abstract BarButtonItem GetPrintPreviewButton();
        protected abstract BarStaticItem GetRecordsCountItem();
        protected abstract RibbonControl GetRibbonControl();

        // ======================================================
        // سازنده
        // ======================================================

        protected BaseFormList()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
        }

        protected BaseFormList(IListService listService)
        {
            _listService = listService ?? throw new ArgumentNullException(nameof(listService));
            EntityBindingSource = new BindingSource();
        }

        // ======================================================
        // Load
        // ======================================================

        protected virtual void BaseFormList_Load(object sender, EventArgs e)
        {
            InitFormExtraConfig();
            HookButtonEvents();
            HookGridEvents();
            LoadData();
        }

        private void InitFormExtraConfig()
        {
            string formName = GetFormTitle();
            ControlExraInit.InitRibonControl(GetRibbonControl(), formName);
            ControlExraInit.InitGridView(GetGridView(), formName);
            GridLayoutHelper.LoadLayout(GetGridView(), 1, this.Name);
        }

        // ======================================================
        // Abstract
        // ======================================================

        protected abstract string GetFormTitle();
        protected abstract IEditForm CreateEditForm(int id, bool isReadOnly);

        // ======================================================
        // Hook Events
        // ======================================================

        private void HookButtonEvents()
        {
            var btnNew = GetNewButton();
            if (btnNew != null) btnNew.ItemClick += bbiNew_ItemClick;

            var btnEdit = GetEditButton();
            if (btnEdit != null) btnEdit.ItemClick += bbiEdit_ItemClick;

            var btnDelete = GetDeleteButton();
            if (btnDelete != null) btnDelete.ItemClick += bbiDelete_ItemClick;

            var btnRefresh = GetRefreshButton();
            if (btnRefresh != null) btnRefresh.ItemClick += bbiRefresh_ItemClick;

            var btnPrint = GetPrintPreviewButton();
            if (btnPrint != null) btnPrint.ItemClick += bbiPrintPreview_ItemClick;
        }

        private void HookGridEvents()
        {
            var gridView = GetGridView();
            if (gridView == null) return;

            gridView.FocusedRowChanged += GridView_FocusedRowChanged;
            gridView.RowCountChanged += GridView_RowCountChanged;
            gridView.DoubleClick += GridView_DoubleClick;

            // شماره ردیف ثابت با Indicator
            gridView.IndicatorWidth = 40;
            gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
        }

        // ======================================================
        // Load Data
        // ======================================================

        protected virtual void LoadData()
        {
            EntityBindingSource.DataSource = _listService.GetAll();
            GetGridControl().DataSource = EntityBindingSource;
            UpdateRecordsCount();
            UpdateButtonsState();
        }

        protected virtual void ReLoadList(int newRowId = 0)
        {
            SavePosition();
            LoadData();

            if (newRowId == 0)
                RestorePosition();
            else
                RestorePosition(newRowId);
        }

        // ======================================================
        // Position Management
        // ======================================================

        private void SavePosition()
        {
            var gridView = GetGridView();
            _focusedRowHandle = gridView.FocusedRowHandle;
            _topRowIndex = gridView.TopRowIndex;
        }

        private void RestorePosition()
        {
            var gridView = GetGridView();
            gridView.FocusedRowHandle = _focusedRowHandle;
            gridView.TopRowIndex = _topRowIndex;
        }

        private void RestorePosition(int newRowId)
        {
            var gridView = GetGridView();
            int handle = gridView.LocateByValue("Id", newRowId);
            if (handle >= 0)
                gridView.FocusedRowHandle = handle;
        }

        // ======================================================
        // Records Count
        // ======================================================

        private void UpdateRecordsCount()
        {
            var item = GetRecordsCountItem();
            if (item == null) return;

            // تعداد کل رکوردها بدون لحاظ فیلتر
            int count = EntityBindingSource.Count;
            item.Caption = $"تعداد رکوردها: {count}";
        }

        // ======================================================
        // Buttons State
        // ======================================================

        private void UpdateButtonsState()
        {
            var gridView = GetGridView();
            bool hasValidRow = gridView != null &&
                               gridView.FocusedRowHandle >= 0 &&
                               gridView.RowCount > 0;

            var btnEdit = GetEditButton();
            if (btnEdit != null) btnEdit.Enabled = hasValidRow;

            var btnDelete = GetDeleteButton();
            if (btnDelete != null) btnDelete.Enabled = hasValidRow;
        }

        // ======================================================
        // Open Edit Form Core
        // ======================================================

        private void OpenEditFormCore(int id, bool isReadOnly)
        {
            var frm = CreateEditForm(id, isReadOnly);
            if (frm == null) return;

            frm.ChangesSaved += (s, args) =>
            {
                int recordId = args.RecordId > 0 ? args.RecordId : id;
                ReLoadList(recordId);
            };

            frm.ShowDialog();
        }

        // ======================================================
        // Grid Events
        // ======================================================

        private void GridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            UpdateButtonsState();
        }

        private void GridView_RowCountChanged(object sender, EventArgs e)
        {
            UpdateRecordsCount();
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            var gridView = GetGridView();
            if (gridView.FocusedRowHandle < 0) return;

            int id = GetFocusedRowId();
            if (id <= 0) return;

            OpenEditFormCore(id, isReadOnly: true);
        }

        private void GridView_CustomDrawRowIndicator(object sender,
            DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        // ======================================================
        // Button Events
        // ======================================================

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenEditFormCore(0, isReadOnly: false);
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            int id = GetFocusedRowId();
            if (id <= 0) return;

            OpenEditFormCore(id, isReadOnly: false);
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            int id = GetFocusedRowId();
            if (id <= 0) return;

            var result = DevExpress.XtraEditors.XtraMessageBox.Show(
                "آیا از حذف این رکورد اطمینان دارید؟",
                "حذف رکورد",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            BeforeDelete();

            var gridView = GetGridView();
            int nextHandle = gridView.FocusedRowHandle;

            _listService.DeleteById(id);

            ReLoadList();

            // فوکوس به ردیف بعدی
            int rowCount = gridView.RowCount;
            if (rowCount > 0)
            {
                if (nextHandle >= rowCount)
                    nextHandle = rowCount - 1;
                gridView.FocusedRowHandle = nextHandle;
            }

            AfterDelete();
        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            int id = GetFocusedRowId();
            ReLoadList(id);
        }

        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetGridControl().ShowRibbonPrintPreview();
        }

        // ======================================================
        // Helpers
        // ======================================================

        protected virtual int GetFocusedRowId()
        {
            var gridView = GetGridView();
            if (gridView == null || gridView.FocusedRowHandle < 0) return 0;

            var val = gridView.GetFocusedRowCellValue("Id");
            if (val == null || val == DBNull.Value) return 0;

            return Convert.ToInt32(val);
        }

        // ======================================================
        // Virtual Hooks
        // ======================================================

        protected virtual void BeforeDelete() { }
        protected virtual void AfterDelete() { }

        // ======================================================
        // FormClosing
        // ======================================================

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            GridLayoutHelper.SaveLayout(GetGridView(), 1, this.Name);
        }
    }
}