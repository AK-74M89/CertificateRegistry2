using System;
using System.Windows.Forms;
using SertificateRegistry2.DataSourceLayer;
using SertificateRegistry2.PresentationLayer;

namespace SertificateRegistry2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBConnectionHandler.Connect();
            Application.Run(new CertificatesListViewForm());
            DBConnectionHandler.Disconnect();
        }
    }
}