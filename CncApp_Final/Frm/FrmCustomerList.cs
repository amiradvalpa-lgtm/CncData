using CncApp_Final.Data;
using CncApp_Final.Entities;
using CncApp_Final.Frm.Base;
using CncApp_Final.Frms.Base;
using CncApp_Final.Helpers;
using CncApp_Final.Services;
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
    public partial class FrmCustomerList : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private int focusedRowHandel;
        private int topRowIndex;

        public FrmCustomerList()
        {
            InitializeComponent();
            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Customers.Load();
            customersBindingSource.DataSource = dbContext.Customers.Local.ToBindingList();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            GridLayoutHelper.LoadLayout(
                                        gridView,
                                        1,
                                        this.Name);
        }

        private void bbiEditCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int customer_Id = (int)gridView.GetFocusedRowCellValue(colId);
            //Frm.FrmCustomerEdit frmCustomerEdit = new Frm.FrmCustomerEdit(customer_Id, false, ReLoadList);
            //frmCustomerEdit.ShowDialog();

            int customer_Id = (int)gridView.GetFocusedRowCellValue(colId);
            var service = new EfCrudService<Customer>(new AppDbContext());
            var frm = new Frms.FrmCustomerEdit(customer_Id, false, service);
            frm.ChangesSaved += (s, args) =>
            {
                ReLoadList(customer_Id);
            };
            frm.ShowDialog();
        }

        private void bbiNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Frm.FrmCustomerEdit frmCustomerEdit = new Frm.FrmCustomerEdit(0, false, ReLoadList);
            //frmCustomerEdit.ShowDialog();



            var service = new EfCrudService<Customer>(new AppDbContext());
            var frm = new Frms.FrmCustomerEdit(0, false, service);
            frm.ChangesSaved += (s, args) =>
            {
                ReLoadList(args.RecordId);
            };
            frm.ShowDialog();
        }

       


        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************
        //***********************************************************************************************************************************



        public void ReLoadList(int _NewRow_Id)
        {
            SavePosition();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Customers.Load();
            customersBindingSource.DataSource = dbContext.Customers.Local.ToBindingList();
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
                var val = Convert.ToDecimal(e.CellValue);
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



        private void FrmCustomers_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridLayoutHelper.SaveLayout(
                                        gridView,
                                        1,
                                        this.Name);
        }
    }
}