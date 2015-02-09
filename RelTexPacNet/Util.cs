using System.Drawing;
using System.Linq;
using System.Security.Cryptography;

namespace RelTexPacNet
{
    public static class Util
    {
        public static int Area(this Size size)
        {
            return size.Height * size.Width;
        }

        public static int Area(this Rectangle rectangle)
        {
            return rectangle.Height * rectangle.Width;
        }

        public static Size Pad(this Size size)
        {
            return new Size(size.Width + 1, size.Height + 1);
        }

        //TODO: intersects, toRectangle, pad, unpad etc
        ////public static Rectangle ToRectangle(this Size size)
        ////{
        ////    return size.Height * size.Width;
        ////}
    }
}