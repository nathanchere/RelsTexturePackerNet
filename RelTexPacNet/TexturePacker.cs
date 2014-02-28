using System;
using System.Collections.Generic;
using System.Drawing;

namespace RelTexPacNet
{
    public class TexturePacker
    {
        private readonly ITextureAtlasCalculator _calculator;
        private readonly Dictionary<string, Image> _sourceImages; 

        public TexturePacker(ITextureAtlasCalculator calculator = null)
        {
            _sourceImages = new Dictionary<string, Image>();
            _calculator = calculator ?? new TextureAtlasCalculator();
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

                var result = _calculator.Render();

                return new Result<TextureAtlas> { 
                    WasSuccessful = true,
                    ErrorMessage = "",
                    Value = result,
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
