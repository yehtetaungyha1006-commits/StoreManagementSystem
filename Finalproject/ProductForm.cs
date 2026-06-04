using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finalproject
{
    public partial class ProductForm : Form
    {
        private double ProductPrice;
        private int ProductStock;
        private int selectedProductid;
        public SqlConnection mycon = null;
        public ProductForm()
        {
            InitializeComponent();

            //string ProductConn = @"Data Source=YEHTETT\SQLEXPRESS;Database=ProductDB;Integrated Security=SSPI";
            //mycon = new SqlConnection(ProductConn);
            mycon = new SqlConnection(DBConnect.ProductConn);
            try
            {
                mycon.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show("SQL Server Error");
                MessageBox.Show("Error code = " + e.ErrorCode);
                MessageBox.Show("Error Message = " + e.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Invalid Message = " + ex.Message);
            }
            //ตรวจสอบสถานะการเชื่่อม
            if (mycon.State != ConnectionState.Open)
            {
                MessageBox.Show("Database Connection is Failed !!!");
                Application.Exit();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Validate ProductName
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อสินค้า", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }

            // Validate Price
            if (!double.TryParse(txtProductPrice.Text, out ProductPrice))
            {
                MessageBox.Show("กรุณากรอกราคาสินค้าให้ถูกต้อง", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductPrice.Focus();
                return;
            }

            // Validate Quantity
            if (!int.TryParse(txtProductStock.Text, out ProductStock))
            {
                MessageBox.Show("กรุณากรอกจำนวนสินค้าให้ถูกต้อง", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductStock.Focus();
                return;
            }

            if (IsProductNameDuplicate(txtProductName.Text))
            {
                MessageBox.Show("ชื่อสินค้านี้มีอยู่แล้ว", "แจ้งเตือน",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return;
            }
            if (MessageBox.Show("ต้องการเพิ่มสินค้าหรือไม่", "การยืนยัน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlTransaction myTransaction = mycon.BeginTransaction();

                // Bug #3 Fix: ต้องกำหนด Connection และ Transaction ให้ SqlCommand
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = mycon;

                myCommand.Transaction = myTransaction;

                try
                {
                    
                    // Bug #2 Fix: แก้ @ProductiName → @ProductName ให้ตรงกัน
                    myCommand.CommandType = CommandType.Text;
                    myCommand.CommandText =
                    "INSERT INTO Products(ProductName, Price, Stock) " +
                    "VALUES(@ProductName, @Price, @Stock)";



                    // Bug #2 Fix: Parameter names ตรงกับ SQL ทุกตัว
                    myCommand.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                    myCommand.Parameters.AddWithValue("@Price", ProductPrice);
                    myCommand.Parameters.AddWithValue("@Stock", ProductStock);

                    object newID = myCommand.ExecuteNonQuery();

                    myTransaction.Commit();
                    MessageBox.Show("เพิ่มสินค้าเรียบร้อยแล้ว", "ยืนยัน",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form
                    txtProductName.Text = "";
                    txtProductPrice.Text = "";
                    txtProductStock.Text = "";

                    showData();
                }

                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool IsProductNameDuplicate(string productName)
        {
            bool isDuplicate = false;

            SqlCommand myCommand = new SqlCommand("SELECT COUNT(*) FROM Products WHERE ProductName = @ProductName", mycon);
            myCommand.Parameters.AddWithValue("@ProductName", productName);

            try
            {
                int count = (int)myCommand.ExecuteScalar();
                if (count > 0)
                {
                    isDuplicate = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isDuplicate;
        
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            
        }

        private void showData()
        {
            DataTable myDataTable = new DataTable();
            SqlDataReader myDataReader;
            SqlCommand mycommand = new SqlCommand();

            mycommand.CommandText = "SELECT * FROM Products";
            mycommand.CommandType = CommandType.Text;
            mycommand.Connection = mycon;

            myDataReader = mycommand.ExecuteReader();

            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                dgvProduct.DataSource = myDataTable;

                dgvProduct.Columns[0].HeaderText = "รหัสสินค้า";
                dgvProduct.Columns[1].HeaderText = "ชื่อสินค้า";
                dgvProduct.Columns[2].HeaderText = "ราคาสินค้า";
                dgvProduct.Columns[3].HeaderText = "จำนวน";
            }
            else
            {
                dgvProduct.DataSource = null;
            }

            myDataReader.Close();
        }

        private void btnClearFrmProduct_Click(object sender, EventArgs e)
        {
            
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            txtProductStock.Text = "";
            dgvProduct.Refresh();
            showData();
        }

        private void btnShowallProduct_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            DataTable myDataTable = new DataTable();
            SqlDataReader myDataReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "SELECT * FROM Products WHERE ProductName LIKE @ProductName";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = mycon;
            myCommand.Parameters.AddWithValue("@ProductName","%" + txtProductName.Text.Trim() + "%");
            myDataReader = myCommand.ExecuteReader();

            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                dgvProduct.DataSource = myDataTable;
            }
            else
            {
                dgvProduct.DataSource = null;
                MessageBox.Show("ไม่พบข้อมูลสินค้า","ผลการค้นหา",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            myDataReader.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
                selectedProductid = Convert.ToInt32(row.Cells[0].Value);
                txtProductName.Text = row.Cells[1].Value.ToString();
                txtProductPrice.Text = row.Cells[2].Value.ToString();
                txtProductStock.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (selectedProductid == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าที่ต้องการแก้ไข", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtProductName.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกชื่อสินค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!double.TryParse(txtProductPrice.Text, out ProductPrice))
            {
                MessageBox.Show("กรุณากรอกราคาสินค้าเป็นตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductPrice.Focus();
                return;
            }
            if (!int.TryParse(txtProductStock.Text, out ProductStock))
            {
                MessageBox.Show("กรุณากรอกจำนวนสินค้าเป็นตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductStock.Focus();
                return;
            }
            SqlCommand myCommand = new SqlCommand();
            SqlTransaction myTransaction;
            if (MessageBox.Show("ต้องการแก้ไขข้อมูลสินค้าหรือไม่", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                myTransaction = mycon.BeginTransaction();
                try
                {
                    myCommand.CommandText = "UPDATE Products SET ProductName = @ProductName, Price = @Price, Stock = @Stock WHERE ProductID = @ProductID";
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Connection = mycon;
                    myCommand.Transaction = myTransaction;
                    myCommand.Parameters.Add(new SqlParameter("@ProductName", txtProductName.Text.Trim()));
                    myCommand.Parameters.Add(new SqlParameter("@Price", ProductPrice));
                    myCommand.Parameters.Add(new SqlParameter("@Stock", ProductStock));
                    myCommand.Parameters.Add(new SqlParameter("@ProductID", selectedProductid));
                    MessageBox.Show("ProductID = " + selectedProductid);
                    myCommand.ExecuteNonQuery();
                    myTransaction.Commit();
                    MessageBox.Show("แก้ไขข้อมูลสินค้าเรียบร้อยแล้ว", "ผลการทำงาน",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                    selectedProductid = 0;
                    dgvProduct.Refresh();
                }
                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    MessageBox.Show("เกิดข้อผิดพลาด", "แจังเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (selectedProductid == 0)
            {
                MessageBox.Show("กรุณาเลือกสินค้าที่ต้องการลบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlCommand myCommand = new SqlCommand();
            SqlTransaction myTransaction;
            if (MessageBox.Show("ต้องการลบข้อมูลสินค้าหรือไม่", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                myTransaction = mycon.BeginTransaction();

                try
                {
                    myCommand.CommandText = "DELETE FROM Products WHERE ProductID = @ProductID";
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Connection = mycon;
                    myCommand.Transaction = myTransaction;

                    myCommand.Parameters.Add(new SqlParameter("@ProductID", selectedProductid));



                    myCommand.ExecuteNonQuery();
                    myTransaction.Commit();
                    MessageBox.Show("ลบข้อมูลสินค้าเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                    selectedProductid = 0;
                    dgvProduct.Refresh();
                }
                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    MessageBox.Show("เกิดข้อผิดพลาด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
