using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RelTexPacNet.Properties;

namespace RelTexPacNet
{
    public class TexturePacker
    {
        public ITextureAtlasCalculator Calculator { get; set; }

        public TexturePacker()
        {            
        }

        public void AddImage(Image image, string reference)
        {
            Calculator.Add(image, reference);
        }

        public Result<TextureAtlas> Run()
        {
            try
            {        
                return new Result<TextureAtlas> { 
                    WasSuccessful = true,
                    ErrorMessage = "",
                    Value = null,
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
