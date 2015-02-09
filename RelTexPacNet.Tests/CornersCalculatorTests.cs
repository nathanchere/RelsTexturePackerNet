using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using RelTexPacNet.Calculators;
using Xunit;

namespace RelTexPacNet
{
    public class CornersCalculatorTests : TestBase
    {
        private CalculatorSettings GetSettings(int width, int height, int padding)
        {
            return new CalculatorSettings
            {
                Size = new Size(width, height),
                Padding = padding,
            };
        }

        [Fact]
        public void Calculate_throws_when_no_images_added()
        {
            var input = new TextureAtlasInput(null);
            var calc = new CornersPacker();
            Assert.Throws<InvalidOperationException>(() => calc.Calculate(input));
        }

        [Fact]
        public void Calculate_does_not_throw_when_images_fit_within_output()
        {
            var input = new TextureAtlasInput(GetSettings(100,100,1));
            var calc = new CornersPacker();
            AddTexture(input, 50, 50, "a");
            AddTexture(input, 50, 50, "b");
            AddTexture(input, 50, 50, "c");
            AddTexture(input, 50, 50, "d");
            calc.Calculate(input);
        }

        [Fact]
        public void Calculate_throws_when_no_insufficient_output_size_to_fit_all_images()
        {
            var input = new TextureAtlasInput(GetSettings(100, 100, 0));
            var calc = new CornersPacker();

            AddTexture(input, 50, 50, "a");
            AddTexture(input, 50, 50, "b");
            AddTexture(input, 50, 50, "c");
            AddTexture(input, 50, 51, "d");
            Assert.Throws<InvalidDataException>(() => calc.Calculate(input));
        }

        [Fact]
        public void Calculate_throws_when_no_insufficient_output_size_to_fit_all_images_with_padding()
        {
            var input = new TextureAtlasInput(GetSettings(100, 100, 1));
            var calc = new CornersPacker();
            AddTexture(input, 50, 50, "a");
            AddTexture(input, 50, 50, "b");
            AddTexture(input, 50, 50, "c");
            AddTexture(input, 50, 50, "d");
            Assert.Throws<InvalidDataException>(() => calc.Calculate(input));
        }

       

        [Fact]
        public void Calculate_returns_all_added_references()
        {
            var calc = new CornersPacker(GetSettings(256, 256, 1));
            AddTexture(calc, 10, 10, "a");
            AddTexture(calc, 10, 10, "b");
            AddTexture(calc, 10, 10, "c");

            var result = calc.Calculate();

            Assert.NotNull(result.Nodes.SingleOrDefault(n => n.Reference == "a"));
            Assert.NotNull(result.Nodes.SingleOrDefault(n => n.Reference == "b"));
            Assert.NotNull(result.Nodes.SingleOrDefault(n => n.Reference == "c"));
        }

        //[Fact]
        //public void Calculate_does_not_produce_textures_outside_atlas_bounds()
        //{
        //    var WIDTH = 512;
        //    var HEIGHT = 512;
        //    var calc = new CornersPacker(GetSettings(WIDTH, HEIGHT, 1));

        //    for (int i = 0; i < 40; i++) AddTexture(calc, 20, 20, "a" + i);
        //    for (int i = 0; i < 10; i++) AddTexture(calc, 80 + 10 * i, 40, "b" + i);
        //    for (int i = 0; i < 40; i++) AddTexture(calc, 40 + i, 10, "c" + i);

        //    var result = calc.Calculate();

        //    var failures = new List<TextureAtlasNode>();
        //    result.Nodes.ToList().ForEach(n =>
        //    {
        //        if (n.X < 0 || n.Y < 0 || n.X > WIDTH - n.Texture.Width || n.Y > HEIGHT - n.Texture.Height)
        //            failures.Add(n);
        //    });
        //    Assert.Equal(0, failures.Count);
        //}

        //[Fact]
        //public void Calculate_does_not_produce_textures_that_overlap()
        //{
        //    var WIDTH = 512;
        //    var HEIGHT = 512;
        //    var calc = new CornersPacker(GetSettings(WIDTH, HEIGHT, 1));

        //    for (int i = 0; i < 40; i++) AddTexture(calc, 20, 20, "a" + i);
        //    for (int i = 0; i < 10; i++) AddTexture(calc, 80 + 10 * i, 40, "b" + i);
        //    for (int i = 0; i < 40; i++) AddTexture(calc, 40 + i, 10, "c" + i);

        //    var result = calc.Calculate();

        //    var nodes = result.Nodes.ToList();
        //    var failures = new List<TextureAtlasNode>();

        //    for (int i = 0; i < nodes.Count(); i++)
        //        for (int j = i + 1; j < nodes.Count(); j++)
        //        {
        //            if (nodes[i].GetBounds().IntersectsWith(nodes[j].GetBounds()))
        //            {
        //                failures.Add(nodes[i]);
        //                j = nodes.Count;
        //            }
        //        }

        //    Assert.Equal(0, failures.Count);

        //    Render(result);
        //}

        //[Fact]
        //public void Calculate_does_not_produce_textures_that_overlap_2()
        //{
        //    var WIDTH = 512;
        //    var HEIGHT = 512;
        //    var calc = new CornersPacker(GetSettings(WIDTH, HEIGHT, 0));

        //    AddTexture(calc, 100, 50, "a");
        //    AddTexture(calc, 80, 80, "c1");
        //    AddTexture(calc, 100, 50, "b");
        //    AddTexture(calc, 80, 80, "c3");
        //    AddTexture(calc, 80, 80, "c4");
        //    AddTexture(calc, 80, 80, "c2");
        //    for (int i = 0; i < 40; i++) AddTexture(calc, 20, 20, "a" + i);
        //    for (int i = 0; i < 10; i++) AddTexture(calc, 80 + 10 * i, 40, "b" + i);
        //    var result = calc.Calculate();

        //    var nodes = result.Nodes.ToList();
        //    var failures = new List<TextureAtlasNode>();

        //    for (int i = 0; i < nodes.Count(); i++)
        //        for (int j = i + 1; j < nodes.Count(); j++)
        //        {
        //            if (nodes[i].GetBounds().IntersectsWith(nodes[j].GetBounds()))
        //            {
        //                failures.Add(nodes[i]);
        //                j = nodes.Count;
        //            }
        //        }

        //    Assert.Equal(0, failures.Count);

        //    Render(result);
        //}

        [Fact]
        //public void Calculate_non_test()
        //{
        //    var WIDTH = 512;
        //    var HEIGHT = 512;
        //    var calc = new CornersPacker(GetSettings(WIDTH, HEIGHT, 0));

        //    for (int i = 0; i < 40; i++) AddTexture(calc, 20, 20, "a" + i);
        //    for (int i = 0; i < 10; i++) AddTexture(calc, 80 + 10 * i, 40, "b" + i);
        //    for (int i = 0; i < 40; i++) AddTexture(calc, 40 + i, 10, "c" + i);
        //    AddTexture(calc, 300, 40, "a");
        //    AddTexture(calc, 50, 400, "d");
        //    AddTexture(calc, 80, 80, "d2");
        //    for (int i = 0; i < 40; i++) AddTexture(calc, 20, 20, "e" + i);
        //    for (int i = 0; i < 10; i++) AddTexture(calc, 80 + 10 * i, 40, "f" + i);
        //    var result = calc.Calculate();

        //    Render(result);
        //}

        #region Visualisation aids        

        private void Render(TextureAtlas atlas)
        {
            var renderer = new TextureAtlasRenderer(new TextureAtlasRendererSettings
            {
                MatteColor = Color.FromArgb(128, 255, 0, 255),
                PixelFormat = PixelFormat.Format32bppArgb,
            });
            var result = renderer.Render(atlas);
            result.Dump();
        }        

        private void AddTexture(TextureAtlasInput input, int width, int height, string reference)
        {
            input.AddSprite(GetBitmap(width,height,reference),reference);
        }
        #endregion
    }
}