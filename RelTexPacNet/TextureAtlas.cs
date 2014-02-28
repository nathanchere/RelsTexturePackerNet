using System.Collections.Generic;
using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlas
    {
        public Color MatteColor { get; set; }
        public Size Size { get; set; }
        public IEnumerable<TextureAtlasNode> Nodes { get; set; }
    }
}