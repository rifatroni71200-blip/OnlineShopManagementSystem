namespace OnlineShopManagementSystem
{
    partial class DashboardForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totalRevenueLabel = new System.Windows.Forms.Label();
            this.totalProductsLabel = new System.Windows.Forms.Label();
            this.totalOrdersLabel = new System.Windows.Forms.Label();
            this.topProductLabel = new System.Windows.Forms.Label();
            this.topCustomerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Banner", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "DASHBOARD";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(33, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Sales Revenue:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Purple;
            this.label4.Location = new System.Drawing.Point(33, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Products in Stock:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Purple;
            this.label6.Location = new System.Drawing.Point(33, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Total Orders Placed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Purple;
            this.label8.Location = new System.Drawing.Point(33, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Top Selling Product:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Purple;
            this.label12.Location = new System.Drawing.Point(33, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(228, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Most Valuable Customer:";
            // 
            // totalRevenueLabel
            // 
            this.totalRevenueLabel.AutoSize = true;
            this.totalRevenueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRevenueLabel.ForeColor = System.Drawing.Color.Navy;
            this.totalRevenueLabel.Location = new System.Drawing.Point(347, 116);
            this.totalRevenueLabel.Name = "totalRevenueLabel";
            this.totalRevenueLabel.Size = new System.Drawing.Size(78, 20);
            this.totalRevenueLabel.TabIndex = 2;
            this.totalRevenueLabel.Text = "Loading...";
            this.totalRevenueLabel.Click += new System.EventHandler(this.totalRevenueLabel_Click);
            // 
            // totalProductsLabel
            // 
            this.totalProductsLabel.AutoSize = true;
            this.totalProductsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalProductsLabel.ForeColor = System.Drawing.Color.Navy;
            this.totalProductsLabel.Location = new System.Drawing.Point(347, 172);
            this.totalProductsLabel.Name = "totalProductsLabel";
            this.totalProductsLabel.Size = new System.Drawing.Size(78, 20);
            this.totalProductsLabel.TabIndex = 4;
            this.totalProductsLabel.Text = "Loading...";
            this.totalProductsLabel.Click += new System.EventHandler(this.totalProductsLabel_Click);
            // 
            // totalOrdersLabel
            // 
            this.totalOrdersLabel.AutoSize = true;
            this.totalOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalOrdersLabel.ForeColor = System.Drawing.Color.Navy;
            this.totalOrdersLabel.Location = new System.Drawing.Point(347, 224);
            this.totalOrdersLabel.Name = "totalOrdersLabel";
            this.totalOrdersLabel.Size = new System.Drawing.Size(78, 20);
            this.totalOrdersLabel.TabIndex = 4;
            this.totalOrdersLabel.Text = "Loading...";
            this.totalOrdersLabel.Click += new System.EventHandler(this.totalOrdersLabel_Click);
            // 
            // topProductLabel
            // 
            this.topProductLabel.AutoSize = true;
            this.topProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topProductLabel.ForeColor = System.Drawing.Color.Navy;
            this.topProductLabel.Location = new System.Drawing.Point(347, 280);
            this.topProductLabel.Name = "topProductLabel";
            this.topProductLabel.Size = new System.Drawing.Size(78, 20);
            this.topProductLabel.TabIndex = 4;
            this.topProductLabel.Text = "Loading...";
            this.topProductLabel.Click += new System.EventHandler(this.topProductLabel_Click);
            // 
            // topCustomerLabel
            // 
            this.topCustomerLabel.AutoSize = true;
            this.topCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topCustomerLabel.ForeColor = System.Drawing.Color.Navy;
            this.topCustomerLabel.Location = new System.Drawing.Point(347, 334);
            this.topCustomerLabel.Name = "topCustomerLabel";
            this.topCustomerLabel.Size = new System.Drawing.Size(78, 20);
            this.topCustomerLabel.TabIndex = 4;
            this.topCustomerLabel.Text = "Loading...";
            this.topCustomerLabel.Click += new System.EventHandler(this.topCustomerLabel_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.topCustomerLabel);
            this.Controls.Add(this.topProductLabel);
            this.Controls.Add(this.totalOrdersLabel);
            this.Controls.Add(this.totalProductsLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.totalRevenueLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totalRevenueLabel;
        private System.Windows.Forms.Label totalProductsLabel;
        private System.Windows.Forms.Label totalOrdersLabel;
        private System.Windows.Forms.Label topProductLabel;
        private System.Windows.Forms.Label topCustomerLabel;
    }
}