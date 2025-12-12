using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CncApp_Final.Entities;
using CncApp_Final.Data;

namespace CncApp_Final.Frm
{
    public partial class FrmOrderDetails : DevExpress.XtraEditors.XtraForm
    {
        private OrderDetails _currentDetail;
        
        public FrmOrderDetails()
        {
            InitializeComponent();
        }

        public FrmOrderDetails(OrderDetails detail, AppDbContext dbContext)
        {
            InitializeComponent();
            _currentDetail = detail;
            orderDetailBindingSource.DataSource = _currentDetail;

        }


        private void FrmOrderDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            orderDetailBindingSource.EndEdit();

            DialogResult = DialogResult.OK; // تأیید موفقیت ویرایش
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}