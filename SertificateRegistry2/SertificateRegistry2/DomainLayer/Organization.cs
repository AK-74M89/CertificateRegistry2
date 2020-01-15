using System.Collections.Generic;
using SertificateRegistry2.DataSourceLayer;

namespace SertificateRegistry2.DomainLayer
{
    class Organization
    {
        private OrganizationGateway Gateway;

        public Organization()
        {
            this.Gateway = new OrganizationGateway();
        }

        /// <summary>
        /// Добавить организацию
        /// </summary>
        /// <param name="Name">название организации</param>
        /// <returns>идентификатор добавленной организации</returns>
        public int AddOrganization(string Name)
        {
            if (!Checker.CheckRegularString(Name))
            {
                throw (new DomainException("Длина имени должна быть менее 255 символов"));
            }
            else
            {
                return this.Gateway.AddOrganization(Name);
            }
        }

        /// <summary>
        /// Удалить организацию
        /// </summary>
        /// <param name="ID_Organization">идентификатор организации</param>
        /// <returns>идентификатор удалённой организации</returns>
        public int DeleteOrganization(int ID_Organization)
        {
            return this.Gateway.DeleteOrganization(ID_Organization);
        }

        /// <summary>
        /// Получить список организаций
        /// </summary>
        /// <returns>массив записей OrganizationListItem</returns>
        public IList<OrganizationListItem> GetOrganizationList()
        {
            return this.Gateway.GetOrganizationList();
        }       
    }
}
