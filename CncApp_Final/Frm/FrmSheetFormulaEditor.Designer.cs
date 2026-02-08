namespace CncApp_Final.Frm
{
    partial class FrmSheetFormulaEditor
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, null, true, true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSheetFormulaEditor));
            this.unboundExpressionPanel1 = new Standalone_ExpressionEditor.UnboundExpressionPanel();
            this.sheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
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
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.unboundExpressionPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // unboundExpressionPanel1
            // 
            this.unboundExpressionPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.unboundExpressionPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unboundExpressionPanel1.ExpressionText = null;
            this.unboundExpressionPanel1.Location = new System.Drawing.Point(2, 23);
            this.unboundExpressionPanel1.Name = "unboundExpressionPanel1";
            this.unboundExpressionPanel1.Size = new System.Drawing.Size(572, 447);
            this.unboundExpressionPanel1.TabIndex = 1;
            this.unboundExpressionPanel1.ExpressionChanged += new Standalone_ExpressionEditor.ExpressionChangedHandler(this.unboundExpressionPanel1_ExpressionChanged);
            this.unboundExpressionPanel1.VisibleChanged += new System.EventHandler(this.unboundExpressionPanel1_VisibleChanged);
            this.unboundExpressionPanel1.Resize += new System.EventHandler(this.unboundExpressionPanel1_Resize);
            // 
            // sheetsBindingSource
            // 
            this.sheetsBindingSource.DataSource = typeof(CncApp_Final.Entities.Sheet);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "WXI";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.gridControl);
            this.groupControl1.Controls.Add(this.unboundExpressionPanel1);
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl1.Location = new System.Drawing.Point(16, 140);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl1.Size = new System.Drawing.Size(576, 472);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "فرمول";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.sheetsBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 23);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(572, 447);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.Visible = false;
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
            this.colSheetPriceFormula.OptionsColumn.ShowInExpressionEditor = false;
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
            this.colPicesPriceFormula.OptionsColumn.ShowInExpressionEditor = false;
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
            // memoEdit1
            // 
            this.memoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoEdit1.Location = new System.Drawing.Point(14, 26);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.memoEdit1.Size = new System.Drawing.Size(541, 62);
            this.memoEdit1.TabIndex = 5;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.memoEdit1);
            this.groupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl2.Location = new System.Drawing.Point(16, 16);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl2.Size = new System.Drawing.Size(576, 102);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "توضیحات محاسبات فرمول";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Controls.Add(this.groupControl2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(858, 304, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(608, 628);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.splitterItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(608, 628);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl2;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(582, 108);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.groupControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 124);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(582, 478);
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.Location = new System.Drawing.Point(0, 108);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(582, 16);
            // 
            // FrmSheetFormulaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 628);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmSheetFormulaEditor.IconOptions.Image")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSheetFormulaEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "محاسبات ورق";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSheetFormulaEditor_FormClosing);
            this.Load += new System.EventHandler(this.FrmSheetFormulaEditor_Load);
            this.Shown += new System.EventHandler(this.FrmSheetFormulaEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.unboundExpressionPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Standalone_ExpressionEditor.UnboundExpressionPanel unboundExpressionPanel1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource sheetsBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colThickness_mm;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetSize;
        private DevExpress.XtraGrid.Columns.GridColumn colLastBuyPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetPriceFormula;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPicesPriceFormula;
        private DevExpress.XtraGrid.Columns.GridColumn colPicesPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colCNCPriceByMeter;
        private DevExpress.XtraGrid.Columns.GridColumn colCNCPriceBySheet;
        private DevExpress.XtraGrid.Columns.GridColumn colCNCPriceByPice;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouses;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetName;
        private DevExpress.XtraGrid.Columns.GridColumn colThickness;
        private DevExpress.XtraGrid.Columns.GridColumn colLength;
        private DevExpress.XtraGrid.Columns.GridColumn colWidth;
        private DevExpress.XtraGrid.Columns.GridColumn colTempExpression;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
    }
}

