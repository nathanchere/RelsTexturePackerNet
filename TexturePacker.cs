using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RelTexPacNet
{
    public class TexturePacker
    {
        public class Settings
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
                Unknown,
                BMP,
                PNG,
            }

            public Size OutputSize  { get; set; }
            public string OutputFileName { get; set; }
            public BitsPerPixel OutputBitsPerPixel { get; set; }
            public FileFormat OutputFileFormat { get; set; }
            public int Margin { get; set; }
        }
    }
}
