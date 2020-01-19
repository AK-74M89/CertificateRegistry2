using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Collections.Generic; 

namespace AccessPostgresConverter
{
    struct Certificate
    {
        public int ID;
        public string Name;
        public string Number;
        public string Begin;
        public string End;
        public string Agency;
    }

    class AccessConnector
    {
        private OleDbConnection AccessDBConnection = null;

        public AccessConnector(string DataFile)
        {
            string connectionString = @"provider=Microsoft.Jet.OLEDB.4.0; data source=" + DataFile;
            AccessDBConnection = new OleDbConnection(connectionString);            
        }

        public void Connect()
        {
            if (AccessDBConnection != null)
            {
                AccessDBConnection.Open();
            }
        }

        public void Disconnect()        
        {
            if (AccessDBConnection.State != ConnectionState.Closed)
            {
                AccessDBConnection.Close();
            }
        }

        public IList<Certificate> GetData()
        {
            OleDbCommand myOleDbCommand = AccessDBConnection.CreateCommand();
            myOleDbCommand.CommandText = "SELECT * FROM Certificates";

            IList<Certificate> Result = new List<Certificate>();
            Certificate CurrentCertificate = new Certificate();

            // Считываем данные  
            OleDbDataReader DataReader = myOleDbCommand.ExecuteReader();  
            while (DataReader.Read())  
            {
                CurrentCertificate.ID = Convert.ToInt32(DataReader[0]);
                CurrentCertificate.Name = Convert.ToString(DataReader[1]);
                CurrentCertificate.Number = Convert.ToString(DataReader[2]);
                CurrentCertificate.Begin = Convert.ToString(DataReader[3]);
                CurrentCertificate.End = Convert.ToString(DataReader[4]);
                CurrentCertificate.Agency = Convert.ToString(DataReader[5]);
                Result.Add(CurrentCertificate);
            }  
            DataReader.Close();

            return Result;
        }
    }
}