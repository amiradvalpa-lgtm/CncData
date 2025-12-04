namespace CncApp_Final.TempFrm
{
    partial class XtraForm1
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransportCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiscCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(525, 451);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CncApp_Final.Entities.Order);
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
            this.colTransportCost,
            this.colMiscCost,
            this.colDescription,
            this.colOrderDetails,
            this.colCustomerName,
            this.colFaOrderDate,
            this.colFaDeliveryDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "WXI";
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
            // colTransportCost
            // 
            this.colTransportCost.FieldName = "TransportCost";
            this.colTransportCost.Name = "colTransportCost";
            this.colTransportCost.Visible = true;
            this.colTransportCost.VisibleIndex = 6;
            // 
            // colMiscCost
            // 
            this.colMiscCost.FieldName = "MiscCost";
            this.colMiscCost.Name = "colMiscCost";
            this.colMiscCost.Visible = true;
            this.colMiscCost.VisibleIndex = 7;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 8;
            // 
            // colOrderDetails
            // 
            this.colOrderDetails.FieldName = "OrderDetails";
            this.colOrderDetails.Name = "colOrderDetails";
            this.colOrderDetails.Visible = true;
            this.colOrderDetails.VisibleIndex = 9;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.ReadOnly = true;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 10;
            // 
            // colFaOrderDate
            // 
            this.colFaOrderDate.FieldName = "FaOrderDate";
            this.colFaOrderDate.Name = "colFaOrderDate";
            this.colFaOrderDate.Visible = true;
            this.colFaOrderDate.VisibleIndex = 11;
            // 
            // colFaDeliveryDate
            // 
            this.colFaDeliveryDate.FieldName = "FaDeliveryDate";
            this.colFaDeliveryDate.Name = "colFaDeliveryDate";
            this.colFaDeliveryDate.Visible = true;
            this.colFaDeliveryDate.VisibleIndex = 12;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 451);
            this.Controls.Add(this.gridControl1);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTransportCost;
        private DevExpress.XtraGrid.Columns.GridColumn colMiscCost;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colFaOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFaDeliveryDate;
    }
}