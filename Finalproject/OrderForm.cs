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
    public partial class OrderForm : Form
    {
        private int selectedOrderid;
        public SqlConnection mycon = null;
        public OrderForm()
        {
            InitializeComponent();

            mycon = new SqlConnection(DBConnect.OrderConn);
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
        private void LoadCustomer()
        {
            //ดึงข้อมูลลูกค้ามาแสดงใน ComboBox
            DataTable dtCust = new DataTable();
            SqlDataAdapter daCust =
                new SqlDataAdapter(
                "SELECT CustomerID, CustomerName FROM Customers",
                DBConnect.CustomerConn);
            daCust.Fill(dtCust);
            cmbCust.DataSource = dtCust;
            cmbCust.DisplayMember = "CustomerName";
            cmbCust.ValueMember = "CustomerID";
        }
        private void LoadProduct()
        {
            //ดึงข้อมูลสินค้ามาแสดงใน ComboBox
            DataTable dtProduct = new DataTable();
            SqlDataAdapter daProduct =
                new SqlDataAdapter(
                "SELECT ProductID, ProductName, Price FROM Products",
                DBConnect.ProductConn);
            daProduct.Fill(dtProduct);
            cmbProduct.DataSource = dtProduct;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
        }
        private void showData()
        {
            //แสดงข้อมูลรายการสั่งซื้อทั้งหมดใน DataGridView
            DataTable myDataTable = new DataTable();
            SqlDataReader myDataReader;
            SqlCommand mycommand = new SqlCommand();

            mycommand.CommandText = "SELECT * FROM Orders";
            mycommand.CommandType = CommandType.Text;
            mycommand.Connection = mycon;

            myDataReader = mycommand.ExecuteReader();

            if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                dgvOrder.DataSource = myDataTable;

                dgvOrder.Columns[0].HeaderText = "รหัส Order";
                dgvOrder.Columns[1].HeaderText = "รหัสลูกค้า";
                dgvOrder.Columns[2].HeaderText = "ชื่อลูกค้า";
                dgvOrder.Columns[3].HeaderText = "ชื่อสินค้า";
                dgvOrder.Columns[4].HeaderText = "ราคา";
                dgvOrder.Columns[5].HeaderText = "จำนวน";
                dgvOrder.Columns[6].HeaderText = "ราคารวม";
            }
            else
            {
                dgvOrder.DataSource = null;
            }

            myDataReader.Close();   
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 12);
            int y = 50;

            e.Graphics.DrawString("RECEIPT",
                titleFont,Brushes.Black,250,y);
                y += 50;

            e.Graphics.DrawString("ชื่อลูกค้า : " + cmbCust.Text,
                bodyFont,Brushes.Black,50,y);
                y += 30;

            e.Graphics.DrawString("ชื่อสินค้า : " + cmbProduct.Text,
                bodyFont,Brushes.Black,50,y);
                y += 30;

            e.Graphics.DrawString("ราคาต่อหน่วย : " + txtProductPrice.Text,
                bodyFont,Brushes.Black,50,y);
                y += 30;

            e.Graphics.DrawString("จำนวนสินค้าที่ซื้อ : " + txtQuantity.Text,
                bodyFont,Brushes.Black,50,y);
                y += 30;

            e.Graphics.DrawString("ราคารวม : " + txtTotalPrice.Text,
                bodyFont,Brushes.Black,50,y);
                y += 50;

            e.Graphics.DrawString("Thank You",
                titleFont,Brushes.Black,200,y);
        }
    
        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadProduct();
            showData();
            printPreviewDialog1.Document = printDocument1;

        }

        private void cmbProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlConnection Mycon2 =new SqlConnection(DBConnect.ProductConn);
            Mycon2.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText =
                "SELECT Price FROM Products WHERE ProductName = @ProductName";
            myCommand.Connection = Mycon2;
            myCommand.Parameters.AddWithValue(
                "@ProductName",
                cmbProduct.Text);
            object result = myCommand.ExecuteScalar();
            if (result != null)
            {
                txtProductPrice.Text = result.ToString();
            }
            Mycon2.Close();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            double price;
            int Quantity;

            if (double.TryParse(txtProductPrice.Text, out price) &&
                int.TryParse(txtQuantity.Text, out Quantity))
            {
                txtTotalPrice.Text = (price * Quantity).ToString();
            }
            else
            {
                txtTotalPrice.Text = "";
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            // ตรวจสอบเลือกลูกค้า
            if (cmbCust.SelectedIndex == -1)
            {
                MessageBox.Show("กรุณาเลือกลูกค้า", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCust.Focus();
                return;
            }
            // ตรวจสอบเลือกสินค้า           
            if (cmbProduct.SelectedIndex == -1)
            {
                MessageBox.Show("กรุณาเลือกสินค้า", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProduct.Focus();
                return;
            }
            if (txtQuantity.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกจำนวนสินค้าให้ถูกต้อง", "แจ้งเตือน",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }
            
            if (MessageBox.Show("ต้องการชื้อสินค้าหรือไม่", "การยืนยัน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {               
                SqlTransaction myTransaction = mycon.BeginTransaction();

                //เช็ค Stock ก่อนสั่งซื้อสินค้า
                SqlConnection productCon =new SqlConnection(DBConnect.ProductConn);
                productCon.Open();
                SqlCommand checkStock = new SqlCommand("SELECT Stock FROM Products WHERE ProductName = @ProductName",productCon);
                checkStock.Parameters.AddWithValue("@ProductName",cmbProduct.Text);

                int currentStock =
                    Convert.ToInt32(checkStock.ExecuteScalar());

                MessageBox.Show("สินค้าคงเหลือ : " + currentStock + " ชิ้น","จำนวนสินค้าใน Stock",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);

                int orderQty =
                    Convert.ToInt32(txtQuantity.Text);

                if (orderQty > currentStock)
                {
                    MessageBox.Show("สินค้าใน Stock ไม่เพียงพอ","แจ้งเตือน",
                        MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    productCon.Close();
                    return;
                }
                productCon.Close();

                // Bug #3 Fix: ต้องกำหนด Connection และ Transaction ให้ SqlCommand
                //ซื้อสินค้าและบันทึกข้อมูลการสั่งซื้อ
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = mycon;
                myCommand.Transaction = myTransaction;

                try
                {
                    myCommand.CommandType = CommandType.Text;
                    myCommand.CommandText =
                    "INSERT INTO Orders(CustomerID, CustomerName, ProductName, Price, Quantity, TotalPrice) " +
                    "VALUES(@CustomerID, @CustomerName, @ProductName, @Price, @Quantity, @TotalPrice)";
                    myCommand.Parameters.AddWithValue("@CustomerID",cmbCust.SelectedValue);
                    myCommand.Parameters.AddWithValue("@CustomerName",cmbCust.Text);
                    myCommand.Parameters.AddWithValue("@ProductName",cmbProduct.Text);
                    myCommand.Parameters.AddWithValue("@Price",Convert.ToDecimal(txtProductPrice.Text));
                    myCommand.Parameters.AddWithValue("@Quantity",Convert.ToInt32(txtQuantity.Text));
                    myCommand.Parameters.AddWithValue("@TotalPrice",Convert.ToDouble(txtTotalPrice.Text));
                    myCommand.ExecuteNonQuery();

                    //SqlConnection productCon = new SqlConnection(DBConnect.ProductConn);
                    //Update Stock หลังจากสั่งซื้อสินค้า
                    productCon.Open();
                    SqlCommand updateStock = new SqlCommand("UPDATE Products " +"SET Stock = Stock - @Qty " +"WHERE ProductName = @ProductName",productCon);
                    updateStock.Parameters.AddWithValue("@Qty",Convert.ToInt32(txtQuantity.Text));
                    updateStock.Parameters.AddWithValue("@ProductName",cmbProduct.Text);
                    updateStock.ExecuteNonQuery();
                    productCon.Close();
                    myTransaction.Commit();

                    MessageBox.Show("เพิ่มรายการสั่งซื้อเรียบร้อยแล้ว","ยืนยัน",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
 
                    // Clear form
                    cmbCust.SelectedIndex = -1;
                    cmbProduct.SelectedIndex = -1;
                    txtProductPrice.Text = "";
                    txtQuantity.Text = "";
                    txtTotalPrice.Text = "";
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

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvOrder.Rows[e.RowIndex];
                selectedOrderid = Convert.ToInt32(row.Cells[0].Value);
                cmbCust.Text = row.Cells[2].Value.ToString();
                cmbProduct.Text = row.Cells[3].Value.ToString();
                txtProductPrice.Text = row.Cells[4].Value.ToString();
                txtQuantity.Text = row.Cells[5].Value.ToString();
                txtTotalPrice.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnShowAllOrder_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            
            if (selectedOrderid == 0)
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการแก้ไข","แจ้งเตือน",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (cmbCust.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาเลือกลูกค้า");
                return;
            }
            if (cmbProduct.Text.Trim() == "")
            {
                MessageBox.Show("กรุณาเลือกสินค้า");
                return;
            }
            if (txtQuantity.Text.Trim() == "")
            {
                MessageBox.Show("กรุณากรอกจำนวนสินค้า");
                return;
            }

            SqlCommand myCommand = new SqlCommand();
            SqlTransaction myTransaction;
            if (MessageBox.Show("ต้องการแก้ไขรายการสั่งซื้อหรือไม่","คำยืนยัน",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                myTransaction = mycon.BeginTransaction();

                // ดึงข้อมูลจำนวนสินค้าที่สั่งซื้อเดิมมาเปรียบเทียบกับจำนวนใหม่
                SqlCommand oldQtyCmd = new SqlCommand("SELECT Quantity FROM Orders WHERE OrderID = @OrderID",mycon);
                oldQtyCmd.Transaction = myTransaction;
                oldQtyCmd.Parameters.AddWithValue("@OrderID",selectedOrderid);

                int oldQty =
                    Convert.ToInt32(oldQtyCmd.ExecuteScalar());
                int newQty =
                    Convert.ToInt32(txtQuantity.Text);
                int diffQty = newQty - oldQty;


                // Bug #3 Fix: ต้องกำหนด Connection และ Transaction ให้ SqlCommand
                try
                {
                    myCommand.CommandText =
                    " UPDATE Orders SET CustomerID = @CustomerID, CustomerName = @CustomerName, ProductName = @ProductName, Price = @Price, Quantity = @Quantity, TotalPrice = @TotalPrice WHERE OrderID = @OrderID";                  
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Connection = mycon;
                    myCommand.Transaction = myTransaction;

                    myCommand.Parameters.AddWithValue("@CustomerID",cmbCust.SelectedValue);
                    myCommand.Parameters.AddWithValue("@CustomerName",cmbCust.Text);
                    myCommand.Parameters.AddWithValue("@ProductName",cmbProduct.Text);
                    myCommand.Parameters.AddWithValue("@Price",Convert.ToDecimal(txtProductPrice.Text));
                    myCommand.Parameters.AddWithValue("@Quantity",Convert.ToInt32(txtQuantity.Text));
                    myCommand.Parameters.AddWithValue("@TotalPrice",Convert.ToDecimal(txtTotalPrice.Text));
                    myCommand.Parameters.AddWithValue("@OrderID",selectedOrderid);
                    myCommand.ExecuteNonQuery();

                    SqlConnection productCon =new SqlConnection(DBConnect.ProductConn);
                    productCon.Open();

                    //ปรับปรุง Stock ตามจำนวนที่เปลี่ยนแปลง
                    if (diffQty > 0)
                    {
                        SqlCommand stockCmd = new SqlCommand("UPDATE Products " +"SET Stock = Stock - @Qty " +"WHERE ProductName = @ProductName",productCon);
                        stockCmd.Parameters.AddWithValue("@Qty", diffQty);
                        stockCmd.Parameters.AddWithValue("@ProductName", cmbProduct.Text);
                        stockCmd.ExecuteNonQuery();
                    }
                    else if (diffQty < 0)
                    {
                        SqlCommand stockCmd = new SqlCommand("UPDATE Products " +"SET Stock = Stock + @Qty " +"WHERE ProductName = @ProductName",productCon);
                        stockCmd.Parameters.AddWithValue("@Qty", Math.Abs(diffQty));
                        stockCmd.Parameters.AddWithValue("@ProductName", cmbProduct.Text);
                        stockCmd.ExecuteNonQuery();
                    }
                   productCon.Close();

                    //ถ้าจำนวนที่เพิ่มขึ้นมากกว่า 0 ให้เช็ค Stock ก่อนปรับปรุงข้อมูล
                    if (diffQty > 0)
                    {
                        //SqlConnection productCon =
                            //new SqlConnection(DBConnect.ProductConn)
                        productCon.Open();

                        SqlCommand checkStock = new SqlCommand("SELECT Stock FROM Products WHERE ProductName = @ProductName",productCon);

                        checkStock.Parameters.AddWithValue("@ProductName",cmbProduct.Text);

                        int currentStock =
                            Convert.ToInt32(checkStock.ExecuteScalar());

                        if (diffQty > currentStock)
                        {
                            MessageBox.Show("สินค้าใน Stock ไม่เพียงพอ","แจ้งเตือน");
                            productCon.Close();
                            return;
                        }
                        productCon.Close();
                    }
                    myTransaction.Commit();
                    MessageBox.Show("แก้ไขรายการสั่งซื้อเรียบร้อยแล้ว","ผลการทำงาน",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                    showData();
                    selectedOrderid = 0;
                }
                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    MessageBox.Show(ex.Message,"ข้อผิดพลาด",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (selectedOrderid == 0)
            {
                MessageBox.Show("กรุณาเลือกรายการสั่งซื้อที่ต้องการลบ","แจ้งเตือน",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            SqlCommand myCommand = new SqlCommand();
            SqlTransaction myTransaction;

            if (MessageBox.Show("ต้องการลบรายการสั่งซื้อหรือไม่","คำยืนยัน",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                myTransaction = mycon.BeginTransaction();

                // ดึงข้อมูลชื่อสินค้าและจำนวนที่สั่งซื้อมาใช้ในการปรับปรุง Stock เมื่อมีการลบรายการสั่งซื้อ
                SqlCommand getOrderCmd = new SqlCommand("SELECT ProductName, Quantity FROM Orders WHERE OrderID = @OrderID",mycon);
                getOrderCmd.Transaction = myTransaction;
                getOrderCmd.Parameters.AddWithValue("@OrderID",selectedOrderid);
                SqlDataReader dr = getOrderCmd.ExecuteReader();

                string productName = "";
                int qty = 0;
                // ถ้าเจอข้อมูลรายการสั่งซื้อที่ต้องการลบ ให้ดึงชื่อสินค้าและจำนวนที่สั่งซื้อมาใช้ในการปรับปรุง Stock
                if (dr.Read())
                {
                    productName = dr["ProductName"].ToString();
                    qty = Convert.ToInt32(dr["Quantity"]);
                }

                dr.Close();
                
                SqlConnection productCon =new SqlConnection(DBConnect.ProductConn);
                productCon.Open();
                // ปรับปรุง Stock โดยเพิ่มจำนวนสินค้ากลับเข้าไปใน Stock เมื่อมีการลบรายการสั่งซื้อ
                SqlCommand stockCmd = new SqlCommand("UPDATE Products " +"SET Stock = Stock + @Qty " +"WHERE ProductName = @ProductName",productCon);

                stockCmd.Parameters.AddWithValue("@Qty", qty);
                stockCmd.Parameters.AddWithValue("@ProductName", productName);

                stockCmd.ExecuteNonQuery();
                productCon.Close();

                try
                {
                    myCommand.CommandText =
                        "DELETE FROM Orders WHERE OrderID = @OrderID";
                    myCommand.CommandType = CommandType.Text;
                    myCommand.Connection = mycon;
                    myCommand.Transaction = myTransaction;
                    myCommand.Parameters.Add(new SqlParameter("@OrderID", selectedOrderid));
                    myCommand.ExecuteNonQuery();
                    myTransaction.Commit();
                    MessageBox.Show("ลบรายการสั่งซื้อเรียบร้อยแล้ว","ผลการทำงาน",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                    showData();
                    selectedOrderid = 0;
                    dgvOrder.Refresh();
                }
                catch (Exception ex)
                {
                    myTransaction.Rollback();
                    MessageBox.Show("เกิดข้อผิดพลาด","แจ้งเตือน",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            DataTable myDataTable = new DataTable();
            SqlDataReader myDataReader;
            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText =
                "SELECT * FROM Orders WHERE CustomerName LIKE @CustomerName";

            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = mycon;
            myCommand.Parameters.AddWithValue("@CustomerName","%" + cmbCust.Text.Trim() + "%");
            myDataReader = myCommand.ExecuteReader();
           if (myDataReader.HasRows)
            {
                myDataTable.Load(myDataReader);
                dgvOrder.DataSource = myDataTable;
            }
            else
            {
                dgvOrder.DataSource = null;

                MessageBox.Show("ไม่พบข้อมูลรายการสั่งซื้อ","ผลการค้นหา",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            myDataReader.Close();
        }

        private void btnPrintOrder_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }
    }
    
}
