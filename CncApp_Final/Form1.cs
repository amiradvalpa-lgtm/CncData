using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CncApp_Final.Data;

namespace CncApp_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new Data.AppDbContext())
            {
                var banks = db.BankAccounts.Count();
                var customers = db.Customers.Count();

                
                //MessageBox.Show($"اتصال موفق!\nحساب‌ها: {banks}\nمشتریان: {customers}", "موفقیت",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadBankAccounts();
        }
        private void LoadBankAccounts()
        {
            //using (var db = new AppDbContext())
            //{
            //    var banks = db.BankAccounts
            //        .OrderBy(b => b.Id)
            //        .Select(b => new
            //        {
            //            b.Id,
            //            نام_حساب = b.AccountName
            //        })
            //        .ToList();

            //    dgvBanks.DataSource = banks;

            //    // تنظیمات ظاهری (اختیاری ولی قشنگ میشه)
            //    dgvBanks.Columns["Id"].HeaderText = "کد";
            //    dgvBanks.Columns["Id"].Width = 60;
            //    dgvBanks.Columns["نام_حساب"].HeaderText = "نام حساب بانکی";
            //    dgvBanks.Columns["نام_حساب"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //    dgvBanks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //    dgvBanks.MultiSelect = false;
            //    dgvBanks.ReadOnly = true;
            //    dgvBanks.AllowUserToAddRows = false;
            //}
        }
    }
}
