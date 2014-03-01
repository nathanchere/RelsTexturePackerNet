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
        private TextureAtlasNode MockNode(int width, int height, string reference)
        {
            return new TextureAtlasNode { 
                Texture = new Bitmap(width,height),
                Reference = reference,
            };
        }

        [Fact]
        public void Calculate_throws_when_no_images_added()
        {
            var calc = new TextureAtlasCalculator();
            //Assert.Throws<InvalidOperationException>(() => calc.Calculate());
        }
    }
}