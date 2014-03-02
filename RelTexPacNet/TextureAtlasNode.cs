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

        public Rectangle GetBounds()
        {
            return new Rectangle(X,Y,Texture.Width,Texture.Height);
        }
    }
}