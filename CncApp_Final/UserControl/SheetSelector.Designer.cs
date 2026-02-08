namespace CncApp_Final.UserControl
{
    partial class SheetSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.lkpThickness = new DevExpress.XtraEditors.LookUpEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.lkpMaterial = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpSheetId = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpThickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpSheetId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.lkpThickness);
            this.groupControl5.Controls.Add(this.label15);
            this.groupControl5.Controls.Add(this.lkpMaterial);
            this.groupControl5.Controls.Add(this.lkpSheetId);
            this.groupControl5.Controls.Add(this.label2);
            this.groupControl5.Controls.Add(this.label1);
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new System.Drawing.Size(361, 102);
            this.groupControl5.TabIndex = 0;
            this.groupControl5.Text = "groupControl4";
            // 
            // lkpThickness
            // 
            this.lkpThickness.EnterMoveNextControl = true;
            this.lkpThickness.Location = new System.Drawing.Point(16, 13);
            this.lkpThickness.Name = "lkpThickness";
            this.lkpThickness.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.lkpThickness.Properties.Appearance.Options.UseFont = true;
            this.lkpThickness.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpThickness.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpThickness.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpThickness.Properties.DropDownItemHeight = 25;
            this.lkpThickness.Properties.NullText = "  ؟";
            this.lkpThickness.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkpThickness.Properties.ShowHeader = false;
            this.lkpThickness.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lkpThickness.Size = new System.Drawing.Size(76, 36);
            this.lkpThickness.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(285, 69);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "سایز ورق:";
            // 
            // lkpMaterial
            // 
            this.lkpMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpMaterial.EnterMoveNextControl = true;
            this.lkpMaterial.Location = new System.Drawing.Point(171, 13);
            this.lkpMaterial.Name = "lkpMaterial";
            this.lkpMaterial.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.lkpMaterial.Properties.Appearance.Options.UseFont = true;
            this.lkpMaterial.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpMaterial.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpMaterial.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkpMaterial.Properties.BestFitRowCount = 5;
            this.lkpMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpMaterial.Properties.DropDownItemHeight = 25;
            this.lkpMaterial.Properties.NullText = " ؟";
            this.lkpMaterial.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkpMaterial.Properties.PopupWidth = 60;
            this.lkpMaterial.Properties.ShowHeader = false;
            this.lkpMaterial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lkpMaterial.Size = new System.Drawing.Size(107, 36);
            this.lkpMaterial.TabIndex = 0;
            // 
            // lkpSheetId
            // 
            this.lkpSheetId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpSheetId.EnterMoveNextControl = true;
            this.lkpSheetId.Location = new System.Drawing.Point(16, 55);
            this.lkpSheetId.Name = "lkpSheetId";
            this.lkpSheetId.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.lkpSheetId.Properties.Appearance.Options.UseFont = true;
            this.lkpSheetId.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpSheetId.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpSheetId.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkpSheetId.Properties.BestFitRowCount = 5;
            this.lkpSheetId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpSheetId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "شناسه ورق", 5, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText", "DisplayText"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Width", "عرض", 5, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Length", "طول", 5, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetPrice", "قیمت کامل", 5, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PicesPrice", "قیمت تکه", 5, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CNCPrice", "قیمت خدمات CNC", 5, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetSize", "سایز ورق", 5, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkpSheetId.Properties.DropDownItemHeight = 25;
            this.lkpSheetId.Properties.NullText = "  ؟";
            this.lkpSheetId.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkpSheetId.Properties.PopupWidth = 60;
            this.lkpSheetId.Properties.ShowHeader = false;
            this.lkpSheetId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lkpSheetId.Size = new System.Drawing.Size(263, 36);
            this.lkpSheetId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(98, 24);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ضخامت ورق:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(285, 24);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "جنس ورق:";
            // 
            // SheetSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl5);
            this.Name = "SheetSelector";
            this.Size = new System.Drawing.Size(361, 102);
            this.Load += new System.EventHandler(this.SheetSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpThickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpSheetId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LookUpEdit lkpThickness;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.LookUpEdit lkpMaterial;
        private DevExpress.XtraEditors.LookUpEdit lkpSheetId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
