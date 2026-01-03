using DevExpress.Data;
using DevExpress.Data.ExpressionEditor;
using DevExpress.DataAccess.UI.ExpressionEditor;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ExpressionEditor;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Internal;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraTreeList.Columns;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Standalone_ExpressionEditor
{
    [ToolboxItem(true)]
    [DesignerCategory("")]
    public class UnboundExpressionPanel : PanelControl
    {
        ExpressionEditorView view;
        object column;
        IDataColumnInfo columnContext;

        public UnboundExpressionPanel() : base() {
            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }
        void DestroyExpressionControls() {
            if (view != null) {
                Controls.Remove(view);
                view.Dispose();
            }
        }
        ExpressionEditorView CreateExpressionControl() {
            ExpressionEditorControl control = new ExpressionEditorControl();
            if (column is GridColumn)
                columnContext = new GridColumnIDataColumnInfoWrapper(column as GridColumn, GridColumnIDataColumnInfoWrapperEnum.ExpressionEditor);
            if (column is TreeListColumn)
                columnContext = column as IDataColumnInfo;
            control.Context = ExpressionEditorHelper.GetExpressionEditorContext(LookAndFeel, columnContext);
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
        public void StartEdit(object columnObject) {
            SuspendLayout();
            column = columnObject;
            DestroyExpressionControls();
            view = CreateExpressionControl();
            Controls.Add(view);




            //DumpControls(view);

            RichEditControl richEditControl = (RichEditControl)FindControlRecursive(view, "richEdit");
            richEditControl.BackColor = System.Drawing.Color.Green;

            // 2. تراز پیش‌فرض پاراگراف‌ها را به راست تغییر دهید
            //richEditControl.Document.Paragraphs.Alignment = ParagraphAlignment.Right;

            // یا برای تمام بخش‌ها (Sections):
            foreach (Section section in richEditControl.Document.Sections)
            {
                section.RightToLeft = true;  // جهت بخش را RTL می‌کند (مفید برای ستون‌ها و layout پیچیده)
                section.Margins.Right = 40;  // اختیاری: حاشیه راست بیشتر برای ظاهر بهتر
                section.Margins.Left = 20;
            }





            string expression = string.Empty;
            if (column is GridColumn)
                expression = (column as GridColumn).UnboundExpression;
            if (column is TreeListColumn)
                expression = (column as TreeListColumn).UnboundExpression;
            view.ExpressionString = UnboundExpressionConvertHelper.ConvertToCaption(columnContext, expression);
            ResumeLayout();
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



        private void ExpressionView_Ok(object sender, EventArgs e) {
            string expression = UnboundExpressionConvertHelper.ConvertToFields(columnContext, view.ExpressionString);
            string expressionCaption = UnboundExpressionConvertHelper.ConvertToCaption(columnContext, view.ExpressionString);

            if (column is GridColumn)
                (column as GridColumn).UnboundExpression = expression;
            if (column is TreeListColumn)
                (column as TreeListColumn).UnboundExpression = expression;
        }
        private void ExpressionView_Cancel(object sender, EventArgs e) {
            // TO DO

            RichEditControl richEditControl = (RichEditControl)FindControlRecursive(view, "richEdit");
            richEditControl.BackColor = System.Drawing.Color.Green;


            // 2. تراز پیش‌فرض پاراگراف‌ها را به راست تغییر دهید
            //richEditControl.Document.Paragraphs.Alignment = ParagraphAlignment.Right;

            // یا برای تمام بخش‌ها (Sections):
            foreach (Section section in richEditControl.Document.Sections)
            {
                section.RightToLeft = true;  // جهت بخش را RTL می‌کند (مفید برای ستون‌ها و layout پیچیده)
                section.Margins.Right = 40;  // اختیاری: حاشیه راست بیشتر برای ظاهر بهتر
                section.Margins.Left = 20;

                richEditControl.Document.Paragraphs[0].RightToLeft = false;
                richEditControl.Document.Paragraphs[0].Alignment = ParagraphAlignment.Left;

            }

        }
    }
}
