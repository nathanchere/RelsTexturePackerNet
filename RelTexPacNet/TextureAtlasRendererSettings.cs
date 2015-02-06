using System.Drawing;
using System.Drawing.Imaging;

namespace RelTexPacNet
{
    public class TextureAtlasRendererSettings
    {
        //// NOTE: unless there's a specific need, am assuming always 32bit PNG
        //public PixelFormat PixelFormat { get; set; }
        //public FileFormat OutputFileFormat { get; set; }

        public PixelFormat PixelFormat { get; set; }

        public Color MatteColor { get; set; }
    }
}