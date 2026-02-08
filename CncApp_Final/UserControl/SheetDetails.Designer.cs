namespace CncApp_Final.UserControl
{
    partial class SheetDetails
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
            this.txbThickness = new DevExpress.XtraEditors.TextEdit();
            this.txbLength = new DevExpress.XtraEditors.TextEdit();
            this.txbWidth = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lkpMaterial = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbThickness.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMaterial.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.txbThickness);
            this.groupControl5.Controls.Add(this.txbLength);
            this.groupControl5.Controls.Add(this.txbWidth);
            this.groupControl5.Controls.Add(this.label3);
            this.groupControl5.Controls.Add(this.label15);
            this.groupControl5.Controls.Add(this.lkpMaterial);
            this.groupControl5.Controls.Add(this.label2);
            this.groupControl5.Controls.Add(this.label1);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.groupControl5.Location = new System.Drawing.Point(0, 0);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupControl5.Size = new System.Drawing.Size(556, 83);
            this.groupControl5.TabIndex = 1;
            this.groupControl5.Text = "مشخصات ورق";
            // 
            // txbThickness
            // 
            this.txbThickness.EnterMoveNextControl = true;
            this.txbThickness.Location = new System.Drawing.Point(227, 34);
            this.txbThickness.Name = "txbThickness";
            this.txbThickness.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txbThickness.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbThickness.Properties.Appearance.Options.UseFont = true;
            this.txbThickness.Properties.Appearance.Options.UseTextOptions = true;
            this.txbThickness.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txbThickness.Properties.DisplayFormat.FormatString = "n0";
            this.txbThickness.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txbThickness.Properties.EditFormat.FormatString = "n0";
            this.txbThickness.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txbThickness.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbThickness.Properties.MaskSettings.Set("mask", "n0");
            this.txbThickness.Properties.MaxLength = 9;
            this.txbThickness.Properties.NullValuePrompt = " ؟";
            this.txbThickness.Properties.UseMaskAsDisplayFormat = true;
            this.txbThickness.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbThickness.Size = new System.Drawing.Size(47, 30);
            this.txbThickness.TabIndex = 1;
            // 
            // txbLength
            // 
            this.txbLength.EnterMoveNextControl = true;
            this.txbLength.Location = new System.Drawing.Point(75, 34);
            this.txbLength.Name = "txbLength";
            this.txbLength.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txbLength.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbLength.Properties.Appearance.Options.UseFont = true;
            this.txbLength.Properties.DisplayFormat.FormatString = "n0";
            this.txbLength.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txbLength.Properties.EditFormat.FormatString = "n0";
            this.txbLength.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txbLength.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbLength.Properties.MaskSettings.Set("mask", "n0");
            this.txbLength.Properties.MaxLength = 9;
            this.txbLength.Properties.NullValuePrompt = " ؟";
            this.txbLength.Properties.UseMaskAsDisplayFormat = true;
            this.txbLength.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbLength.Size = new System.Drawing.Size(47, 30);
            this.txbLength.TabIndex = 3;
            // 
            // txbWidth
            // 
            this.txbWidth.EnterMoveNextControl = true;
            this.txbWidth.Location = new System.Drawing.Point(11, 34);
            this.txbWidth.Name = "txbWidth";
            this.txbWidth.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txbWidth.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbWidth.Properties.Appearance.Options.UseFont = true;
            this.txbWidth.Properties.Appearance.Options.UseTextOptions = true;
            this.txbWidth.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txbWidth.Properties.DisplayFormat.FormatString = "n0";
            this.txbWidth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txbWidth.Properties.EditFormat.FormatString = "n0";
            this.txbWidth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txbWidth.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbWidth.Properties.MaskSettings.Set("mask", "n0");
            this.txbWidth.Properties.MaxLength = 9;
            this.txbWidth.Properties.NullValuePrompt = " ؟";
            this.txbWidth.Properties.UseMaskAsDisplayFormat = true;
            this.txbWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbWidth.Size = new System.Drawing.Size(47, 30);
            this.txbWidth.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(61, 43);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "X";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label15.Location = new System.Drawing.Point(128, 43);
            this.label15.Name = "label15";
            this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "سایز ورق:";
            // 
            // lkpMaterial
            // 
            this.lkpMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpMaterial.EnterMoveNextControl = true;
            this.lkpMaterial.Location = new System.Drawing.Point(366, 34);
            this.lkpMaterial.Name = "lkpMaterial";
            this.lkpMaterial.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
            this.lkpMaterial.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.lkpMaterial.Properties.Appearance.Options.UseFont = true;
            this.lkpMaterial.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lkpMaterial.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.lkpMaterial.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lkpMaterial.Properties.BestFitRowCount = 5;
            this.lkpMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpMaterial.Properties.DropDownItemHeight = 25;
            this.lkpMaterial.Properties.NullText = "  ؟";
            this.lkpMaterial.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lkpMaterial.Properties.PopupWidth = 60;
            this.lkpMaterial.Properties.ShowHeader = false;
            this.lkpMaterial.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkpMaterial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lkpMaterial.Size = new System.Drawing.Size(107, 30);
            this.lkpMaterial.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(280, 43);
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
            this.label1.Location = new System.Drawing.Point(479, 43);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "جنس ورق:";
            // 
            // SheetDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl5);
            this.Name = "SheetDetails";
            this.Size = new System.Drawing.Size(556, 83);
            this.Load += new System.EventHandler(this.SheetDetails_Load);
            this.Leave += new System.EventHandler(this.SheetDetails_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbThickness.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpMaterial.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.LookUpEdit lkpMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txbLength;
        private DevExpress.XtraEditors.TextEdit txbWidth;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txbThickness;
    }
}
