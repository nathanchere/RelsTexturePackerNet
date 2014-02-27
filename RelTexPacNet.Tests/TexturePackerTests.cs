using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Moq;
using Xunit;

namespace RelTexPacNet
{
    public class TexturePackerTests
    {
        private Image MockImage(int height, int width)
        {
            return new Bitmap(width, height);
        }


        private ITextureAtlasCalculator MockTextureAtlasCalculator()
        {
            int value = 0;
            var result = new Mock<ITextureAtlasCalculator>();
            result.Setup(x => x.Add(It.IsAny<Image>(), It.IsAny<string>()))
                .Callback(() => { value += 1; });
            result.Setup(x => x.Render())
                .Returns(() =>
                {
                    Debug.WriteLine("Returning mock atlas with " + value + " nodes");
                    return new TextureAtlas
                    {
                        Texture = null,
                        Nodes = null,
                    };
                }

                );
            return result.Object;
        }

        [Fact]
        public void Run_with_no_input_returns_WasSuccessful_false()
        {
            var packer = new TexturePacker();
            var result = packer.Run();

            Assert.False(result.WasSuccessful);
        }

        [Fact]
        public void Add_throws_on_bad_image()
        {
            var packer = new TexturePacker();
            packer.AddImage(null, "");
            var result = packer.Run();

            Assert.False(result.WasSuccessful);
        }

        [Fact]
        public void Add_throws_on_bad_reference()
        {
            var packer = new TexturePacker();
            var image = MockImage(1,1);
            Assert.Throws<Exception>(() => packer.AddImage(null, "test"));
            Assert.Throws<Exception>(() => packer.AddImage(image, ""));
            Assert.Throws<Exception>(() => packer.AddImage(image, " "));
            Assert.Throws<Exception>(() => packer.AddImage(image, null));
        }

        [Fact]
        public void Run_with_no_input_returns_appropriate_error_message()
        {
            var packer = new TexturePacker();
            var result = packer.Run();

            Assert.Equal(result.ErrorMessage, "No input images provided");
        }

        [Fact] //TODO: define what is bad input - reference, image
        public void Run_with_bad_input_returns_appropriate_error_message()
        {           
            var packer = new TexturePacker();
            packer.AddImage(null, "a");

            var result = packer.Run();

            Assert.Equal(result.ErrorMessage, "Cannot process null values");
        }

        [Fact]
        public void Run_with_valid_input_returns_no_error_message()
        {
            var packer = new TexturePacker();
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            Assert.Equal(result.ErrorMessage, "");
        }

        [Fact]
        public void Run_with_valid_input_returns_WasSuccessful_true()
        {
            var packer = new TexturePacker(MockTextureAtlasCalculator());
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            Assert.True(result.WasSuccessful);
        }

        [Fact]
        public void Run_success_result_includes_all_added_textures()
        {
            var packer = new TexturePacker(MockTextureAtlasCalculator());
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            Assert.True(result.Value.Nodes.Count() == 3);
            Assert.True(result.Value.Nodes.Count(n => n.Reference == "a") == 1);
            Assert.True(result.Value.Nodes.Count(n => n.Reference == "b") == 1);
            Assert.True(result.Value.Nodes.Count(n => n.Reference == "c") == 1);
        }

        [Fact]
        public void Run_success_result_only_contains_explicitly_added_node_references()
        {
            var packer = new TexturePacker(MockTextureAtlasCalculator());
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            var wrongCount = result.Value.Nodes
                .Select(n => n.Reference)
                .Count(s => !new[] {"a", "b", "c"}.Contains(s));

            Assert.Equal(wrongCount, 0);
        }
    }
}