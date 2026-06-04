using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalproject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm();
            frm.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm();
            frm.ShowDialog();
        }
    }
}
