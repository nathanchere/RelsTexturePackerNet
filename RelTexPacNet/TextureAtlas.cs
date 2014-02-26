using System.Collections.Generic;
using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlas
    {
        public IEnumerable<TextureAtlasNode> Nodes { get; set; }

        public Image Texture { get; set; }

        //TODO: report method used, free space stats etc
    }
}