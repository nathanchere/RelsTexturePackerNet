using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlasRendererSettings
    {        
        public enum BitsPerPixel
        {
            Unknown,
            BPP_4 = 4,
            BPP_8 = 8,
            BPP_16 = 16,
            BPP_24 = 24,
            BPP_32 = 32,
        }

        public enum FileFormat
        {
            Unknown = -1,
            BMP = 0,
            PNG = 1,
        }

        public BitsPerPixel OutputBitsPerPixel { get; set; }
        public FileFormat OutputFileFormat { get; set; }
        public Color MatteColor { get; set; }
    }
}