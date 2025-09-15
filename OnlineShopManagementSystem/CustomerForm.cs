using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

// Note: Unused 'using' directives have been removed for cleanliness.
// 'using System.Data.SqlClient;' has been added.

namespace OnlineShopManagementSystem
{
    public partial class CustomerForm : Form
    {
        // --- START OF ADDED CODE ---

        // Memory variables to hold the selected customer's and their address's ID
        private int selectedCustomerId = 0;
        private int selectedAddressId = 0;

        // Helper method to load or refresh the customer data in the grid
        private void LoadCustomers()
        {
            using (SqlConnection con = DBConnection.GetConnection())
            {
                // This query joins the Customer and Address tables to show all info in one grid
                string query = @"
                    SELECT 
                        c.custID, c.custName, c.email, c.phoneNum, a.addressID, a.street, a.city, a.state, a.postcode, a.country
                    FROM 
                        Customer c
                    LEFT JOIN 
                        Address a ON c.custID = a.custID AND a.status = 'Active'";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                customersDataGridView.DataSource = dt;
            }
        }

        // Helper method to clear all input fields and reset selections
        private void ClearForm()
        {
            customerNameTextBox.Clear();
            emailTextBox.Clear();
            phoneTextBox.Clear();
            passwordTextBox.Clear();
            streetTextBox.Clear();
            cityTextBox.Clear();
            stateTextBox.Clear();
            postcodeTextBox.Clear();
            countryTextBox.Clear();
            selectedCustomerId = 0;
            selectedAddressId = 0;
            customersDataGridView.ClearSelection();
        }

        // This is the correct event handler for when a user clicks a cell to select a row.
        // You will need to connect this in the designer.
        private void customersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !customersDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = customersDataGridView.Rows[e.RowIndex];

                selectedCustomerId = Convert.ToInt32(row.Cells["custID"].Value);
                selectedAddressId = row.Cells["addressID"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["addressID"].Value) : 0;

                customerNameTextBox.Text = row.Cells["custName"].Value.ToString();
                emailTextBox.Text = row.Cells["email"].Value.ToString();
                phoneTextBox.Text = row.Cells["phoneNum"].Value.ToString();
                streetTextBox.Text = row.Cells["street"].Value.ToString();
                cityTextBox.Text = row.Cells["city"].Value.ToString();
                stateTextBox.Text = row.Cells["state"].Value.ToString();
                postcodeTextBox.Text = row.Cells["postcode"].Value.ToString();
                countryTextBox.Text = row.Cells["country"].Value.ToString();

                passwordTextBox.Clear();
            }
        }

        // --- END OF ADDED CODE ---


        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            LoadCustomers();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            if (string.IsNullOrWhiteSpace(customerNameTextBox.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text) || string.IsNullOrWhiteSpace(passwordTextBox.Text) || string.IsNullOrWhiteSpace(streetTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields (Name, Email, Password, Street).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = DBConnection.GetConnection();
            SqlTransaction transaction = null;

            try
            {
                con.Open();
                transaction = con.BeginTransaction();

                string emailCheckQuery = "SELECT COUNT(*) FROM Customer WHERE email = @email";
                SqlCommand emailCheckCmd = new SqlCommand(emailCheckQuery, con, transaction);
                emailCheckCmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                if ((int)emailCheckCmd.ExecuteScalar() > 0)
                {
                    MessageBox.Show("A customer with this email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                    return;
                }

                Random rand = new Random();
                int newCustId = 0;
                bool isIdUnique = false;
                while (!isIdUnique)
                {
                    newCustId = rand.Next(1000000, 10000000);
                    string idCheckQuery = "SELECT COUNT(*) FROM Customer WHERE custID = @id";
                    SqlCommand idCheckCmd = new SqlCommand(idCheckQuery, con, transaction);
                    idCheckCmd.Parameters.AddWithValue("@id", newCustId);
                    if ((int)idCheckCmd.ExecuteScalar() == 0)
                    {
                        isIdUnique = true;
                    }
                }

                string customerQuery = "INSERT INTO Customer (custID, custName, password, email, phoneNum) VALUES (@id, @name, @pass, @email, @phone)";
                SqlCommand customerCmd = new SqlCommand(customerQuery, con, transaction);
                customerCmd.Parameters.AddWithValue("@id", newCustId);
                customerCmd.Parameters.AddWithValue("@name", customerNameTextBox.Text);
                customerCmd.Parameters.AddWithValue("@pass", passwordTextBox.Text);
                customerCmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                customerCmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                customerCmd.ExecuteNonQuery();

                string addressQuery = "INSERT INTO Address (custID, street, city, state, postcode, country) VALUES (@id, @street, @city, @state, @postcode, @country)";
                SqlCommand addressCmd = new SqlCommand(addressQuery, con, transaction);
                addressCmd.Parameters.AddWithValue("@id", newCustId);
                addressCmd.Parameters.AddWithValue("@street", streetTextBox.Text);
                addressCmd.Parameters.AddWithValue("@city", cityTextBox.Text);
                addressCmd.Parameters.AddWithValue("@state", stateTextBox.Text);
                addressCmd.Parameters.AddWithValue("@postcode", postcodeTextBox.Text);
                addressCmd.Parameters.AddWithValue("@country", countryTextBox.Text);
                addressCmd.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show($"Customer added successfully!\nNew Customer ID: {newCustId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Failed to add customer. An error occurred.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadCustomers();
                ClearForm();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer from the list to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection con = DBConnection.GetConnection();
            SqlTransaction transaction = null;

            try
            {
                con.Open();
                transaction = con.BeginTransaction();

                string customerQuery = "UPDATE Customer SET custName = @name, email = @email, phoneNum = @phone" +
                                       (!string.IsNullOrWhiteSpace(passwordTextBox.Text) ? ", password = @pass" : "") +
                                       " WHERE custID = @id";
                SqlCommand customerCmd = new SqlCommand(customerQuery, con, transaction);
                customerCmd.Parameters.AddWithValue("@name", customerNameTextBox.Text);
                customerCmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                customerCmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                if (!string.IsNullOrWhiteSpace(passwordTextBox.Text))
                {
                    customerCmd.Parameters.AddWithValue("@pass", passwordTextBox.Text);
                }
                customerCmd.Parameters.AddWithValue("@id", selectedCustomerId);
                customerCmd.ExecuteNonQuery();

                string addressQuery = "UPDATE Address SET street = @street, city = @city, state = @state, postcode = @postcode, country = @country WHERE addressID = @addressId";
                SqlCommand addressCmd = new SqlCommand(addressQuery, con, transaction);
                addressCmd.Parameters.AddWithValue("@street", streetTextBox.Text);
                addressCmd.Parameters.AddWithValue("@city", cityTextBox.Text);
                addressCmd.Parameters.AddWithValue("@state", stateTextBox.Text);
                addressCmd.Parameters.AddWithValue("@postcode", postcodeTextBox.Text);
                addressCmd.Parameters.AddWithValue("@country", countryTextBox.Text);
                addressCmd.Parameters.AddWithValue("@addressId", selectedAddressId);
                addressCmd.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Failed to update customer. An error occurred.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                LoadCustomers();
                ClearForm();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // --- POPULATED METHOD ---
            if (selectedCustomerId == 0)
            {
                MessageBox.Show("Please select a customer from the list to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this customer? This will also delete their addresses.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = "DELETE FROM Customer WHERE custID = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                    con.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Failed to delete customer. They may have existing orders.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        LoadCustomers();
                        ClearForm();
                    }
                }
            }
        }

        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This event is less reliable for row selection.
            // Please connect the 'CellClick' event in the designer to 'customersDataGridView_CellClick' instead.
        }
    }
}