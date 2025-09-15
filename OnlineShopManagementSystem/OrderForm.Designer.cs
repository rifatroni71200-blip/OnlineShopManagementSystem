namespace OnlineShopManagementSystem
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
            this.label1 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.productComboBox = new System.Windows.Forms.ComboBox();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.addToCartButton = new System.Windows.Forms.Button();
            this.orderItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.placeOrderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Customer:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // customerComboBox
            // 
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(141, 30);
            this.customerComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(93, 21);
            this.customerComboBox.TabIndex = 1;
            this.customerComboBox.SelectedIndexChanged += new System.EventHandler(this.customerComboBox_SelectedIndexChanged);
            this.customerComboBox.SelectionChangeCommitted += new System.EventHandler(this.customerComboBox_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Product:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quantity:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // productComboBox
            // 
            this.productComboBox.FormattingEnabled = true;
            this.productComboBox.Location = new System.Drawing.Point(141, 109);
            this.productComboBox.Margin = new System.Windows.Forms.Padding(1);
            this.productComboBox.Name = "productComboBox";
            this.productComboBox.Size = new System.Drawing.Size(93, 21);
            this.productComboBox.TabIndex = 1;
            this.productComboBox.SelectedIndexChanged += new System.EventHandler(this.productComboBox_SelectedIndexChanged);
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(141, 181);
            this.quantityNumericUpDown.Margin = new System.Windows.Forms.Padding(1);
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.quantityNumericUpDown.TabIndex = 4;
            this.quantityNumericUpDown.ValueChanged += new System.EventHandler(this.quantityNumericUpDown_ValueChanged);
            // 
            // addToCartButton
            // 
            this.addToCartButton.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartButton.ForeColor = System.Drawing.Color.DarkRed;
            this.addToCartButton.Location = new System.Drawing.Point(37, 276);
            this.addToCartButton.Margin = new System.Windows.Forms.Padding(1);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(168, 36);
            this.addToCartButton.TabIndex = 5;
            this.addToCartButton.Text = "Add to Cart.";
            this.addToCartButton.UseVisualStyleBackColor = true;
            this.addToCartButton.Click += new System.EventHandler(this.addToCartButton_Click);
            // 
            // orderItemsDataGridView
            // 
            this.orderItemsDataGridView.AllowUserToAddRows = false;
            this.orderItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderItemsDataGridView.Location = new System.Drawing.Point(263, 10);
            this.orderItemsDataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.orderItemsDataGridView.Name = "orderItemsDataGridView";
            this.orderItemsDataGridView.ReadOnly = true;
            this.orderItemsDataGridView.RowTemplate.Height = 24;
            this.orderItemsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderItemsDataGridView.Size = new System.Drawing.Size(395, 302);
            this.orderItemsDataGridView.TabIndex = 6;
            this.orderItemsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderItemsDataGridView_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(259, 318);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total :";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new System.Drawing.Point(313, 316);
            this.totalTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.ReadOnly = true;
            this.totalTextBox.Size = new System.Drawing.Size(141, 20);
            this.totalTextBox.TabIndex = 8;
            this.totalTextBox.TextChanged += new System.EventHandler(this.totalTextBox_TextChanged);
            // 
            // placeOrderButton
            // 
            this.placeOrderButton.BackColor = System.Drawing.Color.SeaShell;
            this.placeOrderButton.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeOrderButton.ForeColor = System.Drawing.Color.Goldenrod;
            this.placeOrderButton.Location = new System.Drawing.Point(499, 319);
            this.placeOrderButton.Margin = new System.Windows.Forms.Padding(1);
            this.placeOrderButton.Name = "placeOrderButton";
            this.placeOrderButton.Size = new System.Drawing.Size(158, 36);
            this.placeOrderButton.TabIndex = 9;
            this.placeOrderButton.Text = "Place Order!";
            this.placeOrderButton.UseVisualStyleBackColor = false;
            this.placeOrderButton.Click += new System.EventHandler(this.placeOrderButton_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 365);
            this.Controls.Add(this.placeOrderButton);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orderItemsDataGridView);
            this.Controls.Add(this.addToCartButton);
            this.Controls.Add(this.quantityNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productComboBox);
            this.Controls.Add(this.customerComboBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Placement";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderItemsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox productComboBox;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.Button addToCartButton;
        private System.Windows.Forms.DataGridView orderItemsDataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Button placeOrderButton;
    }
}