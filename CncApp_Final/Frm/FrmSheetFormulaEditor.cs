using CncApp_Final.Entities;
using CncApp_Final.Helper;
using DevExpress.Data.Controls.ExpressionEditor;
using DevExpress.Data.Controls.ExpressionEditor;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.DataAccess.ExpressionEditor;
using DevExpress.DataAccess.Native.ExpressionEditor;
//using DevExpress.XtraRichEdit
using DevExpress.Xpf.ExpressionEditor;
using DevExpress.Xpf.ExpressionEditor.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraSplashScreen;
using Standalone_ExpressionEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CncApp_Final.Frm
{
    public partial class FrmSheetFormulaEditor : DevExpress.XtraEditors.XtraForm
    {
        public string ExpressionText = string.Empty;

        public FrmSheetFormulaEditor(string expression, string expressionName)
        {
            InitializeComponent();

            
            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();

            ExpressionText = expression;
            this.Text = expressionName;


            //AddUnboundColumns();
            //PopulateComboWithUnboundColumns();
            //comboBoxEdit1.EditValue = "Expression A";
        }

        private void FrmSheetFormulaEditor_Load(object sender, EventArgs e)
        {
            //GridColumn col1 = gridView.Columns.AddVisible("Expression A");
            //col1.Visible = false;
            //col1.ShowUnboundExpressionMenu = false;
            //col1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //col1.UnboundExpression = _expression;
            //ConverFieldNameToCaption();
            //unboundExpressionPanel1.StartEdit(col1);
        }

        private async void FrmSheetFormulaEditor_Shown(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(
                                            this,
                                            typeof(WaitForm1),
                                            true,
                                            true,false,true
                                        );

            // 1️⃣ اجازه بده فرم فوراً دیده شود
            await Task.Yield();

            // 2️⃣ عملیات سنگین برود بعد از Render
            StartExpressionEditor();

            SplashScreenManager.CloseForm();


        }

        private void StartExpressionEditor()
        {
            GridColumn col1 = gridView.Columns.AddVisible("Expression A");
            col1.Visible = false;
            col1.ShowUnboundExpressionMenu = false;
            col1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            col1.UnboundExpression = ExpressionText;
            ConverFieldNameToCaption();   // این هم سنگین است ولی بعد از Render
            unboundExpressionPanel1.StartEdit(col1);
        }



        private void ConverFieldNameToCaption()
        {
            var type = sheetsBindingSource.Current.GetType();   // یا هر DataSource مدل‌ات
            foreach (GridColumn ctxCol in gridView.Columns)
            {
                var prop = TypeDescriptor.GetProperties(type)[ctxCol.FieldName];
                if (prop != null)
                    ctxCol.Caption = prop.DisplayName;
            }
        }


        //private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridColumn unboundColumn = gridView.Columns[comboBoxEdit1.EditValue.ToString()];
        //    unboundExpressionPanel1.StartEdit(unboundColumn);
        //}


        //void AddUnboundColumns()
        //{
        //    //GridColumn col1 = gridView.Columns.AddVisible("Expression A");
        //    //col1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
        //    //col1.UnboundExpression = "[UnitPrice] * [UnitsInStock]";

        //    GridColumn col2 = gridView.Columns.AddVisible("Expression B");
        //    col2.UnboundType = DevExpress.Data.UnboundColumnType.Object;
        //}
        //void PopulateComboWithUnboundColumns()
        //{
        //    foreach (GridColumn col in gridView.Columns)
        //    {
        //        if (col.UnboundType != DevExpress.Data.UnboundColumnType.Bound)
        //            comboBoxEdit1.Properties.Items.Add(col.FieldName);
        //    }
        //}


        private void unboundExpressionPanel1_Resize(object sender, EventArgs e)
        {
            this.Text = this.Size.ToString();
        }

        private void vGridControl1_Click(object sender, EventArgs e)
        {

        }

        private void vGridControl1_CustomUnboundData(object sender, DevExpress.XtraVerticalGrid.Events.CustomDataEventArgs e)
        {
            
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData)
            {
                Sheet currentSheet = e.Row as Sheet;
                if (currentSheet == null) return;

                // اول مطمئن شو که قیمت‌ها بر اساس فرمول اختصاصی این ردیف محاسبه شدن
                SheetCalculator.Calculate(currentSheet);  // همون کلاس محاسبه‌گر قبلی

                // حالا مقدار محاسبه‌شده رو برای ستون مربوطه برگردون
                if (e.Column.FieldName == "SheetPrice")
                    e.Value = currentSheet.SheetPrice;

                else if (e.Column.FieldName == "PicesPrice")
                    e.Value = currentSheet.PicesPrice;

                // می‌تونی ستون‌های unbound دیگه هم اضافه کنی
            }
        }

        private void FrmSheetFormulaEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExpressionText = unboundExpressionPanel1.ExpressionText;
        }

        private void unboundExpressionPanel1_VisibleChanged(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void unboundExpressionPanel1_ExpressionChanged(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
