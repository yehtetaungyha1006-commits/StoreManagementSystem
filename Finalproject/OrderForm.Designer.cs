namespace Finalproject
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.cmbCust = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnSearchOrder = new System.Windows.Forms.Button();
            this.btnShowAllOrder = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnPrintOrder = new System.Windows.Forms.Button();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCust
            // 
            this.cmbCust.FormattingEnabled = true;
            this.cmbCust.Location = new System.Drawing.Point(156, 71);
            this.cmbCust.Name = "cmbCust";
            this.cmbCust.Size = new System.Drawing.Size(184, 24);
            this.cmbCust.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "CustomerName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "ProductName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "TotalPrice";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(156, 271);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(192, 22);
            this.txtQuantity.TabIndex = 10;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(156, 341);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(192, 22);
            this.txtTotalPrice.TabIndex = 11;
           
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Location = new System.Drawing.Point(405, 70);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.RowTemplate.Height = 24;
            this.dgvOrder.Size = new System.Drawing.Size(827, 366);
            this.dgvOrder.TabIndex = 13;
            this.dgvOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            this.dgvOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.Location = new System.Drawing.Point(184, 400);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(122, 36);
            this.btnAddOrder.TabIndex = 15;
            this.btnAddOrder.Text = "ADD";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateOrder.Location = new System.Drawing.Point(184, 459);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(122, 36);
            this.btnUpdateOrder.TabIndex = 16;
            this.btnUpdateOrder.Text = "UPDATE";
            this.btnUpdateOrder.UseVisualStyleBackColor = false;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrder.Location = new System.Drawing.Point(184, 518);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(122, 36);
            this.btnDeleteOrder.TabIndex = 17;
            this.btnDeleteOrder.Text = "DELETE";
            this.btnDeleteOrder.UseVisualStyleBackColor = false;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnSearchOrder
            // 
            this.btnSearchOrder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearchOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchOrder.Location = new System.Drawing.Point(405, 496);
            this.btnSearchOrder.Name = "btnSearchOrder";
            this.btnSearchOrder.Size = new System.Drawing.Size(122, 36);
            this.btnSearchOrder.TabIndex = 18;
            this.btnSearchOrder.Text = "SEARCH";
            this.btnSearchOrder.UseVisualStyleBackColor = false;
            this.btnSearchOrder.Click += new System.EventHandler(this.btnSearchOrder_Click);
            // 
            // btnShowAllOrder
            // 
            this.btnShowAllOrder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShowAllOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllOrder.Location = new System.Drawing.Point(555, 496);
            this.btnShowAllOrder.Name = "btnShowAllOrder";
            this.btnShowAllOrder.Size = new System.Drawing.Size(122, 36);
            this.btnShowAllOrder.TabIndex = 19;
            this.btnShowAllOrder.Text = "SHOW ALL";
            this.btnShowAllOrder.UseVisualStyleBackColor = false;
            this.btnShowAllOrder.Click += new System.EventHandler(this.btnShowAllOrder_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPrintOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintOrder.Location = new System.Drawing.Point(1052, 496);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(180, 36);
            this.btnPrintOrder.TabIndex = 20;
            this.btnPrintOrder.Text = "Print Receipt";
            this.btnPrintOrder.UseVisualStyleBackColor = false;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_Click);
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(156, 199);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(191, 22);
            this.txtProductPrice.TabIndex = 21;
            
            this.txtProductPrice.TextChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(156, 137);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(184, 24);
            this.cmbProduct.TabIndex = 2;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged_1);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1376, 704);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.btnPrintOrder);
            this.Controls.Add(this.btnShowAllOrder);
            this.Controls.Add(this.btnSearchOrder);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCust);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCust;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnSearchOrder;
        private System.Windows.Forms.Button btnShowAllOrder;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnPrintOrder;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.ComboBox cmbProduct;
    }
}