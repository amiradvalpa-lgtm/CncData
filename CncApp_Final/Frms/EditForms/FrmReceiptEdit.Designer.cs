namespace CncApp_Final.Frms.EditForms
{
    partial class FrmReceiptEdit
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
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txbDate = new CncApp_Final.Helper.PersianDateTextEdit();
            this.receiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txbDescription = new DevExpress.XtraEditors.TextEdit();
            this.txbAmount = new DevExpress.XtraEditors.TextEdit();
            this.lkpBanks = new DevExpress.XtraEditors.LookUpEdit();
            this.banksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lkpCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBanks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.banksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ApplicationCaption = "دریافت از مشتری";
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
            this.mainRibbonControl.Size = new System.Drawing.Size(423, 201);
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
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndClose);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSaveAndNew);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiReset);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiDelete);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiClose);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.txbDate);
            this.groupControl1.Controls.Add(this.txbDescription);
            this.groupControl1.Controls.Add(this.txbAmount);
            this.groupControl1.Controls.Add(this.lkpBanks);
            this.groupControl1.Controls.Add(this.lkpCustomer);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 222);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(399, 297);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "مشخصات مشتری";
            // 
            // txbDate
            // 
            this.txbDate.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbDate.Appearance.Options.UseFont = true;
            this.txbDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBindingSource, "Date", true));
            this.txbDate.EditValue = null;
            this.txbDate.Location = new System.Drawing.Point(19, 95);
            this.txbDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbDate.Name = "txbDate";
            this.txbDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbDate.Size = new System.Drawing.Size(286, 36);
            this.txbDate.TabIndex = 1;
            // 
            // receiptBindingSource
            // 
            this.receiptBindingSource.DataSource = typeof(CncApp_Final.Entities.Receipt);
            // 
            // txbDescription
            // 
            this.txbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBindingSource, "Description", true));
            this.txbDescription.EditValue = "";
            this.txbDescription.EnterMoveNextControl = true;
            this.txbDescription.Location = new System.Drawing.Point(19, 242);
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbDescription.Properties.Appearance.Options.UseFont = true;
            this.txbDescription.Size = new System.Drawing.Size(287, 36);
            this.txbDescription.TabIndex = 4;
            // 
            // txbAmount
            // 
            this.txbAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbAmount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBindingSource, "Amount", true));
            this.txbAmount.EditValue = "1404/09/11";
            this.txbAmount.EnterMoveNextControl = true;
            this.txbAmount.Location = new System.Drawing.Point(19, 144);
            this.txbAmount.Name = "txbAmount";
            this.txbAmount.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbAmount.Properties.Appearance.Options.UseFont = true;
            this.txbAmount.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbAmount.Properties.MaskSettings.Set("mask", "n0");
            this.txbAmount.Properties.UseMaskAsDisplayFormat = true;
            this.txbAmount.Size = new System.Drawing.Size(287, 36);
            this.txbAmount.TabIndex = 2;
            // 
            // lkpBanks
            // 
            this.lkpBanks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpBanks.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBindingSource, "BankAccountId", true));
            this.lkpBanks.EnterMoveNextControl = true;
            this.lkpBanks.Location = new System.Drawing.Point(19, 193);
            this.lkpBanks.Name = "lkpBanks";
            this.lkpBanks.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpBanks.Properties.Appearance.Options.UseFont = true;
            this.lkpBanks.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpBanks.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpBanks.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpBanks.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShortName", "نام حساب", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkpBanks.Properties.DataSource = this.banksBindingSource;
            this.lkpBanks.Properties.DisplayMember = "ShortName";
            this.lkpBanks.Properties.DropDownItemHeight = 25;
            this.lkpBanks.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkpBanks.Properties.ShowHeader = false;
            this.lkpBanks.Properties.ValueMember = "Id";
            this.lkpBanks.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lkpBanks.Size = new System.Drawing.Size(287, 36);
            this.lkpBanks.TabIndex = 3;
            // 
            // banksBindingSource
            // 
            this.banksBindingSource.DataSource = typeof(CncApp_Final.Entities.BankAccount);
            // 
            // lkpCustomer
            // 
            this.lkpCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpCustomer.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.receiptBindingSource, "CustomerId", true));
            this.lkpCustomer.EnterMoveNextControl = true;
            this.lkpCustomer.Location = new System.Drawing.Point(19, 46);
            this.lkpCustomer.Name = "lkpCustomer";
            this.lkpCustomer.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkpCustomer.Properties.Appearance.Options.UseFont = true;
            this.lkpCustomer.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpCustomer.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 26, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CustomerFullName", "نام مشتری", 92, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkpCustomer.Properties.DataSource = this.customersBindingSource;
            this.lkpCustomer.Properties.DisplayMember = "CustomerFullName";
            this.lkpCustomer.Properties.DropDownItemHeight = 25;
            this.lkpCustomer.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkpCustomer.Properties.ShowHeader = false;
            this.lkpCustomer.Properties.ValueMember = "Id";
            this.lkpCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lkpCustomer.Size = new System.Drawing.Size(287, 36);
            this.lkpCustomer.TabIndex = 0;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataSource = typeof(CncApp_Final.Entities.Customer);
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Location = new System.Drawing.Point(312, 203);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(40, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "نام بانک:";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(312, 252);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "توضیحات:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(312, 154);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "مبلغ پرداختی:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(312, 105);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "تاریخ پرداخت:";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(312, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "نام مشتری:";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "WXI";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // FrmReceiptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(423, 531);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReceiptEdit";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpBanks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.banksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkpCustomer;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.TextEdit txbDescription;
        private DevExpress.XtraEditors.TextEdit txbAmount;
        private DevExpress.XtraEditors.LookUpEdit lkpBanks;
        private System.Windows.Forms.BindingSource banksBindingSource;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private System.Windows.Forms.BindingSource receiptBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private Helper.PersianDateTextEdit txbDate;
    }
}