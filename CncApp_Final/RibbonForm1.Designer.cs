namespace CncApp_Final
{
    partial class RibbonForm1
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCutLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCutWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalSheetCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrooveLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCncCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransportCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiscCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetBasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierTypeDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(442, 201);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 412);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(442, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 201);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(442, 211);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colInvoiceNumber,
            this.colCustomerId,
            this.colCustomer,
            this.colOrderDate,
            this.colDeliveryDate,
            this.colFilePath,
            this.colSheetId,
            this.colSheet,
            this.colSupplier,
            this.colCutLength,
            this.colCutWidth,
            this.colFinalSheetCost,
            this.colGrooveLength,
            this.colCncCost,
            this.colTransportCost,
            this.colMiscCost,
            this.colDescription,
            this.colCustomerName,
            this.colSheetDetails,
            this.colSheetBasePrice,
            this.colSupplierTypeDescription});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.FieldName = "InvoiceNumber";
            this.colInvoiceNumber.Name = "colInvoiceNumber";
            this.colInvoiceNumber.Visible = true;
            this.colInvoiceNumber.VisibleIndex = 1;
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 2;
            // 
            // colCustomer
            // 
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Visible = true;
            this.colCustomer.VisibleIndex = 3;
            // 
            // colOrderDate
            // 
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 4;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.FieldName = "DeliveryDate";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.Visible = true;
            this.colDeliveryDate.VisibleIndex = 5;
            // 
            // colFilePath
            // 
            this.colFilePath.FieldName = "FilePath";
            this.colFilePath.Name = "colFilePath";
            this.colFilePath.Visible = true;
            this.colFilePath.VisibleIndex = 6;
            // 
            // colSheetId
            // 
            this.colSheetId.FieldName = "SheetId";
            this.colSheetId.Name = "colSheetId";
            this.colSheetId.Visible = true;
            this.colSheetId.VisibleIndex = 7;
            // 
            // colSheet
            // 
            this.colSheet.FieldName = "Sheet";
            this.colSheet.Name = "colSheet";
            this.colSheet.Visible = true;
            this.colSheet.VisibleIndex = 8;
            // 
            // colSupplier
            // 
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.Visible = true;
            this.colSupplier.VisibleIndex = 9;
            // 
            // colCutLength
            // 
            this.colCutLength.FieldName = "CutLength";
            this.colCutLength.Name = "colCutLength";
            this.colCutLength.Visible = true;
            this.colCutLength.VisibleIndex = 10;
            // 
            // colCutWidth
            // 
            this.colCutWidth.FieldName = "CutWidth";
            this.colCutWidth.Name = "colCutWidth";
            this.colCutWidth.Visible = true;
            this.colCutWidth.VisibleIndex = 11;
            // 
            // colFinalSheetCost
            // 
            this.colFinalSheetCost.FieldName = "FinalSheetCost";
            this.colFinalSheetCost.Name = "colFinalSheetCost";
            this.colFinalSheetCost.Visible = true;
            this.colFinalSheetCost.VisibleIndex = 12;
            // 
            // colGrooveLength
            // 
            this.colGrooveLength.FieldName = "GrooveLength";
            this.colGrooveLength.Name = "colGrooveLength";
            this.colGrooveLength.Visible = true;
            this.colGrooveLength.VisibleIndex = 13;
            // 
            // colCncCost
            // 
            this.colCncCost.FieldName = "CncCost";
            this.colCncCost.Name = "colCncCost";
            this.colCncCost.Visible = true;
            this.colCncCost.VisibleIndex = 14;
            // 
            // colTransportCost
            // 
            this.colTransportCost.FieldName = "TransportCost";
            this.colTransportCost.Name = "colTransportCost";
            this.colTransportCost.Visible = true;
            this.colTransportCost.VisibleIndex = 15;
            // 
            // colMiscCost
            // 
            this.colMiscCost.FieldName = "MiscCost";
            this.colMiscCost.Name = "colMiscCost";
            this.colMiscCost.Visible = true;
            this.colMiscCost.VisibleIndex = 16;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 17;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.ReadOnly = true;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 18;
            // 
            // colSheetDetails
            // 
            this.colSheetDetails.FieldName = "SheetDetails";
            this.colSheetDetails.Name = "colSheetDetails";
            this.colSheetDetails.OptionsColumn.ReadOnly = true;
            this.colSheetDetails.Visible = true;
            this.colSheetDetails.VisibleIndex = 19;
            // 
            // colSheetBasePrice
            // 
            this.colSheetBasePrice.FieldName = "SheetBasePrice";
            this.colSheetBasePrice.Name = "colSheetBasePrice";
            this.colSheetBasePrice.OptionsColumn.ReadOnly = true;
            this.colSheetBasePrice.Visible = true;
            this.colSheetBasePrice.VisibleIndex = 20;
            // 
            // colSupplierTypeDescription
            // 
            this.colSupplierTypeDescription.FieldName = "SupplierTypeDescription";
            this.colSupplierTypeDescription.Name = "colSupplierTypeDescription";
            this.colSupplierTypeDescription.OptionsColumn.ReadOnly = true;
            this.colSupplierTypeDescription.Visible = true;
            this.colSupplierTypeDescription.VisibleIndex = 21;
            // 
            // RibbonForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 449);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RibbonForm1";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "RibbonForm1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFilePath;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetId;
        private DevExpress.XtraGrid.Columns.GridColumn colSheet;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.Columns.GridColumn colCutLength;
        private DevExpress.XtraGrid.Columns.GridColumn colCutWidth;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalSheetCost;
        private DevExpress.XtraGrid.Columns.GridColumn colGrooveLength;
        private DevExpress.XtraGrid.Columns.GridColumn colCncCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTransportCost;
        private DevExpress.XtraGrid.Columns.GridColumn colMiscCost;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetBasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierTypeDescription;
    }
}