using System.Collections.Generic;
using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlas
    {
        public class Node
        {
            public string Reference;
            public int Width;
            public int Height;
            public int X;
            public int Y;
        }
        
        public IEnumerable<Node> Nodes { get; set; }

        public Image Texture { get; set; }

        //TODO: report method used, free space stats etc
    }
}