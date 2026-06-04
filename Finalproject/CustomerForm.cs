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
    public partial class CustomerForm : Form
    {
        
        private int selectedCustid;
        public SqlConnection mycon = null;
        public CustomerForm()
        {
            InitializeComponent();
            //string CustConn = @"Data Source=YEHTETT\SQLEXPRESS;Database=CustomerDB;Integrated Security=SSPI";
            //mycon = new SqlConnection(CustConn);
            mycon = new SqlConnection(DBConnect.CustomerConn);
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

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void showData()
        {
            DataTable myDataTable = new DataTable();
            SqlDataReader myDataReader;
            SqlCommand mycommand = new SqlCommand();

            mycommand.CommandText = "SELECT * FROM Customers";
            mycommand.CommandType = CommandType.Text;
            mycommand.Connection = mycon;

            myDataReader = mycommand.ExecuteReader();

            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                dgvCust.DataSource = myDataTable;

                dgvCust.Columns[0].HeaderText = "รหัสลูกค้า";
                dgvCust.Columns[1].HeaderText = "ชื่อลูกค้า";
                dgvCust.Columns[2].HeaderText = "เบอร์";
                dgvCust.Columns[3].HeaderText = "อีเมล์";
                dgvCust.Columns[4].HeaderText = "ที่อยู่";
            }
            else
            {
                dgvCust.DataSource = null;
            }

            myDataReader.Close();
        }
        private void btnAddCust_Click(object sender, EventArgs e)
        {
            // Validate CustName
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อลูกค้า", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            // Validate CustPhone
            if (txtCustomerPhone.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกเบอร์ลูกค้าให้ถูกต้อง", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerPhone.Focus();
                return;
            }

            // Validate Email
            if (txtCustomerEmail.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกอีเมล์ลูกค้าให้ถูกต้อง", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerEmail.Focus();
                return;
            }

            // Validate Location
            if (txtCustomerLocation.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกที่อยู่ลูกค้าให้ถูกต้อง", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerLocation.Focus();
                return;
            }

            if (IsProductNameDuplicate(txtCustomerName.Text))
            {
                MessageBox.Show("ชื่อลูกค้านี้มีอยู่แล้ว", "แจ้งเตือน",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            if (MessageBox.Show("ต้องการเพิ่มลูกค้าหรือไม่", "การยืนยัน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlTransaction myTransaction = mycon.BeginTransaction();

                // Bug #3 Fix: ต้องกำหนด Connection และ Transaction ให้ SqlCommand
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = mycon;
                myCommand.Transaction = myTransaction;

                try
                {
                    myCommand.CommandType = CommandType.Text;
                    myCommand.CommandText ="INSERT INTO Customers(CustomerName, Phone, Email, Location) " +
                    "VALUES(@CustomerName, @Phone, @Email, @Location)";

                    // Bug #2 Fix: Parameter names ตรงกับ SQL ทุกตัว
                    myCommand.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());
                    myCommand.Parameters.AddWithValue("@Phone", txtCustomerPhone.Text.Trim());
                    myCommand.Parameters.AddWithValue("@Email", txtCustomerEmail.Text.Trim());
                    myCommand.Parameters.AddWithValue("@Location", txtCustomerLocation.Text.Trim());

                    object newID = myCommand.ExecuteNonQuery();

                    myTransaction.Commit();
                    MessageBox.Show("เพิ่มลูกค้าเรียบร้อยแล้ว", "ยืนยัน",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form
                    txtCustomerName.Text = "";
                    txtCustomerPhone.Text = "";
                    txtCustomerEmail.Text = "";
                    txtCustomerLocation.Text = "";
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
        private bool IsProductNameDuplicate(string customerName)
        {
            bool isDuplicate = false;

            SqlCommand myCommand = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE CustomerName = @CustomerName", mycon);
            myCommand.Parameters.AddWithValue("@CustomerName", customerName);

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

        private void dgvCust_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCust.Rows[e.RowIndex];
                selectedCustid = Convert.ToInt32(row.Cells[0].Value);
                txtCustomerName.Text = row.Cells[1].Value.ToString();
                txtCustomerPhone.Text = row.Cells[2].Value.ToString();
                txtCustomerEmail.Text = row.Cells[3].Value.ToString();
                txtCustomerLocation.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnShowallCust_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnClearCust_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerLocation.Text = "";
        }

        private void btnUpdateCust_Click(object sender, EventArgs e)
        {
            if (selectedCustid == 0)
            {
                MessageBox.Show("กรุณาเลือกลูกค้าที่ต้องการแก้ไข", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกชื่อลูกค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCustomerPhone.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกเบอร์ลูกค้าเป็นตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerPhone.Focus();
                return;
            }
            if (txtCustomerEmail.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกอีเมล์ของลูกค้าให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerEmail.Focus();
                return;
            }
            if (txtCustomerLocation.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกที่อยู่ของลูกค้าให้ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerLocation.Focus();
                return;
            }

            SqlCommand myCommand = new SqlCommand();
            SqlTransaction myTransaction;
            if (MessageBox.Show("ต้องการแก้ไขข้อมูลลูกค้าหรือไม่", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                myTransaction = mycon.BeginTransaction();
                try
                {
                    myCommand.CommandText = "UPDATE Customers SET CustomerName = @CustomerName, Phone = @Phone, Email = @Email, Location = @Location WHERE CustomerID = @CustomerID";
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Connection = mycon;
                    myCommand.Transaction = myTransaction;
                    myCommand.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());
                    myCommand.Parameters.AddWithValue("@Phone", txtCustomerPhone.Text.Trim());
                    myCommand.Parameters.AddWithValue("@Email", txtCustomerEmail.Text.Trim());
                    myCommand.Parameters.AddWithValue("@Location", txtCustomerLocation.Text.Trim());
                    myCommand.Parameters.Add(new SqlParameter("@CustomerID", selectedCustid));
                    MessageBox.Show("CustomerID = " + selectedCustid);
                    myCommand.ExecuteNonQuery();
                    myTransaction.Commit();
                    MessageBox.Show("แก้ไขข้อมูลลูกค้าเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                    selectedCustid = 0;
                    dgvCust.Refresh();
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

        private void btnDeleteCust_Click(object sender, EventArgs e)
        {
            if (selectedCustid == 0)
            {
                MessageBox.Show("กรุณาเลือกลูกค้าที่ต้องการลบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            SqlCommand myCommand = new SqlCommand();
            SqlTransaction myTransaction;
            if (MessageBox.Show("ต้องการลบข้อมูลลูกค้าหรือไม่", "คำยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                myTransaction = mycon.BeginTransaction();

                try
                {
                    myCommand.CommandText = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Connection = mycon;
                    myCommand.Transaction = myTransaction;
                    myCommand.Parameters.Add(new SqlParameter("@CustomerID", selectedCustid));
                    myCommand.ExecuteNonQuery();
                    myTransaction.Commit();
                    MessageBox.Show("ลบข้อมูลลูกค้าเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                    selectedCustid = 0;
                    dgvCust.Refresh();
                }
                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    MessageBox.Show("เกิดข้อผิดพลาด", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSearchCust_Click(object sender, EventArgs e)
        {
            DataTable myDataTable = new DataTable();
            SqlDataReader myDataReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "SELECT * FROM Customers WHERE CustomerName LIKE @CustomerName";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = mycon;
            myCommand.Parameters.AddWithValue("@CustomerName", "%" + txtCustomerName.Text.Trim() + "%");
            myDataReader = myCommand.ExecuteReader();

            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                dgvCust.DataSource = myDataTable;
            }
            else
            {
                dgvCust.DataSource = null;
                MessageBox.Show("ไม่พบข้อมูลลูกค้า", "ผลการค้นหา", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            myDataReader.Close();
        }
    }
}
