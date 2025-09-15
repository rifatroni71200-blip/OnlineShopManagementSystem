using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OnlineShopManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // --- START: Input Validation ---
            if (string.IsNullOrWhiteSpace(staffIdTextBox.Text))
            {
                MessageBox.Show("Please enter your Staff ID.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int staffId;
            // We must ensure the Staff ID is a valid number before using it in a query.
            if (!int.TryParse(staffIdTextBox.Text, out staffId))
            {
                MessageBox.Show("Staff ID must be a number.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- END: Input Validation ---


            SqlConnection con = DBConnection.GetConnection();
            try
            {
                con.Open();

                // The query now checks for a matching staffID and password.
                string query = "SELECT position FROM Staff WHERE staffID = @id AND password = @password AND status = 'Active'";
                SqlCommand cmd = new SqlCommand(query, con);

                // Safely add the parameters to the query.
                cmd.Parameters.AddWithValue("@id", staffId);
                cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);

                // Execute the query to get the user's position if they exist.
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // If a result is found, login is successful.
                    Program.LoggedInUserPosition = result.ToString(); // Store the user's role
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Show();
                }
                else
                {
                    // If the result is null, no matching user was found.
                    MessageBox.Show("Invalid Staff ID or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}