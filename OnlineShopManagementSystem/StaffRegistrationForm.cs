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
    public partial class StaffRegistrationForm : Form
    {
        public StaffRegistrationForm()
        {
            InitializeComponent();
        }

        private void staffNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void icNumTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(staffNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(passwordTextBox.Text) ||
                string.IsNullOrWhiteSpace(icNumTextBox.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();

                // --- START OF NEW LOGIC ---

                // Step 1: Generate a new random 7-digit ID and ensure it is unique.
                Random rand = new Random();
                int newStaffId = 0;
                bool isIdUnique = false;

                while (!isIdUnique)
                {
                    // Generate a random number between 1,000,000 and 9,999,999.
                    newStaffId = rand.Next(1000000, 10000000);

                    // Check if this ID already exists in the database.
                    string idCheckQuery = "SELECT COUNT(*) FROM Staff WHERE staffID = @id";
                    SqlCommand idCheckCmd = new SqlCommand(idCheckQuery, con);
                    idCheckCmd.Parameters.AddWithValue("@id", newStaffId);

                    if ((int)idCheckCmd.ExecuteScalar() == 0)
                    {
                        // If count is 0, the ID is unique and we can exit the loop.
                        isIdUnique = true;
                    }
                    // If the ID is not unique, the loop will run again to get a new number.
                }

                // --- END OF NEW LOGIC ---

                // Check if email or IC number already exists to prevent errors
                string checkQuery = "SELECT COUNT(*) FROM Staff WHERE email = @email OR icNum = @icNum";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                checkCmd.Parameters.AddWithValue("@icNum", icNumTextBox.Text);

                if ((int)checkCmd.ExecuteScalar() > 0)
                {
                    MessageBox.Show("A staff member with this email or IC number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If no duplicates, proceed with insertion, now including the new staffID.
                string insertQuery = "INSERT INTO Staff (staffID, staffName, password, email, position, status, icNum) VALUES (@id, @name, @pass, @email, 'Staff', 'Active', @icNum)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);

                // Add the new staffID parameter
                insertCmd.Parameters.AddWithValue("@id", newStaffId);
                insertCmd.Parameters.AddWithValue("@name", staffNameTextBox.Text);
                insertCmd.Parameters.AddWithValue("@pass", passwordTextBox.Text);
                insertCmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                insertCmd.Parameters.AddWithValue("@icNum", icNumTextBox.Text);

                insertCmd.ExecuteNonQuery();

                // Show the new ID in the success message.
                MessageBox.Show($"New staff member registered successfully!\n\nTheir Staff ID is: {newStaffId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
