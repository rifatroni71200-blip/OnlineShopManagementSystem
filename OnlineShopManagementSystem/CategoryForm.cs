using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// Note: I have removed the unused 'using' directives like Linq, Tasks, etc. for cleanliness.
// I have also added the necessary 'using System.Data.SqlClient;'

namespace OnlineShopManagementSystem
{
    public partial class CategoryForm : Form
    {
        // --- START OF ADDED CODE ---

        // This variable will hold the ID of the category selected in the grid.
        private int selectedCategoryId = 0;

        // A helper method to load/reload all categories from the database.
        private void LoadCategories()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "SELECT categoryID AS 'Category ID', name AS 'Category Name' FROM Category";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                categoriesDataGridView.DataSource = dt;
            }
        }

        // --- END OF ADDED CODE ---


        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            LoadCategories();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Category name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();

                // --- START OF NEW LOGIC ---
                // Step 1: Check if the category already exists.
                string checkQuery = "SELECT COUNT(*) FROM Category WHERE name = @name";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@name", categoryName);

                // ExecuteScalar gets the single value (the count) from the query.
                int existingCount = (int)checkCmd.ExecuteScalar();

                if (existingCount > 0)
                {
                    // If the count is more than 0, the category exists. Show a message and stop.
                    MessageBox.Show("A category with this name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // --- END OF NEW LOGIC ---


                // If the code reaches here, it means the category is not a duplicate.
                // Step 2: Proceed with the original INSERT command.
                string insertQuery = "INSERT INTO Category (name) VALUES (@name)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@name", categoryName);

                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories(); // Refresh the grid
                categoryNameTextBox.Clear();
                selectedCategoryId = 0;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category from the list to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = DBConnection.GetConnection())
            {
                string query = "UPDATE Category SET name = @name WHERE categoryID = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", categoryNameTextBox.Text);
                cmd.Parameters.AddWithValue("@id", selectedCategoryId);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
                categoryNameTextBox.Clear();
                selectedCategoryId = 0;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            if (selectedCategoryId == 0)
            {
                MessageBox.Show("Please select a category from the list to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "DELETE FROM Category WHERE categoryID = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", selectedCategoryId);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Cannot delete this category because it is being used by existing products.\nError: " + ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        LoadCategories();
                        categoryNameTextBox.Clear();
                        selectedCategoryId = 0;
                    }
                }
            }
        }

        // IMPORTANT NOTE: For selecting rows, the 'CellClick' event is more reliable than 'CellContentClick'.
        // In your designer, please connect the 'CellClick' event of the grid to this method.
        private void categoriesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !categoriesDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = categoriesDataGridView.Rows[e.RowIndex];
                selectedCategoryId = Convert.ToInt32(row.Cells["Category ID"].Value);
                categoryNameTextBox.Text = row.Cells["Category Name"].Value.ToString();
            }
        }

        // --- These are empty event handlers created by the designer. ---
        // --- It is safe to leave them empty if you are not using them. ---

        private void categoryNameTextBox_TextChanged(object sender, EventArgs e)
        {
            // We can leave this empty.
        }

        private void categoriesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This event is often used if you have buttons inside your cells.
            // For simple row selection, CellClick is better, so we will use that instead.
        }
    }
}