using DevExpress.Data;
using DevExpress.Data.Controls.ExpressionEditor;
using DevExpress.Data.Controls.ExpressionEditor.Native;
using DevExpress.Data.ExpressionEditor;
using DevExpress.DataAccess.UI.ExpressionEditor;
using DevExpress.LookAndFeel;
using DevExpress.Utils.Win.Hook;


//using DevExpress.DataAccess.UI.Native.Sql.QueryBuilder;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ExpressionEditor;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Internal;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace Standalone_ExpressionEditor
{
    public delegate void ExpressionChangedHandler(object sender, EventArgs e);


    [ToolboxItem(true)]
    [DesignerCategory("")]
    public class UnboundExpressionPanel : PanelControl
    {
        ExpressionEditorView view;
        object column;
        IDataColumnInfo columnContext;

        public string ExpressionText { get; set; }

        public UnboundExpressionPanel() : base() {
            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }
        void DestroyExpressionControls() {
            if (view != null) {
                Controls.Remove(view);
                view.Dispose();
            }
        }
        ExpressionEditorView CreateExpressionControl()
        {

            ExpressionEditorControl control = new ExpressionEditorControl();
            if (column is GridColumn)
                columnContext = new GridColumnIDataColumnInfoWrapper(column as GridColumn, GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor);
            if (column is TreeListColumn)
                columnContext = column as IDataColumnInfo;

            ExpressionEditorContext expressionEditorContext = ExpressionEditorHelper.GetExpressionEditorContext(LookAndFeel, columnContext);
            List<IBoundProperty> expressionEditorUnboundProperties = EnsureExpressionEditorContextColumns((GridColumn)column, expressionEditorContext);
            ConverFieldNameToCaption(expressionEditorContext);
            control.Context = expressionEditorContext;

            //UnboundExpressionEditorEventArgs unboundExpressionEditorEventArgs = new UnboundExpressionEditorEventArgs((GridColumn)column, ((GridColumn)column).UnboundExpression, expressionEditorView, expressionEditorContext, context);

            ExpressionEditorView expressionView = new ExpressionEditorView(control.LookAndFeel, control);
            expressionView.Dock = System.Windows.Forms.DockStyle.Fill;
            expressionView.TopLevel = false;
            expressionView.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            expressionView.Ok += ExpressionView_Ok;
            expressionView.Cancel += ExpressionView_Cancel;
            //expressionView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            expressionView.Visible = true;
            return expressionView;
        }

        //public static ExpressionEditorContext GetExpressionEditorContext(UserLookAndFeel lookAndFeel, IDataColumnInfo context)
        //{
        //    ExpressionEditorContext expressionEditorContext = ((ExpressionEditorContext)((ExpressionEditorContextHelperUIType?.GetMethod("CreateContext", new Type[1] { typeof(UserLookAndFeel) }))?.Invoke(null, new object[1] { lookAndFeel }))) ?? new ExpressionEditorContext();
        //    MethodInfo methodInfo = ExpressionEditorHelper.ExpressionEditorContextHelperType?.GetMethod("GetColumns", new Type[1] { typeof(object) });
        //    IEnumerable<ColumnInfo> collection = context.Columns.Select((IDataColumnInfo c) => new ColumnInfo
        //    {
        //        Name = c.Caption,
        //        Type = c.FieldType
        //    });
        //    expressionEditorContext.Columns.AddRange(collection);
        //    if (methodInfo?.Invoke(null, new object[1] { context.Controller?.ListSource }) is IEnumerable<ColumnInfo> source)
        //    {
        //        IEnumerable<ColumnInfo> enumerable = source.Where((ColumnInfo c) => context.Columns.All((IDataColumnInfo cc) => c.Name != cc.FieldName));
        //        foreach (ColumnInfo ci in enumerable)
        //        {
        //            ColumnInfo columnInfo = expressionEditorContext.Columns.Find((ColumnInfo c) => c.Name == ci.Name);
        //            if (columnInfo == null)
        //            {
        //                expressionEditorContext.Columns.Add(ci);
        //            }
        //        }
        //    }

        //    return expressionEditorContext;
        //}

        private void ConverFieldNameToCaption(ExpressionEditorContext expressionEditorContext)
        {
            foreach (GridColumn gridCol in ((GridColumn)column).View.Columns)
            {
                var col = expressionEditorContext.Columns
                    .FirstOrDefault(c => c.Name == gridCol.FieldName);

                if (col != null)
                {
                    col.Name = gridCol.Caption;
                }
            }
        }

        public void StartEdit(object columnObject) {
            SuspendLayout();
            column = columnObject;
            DestroyExpressionControls();
            view = CreateExpressionControl();
            Controls.Add(view);


            ////DumpControls(view);
            //RichEditControl richEditControl = (RichEditControl)FindControlRecursive(view, "richEdit");
            //richEditControl.BackColor = System.Drawing.Color.Green;
            //foreach (Section section in richEditControl.Document.Sections)
            //{
            //    section.RightToLeft = true;  // جهت بخش را RTL می‌کند (مفید برای ستون‌ها و layout پیچیده)
            //    section.Margins.Right = 40;  // اختیاری: حاشیه راست بیشتر برای ظاهر بهتر
            //    section.Margins.Left = 20;
            //}

            string newExpression = string.Empty;
            if (column is GridColumn)
                newExpression = (column as GridColumn).UnboundExpression;
            if (column is TreeListColumn)
                newExpression = (column as TreeListColumn).UnboundExpression;
            view.ExpressionString = newExpression;
            //view.ExpressionString = UnboundExpressionConvertHelper.ConvertToCaption(columnContext, newExpression);
            ResumeLayout();
        }


        //***************************************************************************************************************************
        //***************************************************************************************************************************

        Control FindControlRecursive(Control parent, string name)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.Name == name)
                    return c;

                if (c.HasChildren)
                {
                    var result = FindControlRecursive(c, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        //void DumpControls(Control parent, int level = 1)
        //{
        //    foreach (Control c in parent.Controls)
        //    {
        //        System.Diagnostics.Debug.WriteLine(
        //            $"LEVEL {level} => {c.Name}  ({c.GetType().Name})");

        //        if (level < 10 && c.HasChildren)
        //            DumpControls(c, level + 1);
        //    }
        //}





        //***************************************************************************************************************************
        //***************************************************************************************************************************
        //***************************************************************************************************************************
        //***************************************************************************************************************************

        public event ExpressionChangedHandler ExpressionChanged;

        protected virtual void OnExpressionChanged()
        {
            // بررسی null بودن قبل از فراخوانی
            ExpressionChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ExpressionView_Ok(object sender, EventArgs e) {
            string expression = UnboundExpressionConvertHelper.ConvertToFields(columnContext, view.ExpressionString);
            string expressionCaption = UnboundExpressionConvertHelper.ConvertToCaption(columnContext, view.ExpressionString);

            if (column is GridColumn)
                (column as GridColumn).UnboundExpression = expression;
            if (column is TreeListColumn)
                (column as TreeListColumn).UnboundExpression = expression;
            ExpressionText = expressionCaption;
            OnExpressionChanged();


            //UnboundExpressionConvertHelper.ValidateExpressionFields(context, expression, expressionEditorUnboundProperties);
        }



        private void ExpressionView_Cancel(object sender, EventArgs e) {
            // TO DO

            //RichEditControl richEditControl = (RichEditControl)FindControlRecursive(view, "richEdit");
            //richEditControl.BackColor = System.Drawing.Color.Green;


            //// 2. تراز پیش‌فرض پاراگراف‌ها را به راست تغییر دهید
            ////richEditControl.Document.Paragraphs.Alignment = ParagraphAlignment.Right;

            //// یا برای تمام بخش‌ها (Sections):
            //foreach (Section section in richEditControl.Document.Sections)
            //{
            //    section.RightToLeft = true;  // جهت بخش را RTL می‌کند (مفید برای ستون‌ها و layout پیچیده)
            //    section.Margins.Right = 40;  // اختیاری: حاشیه راست بیشتر برای ظاهر بهتر
            //    section.Margins.Left = 20;

            //    richEditControl.Document.Paragraphs[0].RightToLeft = false;
            //    richEditControl.Document.Paragraphs[0].Alignment = ParagraphAlignment.Left;

            //}

        }




        //***************************************************************************************************************************
        //***************************************************************************************************************************
        //***************************************************************************************************************************
        //***************************************************************************************************************************




        private List<IBoundProperty> EnsureExpressionEditorContextColumns(GridColumn column, ExpressionEditorContext expressionEditorContext)
        {
            if (column.View == null)
            {
                return null;
            }

            return EnsureExpressionEditorContextColumns(column.View.Columns, expressionEditorContext);
        }

        private List<IBoundProperty> EnsureExpressionEditorContextColumns(GridColumnCollection viewColumns, ExpressionEditorContext expressionEditorContext)
        {
            List<IBoundProperty> list = null;
            List<ColumnInfo> list2 = expressionEditorContext.Columns;
            for (int num = list2.Count - 1; num > 0; num--)
            {
                GridColumn gridColumn = viewColumns[list2[num].Name];
                if (gridColumn == null && list2[num] is IBoundProperty boundProperty)
                {
                    gridColumn = viewColumns[BoundPropertyWrapper.Unwrap(boundProperty).Name];
                    if (gridColumn == null && boundProperty != null)
                    {
                        list = list ?? new List<IBoundProperty>();
                        list.Add(boundProperty);
                    }
                }

                if (gridColumn != null && !gridColumn.OptionsColumn.ShowInExpressionEditor)
                {
                    list2.RemoveAt(num);
                }
            }

            return list;
        }
    }
}
