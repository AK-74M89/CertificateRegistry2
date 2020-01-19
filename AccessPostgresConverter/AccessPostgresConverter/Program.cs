using System;
using System.Collections.Generic;

namespace AccessPostgresConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string AccessPath = "";
                Console.WriteLine("Введите путь к файлу базы данных Access");
                AccessPath = Console.ReadLine();
                AccessConnector AccessDBConnerctor = new AccessConnector(AccessPath);
                AccessDBConnerctor.Connect();
                IList<Certificate> CertificateList = AccessDBConnerctor.GetData();
                AccessDBConnerctor.Disconnect();

                OrganizationGateway Organization = new OrganizationGateway();
                DBConnectionHandler.Connect();
                for (int i = 0; i < CertificateList.Count; i++)
                {
                    if (!Organization.Exists(CertificateList[i].Agency))
                    {
                        Organization.AddOrganization(CertificateList[i].Agency);
                    }
                }

                int TransfersCount = 0;
                CertificateGateway Certifiate = new CertificateGateway();
                int CurrentOrganizationID;
                for (int i = 0; i < CertificateList.Count; i++)
                {
                    if (CertificateList[i].Name == String.Empty) continue;
                    Console.WriteLine(CertificateList[i].Name);
                    CurrentOrganizationID = Organization.GetID(CertificateList[i].Agency);
                    Certifiate.AddCertificate(CertificateList[i].Name,
                                              CertificateList[i].Number,
                                              Convert.ToDateTime(CertificateList[i].Begin),
                                              Convert.ToDateTime(CertificateList[i].End),
                                              CurrentOrganizationID);
                    TransfersCount++;
       
                }

                DBConnectionHandler.Disconnect();

                Console.WriteLine("Перенос информации завершён. Перенесено " + Convert.ToString(TransfersCount) + " записей.");
                Console.ReadKey(true);
            }
            catch (Exception Error)
            {
                Console.WriteLine("Невозможно перенести информацию: " + Error.Message);
            }

        }
    }
}