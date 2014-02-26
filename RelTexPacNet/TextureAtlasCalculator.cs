using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RelTexPacNet
{
    public class TextureAtlasCalculator
    {
        private class Node
        {
            public string FileName;
            public int Width;
            public int Height;
            public int X;
            public int Y;
        }

        private Size Size;

        public TextureAtlasCalculator(Size size, int padding)
        {
            Size = size;         
        }


    }
}