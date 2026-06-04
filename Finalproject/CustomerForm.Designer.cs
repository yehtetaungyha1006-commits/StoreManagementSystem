namespace Finalproject
{
    partial class CustomerForm
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
            this.CustomerName = new System.Windows.Forms.Label();
            this.CustomerPhone = new System.Windows.Forms.Label();
            this.CustomerEmmail = new System.Windows.Forms.Label();
            this.CustomerLocation = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.txtCustomerLocation = new System.Windows.Forms.TextBox();
            this.btnClearCust = new System.Windows.Forms.Button();
            this.btnUpdateCust = new System.Windows.Forms.Button();
            this.btnAddCust = new System.Windows.Forms.Button();
            this.btnShowallCust = new System.Windows.Forms.Button();
            this.btnSearchCust = new System.Windows.Forms.Button();
            this.btnDeleteCust = new System.Windows.Forms.Button();
            this.dgvCust = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCust)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSize = true;
            this.CustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerName.Location = new System.Drawing.Point(69, 115);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(117, 16);
            this.CustomerName.TabIndex = 0;
            this.CustomerName.Text = "Customer Name";
            // 
            // CustomerPhone
            // 
            this.CustomerPhone.AutoSize = true;
            this.CustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerPhone.Location = new System.Drawing.Point(81, 181);
            this.CustomerPhone.Name = "CustomerPhone";
            this.CustomerPhone.Size = new System.Drawing.Size(105, 16);
            this.CustomerPhone.TabIndex = 1;
            this.CustomerPhone.Text = "PhoneNumber";
            // 
            // CustomerEmmail
            // 
            this.CustomerEmmail.AutoSize = true;
            this.CustomerEmmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerEmmail.Location = new System.Drawing.Point(140, 244);
            this.CustomerEmmail.Name = "CustomerEmmail";
            this.CustomerEmmail.Size = new System.Drawing.Size(46, 16);
            this.CustomerEmmail.TabIndex = 2;
            this.CustomerEmmail.Text = "Email";
            // 
            // CustomerLocation
            // 
            this.CustomerLocation.AutoSize = true;
            this.CustomerLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerLocation.Location = new System.Drawing.Point(120, 302);
            this.CustomerLocation.Name = "CustomerLocation";
            this.CustomerLocation.Size = new System.Drawing.Size(66, 16);
            this.CustomerLocation.TabIndex = 3;
            this.CustomerLocation.Text = "Location";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(226, 112);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(182, 22);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(226, 181);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(182, 22);
            this.txtCustomerPhone.TabIndex = 5;
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Location = new System.Drawing.Point(226, 241);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.Size = new System.Drawing.Size(182, 22);
            this.txtCustomerEmail.TabIndex = 6;
            // 
            // txtCustomerLocation
            // 
            this.txtCustomerLocation.Location = new System.Drawing.Point(226, 299);
            this.txtCustomerLocation.Name = "txtCustomerLocation";
            this.txtCustomerLocation.Size = new System.Drawing.Size(182, 22);
            this.txtCustomerLocation.TabIndex = 7;
            // 
            // btnClearCust
            // 
            this.btnClearCust.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnClearCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCust.Location = new System.Drawing.Point(157, 367);
            this.btnClearCust.Name = "btnClearCust";
            this.btnClearCust.Size = new System.Drawing.Size(106, 33);
            this.btnClearCust.TabIndex = 8;
            this.btnClearCust.Text = "CLEAR";
            this.btnClearCust.UseVisualStyleBackColor = false;
            this.btnClearCust.Click += new System.EventHandler(this.btnClearCust_Click);
            // 
            // btnUpdateCust
            // 
            this.btnUpdateCust.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnUpdateCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCust.Location = new System.Drawing.Point(157, 482);
            this.btnUpdateCust.Name = "btnUpdateCust";
            this.btnUpdateCust.Size = new System.Drawing.Size(106, 33);
            this.btnUpdateCust.TabIndex = 9;
            this.btnUpdateCust.Text = "UPDATE";
            this.btnUpdateCust.UseVisualStyleBackColor = false;
            this.btnUpdateCust.Click += new System.EventHandler(this.btnUpdateCust_Click);
            // 
            // btnAddCust
            // 
            this.btnAddCust.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCust.Location = new System.Drawing.Point(157, 429);
            this.btnAddCust.Name = "btnAddCust";
            this.btnAddCust.Size = new System.Drawing.Size(106, 33);
            this.btnAddCust.TabIndex = 10;
            this.btnAddCust.Text = "ADD";
            this.btnAddCust.UseVisualStyleBackColor = false;
            this.btnAddCust.Click += new System.EventHandler(this.btnAddCust_Click);
            // 
            // btnShowallCust
            // 
            this.btnShowallCust.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShowallCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowallCust.Location = new System.Drawing.Point(300, 482);
            this.btnShowallCust.Name = "btnShowallCust";
            this.btnShowallCust.Size = new System.Drawing.Size(108, 33);
            this.btnShowallCust.TabIndex = 11;
            this.btnShowallCust.Text = "SHOW ALL";
            this.btnShowallCust.UseVisualStyleBackColor = false;
            this.btnShowallCust.Click += new System.EventHandler(this.btnShowallCust_Click);
            // 
            // btnSearchCust
            // 
            this.btnSearchCust.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSearchCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCust.Location = new System.Drawing.Point(300, 429);
            this.btnSearchCust.Name = "btnSearchCust";
            this.btnSearchCust.Size = new System.Drawing.Size(108, 33);
            this.btnSearchCust.TabIndex = 12;
            this.btnSearchCust.Text = "SEARCH";
            this.btnSearchCust.UseVisualStyleBackColor = false;
            this.btnSearchCust.Click += new System.EventHandler(this.btnSearchCust_Click);
            // 
            // btnDeleteCust
            // 
            this.btnDeleteCust.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCust.Location = new System.Drawing.Point(300, 367);
            this.btnDeleteCust.Name = "btnDeleteCust";
            this.btnDeleteCust.Size = new System.Drawing.Size(108, 33);
            this.btnDeleteCust.TabIndex = 13;
            this.btnDeleteCust.Text = "DELETE";
            this.btnDeleteCust.UseVisualStyleBackColor = false;
            this.btnDeleteCust.Click += new System.EventHandler(this.btnDeleteCust_Click);
            // 
            // dgvCust
            // 
            this.dgvCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCust.Location = new System.Drawing.Point(471, 102);
            this.dgvCust.Name = "dgvCust";
            this.dgvCust.RowHeadersWidth = 51;
            this.dgvCust.RowTemplate.Height = 24;
            this.dgvCust.Size = new System.Drawing.Size(737, 413);
            this.dgvCust.TabIndex = 14;
            this.dgvCust.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCust_CellContentClick);
            this.dgvCust.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCust_CellContentClick);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1277, 627);
            this.Controls.Add(this.dgvCust);
            this.Controls.Add(this.btnDeleteCust);
            this.Controls.Add(this.btnSearchCust);
            this.Controls.Add(this.btnShowallCust);
            this.Controls.Add(this.btnAddCust);
            this.Controls.Add(this.btnUpdateCust);
            this.Controls.Add(this.btnClearCust);
            this.Controls.Add(this.txtCustomerLocation);
            this.Controls.Add(this.txtCustomerEmail);
            this.Controls.Add(this.txtCustomerPhone);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.CustomerLocation);
            this.Controls.Add(this.CustomerEmmail);
            this.Controls.Add(this.CustomerPhone);
            this.Controls.Add(this.CustomerName);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CustomerName;
        private System.Windows.Forms.Label CustomerPhone;
        private System.Windows.Forms.Label CustomerEmmail;
        private System.Windows.Forms.Label CustomerLocation;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.TextBox txtCustomerLocation;
        private System.Windows.Forms.Button btnClearCust;
        private System.Windows.Forms.Button btnUpdateCust;
        private System.Windows.Forms.Button btnAddCust;
        private System.Windows.Forms.Button btnShowallCust;
        private System.Windows.Forms.Button btnSearchCust;
        private System.Windows.Forms.Button btnDeleteCust;
        private System.Windows.Forms.DataGridView dgvCust;
    }
}