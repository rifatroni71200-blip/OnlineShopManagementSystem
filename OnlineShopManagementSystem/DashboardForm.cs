using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// Note: Unused 'using' directives have been removed for cleanliness.
// 'using System.Data.SqlClient;' has been added.

namespace OnlineShopManagementSystem
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        // --- START OF ADDED HELPER METHODS ---

        // A reusable method to run a query that returns one single value.
        private object ExecuteScalarQuery(string query)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        private void LoadTotalRevenue()
        {
            string query = "SELECT SUM(oi.productQty * oi.price) FROM OrderItem oi";
            object result = ExecuteScalarQuery(query);
            if (result != null && result != DBNull.Value)
            {
                totalRevenueLabel.Text = Convert.ToDecimal(result).ToString("C");
            }
            else
            {
                totalRevenueLabel.Text = (0).ToString("C"); // Show ৳0.00 if there are no sales
            }
        }

        private void LoadTotalProducts()
        {
            string query = "SELECT SUM(stockQty) FROM Product";
            object result = ExecuteScalarQuery(query);
            totalProductsLabel.Text = result != null && result != DBNull.Value ? result.ToString() : "0";
        }

        private void LoadTotalOrders()
        {
            string query = "SELECT COUNT(*) FROM [Order]";
            object result = ExecuteScalarQuery(query);
            totalOrdersLabel.Text = result != null && result != DBNull.Value ? result.ToString() : "0";
        }

        private void LoadTopSellingProduct()
        {
            string query = @"
                SELECT TOP 1 p.productName
                FROM OrderItem oi
                JOIN Product p ON oi.productID = p.productID
                GROUP BY p.productName
                ORDER BY SUM(oi.productQty) DESC";
            object result = ExecuteScalarQuery(query);
            topProductLabel.Text = result != null ? result.ToString() : "N/A";
        }

        private void LoadTopCustomer()
        {
            string query = @"
                SELECT TOP 1 c.custName
                FROM [Order] o
                JOIN Customer c ON o.custID = c.custID
                JOIN OrderItem oi ON o.orderID = oi.orderID
                GROUP BY c.custName
                ORDER BY SUM(oi.productQty * oi.price) DESC";
            object result = ExecuteScalarQuery(query);
            topCustomerLabel.Text = result != null ? result.ToString() : "N/A";
        }

        // --- END OF ADDED HELPER METHODS ---

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            // Load all dashboard data when the form opens.
            LoadTotalRevenue();
            LoadTotalProducts();
            LoadTotalOrders();
            LoadTopSellingProduct();
            LoadTopCustomer();
        }

        // --- These are empty event handlers from the designer. ---
        // --- It is safe to leave them empty. ---
        private void label1_Click(object sender, EventArgs e) 
        {
            
        }
        private void label13_Click(object sender, EventArgs e) 
        {

        }
        private void label9_Click(object sender, EventArgs e) 
        { 

        }
        private void label7_Click(object sender, EventArgs e) 
        { 

        }
        private void label5_Click(object sender, EventArgs e) 
        { 

        }
        private void totalRevenueLabel_Click(object sender, EventArgs e) 
        {

        }
        private void totalProductsLabel_Click(object sender, EventArgs e) 
        { 

        }
        private void totalOrdersLabel_Click(object sender, EventArgs e) 
        { 

        }
        private void topProductLabel_Click(object sender, EventArgs e) 
        { 

        }
        private void topCustomerLabel_Click(object sender, EventArgs e) 
        { 

        }
    }
}