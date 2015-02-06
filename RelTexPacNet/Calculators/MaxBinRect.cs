using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace RelTexPacNet.Calculators
{
    public class MaxBinRect 
    {
        private class Node
        {
            public int X,Y;            
            public int Width, Height;
            public string Reference;

            public int Score1, Score2;
            public Rectangle FreeSpace;
            public bool IsRotated;
        }

        private CalculatorSettings _settings;
        private Dictionary<string, TextureAtlasNode> _inputNodes;

        public MaxBinRect(CalculatorSettings settings)
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
                new Rectangle(0,0,
                     _settings.Size.Width - _settings.Padding,
                     _settings.Size.Height - _settings.Padding
                     )
            };

            var totalSpace = (_settings.Size.Width - _settings.Padding*2) * (_settings.Size.Height - _settings.Padding*2);

            var nodes = _inputNodes.Select(n=>new Node {
                X = 0, Y = 0,
                Score1 = 0, Score2 = 0,
                Width = n.Value.Texture.Width + _settings.Padding,
                Height = n.Value.Texture.Height + _settings.Padding,
                Reference = n.Key,
            }).ToList();

            var result = new List<TextureAtlasNode>();

            while (nodes.Any())
            {
                nodes.ForEach(n=> Score(n, freeSpace));
                var best = nodes
                    .OrderBy(n => n.Score1)
                    .ThenBy(n => n.Score2)
                    .First();

                if(best.Score1 == int.MaxValue)
                    throw new InvalidDataException("Insufficient free space available");

                VerifySpace(totalSpace, result, freeSpace);
                PlaceNode(best, freeSpace);

                if (best.Reference.Contains("gif")) ;// Debugger.Break();
                VerifyNode(best, result);

                var newNode = new TextureAtlasNode
                {
                    X = best.X + _settings.Padding,
                    Y = best.Y + _settings.Padding,
                    Texture = _inputNodes[best.Reference].Texture,
                    Reference = best.Reference,
                    IsRotated = best.IsRotated,
                };

                //Sanity check - because output is not what expected
                result.ForEach(n => { 
                    if(newNode.GetBounds().IntersectsWith(n.GetBounds())) Debugger.Break();
                });

                result.Add(newNode);
                nodes.Remove(best);

                VerifySpace(totalSpace, result, freeSpace);
            }

            return new TextureAtlas
            {
                Nodes = result,
                Size = _settings.Size,
            };
        }        

        private void PlaceNode(Node node, List<Rectangle> freeSpace)
        {
            node.X = node.FreeSpace.X;
            node.Y = node.FreeSpace.Y;

            if (node.IsRotated)
            {
                var temp = node.Height;
                node.Height = node.Width;
                node.Width = temp;
            }            

            freeSpace.Remove(node.FreeSpace);

            if (node.FreeSpace.Width > node.Width)
            {
                freeSpace.Add(new Rectangle(
                    node.FreeSpace.X + node.Width,
                    node.FreeSpace.Y,
                    node.FreeSpace.Width - node.Width,
                    node.FreeSpace.Height));
            }
            
            if (node.FreeSpace.Height > node.Height)
            {
                freeSpace.Add(new Rectangle(
                    node.FreeSpace.X,
                    node.FreeSpace.Y + node.Height,
                    node.Width,
                    node.FreeSpace.Height - node.Height));
            }
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
                        node.IsRotated = false;
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
                        node.IsRotated = true;
                    }
                }
            });                    
        }

        #region Crap to be removed
        private void VerifyNode(Node best, List<TextureAtlasNode> result)
        {
            var bestRect = new Rectangle(best.X, best.Y, best.Width, best.Height);
            var clashes = new List<TextureAtlasNode>();
            result.ForEach(n =>
            {
                if (n.GetBounds().IntersectsWith(bestRect)) clashes.Add(n);
            });

            if (clashes.Any()) Debugger.Break();
        }

        private void VerifySpace(int totalSpace, List<TextureAtlasNode> nodes, List<Rectangle> freeSpace)
        {
            int nodeTotal = 0;
            int freeSpaceTotal = 0;
            nodes.ForEach(n => nodeTotal += (n.Texture.Height + _settings.Padding) * (n.Texture.Width + _settings.Padding));
            freeSpace.ForEach(n => freeSpaceTotal += (n.Height * n.Width));
            if (nodeTotal + freeSpaceTotal != totalSpace) Debugger.Break();
        }
        #endregion

    }
}