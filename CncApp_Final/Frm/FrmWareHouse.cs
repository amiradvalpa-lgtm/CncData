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
        private int focusedRowHandel;
        private int topRowIndex;

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


        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



        private void ReLoadList()
        {
            SavePosition();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Warehouses.Load();
            warehousesBindingSource.DataSource = dbContext.Warehouses.Local.ToBindingList();

            RestorePosition();
        }

        public void SavePosition()
        {
            gridView = (GridView)this.gridControl.MainView;
            focusedRowHandel = gridView.FocusedRowHandle;
            topRowIndex = gridView.TopRowIndex;
        }

        public void RestorePosition()
        {
            gridView.FocusedRowHandle = focusedRowHandel;
            gridView.TopRowIndex = topRowIndex;
        }

        public void RestorePosition(int _NewRow_Id)
        {
            gridView.FocusedRowHandle = gridView.LocateByValue("Id", _NewRow_Id);
        }



        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************




        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWareHouseEdit frmWareHouseEdit = new FrmWareHouseEdit(0, false);
            frmWareHouseEdit.ShowDialog();
            if (frmWareHouseEdit.DialogResult == DialogResult.OK)
            {
                ReLoadList();
                RestorePosition(frmWareHouseEdit._New_Row_Id); 
            }
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            ribbonControl.BeginInit();
            int wareHouse_Id = (int)gridView.GetFocusedRowCellValue(colId);
            FrmWareHouseEdit frmWareHouseEdit = new FrmWareHouseEdit(wareHouse_Id, false);
            frmWareHouseEdit.ShowDialog();
            if (frmWareHouseEdit.DialogResult == DialogResult.OK)
            {
                ReLoadList();
            }
            ribbonControl.EndInit();
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



        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************

    }
}