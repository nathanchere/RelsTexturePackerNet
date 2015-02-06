using System.Drawing;

namespace RelTexPacNet.Calculators
{
    public class Settings
    {
        /// <summary>
        /// Max output texture size to use
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// How many pixels to leave between each texture, including the overall output texture
        /// </summary>
        public int Padding { get; set; }

        /// <summary>
        /// Is it OK to try to fit sprites by rotating 90 degrees?
        /// </summary>
        public bool IsRotationEnabled { get; set; }

        // TODO: other options like pre-sort by longest side
    }
}