using System;
using System.Drawing;

namespace RelTexPacNet.Calculators
{
    /// <summary>
    /// Simplified based on assumption that line will always be flat along X or Y axis
    /// </summary>
    public struct Line
    {
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line(int startX, int startY, int endX, int endY)
        {
            Start = new Point(startX, startY);
            End = new Point(endX, endY);
        }

        public Point Start;
        public Point End;

        public int Length
        {
            get
            {
                if (Start.X == End.X) return Math.Abs(Start.Y - End.Y);
                if (Start.Y == End.Y) return Math.Abs(Start.X - End.X);
                throw new Exception("You're doing it wrong");
            }
        }
    }
}