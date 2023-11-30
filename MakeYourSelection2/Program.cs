using System.Security.Cryptography;
using System.Text;

namespace MakeYourSelection2
{
    internal class Program
    {
        static void Main(string[] args)
        {                            
            string input = "123456111234AppleBananaBlueberryGrapeOrangeStrawberry133334123456BlueGreenOrangePurpleRedYellow1234561234BushrunnerTreeVine1234FallSpringSummerWinter";
         
            //compute sha256 hash of input
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            //convert hash to hex string
            var sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }
            var hexHash = sb.ToString();
            Console.WriteLine(hexHash);
        }
    }
}