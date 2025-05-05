using CoffeeSell.DataAccessLayer;
using Microsoft.VisualBasic.Logging;
namespace CoffeeSell
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            DAO dao = new DAO();
            if (!dao.TestConnection())
                MessageBox.Show("Database hiện đang tắt hoặc cúp điện");
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}