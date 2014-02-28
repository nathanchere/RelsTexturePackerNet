using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Moq;
using Xunit;

namespace RelTexPacNet
{
    public class TextureAtlasRendererTests
    {
        [Fact]
        private void Render_output_matches_input_size()
        {
            const int width = 512;
            const int height = 256;

            var renderer = new TextureAtlasRenderer();
            var result = renderer.Render(new TextureAtlas {                 
                Size = new Size(width,height),
            });

            Assert.Equal(width, result.Width);
            Assert.Equal(height, result.Height);
        }

        [Fact]
        private void Render_output_uses_matte_color()
        {
            var color = Color.FromArgb(30, 60, 90, 120);
            var renderer = new TextureAtlasRenderer();
            var result = renderer.Render(new TextureAtlas
            {
                MatteColor = color,
            });

            Assert.Equal(color, result.GetPixel(0,0));
        }        

        [Fact]
        private void Render_produces_expected_output()
        {            
            Assert.True(false);
            //TODO: needs reference images to compare
        }
    }
}