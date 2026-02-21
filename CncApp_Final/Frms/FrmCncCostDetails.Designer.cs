namespace CncApp_Final.Frms
{
    partial class FrmCncCostDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCncCostDetails));
            this.txbCncCost = new DevExpress.XtraEditors.TextEdit();
            this.txbCncBasePriceByMeter = new DevExpress.XtraEditors.ButtonEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbGrooveLength = new DevExpress.XtraEditors.ButtonEdit();
            this.txbCncCostByMeter = new DevExpress.XtraEditors.ButtonEdit();
            this.txbCncCostBySheet = new DevExpress.XtraEditors.ButtonEdit();
            this.txbCncCostDifference = new DevExpress.XtraEditors.ButtonEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncBasePriceByMeter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbGrooveLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCostByMeter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCostBySheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCostDifference.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txbCncCost
            // 
            this.txbCncCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCncCost.EnterMoveNextControl = true;
            this.txbCncCost.Location = new System.Drawing.Point(21, 242);
            this.txbCncCost.Name = "txbCncCost";
            this.txbCncCost.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbCncCost.Properties.Appearance.Options.UseFont = true;
            this.txbCncCost.Properties.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbCncCost.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txbCncCost.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbCncCost.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txbCncCost.Properties.MaskSettings.Set("mask", "n0");
            this.txbCncCost.Properties.UseMaskAsDisplayFormat = true;
            this.txbCncCost.Size = new System.Drawing.Size(123, 36);
            this.txbCncCost.TabIndex = 0;
            // 
            // txbCncBasePriceByMeter
            // 
            this.txbCncBasePriceByMeter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCncBasePriceByMeter.EditValue = 123456789D;
            this.txbCncBasePriceByMeter.Location = new System.Drawing.Point(21, 60);
            this.txbCncBasePriceByMeter.Name = "txbCncBasePriceByMeter";
            this.txbCncBasePriceByMeter.Properties.AllowFocused = false;
            this.txbCncBasePriceByMeter.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbCncBasePriceByMeter.Properties.Appearance.Options.UseFont = true;
            this.txbCncBasePriceByMeter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txbCncBasePriceByMeter.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbCncBasePriceByMeter.Properties.MaskSettings.Set("mask", "n0");
            this.txbCncBasePriceByMeter.Properties.ReadOnly = true;
            this.txbCncBasePriceByMeter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txbCncBasePriceByMeter.Properties.UseMaskAsDisplayFormat = true;
            this.txbCncBasePriceByMeter.Size = new System.Drawing.Size(123, 36);
            this.txbCncBasePriceByMeter.TabIndex = 10;
            this.txbCncBasePriceByMeter.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(150, 251);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "هزینه نهایی CNC :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(150, 111);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "قیمت کل ( متر ) :";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label22.Location = new System.Drawing.Point(150, 69);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(90, 13);
            this.label22.TabIndex = 13;
            this.label22.Text = "قیمت پایه ( متر ) :";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(150, 28);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "طول برش:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(150, 153);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "قیمت کل ( ورق ) :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(150, 195);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "تفاوت قیمت :";
            // 
            // txbGrooveLength
            // 
            this.txbGrooveLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbGrooveLength.Location = new System.Drawing.Point(21, 18);
            this.txbGrooveLength.Name = "txbGrooveLength";
            this.txbGrooveLength.Properties.AllowFocused = false;
            this.txbGrooveLength.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbGrooveLength.Properties.Appearance.Options.UseFont = true;
            this.txbGrooveLength.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbGrooveLength.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txbGrooveLength.Properties.MaskSettings.Set("mask", "n0");
            this.txbGrooveLength.Properties.ReadOnly = true;
            this.txbGrooveLength.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txbGrooveLength.Properties.UseMaskAsDisplayFormat = true;
            this.txbGrooveLength.Size = new System.Drawing.Size(123, 36);
            this.txbGrooveLength.TabIndex = 8;
            this.txbGrooveLength.TabStop = false;
            // 
            // txbCncCostByMeter
            // 
            this.txbCncCostByMeter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCncCostByMeter.Location = new System.Drawing.Point(21, 102);
            this.txbCncCostByMeter.Name = "txbCncCostByMeter";
            this.txbCncCostByMeter.Properties.AllowFocused = false;
            this.txbCncCostByMeter.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbCncCostByMeter.Properties.Appearance.Options.UseFont = true;
            this.txbCncCostByMeter.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbCncCostByMeter.Properties.MaskSettings.Set("mask", "n0");
            this.txbCncCostByMeter.Properties.ReadOnly = true;
            this.txbCncCostByMeter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txbCncCostByMeter.Properties.UseMaskAsDisplayFormat = true;
            this.txbCncCostByMeter.Size = new System.Drawing.Size(123, 36);
            this.txbCncCostByMeter.TabIndex = 15;
            this.txbCncCostByMeter.TabStop = false;
            // 
            // txbCncCostBySheet
            // 
            this.txbCncCostBySheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCncCostBySheet.Location = new System.Drawing.Point(21, 144);
            this.txbCncCostBySheet.Name = "txbCncCostBySheet";
            this.txbCncCostBySheet.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbCncCostBySheet.Properties.Appearance.Options.UseFont = true;
            this.txbCncCostBySheet.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbCncCostBySheet.Properties.MaskSettings.Set("mask", "n0");
            this.txbCncCostBySheet.Properties.ReadOnly = true;
            this.txbCncCostBySheet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txbCncCostBySheet.Properties.UseMaskAsDisplayFormat = true;
            this.txbCncCostBySheet.Size = new System.Drawing.Size(123, 36);
            this.txbCncCostBySheet.TabIndex = 15;
            this.txbCncCostBySheet.TabStop = false;
            // 
            // txbCncCostDifference
            // 
            this.txbCncCostDifference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCncCostDifference.Location = new System.Drawing.Point(21, 186);
            this.txbCncCostDifference.Name = "txbCncCostDifference";
            this.txbCncCostDifference.Properties.Appearance.Font = new System.Drawing.Font("IRANSans", 9.75F);
            this.txbCncCostDifference.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbCncCostDifference.Properties.Appearance.Options.UseFont = true;
            this.txbCncCostDifference.Properties.Appearance.Options.UseForeColor = true;
            this.txbCncCostDifference.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txbCncCostDifference.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txbCncCostDifference.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txbCncCostDifference.Properties.MaskSettings.Set("mask", "n0");
            this.txbCncCostDifference.Properties.ReadOnly = true;
            this.txbCncCostDifference.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.txbCncCostDifference.Properties.UseMaskAsDisplayFormat = true;
            this.txbCncCostDifference.Size = new System.Drawing.Size(123, 36);
            this.txbCncCostDifference.TabIndex = 15;
            this.txbCncCostDifference.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnOk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnOk.ImageOptions.ImageToTextIndent = 5;
            this.btnOk.Location = new System.Drawing.Point(21, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 45);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "تایید";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.btnCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.btnCancel.ImageOptions.ImageToTextIndent = 5;
            this.btnCancel.Location = new System.Drawing.Point(139, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 45);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "لغو";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmCncCostDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 353);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txbCncCost);
            this.Controls.Add(this.txbCncBasePriceByMeter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txbGrooveLength);
            this.Controls.Add(this.txbCncCostByMeter);
            this.Controls.Add(this.txbCncCostBySheet);
            this.Controls.Add(this.txbCncCostDifference);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCncCostDetails";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "جزئیات هزینه CNC";
            this.Load += new System.EventHandler(this.FrmCncCostDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncBasePriceByMeter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbGrooveLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCostByMeter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCostBySheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbCncCostDifference.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txbCncCost;
        private DevExpress.XtraEditors.ButtonEdit txbCncBasePriceByMeter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ButtonEdit txbGrooveLength;
        private DevExpress.XtraEditors.ButtonEdit txbCncCostByMeter;
        private DevExpress.XtraEditors.ButtonEdit txbCncCostBySheet;
        private DevExpress.XtraEditors.ButtonEdit txbCncCostDifference;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}