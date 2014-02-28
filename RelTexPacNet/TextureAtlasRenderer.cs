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
        public Bitmap Render(TextureAtlas atlas)
        {
            var result = new Bitmap(
                atlas.Size.Width,
                atlas.Size.Height,
                PixelFormat.Format32bppPArgb
            );            

            using (var g = Graphics.FromImage(result))
            {
                g.Clear(atlas.MatteColor);

                atlas.Nodes.ToList().ForEach(n => {
                    // Rotate image if required
                    // if(condition) n.Texture.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    if (n.Reference == null) ;
                    g.DrawImage(n.Texture, n.X, n.Y);
                });
            }

            return result;
        }        
    }
}