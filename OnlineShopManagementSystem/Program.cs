using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace OnlineShopManagementSystem
{
    internal static class Program
    {
        public static string LoggedInUserPosition { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // --- START OF NEW CODE ---

            // Create a CultureInfo object for Bengali (Bangladesh).
            CultureInfo culture = new CultureInfo("bn-BD");

            // Set the culture for the current thread. This affects formatting for numbers, dates, and currency.
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // --- END OF NEW CODE ---


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
