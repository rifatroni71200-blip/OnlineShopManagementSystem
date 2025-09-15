using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShopManagementSystem
{
    public partial class OrderForm : Form
    {
        
        // --- START OF ADDED CODE ---

        // This list will act as our temporary "shopping cart". It holds a list of OrderItem objects.
        private List<OrderItem> shoppingCart = new List<OrderItem>();
        // This helps link our list to the DataGridView.
        private BindingSource cartBindingSource = new BindingSource();

        // This is the helper class, now safely defined *inside* the OrderForm class.
        public class OrderItem
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal LineTotal => Quantity * UnitPrice; // A calculated property
        }

        private void LoadCustomers()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT custID, custName FROM Customer WHERE status = 'Active'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                customerComboBox.DataSource = dt;
                customerComboBox.DisplayMember = "custName";
                customerComboBox.ValueMember = "custID";
                customerComboBox.SelectedIndex = -1; // Start with no customer selected
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                // This query selects all the necessary columns, including 'stockQty' for our validation.
                string query = "SELECT productID, productName, unitPrice, stockQty FROM Product WHERE status = 'Available' AND stockQty > 0";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                productComboBox.DataSource = dt;
                productComboBox.DisplayMember = "productName";
                productComboBox.ValueMember = "productID";
                productComboBox.SelectedIndex = -1;
            }
        }

        // A helper method to calculate and display the total price.
        private void UpdateTotal()
        {
            decimal total = 0;
            foreach (var item in shoppingCart)
            {
                total += item.LineTotal;
            }
            totalTextBox.Text = total.ToString("C"); // The "C" formats the number as currency (e.g., $123.45)
        }
        private void ClearCart()
        {
            shoppingCart.Clear();
            cartBindingSource.ResetBindings(false);
            UpdateTotal();
        }

        // A helper method to clear the form for a new order.
        private void ClearOrderForm()
        {
            customerComboBox.SelectedIndex = -1;
            productComboBox.SelectedIndex = -1;
            quantityNumericUpDown.Value = 1;
            shoppingCart.Clear();
            cartBindingSource.ResetBindings(false);
            totalTextBox.Text = "";
        }

        // --- END OF ADDED CODE ---


        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            // Populate the dropdowns with data from the database.
            LoadCustomers();
            LoadProducts();

            // Connect our shoppingCart list to the DataGridView.
            cartBindingSource.DataSource = shoppingCart;
            orderItemsDataGridView.DataSource = cartBindingSource;

            // Optional: Make the grid's column headers look nicer.
            orderItemsDataGridView.Columns["ProductName"].HeaderText = "Product";
            orderItemsDataGridView.Columns["Quantity"].HeaderText = "Qty";
            orderItemsDataGridView.Columns["UnitPrice"].HeaderText = "Price";
            orderItemsDataGridView.Columns["LineTotal"].HeaderText = "Total";
            // It's good practice to hide the ID column from the user.
            orderItemsDataGridView.Columns["ProductId"].Visible = false;
        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            if (productComboBox.SelectedValue == null || quantityNumericUpDown.Value <= 0)
            {
                MessageBox.Show("Please select a product and a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView selectedProductRow = (DataRowView)productComboBox.SelectedItem;
            int productId = Convert.ToInt32(selectedProductRow["productID"]);
            string productName = selectedProductRow["productName"].ToString();
            decimal unitPrice = Convert.ToDecimal(selectedProductRow["unitPrice"]);
            int quantityToAdd = (int)quantityNumericUpDown.Value;
            int availableStock = Convert.ToInt32(selectedProductRow["stockQty"]);

            // --- START OF NEW, SMARTER CART LOGIC ---

            // Step 1: Check if this product already exists in the cart.
            OrderItem existingItem = null;
            foreach (var item in shoppingCart)
            {
                if (item.ProductId == productId)
                {
                    existingItem = item;
                    break;
                }
            }

            // Step 2: Perform stock validation.
            int quantityInCart = (existingItem != null) ? existingItem.Quantity : 0;
            if ((quantityToAdd + quantityInCart) > availableStock)
            {
                MessageBox.Show($"Cannot add {quantityToAdd} item(s). You are trying to order more than the available stock.\n\n" +
                                $"Available Stock: {availableStock}\n" +
                                $"Already in Cart: {quantityInCart}",
                                "Stock Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 3: Add or Update the item in the cart.
            if (existingItem != null)
            {
                // If the item exists, just increase its quantity.
                existingItem.Quantity += quantityToAdd;
            }
            else
            {
                // If it's a new item, add it to the cart list.
                shoppingCart.Add(new OrderItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Quantity = quantityToAdd,
                    UnitPrice = unitPrice
                });
            }

            // --- END OF NEW LOGIC ---

            // Refresh the grid and update the total price.
            cartBindingSource.ResetBindings(false);
            UpdateTotal();
        }

        private void placeOrderButton_Click(object sender, EventArgs e)
        {
            if (customerComboBox.SelectedValue == null || shoppingCart.Count == 0)
            {
                MessageBox.Show("Please select a customer and add items to the cart.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = DBConnection.GetConnection();
            SqlTransaction transaction = null;

            try
            {
                con.Open();
                transaction = con.BeginTransaction();

                string orderQuery = "INSERT INTO [Order] (custID, addressID, orderStatus) OUTPUT INSERTED.orderID VALUES (@custID, (SELECT TOP 1 addressID FROM Address WHERE custID = @custID AND status = 'Active'), 'Pending');";
                SqlCommand orderCmd = new SqlCommand(orderQuery, con, transaction);
                orderCmd.Parameters.AddWithValue("@custID", customerComboBox.SelectedValue);
                int orderId = (int)orderCmd.ExecuteScalar();

                // Loop through each item in the cart to process it
                foreach (var item in shoppingCart)
                {
                    // --- START OF NEW, SAFER STOCK UPDATE LOGIC ---

                    // Step 1: Modify the UPDATE query to include a stock check in the WHERE clause.
                    // This command will only update the row if the productID matches AND the stock is sufficient.
                    string stockQuery = "UPDATE Product SET stockQty = stockQty - @qty WHERE productID = @prodID AND stockQty >= @qty";
                    SqlCommand stockCmd = new SqlCommand(stockQuery, con, transaction);
                    stockCmd.Parameters.AddWithValue("@qty", item.Quantity);
                    stockCmd.Parameters.AddWithValue("@prodID", item.ProductId);

                    // Step 2: Execute the command and check how many rows were affected.
                    int rowsAffected = stockCmd.ExecuteNonQuery();

                    // Step 3: If rowsAffected is 0, it means the stock was insufficient.
                    if (rowsAffected == 0)
                    {
                        // The update failed because there wasn't enough stock. We must stop everything.
                        throw new Exception($"Not enough stock for product: {item.ProductName}. Order cancelled.");
                    }

                    // --- END OF NEW LOGIC ---


                    // If the stock update was successful, proceed to insert the order item.
                    string itemQuery = "INSERT INTO OrderItem (orderID, productID, productQty, price) VALUES (@orderID, @prodID, @qty, @price);";
                    SqlCommand itemCmd = new SqlCommand(itemQuery, con, transaction);
                    itemCmd.Parameters.AddWithValue("@orderID", orderId);
                    itemCmd.Parameters.AddWithValue("@prodID", item.ProductId);
                    itemCmd.Parameters.AddWithValue("@qty", item.Quantity);
                    itemCmd.Parameters.AddWithValue("@price", item.UnitPrice);
                    itemCmd.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show($"Order #{orderId} has been placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearOrderForm();
                LoadProducts();
            }
            catch (Exception ex)
            {
                // If any error occurs (including our custom stock error), roll back everything.
                transaction?.Rollback();
                MessageBox.Show("Failed to place the order. Error:\n" + ex.Message, "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }


        // --- These are empty event handlers created by the designer. ---
        // --- It is safe to leave them empty. ---
        private void label2_Click(object sender, EventArgs e) { }
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void quantityNumericUpDown_ValueChanged(object sender, EventArgs e) { }
        private void totalTextBox_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void orderItemsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) { }


        private void customerComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // If there's already something in the cart, ask for confirmation first.
            if (shoppingCart.Count > 0)
            {
                if (MessageBox.Show("Changing the customer will clear the current cart. Are you sure?", "Confirm Customer Change", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // If they click Yes, clear the cart.
                    ClearCart();
                }
                // If they click No, do nothing. The 'else' block has been removed.
            }
        }
    }
}