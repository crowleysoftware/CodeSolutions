using System.Security.Cryptography;
using System.Text;

namespace AnEncryptedString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var encryptedString = Convert.FromBase64String("lIyB4FIcI2m+AbeBom5MDS18grzMcRYh82AHFNQ+8sQ=");

            var aesAlg = Aes.Create();
            aesAlg.Mode = CipherMode.ECB;
            aesAlg.IV = new byte[16]; //CipherMode.ECB doesn't use an IV but must provided all zeros

            aesAlg.Key = Encoding.UTF8.GetBytes("it's-capture-the-flag-gscc-2023!"); //key is solution to Welcome Challenge

            ICryptoTransform decryptor = aesAlg.CreateDecryptor();

            using (MemoryStream msDecrypt = new MemoryStream(encryptedString))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        var plaintext = srDecrypt.ReadToEnd();
                        Console.WriteLine(plaintext);
                    }
                }
            }
        }
    }
}