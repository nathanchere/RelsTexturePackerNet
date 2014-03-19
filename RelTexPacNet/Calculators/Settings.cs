using System.Drawing;

namespace RelTexPacNet.Calculators
{
    public class Settings
    {
        public Size Size { get; set; }
        public int Padding { get; set; }
        public bool IsRotationEnabled { get; set; }

        // TODO: other options like pre-sort by longest side
    }
}