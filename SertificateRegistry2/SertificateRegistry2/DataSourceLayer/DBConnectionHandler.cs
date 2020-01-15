using System.Data;
using Npgsql;
using CertificateRegistry2.Properties;

namespace SertificateRegistry2.DataSourceLayer
{
    static class DBConnectionHandler
    {
        public static NpgsqlConnection DBConnection = null;

        public static void Connect()
        {
            if (DBConnection == null)
            {
                NpgsqlConnectionStringBuilder ConnectionStringCreator = new NpgsqlConnectionStringBuilder();
                ConnectionStringCreator.Add("Server", "127.0.0.1");
                ConnectionStringCreator.Add("Port", "5432");
                ConnectionStringCreator.Add("User Id", Settings.Default.DBUserName);
                ConnectionStringCreator.Add("Password", Settings.Default.DBPassword);
                ConnectionStringCreator.Add("Database", "certificates");
                string ConnectionString = ConnectionStringCreator.ConnectionString;
                DBConnection = new NpgsqlConnection(ConnectionString);
            }
            if (DBConnection.State != ConnectionState.Open)
            {
                DBConnection.Open();
            }
        }

        public static void Disconnect()
        {
            if ((DBConnection != null) && (DBConnection.State != ConnectionState.Closed))
            {
                DBConnection.Close();
            }
        }
    }
}
