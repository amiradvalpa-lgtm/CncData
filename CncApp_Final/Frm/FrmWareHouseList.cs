using CncApp_Final.Helper;
using CncApp_Final.Services;
using CncApp_Final.Data;
using CncApp_Final.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Frm
{
    public partial class FrmWareHouseList : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int focusedRowHandel;
        private int topRowIndex;

        public FrmWareHouseList()
        {
            InitializeComponent();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Warehouses.Load();
            warehousesBindingSource.DataSource = dbContext.Warehouses.Local.ToBindingList();
            
            bsiRecordsCount.Caption = "RECORDS : " + dbContext.Warehouses.Local.Count;

            InitFormExtraConfig();
        }

        private void InitFormExtraConfig()
        {
            ControlExraInit.InitRibonControl(ribbonControl, "لیست انبار");
            ControlExraInit.InitGridView(gridView, "لیست انبار");
        }

        private void FrmWareHouseList_Load(object sender, EventArgs e)
        {
            //GridLayoutHelper.LoadLayout(
            //                            gridView,
            //                            1,
            //                            this.Name);
        }


        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



        public void ReLoadList(int _NewRow_Id)
        {
            SavePosition();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Warehouses.Load();
            warehousesBindingSource.DataSource = dbContext.Warehouses.Local.ToBindingList();
            if (_NewRow_Id == 0)
                RestorePosition();
            else
                RestorePosition(_NewRow_Id);
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
            //FrmWareHouseEdit frmWareHouseEdit = new FrmWareHouseEdit(0, false);
            //frmWareHouseEdit.ShowDialog();
            //if (frmWareHouseEdit.DialogResult == DialogResult.OK)
            //{
            //    ReLoadList();
            //    RestorePosition(frmWareHouseEdit._New_Row_Id); 
            //}


            var service = new EfCrudService<Warehouse>(new AppDbContext());
            var frm = new Frms.EditForms.FrmWareHouseEdit(0, false, service);
            frm.ChangesSaved += (s, args) =>
            {
                ReLoadList(args.RecordId);
            };
            frm.ShowDialog();
        }

        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ribbonControl.BeginInit();
            //int wareHouse_Id = (int)gridView.GetFocusedRowCellValue(colId);
            //FrmWareHouseEdit frmWareHouseEdit = new FrmWareHouseEdit(wareHouse_Id, false);
            //frmWareHouseEdit.ShowDialog();
            //if (frmWareHouseEdit.DialogResult == DialogResult.OK)
            //{
            //    ReLoadList();
            //}
            //ribbonControl.EndInit();


            int warehouse_Id = (int)gridView.GetFocusedRowCellValue(colId);
            var service = new EfCrudService<Warehouse>(new AppDbContext());
            var frm = new Frms.EditForms.FrmWareHouseEdit(warehouse_Id, false, service);
            frm.ChangesSaved += (s, args) =>
            {
                ReLoadList(warehouse_Id);
            };
            frm.ShowDialog();
        }

        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
           // ReLoadList();
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