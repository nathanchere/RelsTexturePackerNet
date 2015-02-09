using System;
using System.Drawing;
using System.Runtime.InteropServices;
using RelTexPacNet.Calculators;
using Xunit;
using Xunit.Extensions;

namespace RelTexPacNet
{
    public class TextureAtlasInputTests : TestBase
    {
        private CalculatorSettings GetCalculatorSettings(int width, int height, int padding)
        {
            return new CalculatorSettings
            {
                Size = new Size(width, height),
                Padding = padding,
            };
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(100, 0)]
        [InlineData(100, -100)]
        [InlineData(0, 100)]
        [InlineData(-100, 100)]
        [InlineData(-100, -100)]
        public void Add_throws_on_invalid_output_texture_size(int width, int height)
        {
            var settings = GetCalculatorSettings(width, height, 0);
            Assert.Throws<ArgumentOutOfRangeException>(() => new TextureAtlasInput(settings));
        }

        [Theory]
        [InlineData(100, 100, 50)]
        [InlineData(100, 100, 100)]
        [InlineData(100, 50, 25)]
        [InlineData(50, 100, 25)]
        [InlineData(100, 100, -1)]
        public void Add_throws_on_invalid_output_texture_padding(int width, int height, int padding)
        {
            var settings = GetCalculatorSettings(width, height, padding);
            Assert.Throws<ArgumentOutOfRangeException>(() => new TextureAtlasInput(settings));
        }

        [Fact]
        public void Add_throws_when_any_input_image_exceeds_output_size()
        {
            var settings = GetCalculatorSettings(100, 100, 0);
            var input = new TextureAtlasInput(settings);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                input.AddSprite(GetBitmap(256, 10, "Invalid"), "Invalid")
                );                
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Add_throws_on_empty_reference(string reference)
        {
            var settings = GetCalculatorSettings(100, 100, 0);
            var input = new TextureAtlasInput(settings);
            Assert.Throws<ArgumentOutOfRangeException>(() => input.AddSprite(GetBitmap(10, 10, "a"), reference));
        }

        [Fact]
        public void Add_throws_on_null_reference()
        {
            var settings = GetCalculatorSettings(100, 100, 0);
            var input = new TextureAtlasInput(settings);
            Assert.Throws<ArgumentNullException>(() => input.AddSprite(GetBitmap(10, 10, "a"), null));
        }

        [Fact]
        public void Add_throws_on_null_image()
        {
            var settings = GetCalculatorSettings(100, 100, 0);
            var input = new TextureAtlasInput(settings);
            Assert.Throws<ArgumentNullException>(() => input.AddSprite(null, "invalid"));
        }
    }
}