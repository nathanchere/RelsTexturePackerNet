using System.Collections;
using System.Collections.Generic;
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

        public static Rectangle Normalize(this Rectangle rect)
        {
            var result = rect;

            if (result.Height < 0)
            {
                result.Y += result.Height;
                result.Height = -result.Height;
            }

            if (result.Width < 0)
            {
                result.X += result.Width;
                result.Width = -result.Width;
            }

            return result;
        }

        // Assumes no rectangles are overlapping beyond their edges
        public static bool IsSurroundedBy(this Point point, Rectangle[] usedSpace)
        {
            // Cannot surround a point with only one edge
            if (usedSpace.Length < 2) return false;

            var rectsSharingCorner = usedSpace.Where(r => r.GetCorners().Contains(point)).ToArray();
            var rectsSharingEdge = usedSpace.Where(r => r.SharesEdge(point))
                .Where(r => !rectsSharingCorner.Contains(r))
                .ToArray();

            // Four rects sharing a corner = surrounded
            if (rectsSharingCorner.Length == 4) return true;

            // Two rects sharing a corner = one rect needs to share an edge to be surrounded
            if (rectsSharingCorner.Length == 2 && rectsSharingEdge.Length == 1) return true;

            // No rects sharing a corner = two rects needs to share an edge to be surrounded
            if (rectsSharingCorner.Length == 0 && rectsSharingEdge.Length == 2) return true;

            //// One or three rects sharing a corner = at least one diagonal exposed
            //if (rectsSharingCorner.Length == 3) return false;
            //if (rectsSharingCorner.Length == 1) return false;
            return false;
        }

        public static bool IsSurroundedBy(this Point point, Rectangle[] usedSpace, Rectangle boundary)
        {
            if (!boundary.Contains(point)) return false;

            var usedSpaceWithBoundaries = new List<Rectangle> { 
                new Rectangle(boundary.Left-1,boundary.Top, 1,boundary.Height),
                new Rectangle(boundary.Right,boundary.Top, 1,boundary.Height),
                new Rectangle(boundary.Top-1,boundary.Left-1, 1,boundary.Width+2),
                new Rectangle(boundary.Bottom,boundary.Left-1, 1,boundary.Width+2),                
            };
            usedSpaceWithBoundaries.AddRange(usedSpace);

            return point.IsSurroundedBy(usedSpaceWithBoundaries.ToArray());
        }
    }
}