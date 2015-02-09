using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace RelTexPacNet.Calculators
{
    public class FreeSpaceCalculator
    {
        
    }

    public class CornersPacker : ITextureAtlasCalculator
    {
        private class PlacementNode
        {
            public int X, Y;
            public int Width, Height;

            public int TotalEdgeLength
            {
                get { return 2 * (Width + Height); }
            }

            public bool IsRotated;

            public TextureAtlasNode SourceNode;

            public bool IsVaildPlacement = false;

            public int WastageScore; // unutilized edges - lower is better
            public int UtilizationScore; // utilized edges - higher is better

            public PlacementNode(TextureAtlasNode sourceNode)
            {
                SourceNode = sourceNode;
                X = 0;
                Y = 0;
                IsRotated = false;
                IsVaildPlacement = false;
                WastageScore = int.MaxValue;
                UtilizationScore = 0;
                Width = 0;
                Height = 0;
            }

            /// <summary>
            /// Persist the placement information to the actual texture atlas node
            /// </summary>
            public void PlaceNode()
            {
                SourceNode.IsRotated = IsRotated;
                SourceNode.X = X;
                SourceNode.Y = Y;
            }
        }

        private CalculatorSettings _settings;
        private readonly Dictionary<string, TextureAtlasNode> _inputNodes;

        public CornersPacker(CalculatorSettings settings)
        {
            _settings = settings;
            _inputNodes = new Dictionary<string, TextureAtlasNode>();
        }

        #region Adding images
        public void Add(Image image, string reference)
        {
            ValidateInput(image, reference);

            _inputNodes.Add(reference, new TextureAtlasNode
            {
                Texture = image,
                Reference = reference,
            });
        }

        public void Clear()
        {
            _inputNodes.Clear();
        }

        private void ValidateInput(Image image, string reference)
        {
            if (image == null) throw new ArgumentNullException("image", @"Cannot add null images");
            if (string.IsNullOrWhiteSpace(reference)) throw new ArgumentNullException("reference", @"reference cannot be empty");

            int maxLength = Math.Max(
                _settings.Size.Width - _settings.Padding * 2,
                _settings.Size.Height - _settings.Padding * 2
                );

            if (image.Width > maxLength)
                throw new ArgumentOutOfRangeException("image", @"Image width excees atlas working area");
            if (image.Height > maxLength)
                throw new ArgumentOutOfRangeException("image", @"Image height excees atlas working area");
        }
        #endregion

        public TextureAtlas Calculate()
        {
            if (!_inputNodes.Any()) throw new InvalidOperationException("No input textures provided");

            var unplacedNodes = _inputNodes.Values.Select(n => n).ToList();
            var placedNodes = new List<TextureAtlasNode>();

            while (unplacedNodes.Any())
            {
                //var validPlacements = unplacedNodes
                //    .Select(n => Score(n, result))
                //    .Where(n => n.IsVaildPlacement)
                //    .ToList();
                //var best = validPlacements
                //    .OrderBy(n => n.WastageScore)
                //    .ThenByDescending(n => n.UtilizationScore)
                //    .FirstOrDefault();

                var best = unplacedNodes.First();

                //if (best == null) throw new InvalidDataException("Insufficient free space available after " + result.Count + " textures placed");

                //best.PlaceNode();
                //result.Add(best.SourceNode);
                //unplacedNodes.Remove(best.SourceNode);

                placedNodes.Add(best);
                unplacedNodes.Remove(best);
            }

            return new TextureAtlas
            {
                Nodes = placedNodes,
                Size = _settings.Size,
            };
        }

        private PlacementNode Score(TextureAtlasNode node, List<TextureAtlasNode> placedNodes)
        {
            var result = new PlacementNode(node);

            foreach (var plcaedNode in placedNodes)
            {
                // 
            }

            if (_settings.IsRotationEnabled) ;
            return null;
        }

    }
}