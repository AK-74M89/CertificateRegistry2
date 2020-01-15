using System;

namespace SertificateRegistry2
{
    public struct CertificatesListItem
    {
        public int ID_Certificate;
        public string Name;
        public string Number;
        public DateTime Begin;
        public DateTime End;
        public string Organization;
    }

    public struct OrganizationListItem
    {
        public int ID_Organization;
        public string Name;
    }
}