namespace Finalproject
{
    partial class ProductForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.txtProductStock = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.btnShowallProduct = new System.Windows.Forms.Button();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnClearFrmProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stock Quantity";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(243, 153);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(176, 22);
            this.txtProductName.TabIndex = 5;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(243, 224);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(176, 22);
            this.txtProductPrice.TabIndex = 6;
            // 
            // txtProductStock
            // 
            this.txtProductStock.Location = new System.Drawing.Point(243, 288);
            this.txtProductStock.Name = "txtProductStock";
            this.txtProductStock.Size = new System.Drawing.Size(176, 22);
            this.txtProductStock.TabIndex = 7;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(79, 506);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(128, 41);
            this.btnAddProduct.TabIndex = 8;
            this.btnAddProduct.Text = "ADD";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.Location = new System.Drawing.Point(79, 440);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(128, 41);
            this.btnUpdateProduct.TabIndex = 9;
            this.btnUpdateProduct.Text = "UPDATE";
            this.btnUpdateProduct.UseVisualStyleBackColor = false;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProduct.Location = new System.Drawing.Point(254, 376);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(124, 41);
            this.btnDeleteProduct.TabIndex = 10;
            this.btnDeleteProduct.Text = "DELETE";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProduct.Location = new System.Drawing.Point(254, 440);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(124, 41);
            this.btnSearchProduct.TabIndex = 11;
            this.btnSearchProduct.Text = "SEARCH";
            this.btnSearchProduct.UseVisualStyleBackColor = false;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // btnShowallProduct
            // 
            this.btnShowallProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnShowallProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowallProduct.Location = new System.Drawing.Point(254, 506);
            this.btnShowallProduct.Name = "btnShowallProduct";
            this.btnShowallProduct.Size = new System.Drawing.Size(124, 41);
            this.btnShowallProduct.TabIndex = 12;
            this.btnShowallProduct.Text = "SHOW ALL";
            this.btnShowallProduct.UseVisualStyleBackColor = false;
            this.btnShowallProduct.Click += new System.EventHandler(this.btnShowallProduct_Click);
            // 
            // dgvProduct
            // 
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Location = new System.Drawing.Point(479, 84);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.RowTemplate.Height = 24;
            this.dgvProduct.Size = new System.Drawing.Size(605, 478);
            this.dgvProduct.TabIndex = 13;
            this.dgvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentClick);
            this.dgvProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellContentClick);
            // 
            // btnClearFrmProduct
            // 
            this.btnClearFrmProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClearFrmProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFrmProduct.Location = new System.Drawing.Point(79, 376);
            this.btnClearFrmProduct.Name = "btnClearFrmProduct";
            this.btnClearFrmProduct.Size = new System.Drawing.Size(128, 41);
            this.btnClearFrmProduct.TabIndex = 14;
            this.btnClearFrmProduct.Text = "CLEAR ";
            this.btnClearFrmProduct.UseVisualStyleBackColor = false;
            this.btnClearFrmProduct.Click += new System.EventHandler(this.btnClearFrmProduct_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1185, 632);
            this.Controls.Add(this.btnClearFrmProduct);
            this.Controls.Add(this.dgvProduct);
            this.Controls.Add(this.btnShowallProduct);
            this.Controls.Add(this.btnSearchProduct);
            this.Controls.Add(this.btnDeleteProduct);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.txtProductStock);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.TextBox txtProductStock;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.Button btnShowallProduct;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnClearFrmProduct;
    }
}