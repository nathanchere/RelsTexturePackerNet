﻿using System;
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
                    .SelectMany(n => GetScoredPlacements(n, placedNodes, input.Settings))
                    .Where(n => n.Score.IsVaildPlacement)
                    .ToList();

                var best = validPlacements
                    .OrderBy(n => n.Score.CornerParity)
                    .ThenBy(n => n.Score.WastageScore)
                    .ThenByDescending(n => n.Score.UtilizationScore)
                    .FirstOrDefault();

                if (best == null) throw new InvalidDataException("Insufficient free space available after " + placedNodes.Count + " textures placed");

                best.PlaceNode();                
                placedNodes.Add(best.SourceNode);
                unplacedNodes.Remove(best.SourceNode);

                // TODO: Raise event node placed
            }

            return new TextureAtlas
            {
                Nodes = placedNodes,
                Size = input.Settings.Size,
            };
        }
       
        private static Point[] GetCorners(Size input, IEnumerable<TextureAtlasNode> placedNodes)
        {            
            var corners = placedNodes.SelectMany(x => x.GetBounds().GetCorners()).ToList();
            corners.AddRange(input.ToRectangle().GetCorners());
            return corners.Distinct().ToArray();
        }

        private static Line[] GetEdges(Size outputTextureSize, IEnumerable<TextureAtlasNode> placedNodes)
        {
            var edges = placedNodes.SelectMany(x => x.GetBounds().GetEdges()).ToList();
            edges.AddRange(outputTextureSize.GetEdges()); // include overall output boundary
            return edges.Distinct().ToArray();
        }

        /// <summary>
        /// Find the best possible place for the current node and gibe 
        /// </summary>        
        private IEnumerable<PlacementNode> GetScoredPlacements(TextureAtlasNode node, List<TextureAtlasNode> placedNodes, CalculatorSettings settings)
        {       
            var result = new PlacementNode(node);

            //// If this is the first node to be placed, just put it in a corner
            //// TODO: which is better - long size on long size or long on short side?
            ////    Look for minimum waste placement
            //if (!placedNodes.Any())
            //{                
            //    result.Score.IsVaildPlacement = true;
            //    result.Score.UtilizationScore = node.Size.Width + node.Size.Height;
            //    result.Score.WastageScore = 0;
            //    yield return result;
            //    yield break;
            //}

            var usedSpace = placedNodes.Select(n=>n.GetBounds()).ToArray();
            var availableCorners = GetCorners(settings.Size, placedNodes)
                .Distinct()
                .Where(c => !c.IsSurroundedBy(usedSpace));

            foreach (var corner in availableCorners)
            {
                foreach (var placement in GetPossibleNodePlacementsForCorner(corner, node, placedNodes, settings))                
                {
                    var score = Score(corner, placement, placedNodes, settings.Size);
                    if (score.IsVaildPlacement)
                    {
                        yield return new PlacementNode(node) {
                            Score = score,
                            Placement = placement,
                        };
                    }
                }                                
            }            
        }

        private PlacementScore Score(Point corner, PlacementPosition placement, List<TextureAtlasNode> placedNodes, Size outputTextureSize)
        {
            var result = new PlacementScore();

            var edges = GetEdges(outputTextureSize, placedNodes).ToList();
            var corners = GetCorners(outputTextureSize, placedNodes).ToList();

            var sharedEdgeSum = placement
                .GetBounds()
                .GetEdges()
                .Sum(e => edges.Sum(placedEdge => e.GetOverlap(placedEdge)));

            var cornerDistance = placement
                .GetBounds()
                .GetCorners()
                .Sum(p => corners.Min(c => p.DistanceBetween(c)));

            result.UtilizationScore = sharedEdgeSum;
            result.WastageScore = placement.GetBounds().GetEdges().Sum(e=>e.Length) - sharedEdgeSum;

            result.CornerParity = cornerDistance;                      

            result.IsVaildPlacement = true;

            return result;
        }

        private IEnumerable<PlacementPosition> GetPossibleNodePlacementsForCorner(Point corner, TextureAtlasNode node, List<TextureAtlasNode> placedNodes, CalculatorSettings settings)
        {
            var boundaryArea = settings.Size.ToRectangle();

            var possiblePlacementRects =  new[] {
                new Rectangle(corner.X, corner.Y, node.Size.Width, node.Size.Height),
                new Rectangle(corner.X, corner.Y, -node.Size.Width, node.Size.Height).Normalize(),
                new Rectangle(corner.X, corner.Y, -node.Size.Width, -node.Size.Height).Normalize(),
                new Rectangle(corner.X, corner.Y, node.Size.Width, -node.Size.Height).Normalize()
            };

            var validPlacements = possiblePlacementRects
                .Where(r => r.IsEntirelyContainedBy(boundaryArea)).ToArray();
            
            var xx = validPlacements.Where(r => !placedNodes.Any(n => n.GetBounds().IntersectsWith(r))).ToArray();

            foreach(var rect in xx)
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