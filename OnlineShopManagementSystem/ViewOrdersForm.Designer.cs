namespace OnlineShopManagementSystem
{
    partial class ViewOrdersForm
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
            this.ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.orderItemsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Orders.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.AllowUserToAddRows = false;
            this.ordersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDataGridView.Location = new System.Drawing.Point(9, 37);
            this.ordersDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ordersDataGridView.Name = "ordersDataGridView";
            this.ordersDataGridView.ReadOnly = true;
            this.ordersDataGridView.RowTemplate.Height = 24;
            this.ordersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersDataGridView.Size = new System.Drawing.Size(348, 418);
            this.ordersDataGridView.TabIndex = 1;
            this.ordersDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordersDataGridView_CellClick);
            this.ordersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordersDataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(367, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Details of Selected Order";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // orderItemsDataGridView
            // 
            this.orderItemsDataGridView.AllowUserToAddRows = false;
            this.orderItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderItemsDataGridView.Location = new System.Drawing.Point(370, 37);
            this.orderItemsDataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.orderItemsDataGridView.Name = "orderItemsDataGridView";
            this.orderItemsDataGridView.ReadOnly = true;
            this.orderItemsDataGridView.RowTemplate.Height = 24;
            this.orderItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderItemsDataGridView.Size = new System.Drawing.Size(345, 418);
            this.orderItemsDataGridView.TabIndex = 3;
            this.orderItemsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderItemsDataGridView_CellContentClick);
            // 
            // ViewOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 464);
            this.Controls.Add(this.orderItemsDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ordersDataGridView);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Past Orders";
            this.Load += new System.EventHandler(this.ViewOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ordersDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView orderItemsDataGridView;
    }
}