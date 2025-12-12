namespace CncApp_Final.Frm
{
    partial class FrmWareHouseX
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWareHouseX));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.warehouseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSheetName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetBasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheetId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSheet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpsBtnOpenFolder = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.txbSumNetPrice = new DevExpress.XtraEditors.ButtonEdit();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBtnOpenFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbSumNetPrice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl7
            // 
            this.groupControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl7.Controls.Add(this.gridControl);
            this.groupControl7.Controls.Add(this.txbSumNetPrice);
            this.groupControl7.Controls.Add(this.label7);
            this.groupControl7.Location = new System.Drawing.Point(12, 130);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.ShowCaption = false;
            this.groupControl7.Size = new System.Drawing.Size(801, 349);
            this.groupControl7.TabIndex = 5;
            this.groupControl7.Text = "groupControl7";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.warehouseBindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpsBtnOpenFolder});
            this.gridControl.Size = new System.Drawing.Size(797, 345);
            this.gridControl.TabIndex = 25;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // warehouseBindingSource
            // 
            this.warehouseBindingSource.DataSource = typeof(CncApp_Final.Entities.Warehouse);
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
            this.colSheetName,
            this.colFaOrderDate,
            this.colSheetBasePrice,
            this.colDescription,
            this.colId,
            this.colSheetId,
            this.colSheet,
            this.colOrderDate});
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
            // colSheetName
            // 
            this.colSheetName.FieldName = "SheetName";
            this.colSheetName.Name = "colSheetName";
            this.colSheetName.OptionsColumn.ReadOnly = true;
            this.colSheetName.Visible = true;
            this.colSheetName.VisibleIndex = 0;
            // 
            // colFaOrderDate
            // 
            this.colFaOrderDate.FieldName = "FaOrderDate";
            this.colFaOrderDate.Name = "colFaOrderDate";
            this.colFaOrderDate.Visible = true;
            this.colFaOrderDate.VisibleIndex = 1;
            // 
            // colSheetBasePrice
            // 
            this.colSheetBasePrice.FieldName = "SheetBasePrice";
            this.colSheetBasePrice.Name = "colSheetBasePrice";
            this.colSheetBasePrice.Visible = true;
            this.colSheetBasePrice.VisibleIndex = 2;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colSheetId
            // 
            this.colSheetId.FieldName = "SheetId";
            this.colSheetId.Name = "colSheetId";
            // 
            // colSheet
            // 
            this.colSheet.FieldName = "Sheet";
            this.colSheet.Name = "colSheet";
            // 
            // colOrderDate
            // 
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            // 
            // rpsBtnOpenFolder
            // 
            this.rpsBtnOpenFolder.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.rpsBtnOpenFolder.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Open", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.rpsBtnOpenFolder.Name = "rpsBtnOpenFolder";
            this.rpsBtnOpenFolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // txbSumNetPrice
            // 
            this.txbSumNetPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbSumNetPrice.EditValue = 0;
            this.txbSumNetPrice.Location = new System.Drawing.Point(11, 309);
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
            this.label7.Location = new System.Drawing.Point(149, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "مجموع قیمت خدمات :";
            // 
            // FrmWareHouseX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 491);
            this.Controls.Add(this.groupControl7);
            this.Name = "FrmWareHouseX";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmWareHouse";
            this.Load += new System.EventHandler(this.FrmWareHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.warehouseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpsBtnOpenFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbSumNetPrice.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rpsBtnOpenFolder;
        private DevExpress.XtraEditors.ButtonEdit txbSumNetPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource warehouseBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetName;
        private DevExpress.XtraGrid.Columns.GridColumn colFaOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetBasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colSheetId;
        private DevExpress.XtraGrid.Columns.GridColumn colSheet;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
    }
}