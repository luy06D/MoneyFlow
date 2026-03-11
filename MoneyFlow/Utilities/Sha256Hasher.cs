using System.Security.Cryptography;
using System.Text;

namespace MoneyFlow.Utilities
{
    public class Sha256Hasher
    {
        public static string ComputeHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder stringBuilder = new StringBuilder();
                for(int i = 0; i <hashBytes.Length; i++) stringBuilder.Append(hashBytes[i].ToString("x2"));

                return stringBuilder.ToString();    
            }
        }

    }
}
