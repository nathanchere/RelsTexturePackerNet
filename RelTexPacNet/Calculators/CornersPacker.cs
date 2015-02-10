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

        /// <summary>
        /// Find the best possible place for the current node and gibe 
        /// </summary>        
        private PlacementNode Score(TextureAtlasNode node, List<TextureAtlasNode> placedNodes, CalculatorSettings settings)
        {       
            var result = new PlacementNode(node);

            // If this is the first node to be placed, just put it in a corner
            // TODO: which is better - long size on long size or long on short side?
            //    Look for minimum waste placement
            if (!placedNodes.Any())
            {                
                result.Score.IsVaildPlacement = true;
                result.Score.UtilizationScore = node.Size.Width + node.Size.Height;
                result.Score.WastageScore = 0;
                return result;
            }

            var usedSpace = placedNodes.Select(n=>n.GetBounds()).ToArray();
            var availableCorners = GetCorners(settings.Size, placedNodes)
                .Distinct()
                .Where(c => !c.IsSurroundedBy(usedSpace));

            foreach (var corner in availableCorners)
            {
                var score = new PlacementScore();                

                foreach (var placement in GetPossibleNodePlacementsForCorner(corner, node, placedNodes, settings))
                {

                }                                
            }            
            return result;
        }

        private IEnumerable<PlacementPosition> GetPossibleNodePlacementsForCorner(Point corner, TextureAtlasNode node, List<TextureAtlasNode> placedNodes, CalculatorSettings settings)
        {
            var boundaryArea = settings.Size.ToRectangle();

            foreach (var rect in new[] {
                new Rectangle(corner.X, corner.Y, node.Size.Width, node.Size.Height),
                new Rectangle(corner.X, corner.Y, -node.Size.Width, node.Size.Height).Normalize(),
                new Rectangle(corner.X, corner.Y, -node.Size.Width, -node.Size.Height).Normalize(),
                new Rectangle(corner.X, corner.Y, node.Size.Width, -node.Size.Height).Normalize(),
            }
                .Where(r => r.IsEntirelyContainedBy(boundaryArea))
                .Where(r => placedNodes.Any(n => n.GetBounds().IntersectsWith(r)))
                )
            {
                var result = new PlacementPosition(rect.X, rect.Y, false, rect.Width, rect.Height);
                yield return result;
            }

            // No point rotating a square!
            if (!settings.IsRotationEnabled || node.Size.Width == node.Size.Height) yield break;

            foreach (var rect in new[] {
                new Rectangle(corner.X, corner.Y, node.Size.Height, node.Size.Width),
                new Rectangle(corner.X, corner.Y, -node.Size.Height, node.Size.Width).Normalize(),
                new Rectangle(corner.X, corner.Y, -node.Size.Height, -node.Size.Width).Normalize(),
                new Rectangle(corner.X, corner.Y, node.Size.Height, -node.Size.Width).Normalize(),
            }
                .Where(r => r.IsEntirelyContainedBy(boundaryArea))
                .Where(r => placedNodes.Any(n => n.GetBounds().IntersectsWith(r)))
                )
            {
                var result = new PlacementPosition(rect.X, rect.Y, true, rect.Width, rect.Height);
                yield return result;
            }
        }
    }
}