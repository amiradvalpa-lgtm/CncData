namespace CncApp_Final.Frm
{
    partial class FrmWareHouseEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.btnCopyPrice = new DevExpress.XtraEditors.SimpleButton();
            this.SheetIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.sheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FaOrderDateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SheetBasePriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NewSheetPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PreSheetPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NewPicesPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PrePicesPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSheetId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFaOrderDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSheetBasePrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForNewPicesPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForNewSheetPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPreSheetPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPrePicesPrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaOrderDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetBasePriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewSheetPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreSheetPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPicesPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrePicesPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFaOrderDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNewPicesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNewSheetPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPreSheetPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrePicesPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.btnCopyPrice);
            this.dataLayoutControl1.Controls.Add(this.SheetIdLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.FaOrderDateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SheetBasePriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NewSheetPriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PreSheetPriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.NewPicesPriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PrePicesPriceTextEdit);
            this.dataLayoutControl1.DataSource = this.warehousesBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 201);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(772, 262, 785, 400);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(396, 335);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // btnCopyPrice
            // 
            this.btnCopyPrice.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCopyPrice.Location = new System.Drawing.Point(189, 228);
            this.btnCopyPrice.MaximumSize = new System.Drawing.Size(20, 0);
            this.btnCopyPrice.MinimumSize = new System.Drawing.Size(20, 73);
            this.btnCopyPrice.Name = "btnCopyPrice";
            this.btnCopyPrice.Size = new System.Drawing.Size(20, 73);
            this.btnCopyPrice.StyleController = this.dataLayoutControl1;
            this.btnCopyPrice.TabIndex = 13;
            this.btnCopyPrice.Click += new System.EventHandler(this.btnCopyPrice_Click);
            // 
            // SheetIdLookUpEdit
            // 
            this.SheetIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "SheetId", true));
            this.SheetIdLookUpEdit.EnterMoveNextControl = true;
            this.SheetIdLookUpEdit.Location = new System.Drawing.Point(16, 16);
            this.SheetIdLookUpEdit.MenuManager = this.mainRibbonControl;
            this.SheetIdLookUpEdit.Name = "SheetIdLookUpEdit";
            this.SheetIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SheetIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "شناسه ورق", 73, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetName", "نام ورق", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Material", "جنس ورق", 63, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Thickness", "ضخامت", 51, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Width", "عرض", 41, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Length", "طول", 35, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetPrice", "قیمت کامل", 67, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PicesPrice", "قیمت تکه", 60, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CNCPrice", "قیمت خدمات CNC", 100, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OrderDetails", "جزئیات سفارش‌هایی که از این ورق استفاده کرده‌اند", 250, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Warehouses", "موجودی در انبار", 86, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Thickness_mm", "ضخامت ورق", 73, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetSize", "سایز ورق", 60, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.SheetIdLookUpEdit.Properties.DataSource = this.sheetsBindingSource;
            this.SheetIdLookUpEdit.Properties.DisplayMember = "SheetName";
            this.SheetIdLookUpEdit.Properties.NullText = "";
            this.SheetIdLookUpEdit.Properties.ValueMember = "Id";
            this.SheetIdLookUpEdit.Size = new System.Drawing.Size(279, 28);
            this.SheetIdLookUpEdit.StyleController = this.dataLayoutControl1;
            this.SheetIdLookUpEdit.TabIndex = 0;
            // 
            // warehousesBindingSource
            // 
            this.warehousesBindingSource.DataSource = typeof(CncApp_Final.Entities.Warehouse);
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 10;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(396, 201);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Save And Close";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            this.bbiSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndClose_ItemClick);
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Save And New";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            this.bbiSaveAndNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveAndNew_ItemClick);
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Reset Changes";
            this.bbiReset.Id = 5;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Home";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndClose);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndNew);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiReset);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiDelete);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiClose);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // sheetsBindingSource
            // 
            this.sheetsBindingSource.DataSource = typeof(CncApp_Final.Entities.Sheet);
            // 
            // FaOrderDateTextEdit
            // 
            this.FaOrderDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "FaOrderDate", true));
            this.FaOrderDateTextEdit.EnterMoveNextControl = true;
            this.FaOrderDateTextEdit.Location = new System.Drawing.Point(16, 60);
            this.FaOrderDateTextEdit.MenuManager = this.mainRibbonControl;
            this.FaOrderDateTextEdit.Name = "FaOrderDateTextEdit";
            this.FaOrderDateTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.FaOrderDateTextEdit.Size = new System.Drawing.Size(279, 28);
            this.FaOrderDateTextEdit.StyleController = this.dataLayoutControl1;
            this.FaOrderDateTextEdit.TabIndex = 1;
            // 
            // SheetBasePriceTextEdit
            // 
            this.SheetBasePriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "SheetBasePrice", true));
            this.SheetBasePriceTextEdit.EnterMoveNextControl = true;
            this.SheetBasePriceTextEdit.Location = new System.Drawing.Point(16, 104);
            this.SheetBasePriceTextEdit.MenuManager = this.mainRibbonControl;
            this.SheetBasePriceTextEdit.Name = "SheetBasePriceTextEdit";
            this.SheetBasePriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.SheetBasePriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.SheetBasePriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SheetBasePriceTextEdit.Properties.EditFormat.FormatString = "n0";
            this.SheetBasePriceTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SheetBasePriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.SheetBasePriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.SheetBasePriceTextEdit.Properties.MaxLength = 9;
            this.SheetBasePriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.SheetBasePriceTextEdit.Size = new System.Drawing.Size(279, 28);
            this.SheetBasePriceTextEdit.StyleController = this.dataLayoutControl1;
            this.SheetBasePriceTextEdit.TabIndex = 2;
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "Description", true));
            this.DescriptionTextEdit.EnterMoveNextControl = true;
            this.DescriptionTextEdit.Location = new System.Drawing.Point(16, 148);
            this.DescriptionTextEdit.MenuManager = this.mainRibbonControl;
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DescriptionTextEdit.Size = new System.Drawing.Size(279, 28);
            this.DescriptionTextEdit.StyleController = this.dataLayoutControl1;
            this.DescriptionTextEdit.TabIndex = 3;
            // 
            // NewSheetPriceTextEdit
            // 
            this.NewSheetPriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "NewSheetPrice", true));
            this.NewSheetPriceTextEdit.EnterMoveNextControl = true;
            this.NewSheetPriceTextEdit.Location = new System.Drawing.Point(219, 228);
            this.NewSheetPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.NewSheetPriceTextEdit.Name = "NewSheetPriceTextEdit";
            this.NewSheetPriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NewSheetPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.NewSheetPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewSheetPriceTextEdit.Properties.EditFormat.FormatString = "n0";
            this.NewSheetPriceTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewSheetPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.NewSheetPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.NewSheetPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.NewSheetPriceTextEdit.Size = new System.Drawing.Size(83, 28);
            this.NewSheetPriceTextEdit.StyleController = this.dataLayoutControl1;
            this.NewSheetPriceTextEdit.TabIndex = 4;
            // 
            // PreSheetPriceTextEdit
            // 
            this.PreSheetPriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "PreSheetPrice", true));
            this.PreSheetPriceTextEdit.Location = new System.Drawing.Point(25, 228);
            this.PreSheetPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.PreSheetPriceTextEdit.Name = "PreSheetPriceTextEdit";
            this.PreSheetPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.PreSheetPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PreSheetPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.PreSheetPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.PreSheetPriceTextEdit.Properties.ReadOnly = true;
            this.PreSheetPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.PreSheetPriceTextEdit.Size = new System.Drawing.Size(79, 28);
            this.PreSheetPriceTextEdit.StyleController = this.dataLayoutControl1;
            this.PreSheetPriceTextEdit.TabIndex = 9;
            this.PreSheetPriceTextEdit.TabStop = false;
            // 
            // NewPicesPriceTextEdit
            // 
            this.NewPicesPriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "NewPicesPrice", true));
            this.NewPicesPriceTextEdit.EnterMoveNextControl = true;
            this.NewPicesPriceTextEdit.Location = new System.Drawing.Point(219, 272);
            this.NewPicesPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.NewPicesPriceTextEdit.Name = "NewPicesPriceTextEdit";
            this.NewPicesPriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NewPicesPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.NewPicesPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewPicesPriceTextEdit.Properties.EditFormat.FormatString = "n0";
            this.NewPicesPriceTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewPicesPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.NewPicesPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.NewPicesPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.NewPicesPriceTextEdit.Size = new System.Drawing.Size(83, 28);
            this.NewPicesPriceTextEdit.StyleController = this.dataLayoutControl1;
            this.NewPicesPriceTextEdit.TabIndex = 5;
            // 
            // PrePicesPriceTextEdit
            // 
            this.PrePicesPriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "PrePicesPrice", true));
            this.PrePicesPriceTextEdit.Location = new System.Drawing.Point(25, 272);
            this.PrePicesPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.PrePicesPriceTextEdit.Name = "PrePicesPriceTextEdit";
            this.PrePicesPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.PrePicesPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PrePicesPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.PrePicesPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.PrePicesPriceTextEdit.Properties.ReadOnly = true;
            this.PrePicesPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.PrePicesPriceTextEdit.Size = new System.Drawing.Size(79, 28);
            this.PrePicesPriceTextEdit.StyleController = this.dataLayoutControl1;
            this.PrePicesPriceTextEdit.TabIndex = 11;
            this.PrePicesPriceTextEdit.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(396, 335);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSheetId,
            this.ItemForFaOrderDate,
            this.ItemForSheetBasePrice,
            this.ItemForDescription,
            this.layoutControlGroup3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(370, 309);
            // 
            // ItemForSheetId
            // 
            this.ItemForSheetId.Control = this.SheetIdLookUpEdit;
            this.ItemForSheetId.Location = new System.Drawing.Point(0, 0);
            this.ItemForSheetId.Name = "ItemForSheetId";
            this.ItemForSheetId.OptionsToolTip.ToolTip = "ورق انتخاب شده برای سفارش";
            this.ItemForSheetId.Size = new System.Drawing.Size(370, 44);
            this.ItemForSheetId.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForSheetId.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForFaOrderDate
            // 
            this.ItemForFaOrderDate.Control = this.FaOrderDateTextEdit;
            this.ItemForFaOrderDate.Location = new System.Drawing.Point(0, 44);
            this.ItemForFaOrderDate.Name = "ItemForFaOrderDate";
            this.ItemForFaOrderDate.Size = new System.Drawing.Size(370, 44);
            this.ItemForFaOrderDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForFaOrderDate.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForSheetBasePrice
            // 
            this.ItemForSheetBasePrice.Control = this.SheetBasePriceTextEdit;
            this.ItemForSheetBasePrice.Location = new System.Drawing.Point(0, 88);
            this.ItemForSheetBasePrice.Name = "ItemForSheetBasePrice";
            this.ItemForSheetBasePrice.OptionsToolTip.ToolTip = "قیمت پایه ورق";
            this.ItemForSheetBasePrice.Size = new System.Drawing.Size(370, 44);
            this.ItemForSheetBasePrice.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForSheetBasePrice.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 132);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.OptionsToolTip.ToolTip = "توضیحات مربوط به خرید ورق";
            this.ItemForDescription.Size = new System.Drawing.Size(370, 44);
            this.ItemForDescription.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForDescription.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForNewPicesPrice,
            this.ItemForNewSheetPrice,
            this.ItemForPreSheetPrice,
            this.ItemForPrePicesPrice,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 176);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup3.Size = new System.Drawing.Size(370, 133);
            this.layoutControlGroup3.Text = "محاسبات قیمت ورق براساس قیمت پایه کامل";
            // 
            // ItemForNewPicesPrice
            // 
            this.ItemForNewPicesPrice.Control = this.NewPicesPriceTextEdit;
            this.ItemForNewPicesPrice.Location = new System.Drawing.Point(194, 44);
            this.ItemForNewPicesPrice.Name = "ItemForNewPicesPrice";
            this.ItemForNewPicesPrice.OptionsToolTip.ToolTip = "SheetBasePrice * 1.15";
            this.ItemForNewPicesPrice.Size = new System.Drawing.Size(158, 44);
            this.ItemForNewPicesPrice.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForNewPicesPrice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForNewPicesPrice.TextSize = new System.Drawing.Size(69, 13);
            this.ItemForNewPicesPrice.TextToControlDistance = 0;
            // 
            // ItemForNewSheetPrice
            // 
            this.ItemForNewSheetPrice.Control = this.NewSheetPriceTextEdit;
            this.ItemForNewSheetPrice.Location = new System.Drawing.Point(194, 0);
            this.ItemForNewSheetPrice.Name = "ItemForNewSheetPrice";
            this.ItemForNewSheetPrice.OptionsToolTip.ToolTip = "SheetBasePrice * 1.25";
            this.ItemForNewSheetPrice.Size = new System.Drawing.Size(158, 44);
            this.ItemForNewSheetPrice.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForNewSheetPrice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForNewSheetPrice.TextSize = new System.Drawing.Size(69, 13);
            this.ItemForNewSheetPrice.TextToControlDistance = 0;
            // 
            // ItemForPreSheetPrice
            // 
            this.ItemForPreSheetPrice.Control = this.PreSheetPriceTextEdit;
            this.ItemForPreSheetPrice.Location = new System.Drawing.Point(0, 0);
            this.ItemForPreSheetPrice.Name = "ItemForPreSheetPrice";
            this.ItemForPreSheetPrice.OptionsToolTip.ToolTip = "Sheet.SheetPrice";
            this.ItemForPreSheetPrice.Size = new System.Drawing.Size(154, 44);
            this.ItemForPreSheetPrice.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForPreSheetPrice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForPreSheetPrice.TextSize = new System.Drawing.Size(69, 13);
            this.ItemForPreSheetPrice.TextToControlDistance = 0;
            // 
            // ItemForPrePicesPrice
            // 
            this.ItemForPrePicesPrice.Control = this.PrePicesPriceTextEdit;
            this.ItemForPrePicesPrice.Location = new System.Drawing.Point(0, 44);
            this.ItemForPrePicesPrice.Name = "ItemForPrePicesPrice";
            this.ItemForPrePicesPrice.OptionsToolTip.ToolTip = "Sheet.PicesPrice";
            this.ItemForPrePicesPrice.Size = new System.Drawing.Size(154, 44);
            this.ItemForPrePicesPrice.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 10);
            this.ItemForPrePicesPrice.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.ItemForPrePicesPrice.TextSize = new System.Drawing.Size(69, 13);
            this.ItemForPrePicesPrice.TextToControlDistance = 0;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Location = new System.Drawing.Point(154, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(10, 88);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCopyPrice;
            this.layoutControlItem2.Location = new System.Drawing.Point(164, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(30, 79);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(30, 79);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(30, 88);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextVisible = false;
            // 
            // FrmWareHouseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(396, 536);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.Name = "FrmWareHouseEdit";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWareHouseEdit_FormClosing);
            this.Load += new System.EventHandler(this.FrmWareHouseEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SheetIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaOrderDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetBasePriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewSheetPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreSheetPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPicesPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrePicesPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFaOrderDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNewPicesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForNewSheetPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPreSheetPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPrePicesPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private DevExpress.XtraEditors.LookUpEdit SheetIdLookUpEdit;
        private DevExpress.XtraEditors.TextEdit FaOrderDateTextEdit;
        private DevExpress.XtraEditors.TextEdit SheetBasePriceTextEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSheetId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFaOrderDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSheetBasePrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private System.Windows.Forms.BindingSource sheetsBindingSource;
        private DevExpress.XtraEditors.TextEdit NewSheetPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit PreSheetPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit NewPicesPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit PrePicesPriceTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNewSheetPrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPreSheetPrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForNewPicesPrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPrePicesPrice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnCopyPrice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}