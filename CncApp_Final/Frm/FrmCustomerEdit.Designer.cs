namespace CncApp_Final.Frm
{
    partial class FrmCustomerEdit
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerEdit));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.txbCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbBanalceMode = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txbMhkCustomerId = new DevExpress.XtraEditors.TextEdit();
            this.txbBeginning_Balance = new DevExpress.XtraEditors.TextEdit();
            this.txbDescription = new DevExpress.XtraEditors.TextEdit();
            this.txbAddress = new DevExpress.XtraEditors.TextEdit();
            this.txbPhone = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBanalceMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbMhkCustomerId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbBeginning_Balance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ApplicationCaption = "ویرایش مشخصات مشتری";
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
            this.mainRibbonControl.Size = new System.Drawing.Size(460, 201);
            this.mainRibbonControl.Toolbar.ShowCustomizeItem = false;
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
            this.bbiReset.Enabled = false;
            this.bbiReset.Id = 5;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReset_ItemClick);
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
            // txbCustomerName
            // 
            this.txbCustomerName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerBindingSource, "CustomerName", true));
            this.txbCustomerName.EnterMoveNextControl = true;
            this.txbCustomerName.Location = new System.Drawing.Point(19, 46);
            this.txbCustomerName.MenuManager = this.mainRibbonControl;
            this.txbCustomerName.Name = "txbCustomerName";
            this.txbCustomerName.Properties.ValidateOnEnterKey = true;
            this.txbCustomerName.Size = new System.Drawing.Size(324, 28);
            this.txbCustomerName.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.txbCustomerName, conditionValidationRule1);
            this.txbCustomerName.EditValueChanged += new System.EventHandler(this.txbCustomerName_EditValueChanged);
            this.txbCustomerName.Leave += new System.EventHandler(this.txbCustomerName_Leave);
            this.txbCustomerName.Validating += new System.ComponentModel.CancelEventHandler(this.txbCustomerName_Validating);
            this.txbCustomerName.Validated += new System.EventHandler(this.txbCustomerName_Validated);
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(CncApp_Final.Entities.Customer);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.cmbBanalceMode);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txbMhkCustomerId);
            this.groupControl1.Controls.Add(this.txbBeginning_Balance);
            this.groupControl1.Controls.Add(this.txbDescription);
            this.groupControl1.Controls.Add(this.txbAddress);
            this.groupControl1.Controls.Add(this.txbPhone);
            this.groupControl1.Controls.Add(this.txbCustomerName);
            this.groupControl1.Location = new System.Drawing.Point(12, 220);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(436, 302);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "مشخصات مشتری";
            // 
            // cmbBanalceMode
            // 
            this.cmbBanalceMode.EnterMoveNextControl = true;
            this.cmbBanalceMode.Location = new System.Drawing.Point(19, 214);
            this.cmbBanalceMode.MenuManager = this.mainRibbonControl;
            this.cmbBanalceMode.Name = "cmbBanalceMode";
            this.cmbBanalceMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBanalceMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("بی حساب", 0D, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("بدهکار", -1D, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("بستانکار", 1D, 2)});
            this.cmbBanalceMode.Properties.SmallImages = this.imageCollection1;
            this.cmbBanalceMode.Size = new System.Drawing.Size(121, 28);
            this.cmbBanalceMode.TabIndex = 5;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("apply_16x16.png", "images/actions/apply_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "apply_16x16.png");
            this.imageCollection1.InsertGalleryImage("cancel_16x16.png", "images/actions/cancel_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "cancel_16x16.png");
            this.imageCollection1.InsertGalleryImage("add_16x16.png", "images/actions/add_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png"), 2);
            this.imageCollection1.Images.SetKeyName(2, "add_16x16.png");
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(349, 263);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(82, 13);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "کد مشتری محک:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(146, 221);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(75, 13);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "ماهیت اول دوره:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(349, 221);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "مانده اول دوره:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(349, 179);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "توضیحات:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(349, 137);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "آدرس:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(349, 95);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "شماره تماس:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(349, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "نام مشتری:";
            // 
            // txbMhkCustomerId
            // 
            this.txbMhkCustomerId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerBindingSource, "MhkCustomerId", true));
            this.txbMhkCustomerId.EnterMoveNextControl = true;
            this.txbMhkCustomerId.Location = new System.Drawing.Point(19, 256);
            this.txbMhkCustomerId.Name = "txbMhkCustomerId";
            this.txbMhkCustomerId.Size = new System.Drawing.Size(324, 28);
            this.txbMhkCustomerId.TabIndex = 6;
            // 
            // txbBeginning_Balance
            // 
            this.txbBeginning_Balance.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerBindingSource, "Beginning_Balance", true));
            this.txbBeginning_Balance.EnterMoveNextControl = true;
            this.txbBeginning_Balance.Location = new System.Drawing.Point(238, 214);
            this.txbBeginning_Balance.Name = "txbBeginning_Balance";
            this.txbBeginning_Balance.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbBeginning_Balance.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txbBeginning_Balance.Properties.MaskSettings.Set("mask", "n0");
            this.txbBeginning_Balance.Properties.UseMaskAsDisplayFormat = true;
            this.txbBeginning_Balance.Size = new System.Drawing.Size(105, 28);
            this.txbBeginning_Balance.TabIndex = 4;
            // 
            // txbDescription
            // 
            this.txbDescription.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerBindingSource, "Description", true));
            this.txbDescription.EnterMoveNextControl = true;
            this.txbDescription.Location = new System.Drawing.Point(19, 172);
            this.txbDescription.Name = "txbDescription";
            this.txbDescription.Size = new System.Drawing.Size(324, 28);
            this.txbDescription.TabIndex = 3;
            // 
            // txbAddress
            // 
            this.txbAddress.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerBindingSource, "Address", true));
            this.txbAddress.EnterMoveNextControl = true;
            this.txbAddress.Location = new System.Drawing.Point(19, 130);
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(324, 28);
            this.txbAddress.TabIndex = 2;
            this.txbAddress.EditValueChanged += new System.EventHandler(this.txbAddress_EditValueChanged);
            // 
            // txbPhone
            // 
            this.txbPhone.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.customerBindingSource, "Phone", true));
            this.txbPhone.EditValue = "09147121463";
            this.txbPhone.EnterMoveNextControl = true;
            this.txbPhone.Location = new System.Drawing.Point(19, 88);
            this.txbPhone.Name = "txbPhone";
            this.txbPhone.Properties.Appearance.Options.UseTextOptions = true;
            this.txbPhone.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txbPhone.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txbPhone.Properties.MaskSettings.Set("mask", "0000 000 0000");
            this.txbPhone.Properties.UseMaskAsDisplayFormat = true;
            this.txbPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPhone.Size = new System.Drawing.Size(324, 28);
            this.txbPhone.TabIndex = 1;
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.dxValidationProvider1.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.dxValidationProvider1_ValidationFailed);
            // 
            // FrmCustomerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(460, 534);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.IconOptions.ShowIcon = false;
            this.Name = "FrmCustomerEdit";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmCustomerEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBanalceMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbMhkCustomerId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbBeginning_Balance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPhone.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txbCustomerName;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txbMhkCustomerId;
        private DevExpress.XtraEditors.TextEdit txbBeginning_Balance;
        private DevExpress.XtraEditors.TextEdit txbDescription;
        private DevExpress.XtraEditors.TextEdit txbAddress;
        private DevExpress.XtraEditors.TextEdit txbPhone;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbBanalceMode;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}