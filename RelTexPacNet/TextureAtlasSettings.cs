using System.Drawing;

namespace RelTexPacNet
{
    public class TextureAtlasSettings
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

         
        // Texture atlas properties
        public Color MatteColor { get; set; }
        public Size MaximumSize { get; set; }
        public int TexturePadding { get; set; }

        public string OutputFileName { get; set; }
        public string OutputPath { get; set; }

        public BitsPerPixel OutputBitsPerPixel { get; set; }
        public FileFormat OutputFileFormat { get; set; }
    }
}