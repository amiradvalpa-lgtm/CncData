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

namespace CncApp_Final.Frms
{
    public partial class FrmCncCostDetails : DevExpress.XtraEditors.XtraForm
    {
        OrderDetails _orderDetails;
        Sheet _sheet;

        public double CncCost {  get; set; }


        public FrmCncCostDetails(OrderDetails orderDetails)
        {
            InitializeComponent();
            _orderDetails = orderDetails;
        }

        private void FrmCncCostDetails_Load(object sender, EventArgs e)
        {
            LoadAllSheets();

            txbCncCost.EditValue = _orderDetails.CncCost;
            txbCncCostBySheet.EditValue = _orderDetails.CncCost;
            txbGrooveLength.EditValue = _orderDetails.GrooveLength;
            txbCncBasePriceByMeter.EditValue = _sheet.CNCPriceByMeter;

            int tolerance = 100000;
            int CncCostByMeter  = Convert.ToInt32(_sheet.CNCPriceByMeter * _orderDetails.GrooveLength / tolerance) * tolerance;
            int howMuchCncCostSmaller = Convert.ToInt32(_orderDetails.CncCost - CncCostByMeter);
            txbCncCostByMeter.EditValue = CncCostByMeter;
            txbCncCostDifference.EditValue = -howMuchCncCostSmaller;

            txbCncCost.Focus();

        }

        private void LoadAllSheets()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    _sheet = context.Sheets.ToList().FirstOrDefault(s => s.Id == _orderDetails.SheetId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در لود ورق‌ها از پایگاه داده:\n" + ex.Message, "خطا",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CncCost = Math.Abs((double)txbCncCost.EditValue);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}