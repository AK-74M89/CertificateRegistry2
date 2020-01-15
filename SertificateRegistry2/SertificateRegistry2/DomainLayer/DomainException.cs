using System;

namespace SertificateRegistry2.DomainLayer
{
    class DomainException: Exception
    {
        public DomainException(string Message)
            : base(Message)
        {
        }
    }
}