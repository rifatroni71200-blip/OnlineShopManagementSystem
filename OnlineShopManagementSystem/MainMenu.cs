using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShopManagementSystem
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Role-based visibility
            if (Program.LoggedInUserPosition != "Admin")
            {
                // Hide only the controls that should be admin-only
                manageCategoriesButton.Visible = false;
                button1.Visible = false;
                // If you also want to hide the payment option for non-admins,
                // uncomment the next line:
                // paymentButton.Visible = false;
            }

        }

        private void productButton_Click(object sender, EventArgs e)
        {
            new ProductForm().Show();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            new OrderForm().Show();
        }

        private void viewOrdersButton_Click(object sender, EventArgs e)
        {
            new ViewOrdersForm().Show();
        }

        private void manageCategoriesButton_Click(object sender, EventArgs e)
        {
            new CategoryForm().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new StaffRegistrationForm().ShowDialog();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            new DashboardForm().ShowDialog();
        }

        private void manageCustomersButton_Click(object sender, EventArgs e)
        {
            new CustomerForm().ShowDialog();
        }

        private void paymentButton_Click(object sender, EventArgs e)
        {
            // Open the Payment form
            new PaymentForm().ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}