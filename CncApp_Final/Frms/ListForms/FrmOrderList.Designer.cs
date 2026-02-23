namespace CncApp_Final.Frms.ListForms
{
    partial class FrmOrderList
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
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ordersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalSheetCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCncCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransportCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiscCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiPrintPreview,
            this.bsiRecordsCount,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 20;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1098, 201);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "New";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.Name = "bbiNew";
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tasks";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Print and Export";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 612);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1098, 37);
            // 
            // ordersBindingSource
            // 
            this.ordersBindingSource.DataSource = typeof(CncApp_Final.Entities.Order);
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.ordersBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 201);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1098, 411);
            this.gridControl.TabIndex = 4;
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
            this.colInvoiceNumber,
            this.colCustomerName,
            this.colOrderTitle,
            this.colFaOrderDate,
            this.colFaDeliveryDate,
            this.colTotalSheetCost,
            this.colTotalCncCost,
            this.colTransportCost,
            this.colMiscCost,
            this.colTotalAmount,
            this.colDescription,
            this.colCustomer,
            this.colOrderDetails,
            this.colId,
            this.colCustomerId,
            this.colOrderDate,
            this.colDeliveryDate});
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
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colInvoiceNumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInvoiceNumber.Caption = "شماره فاکتور";
            this.colInvoiceNumber.FieldName = "InvoiceNumber";
            this.colInvoiceNumber.Name = "colInvoiceNumber";
            this.colInvoiceNumber.Visible = true;
            this.colInvoiceNumber.VisibleIndex = 0;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "نام مشتری";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.ReadOnly = true;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            // 
            // colOrderTitle
            // 
            this.colOrderTitle.Caption = "عنوان سفارش";
            this.colOrderTitle.FieldName = "OrderTitle";
            this.colOrderTitle.Name = "colOrderTitle";
            this.colOrderTitle.OptionsColumn.ReadOnly = true;
            this.colOrderTitle.Visible = true;
            this.colOrderTitle.VisibleIndex = 2;
            // 
            // colFaOrderDate
            // 
            this.colFaOrderDate.AppearanceCell.Options.UseTextOptions = true;
            this.colFaOrderDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFaOrderDate.Caption = "تاریخ سفارش";
            this.colFaOrderDate.FieldName = "FaOrderDate";
            this.colFaOrderDate.Name = "colFaOrderDate";
            this.colFaOrderDate.Visible = true;
            this.colFaOrderDate.VisibleIndex = 3;
            // 
            // colFaDeliveryDate
            // 
            this.colFaDeliveryDate.AppearanceCell.Options.UseTextOptions = true;
            this.colFaDeliveryDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFaDeliveryDate.Caption = "تاریخ تحویل";
            this.colFaDeliveryDate.FieldName = "FaDeliveryDate";
            this.colFaDeliveryDate.Name = "colFaDeliveryDate";
            this.colFaDeliveryDate.Visible = true;
            this.colFaDeliveryDate.VisibleIndex = 4;
            // 
            // colTotalSheetCost
            // 
            this.colTotalSheetCost.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalSheetCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotalSheetCost.Caption = "مبلغ کل ورق";
            this.colTotalSheetCost.DisplayFormat.FormatString = "n0";
            this.colTotalSheetCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalSheetCost.FieldName = "TotalSheetCost";
            this.colTotalSheetCost.Name = "colTotalSheetCost";
            this.colTotalSheetCost.OptionsColumn.ReadOnly = true;
            this.colTotalSheetCost.Visible = true;
            this.colTotalSheetCost.VisibleIndex = 5;
            // 
            // colTotalCncCost
            // 
            this.colTotalCncCost.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalCncCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotalCncCost.Caption = "مبلغ کل CNC";
            this.colTotalCncCost.DisplayFormat.FormatString = "n0";
            this.colTotalCncCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalCncCost.FieldName = "TotalCncCost";
            this.colTotalCncCost.Name = "colTotalCncCost";
            this.colTotalCncCost.OptionsColumn.ReadOnly = true;
            this.colTotalCncCost.Visible = true;
            this.colTotalCncCost.VisibleIndex = 6;
            // 
            // colTransportCost
            // 
            this.colTransportCost.AppearanceCell.Options.UseTextOptions = true;
            this.colTransportCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTransportCost.Caption = "کرایه";
            this.colTransportCost.DisplayFormat.FormatString = "n0";
            this.colTransportCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTransportCost.FieldName = "TransportCost";
            this.colTransportCost.Name = "colTransportCost";
            this.colTransportCost.Visible = true;
            this.colTransportCost.VisibleIndex = 7;
            // 
            // colMiscCost
            // 
            this.colMiscCost.AppearanceCell.Options.UseTextOptions = true;
            this.colMiscCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colMiscCost.Caption = "هزینه متفرقه";
            this.colMiscCost.DisplayFormat.FormatString = "n0";
            this.colMiscCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMiscCost.FieldName = "MiscCost";
            this.colMiscCost.Name = "colMiscCost";
            this.colMiscCost.Visible = true;
            this.colMiscCost.VisibleIndex = 8;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTotalAmount.Caption = "مبلغ کل ";
            this.colTotalAmount.DisplayFormat.FormatString = "n0";
            this.colTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalAmount.FieldName = "TotalAmount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.OptionsColumn.ReadOnly = true;
            this.colTotalAmount.Visible = true;
            this.colTotalAmount.VisibleIndex = 9;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "توضیحات";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 10;
            // 
            // colCustomer
            // 
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            // 
            // colOrderDetails
            // 
            this.colOrderDetails.FieldName = "OrderDetails";
            this.colOrderDetails.Name = "colOrderDetails";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            // 
            // colOrderDate
            // 
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.FieldName = "DeliveryDate";
            this.colDeliveryDate.Name = "colDeliveryDate";
            // 
            // FrmOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 649);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Name = "FrmOrderList";
            this.Ribbon = this.ribbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusBar = this.ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource ordersBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colFaOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalSheetCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCncCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTransportCost;
        private DevExpress.XtraGrid.Columns.GridColumn colMiscCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryDate;
    }
}