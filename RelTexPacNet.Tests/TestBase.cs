using System;
using System.Drawing;

namespace RelTexPacNet
{
    public class TestBase
    {
        private readonly Random rnd = new Random();
        private readonly Font font = new Font("Source Code Pro", 8);

        protected Image GetBitmap(int width, int height, string reference)
        {
            const float shadeRatio = 0.5f;
            const int border = 2;

            var result = new Bitmap(width, height);
            int r = rnd.Next(64, 255),
                g = rnd.Next(64, 255),
                b = rnd.Next(64, 255);
            using (var canvas = Graphics.FromImage(result))
            {

                var borderColor = Color.FromArgb(r, g, b);
                var fillColor = Color.FromArgb((int)(r * shadeRatio), (int)(g * shadeRatio), (int)(b * shadeRatio));
                canvas.Clear(borderColor);
                canvas.FillRectangle(new SolidBrush(fillColor), border, border, width - (border * 2), height - (border * 2));

                canvas.DrawString(reference, font, Brushes.White, 1, 1);
            }
            return result;
        }
    }
}