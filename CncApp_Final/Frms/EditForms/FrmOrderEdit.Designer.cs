namespace CncApp_Final.Frms.EditForms
{
    partial class FrmOrderEdit
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrderEdit));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.txbInvoiceNumber = new DevExpress.XtraBars.BarEditItem();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.orderDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.btnOpenFile = new DevExpress.XtraEditors.ButtonEdit();
            this.txbFaDeliveryDate = new CncApp_Final.Helper.PersianDateTextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txbFaOrderDate = new CncApp_Final.Helper.PersianDateTextEdit();
            this.btnImportFromCorel = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewDetail = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txbTotalAmount = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txbTotalShetCost = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.textEdit7 = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txbMiscCost = new DevExpress.XtraEditors.TextEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.txbTransportCost = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txbTotalCncCost = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.lueCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDescription = new DevExpress.XtraEditors.TextEdit();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.grdvOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCutSheetDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrooveLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalSheetCostDisplay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalSheetCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCncCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleteSelectedDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsBtnDeleteCurrentDetail = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colOrderId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCutLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCutWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPicesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierTypeDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txbSumNetPrice = new DevExpress.XtraEditors.ButtonEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbTotalAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbTotalShetCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbMiscCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbTransportCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbTotalCncCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBtnDeleteCurrentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbSumNetPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose,
            this.txbInvoiceNumber,
            this.barStaticItem1});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 10;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.OptionsPageCategories.ShowCaptions = false;
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2});
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(761, 181);
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
            // txbInvoiceNumber
            // 
            this.txbInvoiceNumber.DataBindings.Add(new System.Windows.Forms.Binding("AccessibleDescription", this.orderBindingSource, "InvoiceNumber", true));
            this.txbInvoiceNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "InvoiceNumber", true));
            this.txbInvoiceNumber.Edit = this.repositoryItemTextEdit2;
            this.txbInvoiceNumber.EditValue = "F04-0101";
            this.txbInvoiceNumber.EditWidth = 80;
            this.txbInvoiceNumber.Enabled = false;
            this.txbInvoiceNumber.Id = 12;
            this.txbInvoiceNumber.Name = "txbInvoiceNumber";
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(CncApp_Final.Entities.Order);
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemTextEdit2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.repositoryItemTextEdit2.Appearance.Options.UseFont = true;
            this.repositoryItemTextEdit2.Appearance.Options.UseForeColor = true;
            this.repositoryItemTextEdit2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTextEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemTextEdit2.AppearanceDisabled.ForeColor = System.Drawing.Color.Red;
            this.repositoryItemTextEdit2.AppearanceDisabled.Options.UseForeColor = true;
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.ReadOnly = true;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.AllowFocus = DevExpress.Utils.DefaultBoolean.False;
            this.barStaticItem1.Caption = "شماره فاکتور";
            this.barStaticItem1.Id = 13;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.RightIndent = 11;
            this.barStaticItem1.Width = 70;
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup,
            this.ribbonPageGroup1});
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
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.txbInvoiceNumber);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // orderDetailsBindingSource
            // 
            this.orderDetailsBindingSource.DataSource = typeof(CncApp_Final.Entities.OrderDetails);
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataSource = typeof(CncApp_Final.Entities.Customer);
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.Controls.Add(this.btnOpenFile);
            this.groupControl4.Controls.Add(this.txbFaDeliveryDate);
            this.groupControl4.Controls.Add(this.label8);
            this.groupControl4.Controls.Add(this.txbFaOrderDate);
            this.groupControl4.Controls.Add(this.btnImportFromCorel);
            this.groupControl4.Controls.Add(this.btnNewDetail);
            this.groupControl4.Controls.Add(this.groupControl2);
            this.groupControl4.Controls.Add(this.groupControl1);
            this.groupControl4.Controls.Add(this.lueCustomer);
            this.groupControl4.Controls.Add(this.label1);
            this.groupControl4.Controls.Add(this.btnNewCustomer);
            this.groupControl4.Controls.Add(this.label2);
            this.groupControl4.Controls.Add(this.label3);
            this.groupControl4.Controls.Add(this.label4);
            this.groupControl4.Controls.Add(this.txbDescription);
            this.groupControl4.Location = new System.Drawing.Point(19, 207);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl4.ShowCaption = false;
            this.groupControl4.Size = new System.Drawing.Size(730, 290);
            this.groupControl4.TabIndex = 28;
            this.groupControl4.Text = "groupControl4";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(378, 180);
            this.btnOpenFile.MinimumSize = new System.Drawing.Size(60, 36);
            this.btnOpenFile.Name = "btnOpenFile";
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            editorButtonImageOptions1.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            editorButtonImageOptions1.ImageToTextIndent = 5;
            this.btnOpenFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnOpenFile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnOpenFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnOpenFile.Size = new System.Drawing.Size(272, 28);
            this.btnOpenFile.TabIndex = 30;
            this.btnOpenFile.TabStop = false;
            this.btnOpenFile.EditValueChanged += new System.EventHandler(this.btnOpenFile_EditValueChanged);
            // 
            // txbFaDeliveryDate
            // 
            this.txbFaDeliveryDate.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbFaDeliveryDate.Appearance.Options.UseFont = true;
            this.txbFaDeliveryDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "DeliveryDate", true));
            this.txbFaDeliveryDate.EditValue = null;
            this.txbFaDeliveryDate.Location = new System.Drawing.Point(378, 59);
            this.txbFaDeliveryDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbFaDeliveryDate.Name = "txbFaDeliveryDate";
            this.txbFaDeliveryDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbFaDeliveryDate.Size = new System.Drawing.Size(98, 36);
            this.txbFaDeliveryDate.TabIndex = 23;
            this.txbFaDeliveryDate.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(656, 190);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "فایل کورل:";
            // 
            // txbFaOrderDate
            // 
            this.txbFaOrderDate.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbFaOrderDate.Appearance.Options.UseFont = true;
            this.txbFaOrderDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "OrderDate", true));
            this.txbFaOrderDate.EditValue = null;
            this.txbFaOrderDate.Location = new System.Drawing.Point(551, 59);
            this.txbFaOrderDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbFaOrderDate.Name = "txbFaOrderDate";
            this.txbFaOrderDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbFaOrderDate.Size = new System.Drawing.Size(98, 36);
            this.txbFaOrderDate.TabIndex = 1;
            // 
            // btnImportFromCorel
            // 
            this.btnImportFromCorel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportFromCorel.ImageOptions.Image")));
            this.btnImportFromCorel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnImportFromCorel.ImageOptions.ImageToTextIndent = 3;
            this.btnImportFromCorel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnImportFromCorel.Location = new System.Drawing.Point(378, 222);
            this.btnImportFromCorel.Name = "btnImportFromCorel";
            this.btnImportFromCorel.Size = new System.Drawing.Size(109, 59);
            this.btnImportFromCorel.TabIndex = 3;
            this.btnImportFromCorel.Text = "افزودن لیست از کورل";
            // 
            // btnNewDetail
            // 
            this.btnNewDetail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNewDetail.ImageOptions.Image")));
            this.btnNewDetail.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnNewDetail.ImageOptions.ImageToTextIndent = 3;
            this.btnNewDetail.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnNewDetail.Location = new System.Drawing.Point(541, 222);
            this.btnNewDetail.Name = "btnNewDetail";
            this.btnNewDetail.Size = new System.Drawing.Size(109, 59);
            this.btnNewDetail.TabIndex = 3;
            this.btnNewDetail.Text = "افزودن ردیف جدید";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txbTotalAmount);
            this.groupControl2.Controls.Add(this.label13);
            this.groupControl2.Location = new System.Drawing.Point(35, 234);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(298, 47);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Text = "groupControl2";
            // 
            // txbTotalAmount
            // 
            this.txbTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTotalAmount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "TotalAmount", true));
            this.txbTotalAmount.EditValue = "1234567890";
            this.txbTotalAmount.EnterMoveNextControl = true;
            this.txbTotalAmount.Location = new System.Drawing.Point(5, 5);
            this.txbTotalAmount.Name = "txbTotalAmount";
            this.txbTotalAmount.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbTotalAmount.Properties.Appearance.Options.UseFont = true;
            this.txbTotalAmount.Properties.DisplayFormat.FormatString = "#,###  تومان";
            this.txbTotalAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txbTotalAmount.Properties.ReadOnly = true;
            this.txbTotalAmount.Size = new System.Drawing.Size(163, 36);
            this.txbTotalAmount.TabIndex = 17;
            this.txbTotalAmount.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("IRANSans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(174, 9);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(119, 25);
            this.label13.TabIndex = 3;
            this.label13.Text = "مبلغ کل سفارش:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txbTotalShetCost);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.textEdit7);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.txbMiscCost);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.txbTransportCost);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txbTotalCncCost);
            this.groupControl1.Controls.Add(this.label12);
            this.groupControl1.Location = new System.Drawing.Point(35, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(298, 215);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "groupControl1";
            // 
            // txbTotalShetCost
            // 
            this.txbTotalShetCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTotalShetCost.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "TotalSheetCost", true));
            this.txbTotalShetCost.EditValue = "1234567890";
            this.txbTotalShetCost.EnterMoveNextControl = true;
            this.txbTotalShetCost.Location = new System.Drawing.Point(5, 5);
            this.txbTotalShetCost.Name = "txbTotalShetCost";
            this.txbTotalShetCost.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbTotalShetCost.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbTotalShetCost.Properties.Appearance.Options.UseFont = true;
            this.txbTotalShetCost.Properties.Appearance.Options.UseForeColor = true;
            this.txbTotalShetCost.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbTotalShetCost.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txbTotalShetCost.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbTotalShetCost.Properties.MaskSettings.Set("mask", "n0");
            this.txbTotalShetCost.Properties.ReadOnly = true;
            this.txbTotalShetCost.Properties.UseMaskAsDisplayFormat = true;
            this.txbTotalShetCost.Size = new System.Drawing.Size(163, 36);
            this.txbTotalShetCost.TabIndex = 0;
            this.txbTotalShetCost.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(192, 19);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "مبلغ کل ورق ها:";
            // 
            // textEdit7
            // 
            this.textEdit7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit7.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "Discount", true));
            this.textEdit7.EditValue = "0";
            this.textEdit7.EnterMoveNextControl = true;
            this.textEdit7.Location = new System.Drawing.Point(5, 173);
            this.textEdit7.Name = "textEdit7";
            this.textEdit7.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.textEdit7.Properties.Appearance.Options.UseFont = true;
            this.textEdit7.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.textEdit7.Properties.MaskSettings.Set("mask", "n0");
            this.textEdit7.Properties.UseMaskAsDisplayFormat = true;
            this.textEdit7.Size = new System.Drawing.Size(163, 36);
            this.textEdit7.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(192, 61);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "مبلغ کل CNC:";
            // 
            // txbMiscCost
            // 
            this.txbMiscCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbMiscCost.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "MiscCost", true));
            this.txbMiscCost.EditValue = "1234567890";
            this.txbMiscCost.EnterMoveNextControl = true;
            this.txbMiscCost.Location = new System.Drawing.Point(5, 131);
            this.txbMiscCost.Name = "txbMiscCost";
            this.txbMiscCost.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbMiscCost.Properties.Appearance.Options.UseFont = true;
            this.txbMiscCost.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbMiscCost.Properties.MaskSettings.Set("mask", "n0");
            this.txbMiscCost.Properties.UseMaskAsDisplayFormat = true;
            this.txbMiscCost.Size = new System.Drawing.Size(163, 36);
            this.txbMiscCost.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(192, 103);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "هزینه حمل و نقل:";
            // 
            // txbTransportCost
            // 
            this.txbTransportCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTransportCost.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "TransportCost", true));
            this.txbTransportCost.EditValue = "1234567890";
            this.txbTransportCost.EnterMoveNextControl = true;
            this.txbTransportCost.Location = new System.Drawing.Point(5, 89);
            this.txbTransportCost.Name = "txbTransportCost";
            this.txbTransportCost.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbTransportCost.Properties.Appearance.Options.UseFont = true;
            this.txbTransportCost.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbTransportCost.Properties.MaskSettings.Set("mask", "n0");
            this.txbTransportCost.Properties.UseMaskAsDisplayFormat = true;
            this.txbTransportCost.Size = new System.Drawing.Size(163, 36);
            this.txbTransportCost.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(192, 145);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "هزینه‌های جانبی:";
            // 
            // txbTotalCncCost
            // 
            this.txbTotalCncCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTotalCncCost.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "TotalCncCost", true));
            this.txbTotalCncCost.EditValue = "1234567890";
            this.txbTotalCncCost.EnterMoveNextControl = true;
            this.txbTotalCncCost.Location = new System.Drawing.Point(5, 47);
            this.txbTotalCncCost.Name = "txbTotalCncCost";
            this.txbTotalCncCost.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbTotalCncCost.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbTotalCncCost.Properties.Appearance.Options.UseFont = true;
            this.txbTotalCncCost.Properties.Appearance.Options.UseForeColor = true;
            this.txbTotalCncCost.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbTotalCncCost.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txbTotalCncCost.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbTotalCncCost.Properties.MaskSettings.Set("mask", "n0");
            this.txbTotalCncCost.Properties.ReadOnly = true;
            this.txbTotalCncCost.Properties.UseMaskAsDisplayFormat = true;
            this.txbTotalCncCost.Size = new System.Drawing.Size(163, 36);
            this.txbTotalCncCost.TabIndex = 1;
            this.txbTotalCncCost.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(192, 187);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "تخفیف:";
            // 
            // lueCustomer
            // 
            this.lueCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lueCustomer.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "CustomerId", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lueCustomer.EnterMoveNextControl = true;
            this.lueCustomer.Location = new System.Drawing.Point(429, 15);
            this.lueCustomer.Name = "lueCustomer";
            this.lueCustomer.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCustomer.Properties.Appearance.Options.UseFont = true;
            this.lueCustomer.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lueCustomer.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lueCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 26, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerFullName", "نام مشتری", 92, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueCustomer.Properties.DataSource = this.customersBindingSource;
            this.lueCustomer.Properties.DisplayMember = "CustomerFullName";
            this.lueCustomer.Properties.DropDownItemHeight = 25;
            this.lueCustomer.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lueCustomer.Properties.ShowHeader = false;
            this.lueCustomer.Properties.ValueMember = "Id";
            this.lueCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lueCustomer.Size = new System.Drawing.Size(221, 36);
            this.lueCustomer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(656, 25);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "نام مشتری:";
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNewCustomer.ImageOptions.Image")));
            this.btnNewCustomer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnNewCustomer.Location = new System.Drawing.Point(378, 15);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(38, 36);
            this.btnNewCustomer.TabIndex = 16;
            this.btnNewCustomer.TabStop = false;
            this.btnNewCustomer.ToolTip = "طرف حساب جدید";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(656, 118);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "توضیحات :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(483, 71);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "تاریخ تحویل:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(656, 67);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "تاریخ سفارش:";
            // 
            // txbDescription
            // 
            this.txbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.orderBindingSource, "Description", true));
            this.txbDescription.Location = new System.Drawing.Point(378, 103);
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbDescription.Properties.Appearance.Options.UseFont = true;
            this.txbDescription.Size = new System.Drawing.Size(272, 36);
            this.txbDescription.TabIndex = 2;
            this.txbDescription.TabStop = false;
            // 
            // groupControl7
            // 
            this.groupControl7.Controls.Add(this.gridControl);
            this.groupControl7.Controls.Add(this.txbSumNetPrice);
            this.groupControl7.Controls.Add(this.label7);
            this.groupControl7.Location = new System.Drawing.Point(19, 511);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.ShowCaption = false;
            this.groupControl7.Size = new System.Drawing.Size(732, 161);
            this.groupControl7.TabIndex = 27;
            this.groupControl7.Text = "groupControl7";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.orderDetailsBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.grdvOrderDetails;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsBtnDeleteCurrentDetail,
            this.repositoryItemMemoEdit1});
            this.gridControl.Size = new System.Drawing.Size(728, 157);
            this.gridControl.TabIndex = 25;
            this.gridControl.TabStop = false;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOrderDetails});
            // 
            // grdvOrderDetails
            // 
            this.grdvOrderDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvOrderDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOrderDetails.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvOrderDetails.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvOrderDetails.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvOrderDetails.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.grdvOrderDetails.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdvOrderDetails.Appearance.Row.Options.UseTextOptions = true;
            this.grdvOrderDetails.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvOrderDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grdvOrderDetails.ColumnPanelRowHeight = 50;
            this.grdvOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colCutSheetDetails,
            this.colSupplier,
            this.colGrooveLength,
            this.colFinalSheetCostDisplay,
            this.colFinalSheetCost,
            this.colCncCost,
            this.colDetailName,
            this.colDescription,
            this.colDeleteSelectedDetail,
            this.colOrderId,
            this.colOrder,
            this.colFilePath,
            this.colSheetId,
            this.colSheet,
            this.colCutLength,
            this.colCutWidth,
            this.colSheetPrice,
            this.colPicesPrice,
            this.colSupplierTypeDescription});
            this.grdvOrderDetails.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdvOrderDetails.GridControl = this.gridControl;
            this.grdvOrderDetails.Name = "grdvOrderDetails";
            this.grdvOrderDetails.OptionsCustomization.AllowFilter = false;
            this.grdvOrderDetails.OptionsCustomization.AllowSort = false;
            this.grdvOrderDetails.OptionsFind.FindDelay = 500;
            this.grdvOrderDetails.OptionsFind.FindNullPrompt = "برای جستجو در فاکتورها، کلمه مورد نظر را وارد کنید...";
            this.grdvOrderDetails.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvOrderDetails.OptionsView.RowAutoHeight = true;
            this.grdvOrderDetails.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MaxWidth = 40;
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            this.colId.Width = 40;
            // 
            // colCutSheetDetails
            // 
            this.colCutSheetDetails.AppearanceCell.Options.UseTextOptions = true;
            this.colCutSheetDetails.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCutSheetDetails.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCutSheetDetails.FieldName = "CutSheetDetails";
            this.colCutSheetDetails.MinWidth = 140;
            this.colCutSheetDetails.Name = "colCutSheetDetails";
            this.colCutSheetDetails.OptionsColumn.AllowEdit = false;
            this.colCutSheetDetails.OptionsColumn.ReadOnly = true;
            this.colCutSheetDetails.Visible = true;
            this.colCutSheetDetails.VisibleIndex = 0;
            this.colCutSheetDetails.Width = 140;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.AcceptsTab = true;
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colSupplier
            // 
            this.colSupplier.AppearanceCell.Options.UseTextOptions = true;
            this.colSupplier.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 1;
            // 
            // colGrooveLength
            // 
            this.colGrooveLength.AppearanceCell.Options.UseTextOptions = true;
            this.colGrooveLength.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGrooveLength.DisplayFormat.FormatString = "#,###.# متر";
            this.colGrooveLength.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGrooveLength.FieldName = "GrooveLength";
            this.colGrooveLength.Name = "colGrooveLength";
            this.colGrooveLength.OptionsColumn.AllowEdit = false;
            this.colGrooveLength.OptionsColumn.ReadOnly = true;
            this.colGrooveLength.Visible = true;
            this.colGrooveLength.VisibleIndex = 2;
            // 
            // colFinalSheetCostDisplay
            // 
            this.colFinalSheetCostDisplay.AppearanceCell.Options.UseTextOptions = true;
            this.colFinalSheetCostDisplay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFinalSheetCostDisplay.FieldName = "FinalSheetCostDisplay";
            this.colFinalSheetCostDisplay.Name = "colFinalSheetCostDisplay";
            this.colFinalSheetCostDisplay.OptionsColumn.AllowEdit = false;
            this.colFinalSheetCostDisplay.OptionsColumn.ReadOnly = true;
            // 
            // colFinalSheetCost
            // 
            this.colFinalSheetCost.AppearanceCell.Options.UseTextOptions = true;
            this.colFinalSheetCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFinalSheetCost.Caption = "هزینه ورق";
            this.colFinalSheetCost.DisplayFormat.FormatString = "n0";
            this.colFinalSheetCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFinalSheetCost.FieldName = "FinalSheetCost";
            this.colFinalSheetCost.Name = "colFinalSheetCost";
            this.colFinalSheetCost.OptionsColumn.AllowEdit = false;
            this.colFinalSheetCost.OptionsColumn.ReadOnly = true;
            this.colFinalSheetCost.Visible = true;
            this.colFinalSheetCost.VisibleIndex = 3;
            // 
            // colCncCost
            // 
            this.colCncCost.AppearanceCell.Options.UseTextOptions = true;
            this.colCncCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCncCost.DisplayFormat.FormatString = "n0";
            this.colCncCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCncCost.FieldName = "CncCost";
            this.colCncCost.Name = "colCncCost";
            this.colCncCost.OptionsColumn.AllowEdit = false;
            this.colCncCost.OptionsColumn.ReadOnly = true;
            this.colCncCost.Visible = true;
            this.colCncCost.VisibleIndex = 4;
            // 
            // colDetailName
            // 
            this.colDetailName.FieldName = "DetailName";
            this.colDetailName.Name = "colDetailName";
            this.colDetailName.OptionsColumn.AllowEdit = false;
            this.colDetailName.OptionsColumn.ReadOnly = true;
            this.colDetailName.Visible = true;
            this.colDetailName.VisibleIndex = 5;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "توضیحات";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 6;
            // 
            // colDeleteSelectedDetail
            // 
            this.colDeleteSelectedDetail.Caption = "حذف";
            this.colDeleteSelectedDetail.ColumnEdit = this.rpsBtnDeleteCurrentDetail;
            this.colDeleteSelectedDetail.MaxWidth = 60;
            this.colDeleteSelectedDetail.MinWidth = 60;
            this.colDeleteSelectedDetail.Name = "colDeleteSelectedDetail";
            this.colDeleteSelectedDetail.Visible = true;
            this.colDeleteSelectedDetail.VisibleIndex = 7;
            this.colDeleteSelectedDetail.Width = 60;
            // 
            // rpsBtnDeleteCurrentDetail
            // 
            this.rpsBtnDeleteCurrentDetail.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.rpsBtnDeleteCurrentDetail.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Detete", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpsBtnDeleteCurrentDetail.Name = "rpsBtnDeleteCurrentDetail";
            this.rpsBtnDeleteCurrentDetail.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rpsBtnDeleteCurrentDetail.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rpsBtnDeleteCurrentDetail_ButtonClick);
            // 
            // colOrderId
            // 
            this.colOrderId.FieldName = "OrderId";
            this.colOrderId.Name = "colOrderId";
            // 
            // colOrder
            // 
            this.colOrder.FieldName = "Order";
            this.colOrder.Name = "colOrder";
            // 
            // colFilePath
            // 
            this.colFilePath.FieldName = "FilePath";
            this.colFilePath.Name = "colFilePath";
            // 
            // colSheetId
            // 
            this.colSheetId.FieldName = "SheetId";
            this.colSheetId.Name = "colSheetId";
            // 
            // colSheet
            // 
            this.colSheet.FieldName = "Sheet";
            this.colSheet.Name = "colSheet";
            // 
            // colCutLength
            // 
            this.colCutLength.FieldName = "CutLength";
            this.colCutLength.Name = "colCutLength";
            // 
            // colCutWidth
            // 
            this.colCutWidth.FieldName = "CutWidth";
            this.colCutWidth.Name = "colCutWidth";
            // 
            // colSheetPrice
            // 
            this.colSheetPrice.FieldName = "SheetPrice";
            this.colSheetPrice.Name = "colSheetPrice";
            this.colSheetPrice.OptionsColumn.ReadOnly = true;
            // 
            // colPicesPrice
            // 
            this.colPicesPrice.FieldName = "PicesPrice";
            this.colPicesPrice.Name = "colPicesPrice";
            this.colPicesPrice.OptionsColumn.ReadOnly = true;
            // 
            // colSupplierTypeDescription
            // 
            this.colSupplierTypeDescription.FieldName = "SupplierTypeDescription";
            this.colSupplierTypeDescription.Name = "colSupplierTypeDescription";
            this.colSupplierTypeDescription.OptionsColumn.ReadOnly = true;
            // 
            // txbSumNetPrice
            // 
            this.txbSumNetPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbSumNetPrice.EditValue = 0;
            this.txbSumNetPrice.Location = new System.Drawing.Point(11, 121);
            this.txbSumNetPrice.Name = "txbSumNetPrice";
            this.txbSumNetPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txbSumNetPrice.Properties.Appearance.Options.UseFont = true;
            this.txbSumNetPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo)});
            this.txbSumNetPrice.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbSumNetPrice.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txbSumNetPrice.Properties.MaskSettings.Set("mask", "c0");
            this.txbSumNetPrice.Properties.MaskSettings.Set("autoHideDecimalSeparator", false);
            this.txbSumNetPrice.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txbSumNetPrice.Properties.UseMaskAsDisplayFormat = true;
            this.txbSumNetPrice.Size = new System.Drawing.Size(137, 30);
            this.txbSumNetPrice.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(149, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "مجموع قیمت خدمات :";
            // 
            // FrmOrderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(761, 680);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "FrmOrderEdit";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbTotalAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbTotalShetCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbMiscCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbTransportCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbTotalCncCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBtnDeleteCurrentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbSumNetPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
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
        private DevExpress.XtraBars.BarEditItem txbInvoiceNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.BindingSource orderDetailsBindingSource;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.ButtonEdit btnOpenFile;
        private Helper.PersianDateTextEdit txbFaDeliveryDate;
        private System.Windows.Forms.Label label8;
        private Helper.PersianDateTextEdit txbFaOrderDate;
        private DevExpress.XtraEditors.SimpleButton btnImportFromCorel;
        private DevExpress.XtraEditors.SimpleButton btnNewDetail;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txbTotalAmount;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txbTotalShetCost;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit textEdit7;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txbMiscCost;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.TextEdit txbTransportCost;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txbTotalCncCost;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.LookUpEdit lueCustomer;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnNewCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txbDescription;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colCutSheetDetails;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colGrooveLength;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalSheetCostDisplay;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalSheetCost;
        private DevExpress.XtraGrid.Columns.GridColumn colCncCost;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteSelectedDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpsBtnDeleteCurrentDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderId;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraGrid.Columns.GridColumn colFilePath;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetId;
        private DevExpress.XtraGrid.Columns.GridColumn colSheet;
        private DevExpress.XtraGrid.Columns.GridColumn colCutLength;
        private DevExpress.XtraGrid.Columns.GridColumn colCutWidth;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPicesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierTypeDescription;
        private DevExpress.XtraEditors.ButtonEdit txbSumNetPrice;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}