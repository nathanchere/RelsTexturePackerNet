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
            var texture = new Bitmap(_size.Width, _size.Height);
            var nodes = _nodes.Values.ToList();

            var g = Graphics.FromImage(texture);

            // Draw textures on appropriate places on bitmap
            nodes.ForEach(n => { 
                g.DrawImageUnscaled(n.Texture,n.X,n.Y);
            });

            return new TextureAtlas
            {
                Texture = texture,
                Nodes = nodes,
            };
        }
    }
}