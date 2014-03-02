using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RelTexPacNet
{
    public class MiscTests
    {
        [Fact(Skip="Rounding errors somewhere in the chain are breaking this where opacity != 0 or 255")]
        private void Color_in_with_partial_opacity_should_equal_color_out()
        {
            var bitmap = new Bitmap(128, 128, PixelFormat.Format32bppArgb);
            var color = Color.FromArgb(30, 60, 90, 120);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(color);
            }

            var result = bitmap.GetPixel(0, 0);

            Assert.Equal(color, result);
        }
    }
}
