using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace RelTexPacNet.Calculators
{
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

        public TextureAtlas Calculate(TextureAtlasInput input)
        {
            ValidateInput(input);

            
            var unplacedNodes = input.Nodes.Select(n => n).ToList();
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
                Size = input.Settings.Size,
            };
        }

        private static void ValidateInput(TextureAtlasInput input)
        {
            if (!input.Nodes.Any()) throw new InvalidOperationException("No input textures provided");

            var totalInputArea = input.Nodes.Sum(x => x.Size.Pad(input.Settings.Padding).Area());
            var totalOutputArea = input.Settings.Size.Pad(-input.Settings.Padding).Area();
            if(totalInputArea > totalOutputArea) throw new ArgumentException("Input images (and padding) exceed the maximum total output area");
        }

        private PlacementNode Score(TextureAtlasNode node, List<TextureAtlasNode> placedNodes, bool isRotationEnabled)
        {
            var result = new PlacementNode(node);

            foreach (var plcaedNode in placedNodes)
            {
                // 
            }

            if (isRotationEnabled) ;
            return null;
        }               
    }
}