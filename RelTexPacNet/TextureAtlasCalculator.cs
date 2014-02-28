using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace RelTexPacNet
{

    // TODO: TAC exception types

    public class TextureAtlasCalculator : ITextureAtlasCalculator
    {
        public Size Size { get; set; }
        public int Padding { get; set; }
        private Dictionary<string, TextureAtlasNode> _nodes;


        public TextureAtlasCalculator()
        {
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

        public TextureAtlas Calculate()
        {
            if (!_nodes.Any()) throw new InvalidDataException("No input textures provided");

            var texture = new Bitmap(Size.Width, Size.Height);
            var nodes = _nodes.Values.ToList();
            
            // work out where they all go

            return new TextureAtlas
            {
                Nodes = nodes,
                MatteColor = Color.Transparent, //TODO
                Size = new Size(), //TODO
            };
        }
    }
}