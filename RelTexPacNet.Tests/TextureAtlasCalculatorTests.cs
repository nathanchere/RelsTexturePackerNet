using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Moq;
using Xunit;

namespace RelTexPacNet
{
    public class TextureAtlasCalculatorTests
    {
        private TextureAtlasCalculator.Settings GetSettings(int width, int height, int padding)
        {
            return new TextureAtlasCalculator.Settings { 
                Size = new Size(width,height),
                Padding = padding,
            };
        }

        [Fact]
        public void Calculate_throws_when_no_images_added()
        {
            var calc = new TextureAtlasCalculator(null);
            Assert.Throws<InvalidOperationException>(() => calc.Calculate());
        }

        [Fact]
        public void Add_throws_when_any_input_image_exceeds_output_size()
        {
            var calc = new TextureAtlasCalculator(GetSettings(256, 256, 1));
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                calc.Add(new Bitmap(256, 10), "invalid")
            );
        }
    }
}