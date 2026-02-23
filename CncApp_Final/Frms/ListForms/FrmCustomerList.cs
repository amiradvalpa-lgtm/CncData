using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Frms.Base;
using CncApp_Final.Frms.EditForms;
using CncApp_Final.Services;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Frms.ListForms
{
    public partial class FrmCustomerList :
#if DEBUG
                    BaseFormList
#else
                    BaseFormListDesignerSafe
#endif
    {
        public FrmCustomerList() : base(new EfListService<Customer>(() => new AppDbContext()))
        {
            InitializeComponent();
            this.Load += BaseFormList_Load;
            this.StartPosition = FormStartPosition.CenterParent;
            
        }

        protected override RibbonControl GetRibbonControl() => ribbonControl;
        protected override GridControl GetGridControl() => gridControl;
        protected override GridView GetGridView() => gridView;
        protected override BarButtonItem GetNewButton() => bbiNew;
        protected override BarButtonItem GetEditButton() => bbiEdit;
        protected override BarButtonItem GetDeleteButton() => bbiDelete;
        protected override BarButtonItem GetRefreshButton() => bbiRefresh;
        protected override BarButtonItem GetPrintPreviewButton() => bbiPrintPreview;
        protected override BarStaticItem GetRecordsCountItem() => bsiRecordsCount;

        protected override string GetFormTitle() => "لیست مشتریان";

        protected override IEditForm CreateEditForm(int id, bool isReadOnly)
        {
            var service = new EfCrudService<Customer>(new AppDbContext());
            return new FrmCustomerEdit(id, isReadOnly, service);
        }


        protected override void BaseFormList_Load(object sender, EventArgs e)
        {
            base.BaseFormList_Load( sender,  e);
            gridView.CustomColumnDisplayText += gridView_CustomColumnDisplayText;
            gridView.CustomDrawCell += gridView_CustomDrawCell;
        }


        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************




        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            {
                if (e.Column == colPhone && e.Value != null)
                {
                    string p = e.Value.ToString().Trim();

                    // اگر طول کمتر بود خراب نشه
                    if (p.Length == 11)   // مثلا 09123456789
                        e.DisplayText = $"{p.Substring(0, 4)}-{p.Substring(4, 3)}-{p.Substring(7, 4)}";
                }
            }
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == colBeginning_Balance.FieldName)
            {
                //var val = Convert.ToDecimal(e.CellValue);
                var val = Convert.ToDecimal(((GridView)sender).GetRowCellValue(e.RowHandle, colBalanceType));
                if (val > 0)
                    e.Appearance.ForeColor = Color.FromArgb(0, 192, 0);
                else if (val < 0)
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
            }
            else if (e.Column.FieldName == colBalanceStatus.FieldName)
            {
                var val = e.CellValue.ToString();
                if (val == "بستانکار")
                    e.Appearance.ForeColor = Color.FromArgb(0, 192, 0);
                else if (val == "بدهکار")
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
            }
        }


        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



    }
}