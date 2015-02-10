namespace RelTexPacNet.Calculators
{
    public class PlacementNode
    {
        public PlacementPosition Placement { get; set; }
        public PlacementScore Score { get; set; }

        public int TotalEdgeLength
        {
            get { return 2 * (Placement.Width + Placement.Height); }
        }

        public TextureAtlasNode SourceNode;        

        public PlacementNode(TextureAtlasNode sourceNode)
        {
            SourceNode = sourceNode;
            Score = new PlacementScore();
            Placement = new PlacementPosition(0, 0, false, 0, 0);
        }

        /// <summary>
        /// Persist the placement information to the actual texture atlas node
        /// </summary>
        public void PlaceNode()
        {
            SourceNode.IsRotated = Placement.IsRotated;
            SourceNode.X = Placement.X;
            SourceNode.Y = Placement.Y;
        }
    }
}