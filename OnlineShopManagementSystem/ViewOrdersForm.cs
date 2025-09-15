using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// Note: I have removed the unused 'using' directives like Linq, Tasks, etc. for cleanliness.
// I have also added the necessary 'using System.Data.SqlClient;'

namespace OnlineShopManagementSystem
{
    public partial class ViewOrdersForm : Form
    {
        public ViewOrdersForm()
        {
            InitializeComponent();
        }

        // --- START OF ADDED HELPER METHODS ---

        private void LoadAllOrders()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                // This SQL query joins three tables and calculates a total amount for each order.
                string query = @"
                    SELECT 
                        o.orderID AS 'Order ID', 
                        c.custName AS 'Customer Name', 
                        o.orderDate AS 'Order Date', 
                        SUM(oi.productQty * oi.price) AS 'Total Amount'
                    FROM 
                        [Order] o
                    JOIN 
                        Customer c ON o.custID = c.custID
                    JOIN 
                        OrderItem oi ON o.orderID = oi.orderID
                    GROUP BY 
                        o.orderID, c.custName, o.orderDate
                    ORDER BY
                        o.orderID DESC"; // Show the most recent orders first.

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ordersDataGridView.DataSource = dt;

                // Format the currency column to look nice
                if (ordersDataGridView.Columns.Contains("Total Amount"))
                {
                    ordersDataGridView.Columns["Total Amount"].DefaultCellStyle.Format = "c";
                }
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                // This query gets the specific items for the selected orderID.
                string query = @"
                    SELECT 
                        p.productName AS 'Product', 
                        oi.productQty AS 'Quantity', 
                        oi.price AS 'Unit Price',
                        (oi.productQty * oi.price) AS 'Line Total'
                    FROM 
                        OrderItem oi
                    JOIN 
                        Product p ON oi.productID = p.productID
                    WHERE 
                        oi.orderID = @orderId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderId", orderId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                orderItemsDataGridView.DataSource = dt;

                // Format the currency columns
                if (orderItemsDataGridView.Columns.Contains("Unit Price"))
                {
                    orderItemsDataGridView.Columns["Unit Price"].DefaultCellStyle.Format = "c";
                }
                if (orderItemsDataGridView.Columns.Contains("Line Total"))
                {
                    orderItemsDataGridView.Columns["Line Total"].DefaultCellStyle.Format = "c";
                }
            }
        }

        // --- END OF ADDED HELPER METHODS ---


        private void ViewOrdersForm_Load(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            LoadAllOrders();
        }

        // IMPORTANT: We are using the 'CellClick' event, not 'CellContentClick'.
        // This event is more reliable for selecting rows.
        private void ordersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // --- POPULATED METHOD ---
            // Check if the click is on a valid row (not the header).
            if (e.RowIndex >= 0)
            {
                // Get the order ID from the clicked row.
                int selectedOrderId = Convert.ToInt32(ordersDataGridView.Rows[e.RowIndex].Cells["Order ID"].Value);

                // Call the method to load the details for this specific order.
                LoadOrderDetails(selectedOrderId);
            }
        }


        // --- These are empty event handlers created by the designer. ---
        // --- It is safe to leave them empty if you are not using them. ---

        private void ordersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This event is often used if you have buttons or links inside your cells.
            // For simple row selection, CellClick is better. We can leave this empty.
        }

        private void orderItemsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // We can leave this empty.
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // We can leave this empty.
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // We can leave this empty.
        }
    }
}