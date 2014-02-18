using System.Collections.Generic;

namespace RelTexPacNet
{
    public class TextureAtlas
    {
        public class Node
        {
            public string FileName;
            public int Width;
            public int Height;
            public int X;
            public int Y;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public List<Node> Nodes { get; set; }

    }
}