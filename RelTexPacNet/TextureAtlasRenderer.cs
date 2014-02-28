using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace RelTexPacNet
{

    // TODO: TAC exception types

    public interface ITextureAtlasRenderer
    {
        Bitmap Render(TextureAtlas atlas);
    }

    public class TextureAtlasRenderer : ITextureAtlasRenderer
    {
        public Bitmap Render(TextureAtlas atlas)
        {
            

        }
    }
}