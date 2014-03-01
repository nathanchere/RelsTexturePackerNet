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
        [Fact]
        public void Calculate_throws_when_no_images_added()
        {
            var calc = new TextureAtlasCalculator(null);
            Assert.Throws<InvalidOperationException>(() => calc.Calculate());
        }

        [Fact]
        public void Calculate_throws_when_any_input_image_exceeds_output_size()
        {
            var calc = new TextureAtlasCalculator(null);
            calc.Add(new Bitmap(513,10), "invalid");
            Assert.Throws<InvalidOperationException>(() => calc.Calculate());
        }
    }
}