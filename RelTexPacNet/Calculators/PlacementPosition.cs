using System.Drawing;

namespace RelTexPacNet.Calculators
{
    public class PlacementPosition
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool IsRotated { get; private set; }

        public PlacementPosition(int x, int y, bool isRotated, int width, int height)
        {        
            X = x;
            Y = y;            
            Width = width;
            Height = height;
            IsRotated = isRotated;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X, Y, Width, Height);
        }
    }    
}