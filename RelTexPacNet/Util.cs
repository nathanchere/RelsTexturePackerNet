using System.Collections;
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

        public static Size Pad(this Size size, int padding)
        {
            return new Size(size.Width + padding, size.Height + padding);
        }

        public static Size Pad(this Size size, int x, int y)
        {
            return new Size(size.Width + x, size.Height + y);
        }

        public static Rectangle ToRectangle(this Size size)
        {
            return new Rectangle(0, 0, size.Width, size.Height);
        }

        public static Point[] GetCorners(this Rectangle rectangle)
        {
            return new []{
                new Point(rectangle.Left, rectangle.Top), 
                new Point(rectangle.Right, rectangle.Top), 
                new Point(rectangle.Right, rectangle.Bottom), 
                new Point(rectangle.Left, rectangle.Bottom), 
            };
        }

        public static bool SharesEdge(this Rectangle rectangle, Point point)
        {
            if (point.Y < rectangle.Top && point.Y > rectangle.Bottom && point.X < rectangle.Left && point.X > rectangle.Right) return false;
            if (point.Y > rectangle.Top && point.Y < rectangle.Bottom && point.X > rectangle.Left && point.X < rectangle.Right) return false;

            if (point.Y == rectangle.Top || point.Y == rectangle.Bottom)
            {
                return point.X >= rectangle.Left && point.X <= rectangle.Right;
            }

            if (point.X == rectangle.Left|| point.X == rectangle.Right)
            {
                return point.Y >= rectangle.Top && point.Y <= rectangle.Bottom;
            }

            // should never reach here
            return false;
        }

        public static bool IsSurroundedBy(this Point point, Rectangle[] usedSpace)
        {
            if (!usedSpace.Any()) return false;

            return true;
            //var relevantSpace = usedSpace.Where(r => r.Contains(point) || r.SharesEdge(point));
//            if(relevantSpace.Any
        }
    }
}