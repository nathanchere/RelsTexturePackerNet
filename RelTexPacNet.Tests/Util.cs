using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RelTexPacNet
{
    public static class Util
    {
        //TODO: move to FerretLib?

        public static byte[] ShaHash(this Image image)
        {;
            var bytes = new byte[1];
            bytes = (byte[])(new ImageConverter()).ConvertTo(image, bytes.GetType());

            return (new SHA256Managed()).ComputeHash(bytes);
        }

        public static bool AreEqual(Image imageA, Image imageB)
        {
            if (imageA.Width != imageB.Width) return false;
            if (imageA.Height != imageB.Height) return false;

            var hashA = imageA.ShaHash();
            var hashB = imageA.ShaHash();

            return !hashA
                .Where((nextByte, index) => nextByte != hashB[index])
                .Any();
        }

        public static void Dump(this Bitmap bitmap, string path = @"C:\")
        {
            if (path.EndsWith(@"\"))
                path = Path.Combine(path, DateTime.Now.Ticks + ".png");

            bitmap.Save(path, ImageFormat.Png);
        }
    }
}
