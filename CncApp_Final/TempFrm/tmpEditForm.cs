using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace CncApp_Final.TempFrm
{
    public partial class tmpEditForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public tmpEditForm()
        {
            InitializeComponent();

            CncApp_Final.Data.AppDbContext dbContext = new CncApp_Final.Data.AppDbContext();
            dbContext.Warehouses.Load();
            warehousesBindingSource.DataSource = dbContext.Warehouses.Local.ToBindingList();
            dbContext.Sheets.Load();
            sheetsBindingSource.DataSource = dbContext.Sheets.Local.ToBindingList();
        }

        private void dataLayoutControl1_FieldRetrieving(object sender, DevExpress.XtraDataLayout.FieldRetrievingEventArgs e)
        {
            if(e.FieldName == "SheetId")
            {
                e.EditorType = typeof(LookUpEdit);
                e.Handled = true;
            }

        }

        private void dataLayoutControl1_FieldRetrieved(object sender, DevExpress.XtraDataLayout.FieldRetrievedEventArgs e)
        {

        }

        private void tmpEditForm_Load(object sender, EventArgs e)
        {
            InitLookupEdit();
        }

        private void InitLookupEdit()
        {
            SheetIdLookUpEdit.Properties.DropDownItemHeight = 25;
            SheetIdLookUpEdit.Properties.PopupSizeable = false;
            SheetIdLookUpEdit.Properties.UseDropDownRowsAsMaxCount = true;
            this.SheetIdLookUpEdit.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth;
            this.SheetIdLookUpEdit.Properties.ShowFooter = false;
            this.SheetIdLookUpEdit.Properties.ShowHeader = false;
        }
    }
}
