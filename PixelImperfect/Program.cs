using System.Drawing;
using System.Text;

namespace PixelImperfect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bitmap orig = (Bitmap)Bitmap.FromFile(@"C:\Users\tekhe\Downloads\ctf\PixelImperfect1.bmp", true);
            Bitmap modified = (Bitmap)Bitmap.FromFile(@"C:\Users\tekhe\Downloads\ctf\PixelImperfect2.bmp", true);

            var letters = new List<byte>();

            int h = orig.Height;
            int w = orig.Width;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    var origPxl = orig.GetPixel(i, j);
                    var modPxl = modified.GetPixel(i, j);

                    if (origPxl.R != modPxl.R)
                    {
                        letters.Add(modPxl.R);
                        Console.Write($"{modPxl.R:x2} ");
                    }

                    if (origPxl.G != modPxl.G)
                    {
                        letters.Add(modPxl.G);
                        Console.Write($"{modPxl.G:x2} ");
                    }

                    if (origPxl.B != modPxl.B)
                    {
                        letters.Add(modPxl.B);
                        Console.Write($"{modPxl.B:x2} ");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(Encoding.UTF8.GetString(letters.ToArray())); //This is the flag!
        }
    }
}