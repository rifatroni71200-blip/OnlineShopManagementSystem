namespace OnlineShopManagementSystem
{
    partial class MainMenu
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
            this.productButton = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.viewOrdersButton = new System.Windows.Forms.Button();
            this.manageCategoriesButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.manageCustomersButton = new System.Windows.Forms.Button();
            this.paymentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Online Shop Management System";
            // 
            // productButton
            // 
            this.productButton.BackColor = System.Drawing.Color.PeachPuff;
            this.productButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productButton.Location = new System.Drawing.Point(20, 76);
            this.productButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.productButton.Name = "productButton";
            this.productButton.Size = new System.Drawing.Size(241, 95);
            this.productButton.TabIndex = 1;
            this.productButton.Text = "Product Management";
            this.productButton.UseVisualStyleBackColor = false;
            this.productButton.Click += new System.EventHandler(this.productButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.BackColor = System.Drawing.Color.PeachPuff;
            this.orderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderButton.Location = new System.Drawing.Point(267, 76);
            this.orderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(261, 95);
            this.orderButton.TabIndex = 2;
            this.orderButton.Text = "Order Placement";
            this.orderButton.UseVisualStyleBackColor = false;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.DarkRed;
            this.exitButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitButton.Location = new System.Drawing.Point(569, 378);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(219, 59);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // viewOrdersButton
            // 
            this.viewOrdersButton.BackColor = System.Drawing.Color.PeachPuff;
            this.viewOrdersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewOrdersButton.Location = new System.Drawing.Point(535, 76);
            this.viewOrdersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewOrdersButton.Name = "viewOrdersButton";
            this.viewOrdersButton.Size = new System.Drawing.Size(251, 95);
            this.viewOrdersButton.TabIndex = 4;
            this.viewOrdersButton.Text = "View Orders";
            this.viewOrdersButton.UseVisualStyleBackColor = false;
            this.viewOrdersButton.Click += new System.EventHandler(this.viewOrdersButton_Click);
            // 
            // manageCategoriesButton
            // 
            this.manageCategoriesButton.BackColor = System.Drawing.Color.PeachPuff;
            this.manageCategoriesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCategoriesButton.Location = new System.Drawing.Point(535, 176);
            this.manageCategoriesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.manageCategoriesButton.Name = "manageCategoriesButton";
            this.manageCategoriesButton.Size = new System.Drawing.Size(251, 92);
            this.manageCategoriesButton.TabIndex = 5;
            this.manageCategoriesButton.Text = "Manage Categories";
            this.manageCategoriesButton.UseVisualStyleBackColor = false;
            this.manageCategoriesButton.Click += new System.EventHandler(this.manageCategoriesButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(20, 273);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 85);
            this.button1.TabIndex = 6;
            this.button1.Text = "Register New Staff";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.BackColor = System.Drawing.Color.LightGray;
            this.dashboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardButton.Location = new System.Drawing.Point(268, 178);
            this.dashboardButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(260, 91);
            this.dashboardButton.TabIndex = 7;
            this.dashboardButton.Text = "View Dashboard";
            this.dashboardButton.UseVisualStyleBackColor = false;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // manageCustomersButton
            // 
            this.manageCustomersButton.BackColor = System.Drawing.Color.LightGray;
            this.manageCustomersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCustomersButton.Location = new System.Drawing.Point(20, 177);
            this.manageCustomersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.manageCustomersButton.Name = "manageCustomersButton";
            this.manageCustomersButton.Size = new System.Drawing.Size(241, 92);
            this.manageCustomersButton.TabIndex = 6;
            this.manageCustomersButton.Text = "Manage Customers";
            this.manageCustomersButton.UseVisualStyleBackColor = false;
            this.manageCustomersButton.Click += new System.EventHandler(this.manageCustomersButton_Click);
            // 
            // paymentButton
            // 
            this.paymentButton.BackColor = System.Drawing.Color.PeachPuff;
            this.paymentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentButton.Location = new System.Drawing.Point(268, 275);
            this.paymentButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paymentButton.Name = "paymentButton";
            this.paymentButton.Size = new System.Drawing.Size(241, 90);
            this.paymentButton.TabIndex = 8;
            this.paymentButton.Text = "Payment";
            this.paymentButton.UseVisualStyleBackColor = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.paymentButton);
            this.Controls.Add(this.dashboardButton);
            this.Controls.Add(this.manageCustomersButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.manageCategoriesButton);
            this.Controls.Add(this.viewOrdersButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.productButton);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button productButton;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button viewOrdersButton;
        private System.Windows.Forms.Button manageCategoriesButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button manageCustomersButton;
        private System.Windows.Forms.Button paymentButton;
    }
}