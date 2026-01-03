using CncApp_Final.Frm;
using CncApp_Final.Helpers;
using CncApp_Final.TempFrm;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Frm
{
    public partial class FrmReceipts : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private int focusedRowHandel;
        private int topRowIndex;

        public FrmReceipts()
        {
            InitializeComponent();
            
        }

        private void FrmReceipts_Load(object sender, EventArgs e)
        {
            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Receipts.Load();
            receiptsBindingSource.DataSource = dbContext.Receipts.Local.ToBindingList();

            GridLayoutHelper.LoadLayout(
                                        gridView,
                                        1,
                                        this.Name);
        }

        private void bbiNewReceipt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmReceiptEdit frmReceiptEdit = new FrmReceiptEdit(0, false, ReLoadList);
            frmReceiptEdit.ShowDialog();
        }

        private void bbiEditReceipt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int receipt_Id = (int)gridView.GetFocusedRowCellValue(colId);
            FrmReceiptEdit frmReceiptEdit = new FrmReceiptEdit(receipt_Id, false, ReLoadList);
            frmReceiptEdit.ShowDialog();
        }

        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



        public void ReLoadList(int _NewRow_Id)
        {
            SavePosition();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Receipts.Load();
            receiptsBindingSource.DataSource = dbContext.Receipts.Local.ToBindingList();
            if(_NewRow_Id == 0)
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

        private void FrmReceipts_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridLayoutHelper.SaveLayout(
                                        gridView,
                                        1,
                                        this.Name);
        }


    }
}
