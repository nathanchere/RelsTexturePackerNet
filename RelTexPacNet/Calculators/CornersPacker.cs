using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace RelTexPacNet.Calculators
{
    public class CornersPacker : ITextureAtlasCalculator
    {       
        private static void ValidateInput(TextureAtlasInput input)
        {
            if (!input.Nodes.Any()) throw new InvalidOperationException("No input textures provided");

            var totalInputArea = input.Nodes.Sum(x => x.Size.Pad(input.Settings.Padding).Area());
            var totalOutputArea = input.Settings.Size.Pad(-input.Settings.Padding).Area();
            if (totalInputArea > totalOutputArea) throw new ArgumentException("Input images (and padding) exceed the maximum total output area");
        }

        public TextureAtlas Calculate(TextureAtlasInput input)
        {
            ValidateInput(input);
            
            var unplacedNodes = input.Nodes.Select(n => n).ToList();
            var placedNodes = new List<TextureAtlasNode>();

            while (unplacedNodes.Any())
            {                
                var validPlacements = unplacedNodes
                    .Select(n => Score(n, placedNodes, input.Settings))
                    .Where(n => n.Score.IsVaildPlacement)
                    .ToList();

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

                // TODO: Raise event node placed
            }

            return new TextureAtlas
            {
                Nodes = placedNodes,
                Size = input.Settings.Size,
            };
        }

        /// <summary>
        /// Return a list of all corners for 
        /// </summary>       
        private static Point[] GetCorners(Size input, IEnumerable<TextureAtlasNode> placedNodes)
        {            
            var corners = placedNodes.SelectMany(x => x.GetBounds().GetCorners()).ToList();
            corners.AddRange(input.ToRectangle().GetCorners());
            return corners.Distinct().ToArray();
        }

        private PlacementNode Score(TextureAtlasNode node, List<TextureAtlasNode> placedNodes, CalculatorSettings settings)
        {       
            var result = new PlacementNode(node);

            if (!placedNodes.Any())
            {                
                result.Score.IsVaildPlacement = true;
                result.Score.UtilizationScore = node.Size.Width + node.Size.Height;
                result.Score.WastageScore = 0;
                return result;
            }

            var usedSpace = placedNodes.Select(n=>n.GetBounds()).ToArray();
            var availableCorners = GetCorners(settings.Size, placedNodes)
                .Where(c => !c.IsSurroundedBy(usedSpace));

            foreach (var corner in availableCorners)
            {
                var score = new PlacementScore();
                var position = new PlacementPosition(corner.X, corner.Y, false, node.Size.Width, node.Size.Height);

                foreach (var placement in GetPossibleNodePlacementsForCorner(corner, node.Size, placedNodes, settings))
                {
                }                                
                
                //if (usedSpace.Where(r => r.IntersectsWith(placement)).Any()) continue;
                
                //position 
                
            }

            if (settings.IsRotationEnabled) ;
            return result;
        }
       
        private IEnumerable<PlacementNode> GetPossibleNodePlacementsForCorner(Point corner, Size nodeSize, List<TextureAtlasNode> placedNodes, CalculatorSettings settings)
        {
            var result = new List<Rectangle>();
            result.Add(new Rectangle(corner, nodeSize));
            result.Add(new Rectangle(corner, nodeSize));
            result.Add(new Rectangle(corner, nodeSize));
            result.Add(new Rectangle(corner, nodeSize));
            return null;
            // top left
            // top right
            // etc

            // out of bounds
            // surrounded
            // overlaps other node
        }
    }
}