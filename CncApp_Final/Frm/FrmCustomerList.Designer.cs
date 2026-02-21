namespace CncApp_Final.Frm
{
    partial class FrmCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerList));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue4 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colBalanceStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeginning_Balance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMhkCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisplayBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrders = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceipts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsBtnOpenFolder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.txbSumNetPrice = new DevExpress.XtraEditors.ButtonEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.colBalanceType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBtnOpenFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbSumNetPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colBalanceStatus
            // 
            this.colBalanceStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colBalanceStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBalanceStatus.Caption = "ماهیت فعلی";
            this.colBalanceStatus.FieldName = "BalanceStatus";
            this.colBalanceStatus.Name = "colBalanceStatus";
            this.colBalanceStatus.Visible = true;
            this.colBalanceStatus.VisibleIndex = 8;
            // 
            // colBeginning_Balance
            // 
            this.colBeginning_Balance.AppearanceCell.Options.UseTextOptions = true;
            this.colBeginning_Balance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBeginning_Balance.DisplayFormat.FormatString = "#,###;#,###;0";
            this.colBeginning_Balance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBeginning_Balance.FieldName = "Beginning_Balance";
            this.colBeginning_Balance.Name = "colBeginning_Balance";
            this.colBeginning_Balance.Visible = true;
            this.colBeginning_Balance.VisibleIndex = 6;
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ApplicationCaption = "لیست مشتریان";
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose,
            this.bbiEditCustomer,
            this.bbiNewCustomer});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 12;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.OptionsPageCategories.ShowCaptions = false;
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.RibbonCaptionAlignment = DevExpress.XtraBars.Ribbon.RibbonCaptionAlignment.Right;
            this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.mainRibbonControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.ShowToolbarCustomizeItem = false;
            this.mainRibbonControl.Size = new System.Drawing.Size(931, 201);
            this.mainRibbonControl.Toolbar.ShowCustomizeItem = false;
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
            // bbiEditCustomer
            // 
            this.bbiEditCustomer.Caption = "ویرایش مشتری";
            this.bbiEditCustomer.Id = 10;
            this.bbiEditCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEditCustomer.ImageOptions.Image")));
            this.bbiEditCustomer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEditCustomer.ImageOptions.LargeImage")));
            this.bbiEditCustomer.Name = "bbiEditCustomer";
            this.bbiEditCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditCustomer_ItemClick);
            // 
            // bbiNewCustomer
            // 
            this.bbiNewCustomer.Caption = "افزودن مشتری";
            this.bbiNewCustomer.Id = 11;
            this.bbiNewCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiNewCustomer.ImageOptions.Image")));
            this.bbiNewCustomer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiNewCustomer.ImageOptions.LargeImage")));
            this.bbiNewCustomer.Name = "bbiNewCustomer";
            this.bbiNewCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNewCustomer_ItemClick);
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
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiNewCustomer);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiEditCustomer);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // groupControl7
            // 
            this.groupControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl7.Controls.Add(this.gridControl);
            this.groupControl7.Controls.Add(this.txbSumNetPrice);
            this.groupControl7.Controls.Add(this.label7);
            this.groupControl7.Location = new System.Drawing.Point(12, 224);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.ShowCaption = false;
            this.groupControl7.Size = new System.Drawing.Size(907, 363);
            this.groupControl7.TabIndex = 6;
            this.groupControl7.Text = "groupControl7";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.customersBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsBtnOpenFolder});
            this.gridControl.Size = new System.Drawing.Size(903, 359);
            this.gridControl.TabIndex = 25;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataSource = typeof(CncApp_Final.Entities.Customer);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.ColumnPanelRowHeight = 50;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colMhkCustomerId,
            this.colCustomerName,
            this.colHint,
            this.colPhone,
            this.colAddress,
            this.colDescription,
            this.colBeginning_Balance,
            this.colDisplayBalance,
            this.colBalanceStatus,
            this.colOrders,
            this.colReceipts,
            this.colBalanceType});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.Column = this.colBalanceStatus;
            gridFormatRule1.Enabled = false;
            gridFormatRule1.Name = "BalanceStatusNegative";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "بدهکار";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Column = this.colBalanceStatus;
            gridFormatRule2.Enabled = false;
            gridFormatRule2.Name = "BalanceStatusPositive";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "بستانکار";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.Column = this.colBalanceType;
            gridFormatRule3.ColumnApplyTo = this.colBeginning_Balance;
            gridFormatRule3.Enabled = false;
            gridFormatRule3.Name = "Beginning_BalanceNegative";
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue3.Value1 = "0";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            gridFormatRule4.Column = this.colBalanceType;
            gridFormatRule4.ColumnApplyTo = this.colBeginning_Balance;
            gridFormatRule4.Enabled = false;
            gridFormatRule4.Name = "Beginning_BalancePositive";
            formatConditionRuleValue4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            formatConditionRuleValue4.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue4.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue4.Value1 = 0D;
            gridFormatRule4.Rule = formatConditionRuleValue4;
            this.gridView.FormatRules.Add(gridFormatRule1);
            this.gridView.FormatRules.Add(gridFormatRule2);
            this.gridView.FormatRules.Add(gridFormatRule3);
            this.gridView.FormatRules.Add(gridFormatRule4);
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindDelay = 500;
            this.gridView.OptionsFind.FindNullPrompt = "برای جستجو در فاکتورها، کلمه مورد نظر را وارد کنید...";
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowHeight = 30;
            this.gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView_CustomDrawCell);
            this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colMhkCustomerId
            // 
            this.colMhkCustomerId.Caption = "کد محک";
            this.colMhkCustomerId.FieldName = "MhkCustomerId";
            this.colMhkCustomerId.Name = "colMhkCustomerId";
            this.colMhkCustomerId.Visible = true;
            this.colMhkCustomerId.VisibleIndex = 0;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            // 
            // colHint
            // 
            this.colHint.FieldName = "Hint";
            this.colHint.Name = "colHint";
            this.colHint.Visible = true;
            this.colHint.VisibleIndex = 2;
            // 
            // colPhone
            // 
            this.colPhone.AppearanceCell.Options.UseTextOptions = true;
            this.colPhone.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 3;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 4;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            // 
            // colDisplayBalance
            // 
            this.colDisplayBalance.AppearanceCell.Options.UseTextOptions = true;
            this.colDisplayBalance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDisplayBalance.Caption = "مانده حساب";
            this.colDisplayBalance.DisplayFormat.FormatString = "n0";
            this.colDisplayBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDisplayBalance.FieldName = "DisplayBalance";
            this.colDisplayBalance.Name = "colDisplayBalance";
            this.colDisplayBalance.Visible = true;
            this.colDisplayBalance.VisibleIndex = 7;
            // 
            // colOrders
            // 
            this.colOrders.FieldName = "Orders";
            this.colOrders.Name = "colOrders";
            // 
            // colReceipts
            // 
            this.colReceipts.FieldName = "Receipts";
            this.colReceipts.Name = "colReceipts";
            // 
            // rpsBtnOpenFolder
            // 
            this.rpsBtnOpenFolder.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.rpsBtnOpenFolder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Open", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpsBtnOpenFolder.Name = "rpsBtnOpenFolder";
            this.rpsBtnOpenFolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // txbSumNetPrice
            // 
            this.txbSumNetPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbSumNetPrice.EditValue = 0;
            this.txbSumNetPrice.Location = new System.Drawing.Point(11, 323);
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
            this.label7.Location = new System.Drawing.Point(149, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "مجموع قیمت خدمات :";
            // 
            // colBalanceType
            // 
            this.colBalanceType.FieldName = "BalanceType";
            this.colBalanceType.Name = "colBalanceType";
            // 
            // FrmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(931, 599);
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.mainRibbonControl);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmCustomerList";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustomers_FormClosing);
            this.Load += new System.EventHandler(this.FrmCustomerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBtnOpenFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbSumNetPrice.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colMhkCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colBeginning_Balance;
        private DevExpress.XtraGrid.Columns.GridColumn colOrders;
        private DevExpress.XtraGrid.Columns.GridColumn colReceipts;
        private DevExpress.XtraGrid.Columns.GridColumn colDisplayBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpsBtnOpenFolder;
        private DevExpress.XtraEditors.ButtonEdit txbSumNetPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private DevExpress.XtraBars.BarButtonItem bbiEditCustomer;
        private DevExpress.XtraBars.BarButtonItem bbiNewCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colHint;
        private DevExpress.XtraGrid.Columns.GridColumn colBalanceType;
    }
}