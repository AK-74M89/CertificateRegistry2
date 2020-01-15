namespace SertificateRegistry2.DomainLayer
{
    static class Checker
    {
        /// <summary>
        /// Проверка длины обычной строки. 
        /// Длина должна быть от 0 до 255
        /// </summary>
        /// <param name="RegularString">строка для проверки</param>
        /// <returns></returns>
        public static bool CheckRegularString(string RegularString)
        {
            return (RegularString.Length >= 0) && (RegularString.Length <= 255);
        }
    }
}
