using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace RelTexPacNet.Calculators
{
    public class Corners : ITextureAtlasCalculator
    {
        private class Node
        {
            public int X,Y;            
            public int Width, Height;
            public string Reference;

            public int Score1; // unutilized edges - lower is better
            public int Score2; // utilized edges - higher is better
            public bool IsRotated;
        }

        private Settings _settings;
        private Dictionary<string, TextureAtlasNode> _inputNodes;

        public Corners(Settings settings)
        {
            _settings = settings;
            _inputNodes = new Dictionary<string, TextureAtlasNode>();
        }

        public void Add(Image image, string reference)
        {
            ValidateInput(image, reference);

            _inputNodes.Add(reference, new TextureAtlasNode
            {
                Texture = image,
                Reference = reference,
            } );
        }

        private void ValidateInput(Image image, string reference)
        {
            if (image == null) throw new ArgumentNullException("Cannot add null images");
            if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException("reference cannot be empty");

            int maxLength = Math.Max(
                _settings.Size.Width - _settings.Padding * 2,
                _settings.Size.Height - _settings.Padding * 2
                );

            if (image.Width > maxLength)
                throw new ArgumentOutOfRangeException("Image width excees atlas working area");
            if (image.Height > maxLength)
                throw new ArgumentOutOfRangeException("Image height excees atlas working area");
        }

        public TextureAtlas Calculate()
        {
            if (!_inputNodes.Any()) throw new InvalidOperationException("No input textures provided");
            
            var nodes = _inputNodes.Select(n=>new Node {
                X = 0, Y = 0,
                Score1 = 0, Score2 = 0,
                Width = n.Value.Texture.Width + _settings.Padding,
                Height = n.Value.Texture.Height + _settings.Padding,
                Reference = n.Key,
            }).ToList();

            var usedSpace = new List<Rectangle> { // default for boundaries
                new Rectangle(0,-1,_settings.Size.Width -_settings.Padding, 1), //top
                new Rectangle(0,_settings.Size.Height - _settings.Padding, _settings.Size.Width -_settings.Padding, 1), //bottom
                new Rectangle(-1,0,1,_settings.Size.Height - _settings.Padding), //left
                new Rectangle(_settings.Size.Width - _settings.Padding, 0, 1, _settings.Size.Height - _settings.Padding), //right
            };

            var result = new List<TextureAtlasNode>();   

            while (nodes.Any())
            {
                nodes.ForEach(n => Score(n, usedSpace));
                var best = nodes
                    .OrderBy(n => n.Score1) // edge waste
                    .ThenByDescending(n => n.Score2) // edge utilisation
                    .First();

                if (best.Score1 == int.MaxValue) throw new InvalidDataException("Insufficient free space available");

                usedSpace.Add(new Rectangle(best.X,best.Y,best.Width,best.Height));
                result.Add(new TextureAtlasNode
                {
                    X = best.X + _settings.Padding,
                    Y = best.Y + _settings.Padding,
                    Texture = _inputNodes[best.Reference].Texture,
                    Reference = best.Reference,
                    IsRotated = best.IsRotated,
                });
                nodes.Remove(best);
            }

            return new TextureAtlas
            {
                Nodes = result,
                Size = _settings.Size,
            };
        }        

        private void Score(Node node, List<Rectangle> placedNodes)
        {
            node.Score1 = int.MaxValue;
            node.Score2 = 0;

            foreach (var plcaedNode in placedNodes)
            {
                // 
            }

            if (_settings.IsRotationEnabled);
        }

    }
}