using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OnlineShopManagementSystem
{
    public partial class ProductForm : Form
    {
        private int selectedProductId = 0;

        public ProductForm()
        {
            InitializeComponent();
        }

        // --- START: NEWLY POPULATED METHODS FOR SEARCH ---

        private void showAllButton_Click(object sender, EventArgs e)
        {
            // Call LoadProducts with no search term to show all products again.
            LoadProducts();
            // Also clear the search box.
            searchTextBox.Clear();
        }

        // --- END: NEWLY POPULATED METHODS FOR SEARCH ---


        // --- START: MODIFIED METHODS ---

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // This now calls the modified LoadProducts method without a parameter to show all products initially.
            LoadProducts();
            LoadCategories();
        }

        // This method is now modified to accept an optional 'searchTerm'.
        private void LoadProducts(string searchTerm = "")
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                // Start with the base query.
                string query = @"
                    SELECT p.productID, p.productName, p.productDesc, p.unitPrice, p.stockQty, 
       c.categoryID, c.name as categoryName 
FROM Product p 
JOIN Category c ON p.categoryID = c.categoryID;


                // If the searchTerm is not empty, add a WHERE clause to filter.
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query += " WHERE p.productName LIKE @searchTerm";
                }

                SqlCommand cmd = new SqlCommand(query, con);

                // Only add the parameter if we are actually searching.
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                productsDataGridView.DataSource = dt;
            }
        }

        // --- END: MODIFIED METHODS ---


        // --- ALL YOUR EXISTING METHODS (Unchanged) ---

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productNameTextBox.Text))
            {
                MessageBox.Show("Product Name is required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (categoryComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO Product
                         (productName, productDesc, unitPrice, stockQty, categoryID)
                         VALUES (@name, @desc, @price, @qty, @catID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", productNameTextBox.Text);
                cmd.Parameters.AddWithValue("@desc", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", decimal.Parse(unitPriceTextBox.Text));
                cmd.Parameters.AddWithValue("@qty", int.Parse(stockQuantityTextBox.Text));
                cmd.Parameters.AddWithValue("@catID", categoryComboBox.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully!");
                LoadProducts();
                ClearForm();
            }
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select a product to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "UPDATE Product SET productName=@name, productDesc=@desc, unitPrice=@price, stockQty=@qty, categoryID=@catID WHERE productID=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", selectedProductId);
                cmd.Parameters.AddWithValue("@name", productNameTextBox.Text);
                cmd.Parameters.AddWithValue("@desc", descriptionTextBox.Text);
                cmd.Parameters.AddWithValue("@price", decimal.Parse(unitPriceTextBox.Text));
                cmd.Parameters.AddWithValue("@qty", int.Parse(stockQuantityTextBox.Text));
                cmd.Parameters.AddWithValue("@catID", categoryComboBox.SelectedValue);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product updated successfully!");
                LoadProducts();
                ClearForm();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select a product to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Product WHERE productID = @id", con);
                    cmd.Parameters.AddWithValue("@id", selectedProductId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted successfully!");
                    LoadProducts();
                    ClearForm();
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LoadCategories()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT categoryID, name FROM Category", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                categoryComboBox.DataSource = dt;
                categoryComboBox.DisplayMember = "name";
                categoryComboBox.ValueMember = "categoryID";
                categoryComboBox.SelectedIndex = -1;
            }
        }

        private void ClearForm()
        {
            productNameTextBox.Clear();
            descriptionTextBox.Clear();
            unitPriceTextBox.Clear();
            stockQuantityTextBox.Clear();
            categoryComboBox.SelectedIndex = -1;
            selectedProductId = 0;
            productsDataGridView.ClearSelection();
        }

        private void productsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !productsDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = productsDataGridView.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["productID"].Value);
                productNameTextBox.Text = row.Cells["productName"].Value.ToString();
                descriptionTextBox.Text = row.Cells["productDesc"].Value.ToString();
                unitPriceTextBox.Text = row.Cells["unitPrice"].Value.ToString();
                stockQuantityTextBox.Text = row.Cells["stockQty"].Value.ToString();
                categoryComboBox.SelectedValue = row.Cells["categoryID"].Value;

            }
        }

        // --- EMPTY EVENT HANDLERS (safe to leave empty) ---

        private void descriptionTextBox_TextChanged(object sender, EventArgs e) 
        { 
        
        }
        private void unitPriceTextBox_TextChanged(object sender, EventArgs e) 
        { 
        
        }
        private void button4_Click(object sender, EventArgs e) 
        { 
        
        }
        private void button1_Click(object sender, EventArgs e) 
        { 
        
        }
        private void label5_Click(object sender, EventArgs e) 
        { 
        
        }
        private void productsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
        
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
             LoadProducts(searchTextBox.Text);
        }
    }
}