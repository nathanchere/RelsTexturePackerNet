using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace RelTexPacNet
{
    public class TextureAtlasCalculator : ITextureAtlasCalculator
    {
        public class Settings
        {
            public Size Size { get; set; }
            public int Padding { get; set; }
        }

        private Settings _settings;
        private Dictionary<string, TextureAtlasNode> _nodes;

        public TextureAtlasCalculator(Settings settings)
        {
            _settings = settings;
            _nodes = new Dictionary<string, TextureAtlasNode>();
        }

        public void Add(Image image, string reference)
        {
            if (image == null) throw new ArgumentNullException("Cannot add null images");
            if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException("reference cannot be empty");
            
            int maxLength = Math.Max(
                _settings.Size.Width - _settings.Padding * 2,
                _settings.Size.Height - _settings.Padding * 2
                );

            if(image.Width > maxLength)
                throw new ArgumentOutOfRangeException("Image width excees atlas working area");
            if (image.Height > maxLength)
                throw new ArgumentOutOfRangeException("Image height excees atlas working area");

            _nodes.Add(reference, new TextureAtlasNode
            {
                Texture = image,
                Reference = reference,
            } );

            // TODO: calculate X Y
        }

        public TextureAtlas Calculate()
        {
            if (!_nodes.Any()) throw new InvalidOperationException("No input textures provided");

            var texture = new Bitmap(_settings.Size.Width, _settings.Size.Height);
            var nodes = _nodes.Values.ToList();
            
            // work out where they all go

            return new TextureAtlas
            {
                Nodes = nodes,
                Size = _settings.Size,
            };
        }
    }
}