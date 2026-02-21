namespace CncApp_Final.Frms.EditForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWareHouseEdit));
            this.btnCopyPrice = new DevExpress.XtraEditors.SimpleButton();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFormula = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.sheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SheetBuyPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NewSheetPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PreSheetPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.NewPicesPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PrePicesPriceTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.grpSheetPrice = new DevExpress.XtraEditors.GroupControl();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCalcPrices = new DevExpress.XtraEditors.SimpleButton();
            this.ckbUpdateSheetPrice = new DevExpress.XtraEditors.CheckEdit();
            this.txbOrderDate = new CncApp_Final.Helper.PersianDateTextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.sheetSelector1 = new CncApp_Final.UserControl.SheetSelector();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetBuyPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewSheetPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreSheetPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPicesPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrePicesPriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSheetPrice)).BeginInit();
            this.grpSheetPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbUpdateSheetPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopyPrice
            // 
            this.btnCopyPrice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyPrice.ImageOptions.Image")));
            this.btnCopyPrice.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnCopyPrice.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCopyPrice.Location = new System.Drawing.Point(121, 42);
            this.btnCopyPrice.Name = "btnCopyPrice";
            this.btnCopyPrice.Size = new System.Drawing.Size(28, 80);
            this.btnCopyPrice.TabIndex = 3;
            this.btnCopyPrice.Text = "کپی";
            this.btnCopyPrice.Click += new System.EventHandler(this.btnCopyPrice_Click);
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
            this.bbiClose,
            this.bbiFormula});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 11;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage,
            this.ribbonPage1});
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
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Save And Close";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Save And New";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
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
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            // 
            // bbiFormula
            // 
            this.bbiFormula.Caption = "فرمول قیمت ورق";
            this.bbiFormula.Id = 10;
            this.bbiFormula.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiFormula.ImageOptions.Image")));
            this.bbiFormula.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiFormula.ImageOptions.LargeImage")));
            this.bbiFormula.Name = "bbiFormula";
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Formula";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiFormula);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // sheetsBindingSource
            // 
            this.sheetsBindingSource.DataSource = typeof(CncApp_Final.Entities.Sheet);
            // 
            // SheetBuyPriceTextEdit
            // 
            this.SheetBuyPriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "SheetBasePrice", true));
            this.SheetBuyPriceTextEdit.EnterMoveNextControl = true;
            this.SheetBuyPriceTextEdit.Location = new System.Drawing.Point(16, 53);
            this.SheetBuyPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.SheetBuyPriceTextEdit.Name = "SheetBuyPriceTextEdit";
            this.SheetBuyPriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.SheetBuyPriceTextEdit.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.SheetBuyPriceTextEdit.Properties.Appearance.Options.UseFont = true;
            this.SheetBuyPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.SheetBuyPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SheetBuyPriceTextEdit.Properties.EditFormat.FormatString = "n0";
            this.SheetBuyPriceTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SheetBuyPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.SheetBuyPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.SheetBuyPriceTextEdit.Properties.MaxLength = 9;
            this.SheetBuyPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.SheetBuyPriceTextEdit.Size = new System.Drawing.Size(263, 36);
            this.SheetBuyPriceTextEdit.TabIndex = 1;
            this.SheetBuyPriceTextEdit.EditValueChanged += new System.EventHandler(this.SheetBuyPriceTextEdit_EditValueChanged);
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "Description", true));
            this.DescriptionTextEdit.EnterMoveNextControl = true;
            this.DescriptionTextEdit.Location = new System.Drawing.Point(16, 95);
            this.DescriptionTextEdit.MenuManager = this.mainRibbonControl;
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DescriptionTextEdit.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.DescriptionTextEdit.Properties.Appearance.Options.UseFont = true;
            this.DescriptionTextEdit.Size = new System.Drawing.Size(262, 36);
            this.DescriptionTextEdit.TabIndex = 2;
            // 
            // NewSheetPriceTextEdit
            // 
            this.NewSheetPriceTextEdit.EnterMoveNextControl = true;
            this.NewSheetPriceTextEdit.Location = new System.Drawing.Point(221, 42);
            this.NewSheetPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.NewSheetPriceTextEdit.Name = "NewSheetPriceTextEdit";
            this.NewSheetPriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NewSheetPriceTextEdit.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewSheetPriceTextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.NewSheetPriceTextEdit.Properties.Appearance.Options.UseFont = true;
            this.NewSheetPriceTextEdit.Properties.Appearance.Options.UseForeColor = true;
            this.NewSheetPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.NewSheetPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewSheetPriceTextEdit.Properties.EditFormat.FormatString = "n0";
            this.NewSheetPriceTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewSheetPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.NewSheetPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.NewSheetPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.NewSheetPriceTextEdit.Size = new System.Drawing.Size(99, 36);
            this.NewSheetPriceTextEdit.TabIndex = 1;
            // 
            // PreSheetPriceTextEdit
            // 
            this.PreSheetPriceTextEdit.Location = new System.Drawing.Point(16, 42);
            this.PreSheetPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.PreSheetPriceTextEdit.Name = "PreSheetPriceTextEdit";
            this.PreSheetPriceTextEdit.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.PreSheetPriceTextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.PreSheetPriceTextEdit.Properties.Appearance.Options.UseFont = true;
            this.PreSheetPriceTextEdit.Properties.Appearance.Options.UseForeColor = true;
            this.PreSheetPriceTextEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Red;
            this.PreSheetPriceTextEdit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.PreSheetPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.PreSheetPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PreSheetPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.PreSheetPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.PreSheetPriceTextEdit.Properties.ReadOnly = true;
            this.PreSheetPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.PreSheetPriceTextEdit.Size = new System.Drawing.Size(99, 36);
            this.PreSheetPriceTextEdit.TabIndex = 9;
            this.PreSheetPriceTextEdit.TabStop = false;
            // 
            // NewPicesPriceTextEdit
            // 
            this.NewPicesPriceTextEdit.EnterMoveNextControl = true;
            this.NewPicesPriceTextEdit.Location = new System.Drawing.Point(221, 86);
            this.NewPicesPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.NewPicesPriceTextEdit.Name = "NewPicesPriceTextEdit";
            this.NewPicesPriceTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NewPicesPriceTextEdit.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.NewPicesPriceTextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.NewPicesPriceTextEdit.Properties.Appearance.Options.UseFont = true;
            this.NewPicesPriceTextEdit.Properties.Appearance.Options.UseForeColor = true;
            this.NewPicesPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.NewPicesPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewPicesPriceTextEdit.Properties.EditFormat.FormatString = "n0";
            this.NewPicesPriceTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.NewPicesPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.NewPicesPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.NewPicesPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.NewPicesPriceTextEdit.Size = new System.Drawing.Size(99, 36);
            this.NewPicesPriceTextEdit.TabIndex = 2;
            // 
            // PrePicesPriceTextEdit
            // 
            this.PrePicesPriceTextEdit.Location = new System.Drawing.Point(16, 86);
            this.PrePicesPriceTextEdit.MenuManager = this.mainRibbonControl;
            this.PrePicesPriceTextEdit.Name = "PrePicesPriceTextEdit";
            this.PrePicesPriceTextEdit.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.PrePicesPriceTextEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.PrePicesPriceTextEdit.Properties.Appearance.Options.UseFont = true;
            this.PrePicesPriceTextEdit.Properties.Appearance.Options.UseForeColor = true;
            this.PrePicesPriceTextEdit.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Red;
            this.PrePicesPriceTextEdit.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.PrePicesPriceTextEdit.Properties.DisplayFormat.FormatString = "n0";
            this.PrePicesPriceTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PrePicesPriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.PrePicesPriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.PrePicesPriceTextEdit.Properties.ReadOnly = true;
            this.PrePicesPriceTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.PrePicesPriceTextEdit.Size = new System.Drawing.Size(99, 36);
            this.PrePicesPriceTextEdit.TabIndex = 11;
            this.PrePicesPriceTextEdit.TabStop = false;
            // 
            // grpSheetPrice
            // 
            this.grpSheetPrice.Controls.Add(this.PreSheetPriceTextEdit);
            this.grpSheetPrice.Controls.Add(this.PrePicesPriceTextEdit);
            this.grpSheetPrice.Controls.Add(this.label7);
            this.grpSheetPrice.Controls.Add(this.label6);
            this.grpSheetPrice.Controls.Add(this.NewPicesPriceTextEdit);
            this.grpSheetPrice.Controls.Add(this.NewSheetPriceTextEdit);
            this.grpSheetPrice.Controls.Add(this.btnCalcPrices);
            this.grpSheetPrice.Controls.Add(this.btnCopyPrice);
            this.grpSheetPrice.Location = new System.Drawing.Point(15, 495);
            this.grpSheetPrice.Name = "grpSheetPrice";
            this.grpSheetPrice.Size = new System.Drawing.Size(361, 132);
            this.grpSheetPrice.TabIndex = 3;
            this.grpSheetPrice.Text = "ا    محاسبات (قیمت فروش ورق) براساس (قیمت خرید) برای ورق انتخابی";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(323, 96);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "تکه:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(323, 52);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "کامل:";
            // 
            // btnCalcPrices
            // 
            this.btnCalcPrices.Appearance.Options.UseTextOptions = true;
            this.btnCalcPrices.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCalcPrices.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCalcPrices.ImageOptions.Image")));
            this.btnCalcPrices.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnCalcPrices.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCalcPrices.Location = new System.Drawing.Point(168, 42);
            this.btnCalcPrices.Name = "btnCalcPrices";
            this.btnCalcPrices.Size = new System.Drawing.Size(47, 80);
            this.btnCalcPrices.TabIndex = 3;
            this.btnCalcPrices.Text = "محاسبه قیمت";
            this.btnCalcPrices.Click += new System.EventHandler(this.btnCalcPrices_Click);
            // 
            // ckbUpdateSheetPrice
            // 
            this.ckbUpdateSheetPrice.EditValue = true;
            this.ckbUpdateSheetPrice.Location = new System.Drawing.Point(352, 499);
            this.ckbUpdateSheetPrice.MenuManager = this.mainRibbonControl;
            this.ckbUpdateSheetPrice.Name = "ckbUpdateSheetPrice";
            this.ckbUpdateSheetPrice.Properties.Caption = "";
            this.ckbUpdateSheetPrice.Size = new System.Drawing.Size(22, 22);
            this.ckbUpdateSheetPrice.TabIndex = 2;
            this.ckbUpdateSheetPrice.CheckedChanged += new System.EventHandler(this.ckbUpdateSheetPrice_CheckedChanged);
            // 
            // txbOrderDate
            // 
            this.txbOrderDate.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbOrderDate.Appearance.Options.UseFont = true;
            this.txbOrderDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "OrderDate", true));
            this.txbOrderDate.EditValue = null;
            this.txbOrderDate.Location = new System.Drawing.Point(16, 9);
            this.txbOrderDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbOrderDate.Name = "txbOrderDate";
            this.txbOrderDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbOrderDate.Size = new System.Drawing.Size(262, 36);
            this.txbOrderDate.TabIndex = 0;
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(285, 20);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "تاریخ خرید:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(285, 63);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "قیمت خرید:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(284, 105);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "توضیحات:";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txbOrderDate);
            this.groupControl2.Controls.Add(this.DescriptionTextEdit);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.SheetBuyPriceTextEdit);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Location = new System.Drawing.Point(15, 343);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(361, 146);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "groupControl2";
            // 
            // sheetSelector1
            // 
            this.sheetSelector1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "SheetId", true));
            this.sheetSelector1.Location = new System.Drawing.Point(15, 235);
            this.sheetSelector1.Name = "sheetSelector1";
            this.sheetSelector1.Size = new System.Drawing.Size(361, 102);
            this.sheetSelector1.TabIndex = 0;
            // 
            // FrmWareHouseEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(396, 632);
            this.Controls.Add(this.ckbUpdateSheetPrice);
            this.Controls.Add(this.sheetSelector1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grpSheetPrice);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWareHouseEdit";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetBuyPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewSheetPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreSheetPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPicesPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrePicesPriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSheetPrice)).EndInit();
            this.grpSheetPrice.ResumeLayout(false);
            this.grpSheetPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbUpdateSheetPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private DevExpress.XtraEditors.TextEdit SheetBuyPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private System.Windows.Forms.BindingSource sheetsBindingSource;
        private DevExpress.XtraEditors.TextEdit NewSheetPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit PreSheetPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit NewPicesPriceTextEdit;
        private DevExpress.XtraEditors.TextEdit PrePicesPriceTextEdit;
        private DevExpress.XtraEditors.SimpleButton btnCopyPrice;
        private DevExpress.XtraEditors.GroupControl grpSheetPrice;
        private Helper.PersianDateTextEdit txbOrderDate;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiFormula;
        private UserControl.SheetSelector sheetSelector1;
        private DevExpress.XtraEditors.SimpleButton btnCalcPrices;
        private DevExpress.XtraEditors.CheckEdit ckbUpdateSheetPrice;
    }
}