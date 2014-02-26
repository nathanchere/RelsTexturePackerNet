using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RelTexPacNet
{

    // TODO: TAC exception types

    public class TextureAtlasCalculator
    {
        private Size _size;
        private int _padding;
        private Dictionary<string, TextureAtlasNode> _nodes;


        public TextureAtlasCalculator(Size size, int padding)
        {
            _size = size;
            _padding = padding;
            _nodes = new Dictionary<string, TextureAtlasNode>();
        }

        public void Add(Image image, string reference)
        {
            _nodes.Add(reference, new TextureAtlasNode
            {
                Texture = image,
                Reference = reference,
            } );

            // TODO: calculate X Y
        }

        public TextureAtlas Render()
        {
            var result = new TextureAtlas { 
                Texture = new Bitmap(_size.Width,_size.Height),
                Nodes = _nodes.Values,
            };



            return result;
        }
    }
}