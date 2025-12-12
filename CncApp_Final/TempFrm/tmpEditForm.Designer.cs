namespace CncApp_Final.TempFrm
{
    partial class tmpEditForm
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
            this.SheetBasePriceTextEdit = new DevExpress.XtraEditors.TextEdit();
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
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SheetNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FaOrderDateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SheetLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.SheetIdLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.sheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItemForSheetName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSheet = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSheetId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFaOrderDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSheetBasePrice = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SheetBasePriceTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaOrderDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetIdLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFaOrderDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetBasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.SheetBasePriceTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SheetNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.FaOrderDateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SheetLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.SheetIdLookUpEdit);
            this.dataLayoutControl1.DataSource = this.warehousesBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSheetName,
            this.ItemForSheet});
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 201);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1048, 307, 650, 400);
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 50);
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(422, 209);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.FieldRetrieved += new System.EventHandler<DevExpress.XtraDataLayout.FieldRetrievedEventArgs>(this.dataLayoutControl1_FieldRetrieved);
            this.dataLayoutControl1.FieldRetrieving += new System.EventHandler<DevExpress.XtraDataLayout.FieldRetrievingEventArgs>(this.dataLayoutControl1_FieldRetrieving);
            // 
            // SheetBasePriceTextEdit
            // 
            this.SheetBasePriceTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "SheetBasePrice", true));
            this.SheetBasePriceTextEdit.Location = new System.Drawing.Point(16, 121);
            this.SheetBasePriceTextEdit.MenuManager = this.mainRibbonControl;
            this.SheetBasePriceTextEdit.Name = "SheetBasePriceTextEdit";
            this.SheetBasePriceTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.SheetBasePriceTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.SheetBasePriceTextEdit.Properties.MaskSettings.Set("mask", "n0");
            this.SheetBasePriceTextEdit.Size = new System.Drawing.Size(305, 28);
            this.SheetBasePriceTextEdit.StyleController = this.dataLayoutControl1;
            this.SheetBasePriceTextEdit.TabIndex = 4;
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
            this.mainRibbonControl.Size = new System.Drawing.Size(422, 201);
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
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "Description", true));
            this.DescriptionTextEdit.Location = new System.Drawing.Point(16, 165);
            this.DescriptionTextEdit.MenuManager = this.mainRibbonControl;
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Size = new System.Drawing.Size(305, 28);
            this.DescriptionTextEdit.StyleController = this.dataLayoutControl1;
            this.DescriptionTextEdit.TabIndex = 5;
            // 
            // SheetNameTextEdit
            // 
            this.SheetNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "SheetName", true));
            this.SheetNameTextEdit.Location = new System.Drawing.Point(16, 191);
            this.SheetNameTextEdit.MenuManager = this.mainRibbonControl;
            this.SheetNameTextEdit.Name = "SheetNameTextEdit";
            this.SheetNameTextEdit.Properties.ReadOnly = true;
            this.SheetNameTextEdit.Size = new System.Drawing.Size(305, 28);
            this.SheetNameTextEdit.StyleController = this.dataLayoutControl1;
            this.SheetNameTextEdit.TabIndex = 6;
            // 
            // FaOrderDateTextEdit
            // 
            this.FaOrderDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "FaOrderDate", true));
            this.FaOrderDateTextEdit.Location = new System.Drawing.Point(16, 77);
            this.FaOrderDateTextEdit.MenuManager = this.mainRibbonControl;
            this.FaOrderDateTextEdit.Name = "FaOrderDateTextEdit";
            this.FaOrderDateTextEdit.Size = new System.Drawing.Size(305, 28);
            this.FaOrderDateTextEdit.StyleController = this.dataLayoutControl1;
            this.FaOrderDateTextEdit.TabIndex = 7;
            // 
            // SheetLookUpEdit
            // 
            this.SheetLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "Sheet", true));
            this.SheetLookUpEdit.Location = new System.Drawing.Point(16, 16);
            this.SheetLookUpEdit.MenuManager = this.mainRibbonControl;
            this.SheetLookUpEdit.Name = "SheetLookUpEdit";
            this.SheetLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SheetLookUpEdit.Properties.NullText = "";
            this.SheetLookUpEdit.Size = new System.Drawing.Size(305, 28);
            this.SheetLookUpEdit.StyleController = this.dataLayoutControl1;
            this.SheetLookUpEdit.TabIndex = 8;
            // 
            // SheetIdLookUpEdit
            // 
            this.SheetIdLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.warehousesBindingSource, "SheetId", true));
            this.SheetIdLookUpEdit.Location = new System.Drawing.Point(16, 33);
            this.SheetIdLookUpEdit.MenuManager = this.mainRibbonControl;
            this.SheetIdLookUpEdit.Name = "SheetIdLookUpEdit";
            this.SheetIdLookUpEdit.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.SheetIdLookUpEdit.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SheetIdLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SheetIdLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "شناسه ورق", 73, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetPrice", "قیمت کامل", 67, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PicesPrice", "قیمت تکه", 60, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetName", "نام ورق", 51, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.SheetIdLookUpEdit.Properties.DataSource = this.sheetsBindingSource;
            this.SheetIdLookUpEdit.Properties.DisplayMember = "SheetName";
            this.SheetIdLookUpEdit.Properties.DropDownItemHeight = 25;
            this.SheetIdLookUpEdit.Properties.NullText = "";
            this.SheetIdLookUpEdit.Properties.PopupSizeable = false;
            this.SheetIdLookUpEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.SheetIdLookUpEdit.Properties.ShowFooter = false;
            this.SheetIdLookUpEdit.Properties.ShowHeader = false;
            this.SheetIdLookUpEdit.Properties.UseDropDownRowsAsMaxCount = true;
            this.SheetIdLookUpEdit.Properties.ValueMember = "Id";
            this.SheetIdLookUpEdit.Size = new System.Drawing.Size(305, 28);
            this.SheetIdLookUpEdit.StyleController = this.dataLayoutControl1;
            this.SheetIdLookUpEdit.TabIndex = 10;
            // 
            // sheetsBindingSource
            // 
            this.sheetsBindingSource.DataSource = typeof(CncApp_Final.Entities.Sheet);
            // 
            // ItemForSheetName
            // 
            this.ItemForSheetName.Control = this.SheetNameTextEdit;
            this.ItemForSheetName.Location = new System.Drawing.Point(0, 7);
            this.ItemForSheetName.Name = "ItemForSheetName";
            this.ItemForSheetName.Size = new System.Drawing.Size(396, 222);
            this.ItemForSheetName.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 20, 20);
            this.ItemForSheetName.Text = "نام ورق";
            this.ItemForSheetName.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForSheet
            // 
            this.ItemForSheet.Control = this.SheetLookUpEdit;
            this.ItemForSheet.Location = new System.Drawing.Point(0, 0);
            this.ItemForSheet.Name = "ItemForSheet";
            this.ItemForSheet.Size = new System.Drawing.Size(396, 34);
            this.ItemForSheet.Text = "ورق";
            this.ItemForSheet.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.ItemForSheetId,
            this.ItemForFaOrderDate,
            this.ItemForSheetBasePrice,
            this.ItemForDescription});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(422, 209);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(396, 17);
            // 
            // ItemForSheetId
            // 
            this.ItemForSheetId.Control = this.SheetIdLookUpEdit;
            this.ItemForSheetId.Location = new System.Drawing.Point(0, 17);
            this.ItemForSheetId.Name = "ItemForSheetId";
            this.ItemForSheetId.Size = new System.Drawing.Size(396, 34);
            this.ItemForSheetId.Text = "شناسه ورق";
            this.ItemForSheetId.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForFaOrderDate
            // 
            this.ItemForFaOrderDate.Control = this.FaOrderDateTextEdit;
            this.ItemForFaOrderDate.Location = new System.Drawing.Point(0, 51);
            this.ItemForFaOrderDate.Name = "ItemForFaOrderDate";
            this.ItemForFaOrderDate.Size = new System.Drawing.Size(396, 44);
            this.ItemForFaOrderDate.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            this.ItemForFaOrderDate.Text = "تاریخ خرید";
            this.ItemForFaOrderDate.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForSheetBasePrice
            // 
            this.ItemForSheetBasePrice.Control = this.SheetBasePriceTextEdit;
            this.ItemForSheetBasePrice.Location = new System.Drawing.Point(0, 95);
            this.ItemForSheetBasePrice.Name = "ItemForSheetBasePrice";
            this.ItemForSheetBasePrice.Size = new System.Drawing.Size(396, 44);
            this.ItemForSheetBasePrice.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            this.ItemForSheetBasePrice.Text = "قیمت پایه کامل";
            this.ItemForSheetBasePrice.TextSize = new System.Drawing.Size(69, 13);
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.DescriptionTextEdit;
            this.ItemForDescription.Location = new System.Drawing.Point(0, 139);
            this.ItemForDescription.Name = "ItemForDescription";
            this.ItemForDescription.Size = new System.Drawing.Size(396, 44);
            this.ItemForDescription.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 10, 0);
            this.ItemForDescription.Text = "توضیحات";
            this.ItemForDescription.TextSize = new System.Drawing.Size(69, 13);
            // 
            // tmpEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(422, 410);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "tmpEditForm";
            this.Ribbon = this.mainRibbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.tmpEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SheetBasePriceTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaOrderDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetIdLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFaOrderDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSheetBasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit SheetBasePriceTextEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraEditors.TextEdit SheetNameTextEdit;
        private DevExpress.XtraEditors.TextEdit FaOrderDateTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSheetBasePrice;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSheetName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFaOrderDate;
        private DevExpress.XtraEditors.LookUpEdit SheetLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSheet;
        private DevExpress.XtraEditors.LookUpEdit SheetIdLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSheetId;
        private System.Windows.Forms.BindingSource sheetsBindingSource;
    }
}