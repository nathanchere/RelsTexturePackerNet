using System;
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

            public Color OutputMatte { get; set; }

            public Size OutputSize { get; set; }
            public int OutputMargin { get; set; }

            public string OutputFileName { get; set; }
            public string OutputPath { get; set; }

            public BitsPerPixel OutputBitsPerPixel { get; set; }
            public FileFormat OutputFileFormat { get; set; }
        }

        public class Result
        {
            public bool WasSuccessful { get; set; }
            public string ErrorMessage { get; set; }

            public TextureAtlas TextureAtlas { get; set; }
        }
        #endregion

        private readonly Settings _settings;
        private readonly ITextureAtlasCalculator _calculator;

        public TexturePacker(Settings settings, ITextureAtlasCalculator calculator = null)
        {
            _settings = settings;
            _calculator = calculator ?? new TextureAtlasCalculator(_settings.OutputSize, _settings.OutputMargin);
        }

        public void AddImage(Image image, string reference)
        {
            _calculator.Add(image, reference);
        }

        public Result Run()
        {
            try
            {                  
                return new Result { 
                    WasSuccessful = true,
                    ErrorMessage = "",
                    TextureAtlas = null,
                };
            }
            catch (Exception ex)
            {
                return new Result
                {
                    WasSuccessful = false,
                    ErrorMessage = ex.Message,
                };
            }        
        }
    }
}
