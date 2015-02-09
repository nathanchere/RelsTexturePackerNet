using System.Drawing;
using System.Linq;
using System.Security.Cryptography;

namespace RelTexPacNet
{
    /// <summary>
    /// Generic bits which can maybe be moved into FerretLib?
    /// </summary>
    public static class Util
    {        
        public static int Area(this Size size)
        {
            return size.Height * size.Width;
        }


        //TODO: intersects, toRectangle, pad, unpad etc
        ////public static Rectangle ToRectangle(this Size size)
        ////{
        ////    return size.Height * size.Width;
        ////}
    }
}