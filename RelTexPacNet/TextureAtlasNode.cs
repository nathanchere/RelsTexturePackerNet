using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlasNode
    {
        public string Reference;
        public Image Texture;
        public int X;
        public int Y;
        public bool IsRotated;

        public Size Size {
            get {
                return Texture.Size;
            }
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(X,Y,Texture.Width,Texture.Height);
        }

        public override string ToString()
        {
            if (Texture == null) return "{invalid}";
            return string.Format("'{0}' ({1},{2},{3},{4})", Reference, X, Y, Texture.Width, Texture.Height);
        }
    }
}