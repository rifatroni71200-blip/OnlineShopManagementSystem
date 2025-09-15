using System.Data.SqlClient;

namespace OnlineShopManagementSystem
{
    public class DBConnection
    {
        private static readonly string connectionString = "Data Source=RONI\\SQLEXPRESS;Initial Catalog=OnlineShopDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}