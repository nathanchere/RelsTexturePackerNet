using System.Collections.Generic;
using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlas
    {
        public TextureAtlas()
        {            
            Nodes = new List<TextureAtlasNode>();
        }

        public Size Size { get; set; }
        public IEnumerable<TextureAtlasNode> Nodes { get; set; }
    }
}