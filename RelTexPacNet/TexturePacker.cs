using System;
using System.Collections.Generic;
using System.Drawing;
using RelTexPacNet.Calculators;

namespace RelTexPacNet
{
    public class TexturePacker
    {
        public class Settings
        {
            public Settings()
            {
                CalculatorSettings = new CalculatorSettings();
                RendererSettings = new TextureAtlasRendererSettings();
            }

            public Calculators.CalculatorSettings CalculatorSettings;
            public TextureAtlasRendererSettings RendererSettings;

            // output settings
            // file format
            // file name
            // etc            
        }

        private readonly ITextureAtlasCalculator _calculator;
        private readonly ITextureAtlasRenderer _renderer;
        private readonly Dictionary<string, Image> _sourceImages; 

        public TexturePacker(Settings settings,
            ITextureAtlasCalculator calculator = null,
            ITextureAtlasRenderer renderer = null)
        {
            _sourceImages = new Dictionary<string, Image>();
            _renderer = renderer ?? new TextureAtlasRenderer(settings.RendererSettings);
            _calculator = calculator ?? new CornersPacker(settings.CalculatorSettings);
        }

        public void AddImage(Image image, string reference)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new ArgumentException("Invalid reference: " + reference ?? "{null}");
            if(image == null)
                throw new ArgumentNullException("Image cannot be null");
            _sourceImages.Add(reference,image);
        }

        public Result<TextureAtlas> Run() // TODO: pass in settings, IAtCalc here?
        {
            try
            {
                foreach (var item in _sourceImages)
                    _calculator.Add(item.Value, item.Key);    

                var atlas = _calculator.Calculate();

                return new Result<TextureAtlas> { 
                    WasSuccessful = true,
                    ErrorMessage = "",
                    Value = atlas,
                };
            }
            catch (Exception ex)
            {
                return new Result<TextureAtlas>
                {
                    WasSuccessful = false,
                    ErrorMessage = ex.Message,
                };
            }        
        }
    }
}
