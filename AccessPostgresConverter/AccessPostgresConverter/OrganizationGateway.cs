using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace AccessPostgresConverter
{
    class OrganizationGateway
    {
        /// <summary>
        /// Добавить организацию
        /// </summary>
        /// <param name="Name">название организации</param>
        /// <returns>идентификатор добавленной организации</returns>
        public int AddOrganization(string Name)
        {
            NpgsqlCommand Command = new NpgsqlCommand("organization_add", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[0].NpgsqlDbType = NpgsqlDbType.Varchar;
            Command.Parameters[0].Value = Name;            

            Object Result = Command.ExecuteScalar();
            return Convert.ToInt32(Result);
        }
    
        /// <summary>
        /// Удалить организацию
        /// </summary>
        /// <param name="ID_Organization">идентификатор организации</param>
        /// <returns>идентификатор удалённой организации</returns>
        public int DeleteOrganization(int ID_Organization)
        {
            NpgsqlCommand Command = new NpgsqlCommand("organization_delete", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[0].NpgsqlDbType = NpgsqlDbType.Integer;
            Command.Parameters[0].Value = ID_Organization;

            Object Result = Command.ExecuteScalar();
            return Convert.ToInt32(Result);
        }
        
        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns>массив записей OrganizationListItem</returns>
        public IList<OrganizationListItem> GetOrganizationList()
        {
            IList<OrganizationListItem> OrganizationList = new List<OrganizationListItem>();

            object[] tempArray = new object[2];
            OrganizationListItem CurrentOrganizationRecord;

            NpgsqlCommand Command = new NpgsqlCommand("organization_get_all", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            NpgsqlDataReader dr = Command.ExecuteReader();

            while (dr.Read())
            {
                dr.GetValues(tempArray);

                CurrentOrganizationRecord.ID_Organization = Convert.ToInt32(tempArray[0]);
                CurrentOrganizationRecord.Name = Convert.ToString(tempArray[1]);                

                OrganizationList.Add(CurrentOrganizationRecord);
            }

            dr.Close();

            return OrganizationList;
        }

        /// <summary>
        /// Определяет, существует ли организация с указанным названием
        /// </summary>
        /// <param name="Name">Название организации</param>
        /// <returns>bool</returns>
        public Boolean Exists(string Name)
        {
            NpgsqlCommand Command = new NpgsqlCommand("organization_exists", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[0].NpgsqlDbType = NpgsqlDbType.Varchar;
            Command.Parameters[0].Value = Name;

            Object Result = Command.ExecuteScalar();
            return Convert.ToBoolean(Result);
        }

        /// <summary>
        /// Получение идентификатора организации по названию
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int GetID(string Name)
        {
            NpgsqlCommand Command = new NpgsqlCommand("organization_get_id", DBConnectionHandler.DBConnection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new NpgsqlParameter());
            Command.Parameters[0].NpgsqlDbType = NpgsqlDbType.Varchar;
            Command.Parameters[0].Value = Name;

            Object Result = Command.ExecuteScalar();
            return Convert.ToInt32(Result);
        }
    }
}
