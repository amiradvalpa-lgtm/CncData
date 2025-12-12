using DevExpress.XtraBars;
using DevExpress.XtraEditors;
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
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using CncApp_Final.Helper;

namespace CncApp_Final.Frm
{
    public partial class FrmWareHouse : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmWareHouse()
        {
            InitializeComponent();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Warehouses.Load();
            warehousesBindingSource.DataSource = dbContext.Warehouses.Local.ToBindingList();

            InitFormExtraConfig();
        }

        private void InitFormExtraConfig()
        {
            ControlExraInit.InitRibonControl(ribbonControl, "لیست انبار");
            ControlExraInit.InitGridView(gridView, "لیست انبار");
        }

        private void FrmWareHouse_Load(object sender, EventArgs e)
        {

        }

        

        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWareHouseEdit frmWareHouseEdit = new FrmWareHouseEdit(0, false);
            frmWareHouseEdit.ShowDialog();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            int wareHouse_Id = (int)gridView.GetFocusedRowCellValue(colId);
            FrmWareHouseEdit frmWareHouseEdit = new FrmWareHouseEdit(wareHouse_Id, false);
            frmWareHouseEdit.ShowDialog();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
    }
}