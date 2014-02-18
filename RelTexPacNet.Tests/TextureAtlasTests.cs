using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RelTexPacNet
{
    public class TextureAtlasTests
    {
        public void ReturnsRightValue()
        {
            var target = new TextureAtlasCalculator(512, 256, 1, true);

            var result = false;

            Assert.True(result);
        }
    }
}
