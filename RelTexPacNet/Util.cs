using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            return new[]{
                new Point(rectangle.Left, rectangle.Top), 
                new Point(rectangle.Right, rectangle.Top), 
                new Point(rectangle.Right, rectangle.Bottom), 
                new Point(rectangle.Left, rectangle.Bottom), 
            };
        }

        public static Line[] GetEdges(this Size size)
        {
            return new[]{
                new Line(0,0,size.Width,0), 
                new Line(0,size.Height,size.Width,size.Height), 
                new Line(0,0,size.Height,0), 
                new Line(0,size.Width,size.Height,size.Width),
            };
        }

        public static int DistanceBetween(this Point input, Point target)
        {
            var d = Math.Pow(Math.Abs(input.X - target.X), 2)
                  + Math.Pow(Math.Abs(input.Y - target.Y), 2);
            return (int) Math.Sqrt(d);
        }

        /// <remarks>
        /// Assumes all lines are fixed at 90 degree angles for simplicity
        /// </remarks>
        public static int GetOverlap(this Line input, Line target)
        {
            // Both aligned on X axis
            if (input.Start.X == input.End.X
                && target.Start.X == target.End.X
                && input.Start.X == target.Start.X)
            {
                var inputMinY = Math.Min(input.Start.Y, input.End.Y);
                var inputMaxY = Math.Max(input.Start.Y, input.End.Y);
                var targetMinY = Math.Min(target.Start.Y, target.End.Y);
                var targetMaxY = Math.Max(target.Start.Y, target.End.Y);

                var minY = Math.Max(inputMinY, targetMinY);
                var maxY = Math.Min(inputMaxY, targetMaxY);
                if (minY >= maxY) return 0;
                return maxY - minY;
            }

            // Both aligned on Y axis
            if (input.Start.Y == input.End.Y
                && target.Start.Y == target.End.Y
                && input.Start.Y == target.Start.Y)
            {
                var inputMinX = Math.Min(input.Start.X, input.End.X);
                var inputMaxX = Math.Max(input.Start.X, input.End.X);
                var targetMinX = Math.Min(target.Start.X, target.End.X);
                var targetMaxX = Math.Max(target.Start.X, target.End.X);

                var minX = Math.Max(inputMinX, targetMinX);
                var maxX = Math.Min(inputMaxX, targetMaxX);
                if (minX >= maxX) return 0;
                return maxX - minX;
            }

            return 0;
        }

        public static Line[] GetEdges(this Rectangle rectangle)
        {
            return new[] {
                new Line(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top),
                new Line(rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Bottom),
                new Line(rectangle.Top, rectangle.Left, rectangle.Bottom, rectangle.Left),
                new Line(rectangle.Top, rectangle.Right, rectangle.Bottom, rectangle.Right),
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

        public static bool Intersects(this Point point, Line line)
        {
            if (point.Y == line.Start.Y && point.Y == line.End.Y)
            {
                var leftmost = Math.Min(line.Start.X, line.End.X);
                var rightmost = Math.Max(line.Start.X, line.End.X);
                return point.X >= leftmost && point.X <= rightmost;
            }

            if (point.X == line.Start.X && point.X == line.End.X)
            {
                var topmost = Math.Min(line.Start.Y, line.End.Y);
                var bottommost = Math.Max(line.Start.Y, line.End.Y);
                return point.Y >= topmost && point.Y <= bottommost;
            }

            return false;
        }

        public static bool IsEntirelyContainedBy(this Rectangle rect, Rectangle target)
        {
            return rect.Left < target.Left || rect.Right > target.Right || rect.Top < target.Top || rect.Bottom > target.Bottom;
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