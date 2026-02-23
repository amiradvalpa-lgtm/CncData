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
    public partial class FrmSheetList :
#if DEBUG
                    BaseFormList
#else
                    BaseFormListDesignerSafe
#endif
    {
        public FrmSheetList() : base(new EfListService<Sheet>(() => new AppDbContext()))
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

        protected override string GetFormTitle() => "لیست ورق ها";

        protected override IEditForm CreateEditForm(int id, bool isReadOnly)
        {
            var service = new EfCrudService<Sheet>(new AppDbContext());
            return new FrmSheetEdit(id, isReadOnly, service);
        }


        protected override void BaseFormList_Load(object sender, EventArgs e)
        {
            base.BaseFormList_Load(sender, e);
            //gridView.CustomColumnDisplayText += gridView_CustomColumnDisplayText;
            //gridView.CustomDrawCell += gridView_CustomDrawCell;
        }
    }
}