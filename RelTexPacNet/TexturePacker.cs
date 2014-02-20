﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RelTexPacNet
{
    public class TexturePacker
    {
        #region Child classes
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
                Unknown = -1,
                BMP = 0,
                PNG = 1,
            }

            public string InputPath { get; set; }

            public Size OutputSize  { get; set; }
            public int OutputMargin { get; set; }

            public string OutputFileName { get; set; }
            public string OutputPath { get; set; }

            public BitsPerPixel OutputBitsPerPixel { get; set; }
            public FileFormat OutputFileFormat { get; set; }

            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3} {4} {5} {6}",
                    OutputSize.Width,
                    OutputSize.Height,
                    OutputFileName,
                    (int)OutputBitsPerPixel,
                    (int)OutputFileFormat,
                    OutputMargin,
                    InputPath);
            }
        }

        public class Result
        {
            public bool WasSuccessful { get; set; }
            public string ErrorMessage { get; set; }

            public Bitmap TextureAtlas { get; set; }
            public string UvMap { get; set; }
        }
        #endregion

        private Settings _settings;
        private Dictionary<string, Bitmap> _sourceImages;

        public TexturePacker(Settings settings)
        {
            _settings = settings;
        }

        public void AddImage(Bitmap bitmap, string reference)
        {
            _sourceImages.Add(reference, bitmap);
        }

        public Result Run()
        {
            var x = new TextureAtlasCalculator(512, 256, 1, false);
            var result = x.

            return new Result { ErrorMessage = output };
        }
    }
}