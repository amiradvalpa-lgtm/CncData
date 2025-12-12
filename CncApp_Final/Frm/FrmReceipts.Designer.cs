namespace CncApp_Final.Frm
{
    partial class FrmReceipts
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReceipts));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.receiptsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaReceiptDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankAccountId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsBtnOpenFolder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.txbSumNetPrice = new DevExpress.XtraEditors.ButtonEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.bbiNewReceipt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditReceipt = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBtnOpenFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbSumNetPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ApplicationCaption = "لیست دریافتی ها";
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose,
            this.bbiNewReceipt,
            this.bbiEditReceipt});
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
            this.mainRibbonControl.Size = new System.Drawing.Size(772, 201);
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
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiNewReceipt);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiEditReceipt);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // receiptsBindingSource
            // 
            this.receiptsBindingSource.DataSource = typeof(CncApp_Final.Entities.Receipt);
            // 
            // groupControl7
            // 
            this.groupControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl7.Controls.Add(this.gridControl);
            this.groupControl7.Controls.Add(this.txbSumNetPrice);
            this.groupControl7.Controls.Add(this.label7);
            this.groupControl7.Location = new System.Drawing.Point(12, 219);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.ShowCaption = false;
            this.groupControl7.Size = new System.Drawing.Size(748, 355);
            this.groupControl7.TabIndex = 6;
            this.groupControl7.Text = "groupControl7";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.receiptsBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsBtnOpenFolder});
            this.gridControl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gridControl.Size = new System.Drawing.Size(744, 351);
            this.gridControl.TabIndex = 25;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
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
            this.colCustomerName,
            this.colAmount,
            this.colFaReceiptDate,
            this.colBankName,
            this.colId,
            this.colDate,
            this.colCustomerId,
            this.colCustomer,
            this.colBankAccountId,
            this.colBankAccount});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindDelay = 500;
            this.gridView.OptionsFind.FindNullPrompt = "برای جستجو در فاکتورها، کلمه مورد نظر را وارد کنید...";
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowHeight = 30;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.ReadOnly = true;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 0;
            // 
            // colAmount
            // 
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 1;
            // 
            // colFaReceiptDate
            // 
            this.colFaReceiptDate.FieldName = "FaReceiptDate";
            this.colFaReceiptDate.Name = "colFaReceiptDate";
            this.colFaReceiptDate.Visible = true;
            this.colFaReceiptDate.VisibleIndex = 2;
            // 
            // colBankName
            // 
            this.colBankName.FieldName = "BankName";
            this.colBankName.Name = "colBankName";
            this.colBankName.OptionsColumn.ReadOnly = true;
            this.colBankName.Visible = true;
            this.colBankName.VisibleIndex = 3;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            // 
            // colCustomer
            // 
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            // 
            // colBankAccountId
            // 
            this.colBankAccountId.FieldName = "BankAccountId";
            this.colBankAccountId.Name = "colBankAccountId";
            // 
            // colBankAccount
            // 
            this.colBankAccount.FieldName = "BankAccount";
            this.colBankAccount.Name = "colBankAccount";
            // 
            // rpsBtnOpenFolder
            // 
            this.rpsBtnOpenFolder.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.rpsBtnOpenFolder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Open", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpsBtnOpenFolder.Name = "rpsBtnOpenFolder";
            this.rpsBtnOpenFolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // txbSumNetPrice
            // 
            this.txbSumNetPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbSumNetPrice.EditValue = 0;
            this.txbSumNetPrice.Location = new System.Drawing.Point(11, 315);
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
            this.label7.Location = new System.Drawing.Point(149, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "مجموع قیمت خدمات :";
            // 
            // bbiNewReceipt
            // 
            this.bbiNewReceipt.Caption = "افزودن سند دریافت";
            this.bbiNewReceipt.Id = 10;
            this.bbiNewReceipt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiNewReceipt.ImageOptions.Image")));
            this.bbiNewReceipt.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiNewReceipt.ImageOptions.LargeImage")));
            this.bbiNewReceipt.Name = "bbiNewReceipt";
            this.bbiNewReceipt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNewReceipt_ItemClick);
            // 
            // bbiEditReceipt
            // 
            this.bbiEditReceipt.Caption = "ویرایش سند دریافت";
            this.bbiEditReceipt.Id = 11;
            this.bbiEditReceipt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEditReceipt.ImageOptions.Image")));
            this.bbiEditReceipt.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEditReceipt.ImageOptions.LargeImage")));
            this.bbiEditReceipt.Name = "bbiEditReceipt";
            this.bbiEditReceipt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditReceipt_ItemClick);
            // 
            // FrmReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(772, 586);
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.mainRibbonControl);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmReceipts";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmReceipts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
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
        private System.Windows.Forms.BindingSource receiptsBindingSource;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colFaReceiptDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBankName;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colBankAccountId;
        private DevExpress.XtraGrid.Columns.GridColumn colBankAccount;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpsBtnOpenFolder;
        private DevExpress.XtraEditors.ButtonEdit txbSumNetPrice;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraBars.BarButtonItem bbiNewReceipt;
        private DevExpress.XtraBars.BarButtonItem bbiEditReceipt;
    }
}