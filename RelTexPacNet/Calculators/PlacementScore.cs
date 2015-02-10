namespace RelTexPacNet.Calculators
{
    public class PlacementScore
    {
        public bool IsVaildPlacement;
        public int WastageScore; // unutilized edges - lower is better
        public int UtilizationScore; // utilized edges - higher is better
        public int CornerParity; // how far each edge-aligned corner is from the nearest corner - lower is better

        public PlacementScore()
        {
            WastageScore = int.MaxValue;
            CornerParity = int.MaxValue;
            UtilizationScore = 0;
            IsVaildPlacement = false;
        }

        // TODO comparison
    }
}