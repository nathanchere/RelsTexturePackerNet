using System.Collections.Generic;
using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlas
    {
        public TextureAtlas()
        {
            MatteColor = Color.Transparent;
            Size = new Size(1024,1024);
            Nodes = new List<TextureAtlasNode>();
        }

        public Color MatteColor { get; set; }
        public Size Size { get; set; }
        public IEnumerable<TextureAtlasNode> Nodes { get; set; }
    }
}