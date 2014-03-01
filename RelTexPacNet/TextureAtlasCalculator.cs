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
            public bool IsRotationEnabled { get; set; }

            // TODO: other options like pre-sort by longest side
        }

        private class Node
        {
            public int X,Y;            
            public int Width, Height;
            public string Reference;

            public int Score1, Score2;
            public Rectangle FreeSpace;
        }

        private Settings _settings;
        private Dictionary<string, TextureAtlasNode> _inputNodes;

        public TextureAtlasCalculator(Settings settings)
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
            
            var freeSpace = new List<Rectangle>{
                new Rectangle(Point.Empty,_settings.Size)
            };

            var nodes = _inputNodes.Select(n=>new Node {
                X = 0, Y = 0,
                Score1 = 0, Score2 = 0,
                Width = n.Value.Texture.Width,
                Height = n.Value.Texture.Height,
                Reference = n.Key,
            }).ToList();

            while (nodes.Any())
            {
                nodes.ForEach(n=> Score(n, freeSpace));
                var best = nodes
                    .OrderBy(n => n.Score1)
                    .ThenBy(n => n.Score2)
                    .First();

                PlaceNode(best, freeSpace);

                nodes.Remove(best);
            }

            return new TextureAtlas
            {
                //Nodes = nodes,
                Size = _settings.Size,
            };
        }

        private void PlaceNode(Node node, List<Rectangle> freeSpace)
        {
            
        }

        private void Score(Node node, List<Rectangle> freeSpace)
        {
            node.Score1 = int.MaxValue;
            node.Score2 = int.MaxValue;
            node.FreeSpace = Rectangle.Empty;

            freeSpace.ForEach(r => {
                if (r.Width >= node.Width && r.Height >= node.Height)
                {
                    int freeSpaceX = r.Width - node.Width;
                    int freeSpaceY = r.Height - node.Height;
                    int shortSideFit = Math.Min(freeSpaceX,freeSpaceY);
                    int longSideFit = Math.Max(freeSpaceX,freeSpaceY);

                    if (shortSideFit < node.Score1 || (shortSideFit == node.Score1 && longSideFit < node.Score2))
                    {
                        node.Score1 = shortSideFit;
                        node.Score2 = longSideFit;
                        node.FreeSpace = r;
                    }
                }

                if (_settings.IsRotationEnabled && r.Width >= node.Height && r.Height >= node.Width)
                {
                    int freeSpaceX = r.Width - node.Height;
                    int freeSpaceY = r.Height - node.Width;
                    int shortSideFit = Math.Min(freeSpaceX, freeSpaceY);
                    int longSideFit = Math.Max(freeSpaceX, freeSpaceY);

                    if (shortSideFit < node.Score1 || (shortSideFit == node.Score1 && longSideFit < node.Score2))
                    {
                        node.Score1 = shortSideFit;
                        node.Score2 = longSideFit;
                        node.FreeSpace = r;
                    }
                }
            });                    
        }
        
    }
}