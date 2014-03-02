using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace RelTexPacNet
{
    public class TextureAtlasRenderer : ITextureAtlasRenderer
    {
        public class Settings
        {
            //// NOTE: unless there's a specific need, am assuming always 32bit PNG
            //public PixelFormat PixelFormat { get; set; }
            //public FileFormat OutputFileFormat { get; set; }
            public PixelFormat PixelFormat { get; set; }
            public Color MatteColor { get; set; }
        }

        private readonly Settings _settings;

        public TextureAtlasRenderer(Settings settings)
        {
            _settings = settings;
        }

        public Bitmap Render(TextureAtlas atlas)
        {
            var result = new Bitmap(
                atlas.Size.Width,
                atlas.Size.Height,
                _settings.PixelFormat
            );            

            using (var g = Graphics.FromImage(result))
            {
                g.Clear(_settings.MatteColor);

                atlas.Nodes.ToList().ForEach(n => {
                    
                    if(n.IsRotated) n.Texture.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    if (n.Reference == null) ;
                    g.DrawImage(n.Texture, n.X, n.Y);
                });
            }

            return result;
        }        
    }
}