namespace CncApp_Final.Frm
{
    partial class FrmSheetList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSheetList));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.sheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThickness_mm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastBuyPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetPriceFormula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPicesPriceFormula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPicesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNCPriceByMeter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNCPriceBySheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNCPriceByPice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouses = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThickness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTempExpression = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSheetPriceFilter = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.sheetsBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 201);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1053, 435);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // sheetsBindingSource
            // 
            this.sheetsBindingSource.DataSource = typeof(CncApp_Final.Entities.Sheet);
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colMaterial,
            this.colThickness_mm,
            this.colSheetSize,
            this.colLastBuyPrice,
            this.colSheetPriceFormula,
            this.colSheetPrice,
            this.colPicesPriceFormula,
            this.colPicesPrice,
            this.colCNCPriceByMeter,
            this.colCNCPriceBySheet,
            this.colCNCPriceByPice,
            this.colDescription,
            this.colOrderDetails,
            this.colWarehouses,
            this.colSheetName,
            this.colThickness,
            this.colLength,
            this.colWidth,
            this.colTempExpression});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.UnboundExpressionEditorCreated += new DevExpress.XtraGrid.Views.Base.UnboundExpressionEditorEventHandler(this.gridView_UnboundExpressionEditorCreated);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colMaterial
            // 
            this.colMaterial.FieldName = "Material";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.OptionsColumn.ShowInExpressionEditor = false;
            this.colMaterial.Visible = true;
            this.colMaterial.VisibleIndex = 0;
            // 
            // colThickness_mm
            // 
            this.colThickness_mm.FieldName = "Thickness_mm";
            this.colThickness_mm.Name = "colThickness_mm";
            this.colThickness_mm.OptionsColumn.ReadOnly = true;
            this.colThickness_mm.OptionsColumn.ShowInExpressionEditor = false;
            this.colThickness_mm.Visible = true;
            this.colThickness_mm.VisibleIndex = 1;
            // 
            // colSheetSize
            // 
            this.colSheetSize.FieldName = "SheetSize";
            this.colSheetSize.Name = "colSheetSize";
            this.colSheetSize.OptionsColumn.ReadOnly = true;
            this.colSheetSize.OptionsColumn.ShowInExpressionEditor = false;
            this.colSheetSize.Visible = true;
            this.colSheetSize.VisibleIndex = 2;
            // 
            // colLastBuyPrice
            // 
            this.colLastBuyPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colLastBuyPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLastBuyPrice.DisplayFormat.FormatString = "n0";
            this.colLastBuyPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colLastBuyPrice.FieldName = "LastBuyPrice";
            this.colLastBuyPrice.Name = "colLastBuyPrice";
            this.colLastBuyPrice.Visible = true;
            this.colLastBuyPrice.VisibleIndex = 3;
            // 
            // colSheetPriceFormula
            // 
            this.colSheetPriceFormula.FieldName = "SheetPriceFormula";
            this.colSheetPriceFormula.Name = "colSheetPriceFormula";
            this.colSheetPriceFormula.Visible = true;
            this.colSheetPriceFormula.VisibleIndex = 4;
            // 
            // colSheetPrice
            // 
            this.colSheetPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colSheetPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSheetPrice.DisplayFormat.FormatString = "n0";
            this.colSheetPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSheetPrice.FieldName = "SheetPrice";
            this.colSheetPrice.Name = "colSheetPrice";
            this.colSheetPrice.Visible = true;
            this.colSheetPrice.VisibleIndex = 5;
            // 
            // colPicesPriceFormula
            // 
            this.colPicesPriceFormula.FieldName = "PicesPriceFormula";
            this.colPicesPriceFormula.Name = "colPicesPriceFormula";
            this.colPicesPriceFormula.Visible = true;
            this.colPicesPriceFormula.VisibleIndex = 6;
            // 
            // colPicesPrice
            // 
            this.colPicesPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPicesPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPicesPrice.DisplayFormat.FormatString = "n0";
            this.colPicesPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPicesPrice.FieldName = "PicesPrice";
            this.colPicesPrice.Name = "colPicesPrice";
            this.colPicesPrice.Visible = true;
            this.colPicesPrice.VisibleIndex = 7;
            // 
            // colCNCPriceByMeter
            // 
            this.colCNCPriceByMeter.AppearanceCell.Options.UseTextOptions = true;
            this.colCNCPriceByMeter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCNCPriceByMeter.DisplayFormat.FormatString = "n0";
            this.colCNCPriceByMeter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCNCPriceByMeter.FieldName = "CNCPriceByMeter";
            this.colCNCPriceByMeter.Name = "colCNCPriceByMeter";
            this.colCNCPriceByMeter.Visible = true;
            this.colCNCPriceByMeter.VisibleIndex = 8;
            // 
            // colCNCPriceBySheet
            // 
            this.colCNCPriceBySheet.AppearanceCell.Options.UseTextOptions = true;
            this.colCNCPriceBySheet.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCNCPriceBySheet.DisplayFormat.FormatString = "n0";
            this.colCNCPriceBySheet.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCNCPriceBySheet.FieldName = "CNCPriceBySheet";
            this.colCNCPriceBySheet.Name = "colCNCPriceBySheet";
            this.colCNCPriceBySheet.Visible = true;
            this.colCNCPriceBySheet.VisibleIndex = 9;
            // 
            // colCNCPriceByPice
            // 
            this.colCNCPriceByPice.AppearanceCell.Options.UseTextOptions = true;
            this.colCNCPriceByPice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCNCPriceByPice.DisplayFormat.FormatString = "n0";
            this.colCNCPriceByPice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCNCPriceByPice.FieldName = "CNCPriceByPice";
            this.colCNCPriceByPice.Name = "colCNCPriceByPice";
            this.colCNCPriceByPice.Visible = true;
            this.colCNCPriceByPice.VisibleIndex = 10;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.ShowInExpressionEditor = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 11;
            // 
            // colOrderDetails
            // 
            this.colOrderDetails.FieldName = "OrderDetails";
            this.colOrderDetails.Name = "colOrderDetails";
            this.colOrderDetails.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colWarehouses
            // 
            this.colWarehouses.FieldName = "Warehouses";
            this.colWarehouses.Name = "colWarehouses";
            this.colWarehouses.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colSheetName
            // 
            this.colSheetName.FieldName = "SheetName";
            this.colSheetName.Name = "colSheetName";
            this.colSheetName.OptionsColumn.ReadOnly = true;
            this.colSheetName.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colThickness
            // 
            this.colThickness.FieldName = "Thickness";
            this.colThickness.Name = "colThickness";
            this.colThickness.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colLength
            // 
            this.colLength.FieldName = "Length";
            this.colLength.Name = "colLength";
            // 
            // colWidth
            // 
            this.colWidth.FieldName = "Width";
            this.colWidth.Name = "colWidth";
            // 
            // colTempExpression
            // 
            this.colTempExpression.Caption = "gridColumn1";
            this.colTempExpression.Name = "colTempExpression";
            this.colTempExpression.OptionsColumn.ShowInExpressionEditor = false;
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
            this.bbiRefresh,
            this.bbiSheetPriceFilter,
            this.barButtonGroup1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 22;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1053, 201);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrintPreview_ItemClick);
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
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // bbiSheetPriceFilter
            // 
            this.bbiSheetPriceFilter.Caption = "فرمول قیمت ورق";
            this.bbiSheetPriceFilter.Id = 20;
            this.bbiSheetPriceFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSheetPriceFilter.ImageOptions.Image")));
            this.bbiSheetPriceFilter.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSheetPriceFilter.ImageOptions.LargeImage")));
            this.bbiSheetPriceFilter.Name = "bbiSheetPriceFilter";
            this.bbiSheetPriceFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSheetPriceFilter_ItemClick);
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 21;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
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
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiSheetPriceFilter);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonGroup1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiRecordsCount);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 599);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1053, 37);
            // 
            // FrmSheetList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 636);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Name = "FrmSheetList";
            this.Ribbon = this.ribbonControl;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Load += new System.EventHandler(this.FrmSheetList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
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
        private System.Windows.Forms.BindingSource sheetsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colThickness;
        private DevExpress.XtraGrid.Columns.GridColumn colWidth;
        private DevExpress.XtraGrid.Columns.GridColumn colLength;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetPriceFormula;
        private DevExpress.XtraGrid.Columns.GridColumn colPicesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPicesPriceFormula;
        private DevExpress.XtraGrid.Columns.GridColumn colCNCPriceByMeter;
        private DevExpress.XtraGrid.Columns.GridColumn colCNCPriceBySheet;
        private DevExpress.XtraGrid.Columns.GridColumn colCNCPriceByPice;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouses;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetName;
        private DevExpress.XtraGrid.Columns.GridColumn colThickness_mm;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetSize;
        private DevExpress.XtraBars.BarButtonItem bbiSheetPriceFilter;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraGrid.Columns.GridColumn colTempExpression;
        private DevExpress.XtraGrid.Columns.GridColumn colLastBuyPrice;
    }
}