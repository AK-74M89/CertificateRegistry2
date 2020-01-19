using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace AccessPostgresConverter
{
    class CertificateGateway
    {       
        /// <summary>
        /// Добавить сертификат
        /// </summary>
        /// <param name="Name">название сертификата</param>
        /// <param name="Number">номер сертификата</param>
        /// <param name="Begin">дата выдачи</param>
        /// <param name="End">дата завершения</param>
        /// <param name="ID_Organization">идентификатор организации</param>
        /// <returns>идентификатор добавленного сертификата</returns>
        public int AddCertificate(string Name, string Number, DateTime Begin, DateTime End, int ID_Organization)
        {
            NpgsqlCommand Command = new NpgsqlCommand("certificate_add", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[0].NpgsqlDbType = NpgsqlDbType.Varchar;
            Command.Parameters[0].Value = Name;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[1].NpgsqlDbType = NpgsqlDbType.Varchar;
            Command.Parameters[1].Value = Number;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[2].NpgsqlDbType = NpgsqlDbType.Date;
            Command.Parameters[2].Value = Begin;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[3].NpgsqlDbType = NpgsqlDbType.Date;
            Command.Parameters[3].Value = End;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[4].NpgsqlDbType = NpgsqlDbType.Integer;
            Command.Parameters[4].Value = ID_Organization;

            Object Result = Command.ExecuteScalar();
            return Convert.ToInt32(Result);
        }

        /// <summary>
        /// Изменить сертификат
        /// </summary>
        /// <param name="ID_Certificate">идентификатор сертификата</param>
        /// <param name="Name">название сертификата</param>
        /// <param name="Number">номер сертификата</param>
        /// <param name="Begin">дата выдачи</param>
        /// <param name="End">дата завершения</param>
        /// <param name="ID_Organization">идентификатор организации</param>
        /// <returns>идентификатор изменённого сертификата</returns>
        public int EditCertificate(int ID_Certificate, string Name, string Number, DateTime Begin, DateTime End, int ID_Organization)
        {
            NpgsqlCommand Command = new NpgsqlCommand("certificate_edit", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[0].NpgsqlDbType = NpgsqlDbType.Integer;
            Command.Parameters[0].Value = ID_Certificate;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[1].NpgsqlDbType = NpgsqlDbType.Varchar;
            Command.Parameters[1].Value = Name;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[2].NpgsqlDbType = NpgsqlDbType.Varchar;
            Command.Parameters[2].Value = Number;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[3].NpgsqlDbType = NpgsqlDbType.Date;
            Command.Parameters[3].Value = Begin;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[4].NpgsqlDbType = NpgsqlDbType.Date;
            Command.Parameters[4].Value = End;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[5].NpgsqlDbType = NpgsqlDbType.Integer;
            Command.Parameters[5].Value = ID_Organization;

            Object Result = Command.ExecuteScalar();
            return Convert.ToInt32(Result);
        }

        /// <summary>
        /// Удалить сертификат
        /// </summary>
        /// <param name="ID_Certificate">идентификатор сертификата</param>
        /// <returns>идентификатор удалённого сертификата</returns>
        public int DeleteCertificate(int ID_Certificate)
        {
            NpgsqlCommand Command = new NpgsqlCommand("certificate_delete", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[0].NpgsqlDbType = NpgsqlDbType.Integer;
            Command.Parameters[0].Value = ID_Certificate;

            Object Result = Command.ExecuteScalar();
            return Convert.ToInt32(Result);
        }

        /// <summary>
        /// Получить список сертификатов
        /// </summary>
        /// <returns>массив записей CertificatesListItem</returns>
        public IList<CertificatesListItem> GetCertificatesRegistry()
        {
            IList<CertificatesListItem> CertificatesRegistry = new List<CertificatesListItem>();

            object[] tempArray = new object[6];
            CertificatesListItem CurrentCertificateRecord;

            NpgsqlCommand Command = new NpgsqlCommand("certificate_get_registry", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;            

            NpgsqlDataReader dr = Command.ExecuteReader();

            while (dr.Read())
            {
                dr.GetValues(tempArray);

                CurrentCertificateRecord.ID_Certificate = Convert.ToInt32(tempArray[0]);
                CurrentCertificateRecord.Name = Convert.ToString(tempArray[1]);
                CurrentCertificateRecord.Number = Convert.ToString(tempArray[2]);
                CurrentCertificateRecord.Begin = Convert.ToDateTime(tempArray[3]);
                CurrentCertificateRecord.End = Convert.ToDateTime(tempArray[4]);
                CurrentCertificateRecord.Organization = Convert.ToString(tempArray[5]);

                CertificatesRegistry.Add(CurrentCertificateRecord);
            }

            dr.Close();

            return CertificatesRegistry;
        }
    }
}