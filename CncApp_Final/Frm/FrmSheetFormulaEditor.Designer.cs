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
            this.unboundExpressionPanel1 = new Standalone_ExpressionEditor.UnboundExpressionPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThickness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetPriceFormula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPicesPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPicesPriceFormula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNCPriceByMeter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNCPriceBySheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNCPriceByPice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.rowId = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowMaterial = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowThickness = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowWidth = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowLength = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSheetPrice = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSheetPriceFormula = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPicesPrice = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowPicesPriceFormula = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCNCPriceByMeter = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCNCPriceBySheet = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowCNCPriceByPice = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDescription = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowOrderDetails = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowWarehouses = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSheetName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowThickness_mm = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowSheetSize = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.row = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ((System.ComponentModel.ISupportInitialize)(this.unboundExpressionPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // unboundExpressionPanel1
            // 
            this.unboundExpressionPanel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.unboundExpressionPanel1.Location = new System.Drawing.Point(5, 5);
            this.unboundExpressionPanel1.Name = "unboundExpressionPanel1";
            this.unboundExpressionPanel1.Size = new System.Drawing.Size(569, 426);
            this.unboundExpressionPanel1.TabIndex = 1;
            this.unboundExpressionPanel1.Resize += new System.EventHandler(this.unboundExpressionPanel1_Resize);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.sheetsBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(393, 335);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sheetsBindingSource
            // 
            this.sheetsBindingSource.DataSource = typeof(CncApp_Final.Entities.Sheet);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colMaterial,
            this.colThickness,
            this.colWidth,
            this.colLength,
            this.colSheetPrice,
            this.colSheetPriceFormula,
            this.colPicesPrice,
            this.colPicesPriceFormula,
            this.colCNCPriceByMeter,
            this.colCNCPriceBySheet,
            this.colCNCPriceByPice,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView1_CustomUnboundColumnData);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ShowInExpressionEditor = false;
            this.colId.ShowUnboundExpressionMenu = true;
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colMaterial
            // 
            this.colMaterial.FieldName = "Material";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.Visible = true;
            this.colMaterial.VisibleIndex = 1;
            // 
            // colThickness
            // 
            this.colThickness.FieldName = "Thickness";
            this.colThickness.Name = "colThickness";
            this.colThickness.Visible = true;
            this.colThickness.VisibleIndex = 2;
            // 
            // colWidth
            // 
            this.colWidth.FieldName = "Width";
            this.colWidth.Name = "colWidth";
            this.colWidth.Visible = true;
            this.colWidth.VisibleIndex = 3;
            // 
            // colLength
            // 
            this.colLength.FieldName = "Length";
            this.colLength.Name = "colLength";
            this.colLength.Visible = true;
            this.colLength.VisibleIndex = 4;
            // 
            // colSheetPrice
            // 
            this.colSheetPrice.FieldName = "SheetPrice";
            this.colSheetPrice.Name = "colSheetPrice";
            this.colSheetPrice.ShowUnboundExpressionMenu = true;
            this.colSheetPrice.UnboundDataType = typeof(double);
            this.colSheetPrice.UnboundExpression = "[Length] + 1";
            this.colSheetPrice.Visible = true;
            this.colSheetPrice.VisibleIndex = 5;
            // 
            // colSheetPriceFormula
            // 
            this.colSheetPriceFormula.FieldName = "SheetPriceFormula";
            this.colSheetPriceFormula.Name = "colSheetPriceFormula";
            this.colSheetPriceFormula.Visible = true;
            this.colSheetPriceFormula.VisibleIndex = 6;
            // 
            // colPicesPrice
            // 
            this.colPicesPrice.FieldName = "PicesPrice";
            this.colPicesPrice.Name = "colPicesPrice";
            this.colPicesPrice.Visible = true;
            this.colPicesPrice.VisibleIndex = 7;
            // 
            // colPicesPriceFormula
            // 
            this.colPicesPriceFormula.FieldName = "PicesPriceFormula";
            this.colPicesPriceFormula.Name = "colPicesPriceFormula";
            this.colPicesPriceFormula.Visible = true;
            this.colPicesPriceFormula.VisibleIndex = 8;
            // 
            // colCNCPriceByMeter
            // 
            this.colCNCPriceByMeter.FieldName = "CNCPriceByMeter";
            this.colCNCPriceByMeter.Name = "colCNCPriceByMeter";
            this.colCNCPriceByMeter.Visible = true;
            this.colCNCPriceByMeter.VisibleIndex = 9;
            // 
            // colCNCPriceBySheet
            // 
            this.colCNCPriceBySheet.FieldName = "CNCPriceBySheet";
            this.colCNCPriceBySheet.Name = "colCNCPriceBySheet";
            this.colCNCPriceBySheet.Visible = true;
            this.colCNCPriceBySheet.VisibleIndex = 10;
            // 
            // colCNCPriceByPice
            // 
            this.colCNCPriceByPice.FieldName = "CNCPriceByPice";
            this.colCNCPriceByPice.Name = "colCNCPriceByPice";
            this.colCNCPriceByPice.Visible = true;
            this.colCNCPriceByPice.VisibleIndex = 11;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.ShowUnboundExpressionMenu = true;
            this.gridColumn1.UnboundDataType = typeof(double);
            this.gridColumn1.UnboundExpression = "[Width] + 10";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 12;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(12, 27);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(393, 28);
            this.comboBoxEdit1.TabIndex = 3;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "WXI";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.unboundExpressionPanel1);
            this.groupControl1.Location = new System.Drawing.Point(427, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(579, 437);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // vGridControl1
            // 
            this.vGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridControl1.DataSource = this.sheetsBindingSource;
            this.vGridControl1.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.vGridControl1.Location = new System.Drawing.Point(411, 34);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowId,
            this.rowMaterial,
            this.rowThickness,
            this.rowWidth,
            this.rowLength,
            this.rowSheetPrice,
            this.rowSheetPriceFormula,
            this.rowPicesPrice,
            this.rowPicesPriceFormula,
            this.rowCNCPriceByMeter,
            this.rowCNCPriceBySheet,
            this.rowCNCPriceByPice,
            this.rowDescription,
            this.rowOrderDetails,
            this.rowWarehouses,
            this.rowSheetName,
            this.rowThickness_mm,
            this.rowSheetSize,
            this.row});
            this.vGridControl1.Size = new System.Drawing.Size(400, 406);
            this.vGridControl1.TabIndex = 5;
            this.vGridControl1.CustomUnboundData += new DevExpress.XtraVerticalGrid.Events.CustomDataEventHandler(this.vGridControl1_CustomUnboundData);
            this.vGridControl1.Click += new System.EventHandler(this.vGridControl1_Click);
            // 
            // rowId
            // 
            this.rowId.Name = "rowId";
            this.rowId.Properties.FieldName = "Id";
            this.rowId.Properties.ShowUnboundExpressionMenu = true;
            this.rowId.Visible = false;
            // 
            // rowMaterial
            // 
            this.rowMaterial.Name = "rowMaterial";
            this.rowMaterial.Properties.FieldName = "Material";
            // 
            // rowThickness
            // 
            this.rowThickness.Name = "rowThickness";
            this.rowThickness.Properties.FieldName = "Thickness";
            // 
            // rowWidth
            // 
            this.rowWidth.Name = "rowWidth";
            this.rowWidth.Properties.FieldName = "Width";
            // 
            // rowLength
            // 
            this.rowLength.Name = "rowLength";
            this.rowLength.Properties.FieldName = "Length";
            // 
            // rowSheetPrice
            // 
            this.rowSheetPrice.Name = "rowSheetPrice";
            this.rowSheetPrice.Properties.FieldName = "SheetPrice";
            // 
            // rowSheetPriceFormula
            // 
            this.rowSheetPriceFormula.Name = "rowSheetPriceFormula";
            this.rowSheetPriceFormula.Properties.FieldName = "SheetPriceFormula";
            // 
            // rowPicesPrice
            // 
            this.rowPicesPrice.Name = "rowPicesPrice";
            this.rowPicesPrice.Properties.FieldName = "PicesPrice";
            // 
            // rowPicesPriceFormula
            // 
            this.rowPicesPriceFormula.Name = "rowPicesPriceFormula";
            this.rowPicesPriceFormula.Properties.FieldName = "PicesPriceFormula";
            // 
            // rowCNCPriceByMeter
            // 
            this.rowCNCPriceByMeter.Name = "rowCNCPriceByMeter";
            this.rowCNCPriceByMeter.Properties.FieldName = "CNCPriceByMeter";
            // 
            // rowCNCPriceBySheet
            // 
            this.rowCNCPriceBySheet.Name = "rowCNCPriceBySheet";
            this.rowCNCPriceBySheet.Properties.FieldName = "CNCPriceBySheet";
            // 
            // rowCNCPriceByPice
            // 
            this.rowCNCPriceByPice.Name = "rowCNCPriceByPice";
            this.rowCNCPriceByPice.Properties.FieldName = "CNCPriceByPice";
            // 
            // rowDescription
            // 
            this.rowDescription.Name = "rowDescription";
            this.rowDescription.Properties.FieldName = "Description";
            // 
            // rowOrderDetails
            // 
            this.rowOrderDetails.Name = "rowOrderDetails";
            this.rowOrderDetails.Properties.FieldName = "OrderDetails";
            // 
            // rowWarehouses
            // 
            this.rowWarehouses.Name = "rowWarehouses";
            this.rowWarehouses.Properties.FieldName = "Warehouses";
            // 
            // rowSheetName
            // 
            this.rowSheetName.Name = "rowSheetName";
            this.rowSheetName.Properties.FieldName = "SheetName";
            // 
            // rowThickness_mm
            // 
            this.rowThickness_mm.Name = "rowThickness_mm";
            this.rowThickness_mm.Properties.FieldName = "Thickness_mm";
            // 
            // rowSheetSize
            // 
            this.rowSheetSize.Name = "rowSheetSize";
            this.rowSheetSize.Properties.FieldName = "SheetSize";
            // 
            // row
            // 
            this.row.Name = "row";
            this.row.Properties.Caption = "row";
            this.row.Properties.FieldName = "row0";
            this.row.Properties.ShowUnboundExpressionMenu = true;
            this.row.Properties.UnboundDataType = typeof(double);
            this.row.Properties.UnboundExpression = "[Thickness] * 10";
            // 
            // FrmSheetFormulaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 457);
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmSheetFormulaEditor";
            this.Text = "محاسبات ورق";
            this.Load += new System.EventHandler(this.FrmSheetFormulaEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unboundExpressionPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Standalone_ExpressionEditor.UnboundExpressionPanel unboundExpressionPanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowId;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowMaterial;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowThickness;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowWidth;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowLength;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSheetPrice;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSheetPriceFormula;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPicesPrice;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowPicesPriceFormula;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCNCPriceByMeter;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCNCPriceBySheet;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowCNCPriceByPice;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDescription;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowOrderDetails;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowWarehouses;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSheetName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowThickness_mm;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowSheetSize;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow row;
    }
}

