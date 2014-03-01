﻿using System;
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