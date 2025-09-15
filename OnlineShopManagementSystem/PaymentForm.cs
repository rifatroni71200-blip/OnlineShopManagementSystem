using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShopManagementSystem
{
    public partial class PaymentForm : Form
    {
        private DataGridView ordersDataGridView;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private DataGridViewTextBoxColumn orderID;
        private DataGridViewTextBoxColumn custID;
        private DataGridViewTextBoxColumn orderStatus;
        private DataGridViewTextBoxColumn orderDate;
        private Label label1;
        private Label label2;
        private ComboBox paymentComboBox;
        private TextBox amountTextBox;
        private Label label3;
        private Button payButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            LoadPaymentMethods();
            LoadPendingOrders();
        }

        // Load payment methods into ComboBox
        private void LoadPaymentMethods()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT paymentMethodID, name FROM PaymentMethod", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                paymentComboBox.DataSource = dt;
                paymentComboBox.DisplayMember = "name";
                paymentComboBox.ValueMember = "paymentMethodID";
                paymentComboBox.SelectedIndex = -1;
            }
        }

        // Load pending orders into DataGridView
        private void LoadPendingOrders()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"
                    SELECT orderID, custID, orderStatus, orderDate
                    FROM [Order]
                    WHERE orderStatus = 'Pending'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ordersDataGridView.DataSource = dt;
            }
        }

        // When user clicks a row, select the order
        private void ordersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !ordersDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = ordersDataGridView.Rows[e.RowIndex];
                orderIDLabel.Text = row.Cells["orderID"].Value.ToString();
            }
        }

        // Pay button click
        private void payButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(amountTextBox.Text) || paymentComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter amount and select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal amount;
            if (!decimal.TryParse(amountTextBox.Text, out amount))
            {
                MessageBox.Show("Invalid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(orderIDLabel.Text))
            {
                MessageBox.Show("Please select an order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int orderID = int.Parse(orderIDLabel.Text);

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "INSERT INTO Payment (orderID, paymentMethodID, amountPaid) VALUES (@orderID, @paymentMethodID, @amount)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderID", orderID);
                cmd.Parameters.AddWithValue("@paymentMethodID", paymentComboBox.SelectedValue);
                cmd.Parameters.AddWithValue("@amount", amount);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment saved successfully!");

                // Clear selections and reload orders
                amountTextBox.Clear();
                paymentComboBox.SelectedIndex = -1;
                orderIDLabel.Text = "";
                LoadPendingOrders();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.orderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.paymentComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.payButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersDataGridView
            // 
            this.ordersDataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderID,
            this.custID,
            this.orderStatus,
            this.orderDate});
            this.ordersDataGridView.Location = new System.Drawing.Point(12, 61);
            this.ordersDataGridView.Name = "ordersDataGridView";
            this.ordersDataGridView.RowHeadersWidth = 51;
            this.ordersDataGridView.RowTemplate.Height = 24;
            this.ordersDataGridView.Size = new System.Drawing.Size(553, 286);
            this.ordersDataGridView.TabIndex = 0;
            this.ordersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // orderID
            // 
            this.orderID.HeaderText = "Order ID";
            this.orderID.MinimumWidth = 6;
            this.orderID.Name = "orderID";
            this.orderID.Width = 125;
            // 
            // custID
            // 
            this.custID.HeaderText = "Customer ID";
            this.custID.MinimumWidth = 6;
            this.custID.Name = "custID";
            this.custID.Width = 125;
            // 
            // orderStatus
            // 
            this.orderStatus.HeaderText = "Order Status";
            this.orderStatus.MinimumWidth = 6;
            this.orderStatus.Name = "orderStatus";
            this.orderStatus.Width = 125;
            // 
            // orderDate
            // 
            this.orderDate.HeaderText = "Date";
            this.orderDate.MinimumWidth = 6;
            this.orderDate.Name = "orderDate";
            this.orderDate.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Order ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(632, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Payment Method :";
            // 
            // paymentComboBox
            // 
            this.paymentComboBox.FormattingEnabled = true;
            this.paymentComboBox.Location = new System.Drawing.Point(825, 199);
            this.paymentComboBox.Name = "paymentComboBox";
            this.paymentComboBox.Size = new System.Drawing.Size(143, 24);
            this.paymentComboBox.TabIndex = 4;
            // 
            // amountTextBox
            // 
            this.amountTextBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.amountTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.amountTextBox.Location = new System.Drawing.Point(825, 159);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(122, 22);
            this.amountTextBox.TabIndex = 6;
            this.amountTextBox.Text = "Enter Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(687, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Amount Paid";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // payButton
            // 
            this.payButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.payButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.payButton.Location = new System.Drawing.Point(905, 257);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(75, 40);
            this.payButton.TabIndex = 8;
            this.payButton.Text = "Pay";
            this.payButton.UseVisualStyleBackColor = false;
            // 
            // PaymentForm
            // 
            this.ClientSize = new System.Drawing.Size(1048, 635);
            this.Controls.Add(this.payButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.paymentComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ordersDataGridView);
            this.Name = "PaymentForm";
            this.Load += new System.EventHandler(this.PaymentForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PaymentForm_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
