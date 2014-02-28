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

    public interface ITextureAtlasCalculator
    {
        void Add(Image image, string reference);
        TextureAtlas Calculate();
    }

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

            var g = Graphics.FromImage(texture);
            g.Clear(Color.FromArgb(0,255,0,255));

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