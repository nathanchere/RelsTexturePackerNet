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

        // No no no no no

        [Fact]
        public void Run_with_no_input_returns_WasSuccessful_false()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            var result = packer.Run();

            Assert.False(result.WasSuccessful);
        }

        [Fact]
        public void Run_with_bad_input_returns_WasSuccessful_false()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            packer.AddImage(null, "");
            var result = packer.Run();

            Assert.False(result.WasSuccessful);
        }

        [Fact]
        public void Run_with_no_input_returns_appropriate_error_message()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            var result = packer.Run();

            Assert.Equal(result.ErrorMessage, "No input images provided");
        }

        [Fact] //TODO: define what is bad input - reference, image
        public void Run_with_bad_input_returns_appropriate_error_message()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            packer.AddImage(null, "a");

            var result = packer.Run();

            Assert.Equal(result.ErrorMessage, "Cannot process null values");
        }

        [Fact]
        public void Run_with_valid_input_returns_no_error_message()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            Assert.Equal(result.ErrorMessage, "");
        }

        [Fact]
        public void Run_with_valid_input_returns_WasSuccessful_true()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            Assert.True(result.WasSuccessful);
        }

        [Fact]
        public void Run_success_result_includes_all_added_textures()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            Assert.True(result.Nodes.Count == 3);
            Assert.True(result.Nodes.Count(n => n.Reference == "a") == 1);
            Assert.True(result.Nodes.Count(n => n.Reference == "b") == 1);
            Assert.True(result.Nodes.Count(n => n.Reference == "c") == 1);
        }

        [Fact]
        public void Run_success_result_only_contains_explicitly_added_node_references()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            packer.AddImage(new Bitmap(120, 60), "a");
            packer.AddImage(new Bitmap(80, 100), "b");
            packer.AddImage(new Bitmap(32, 32), "c");

            var result = packer.Run();

            var wrongCount = result.Nodes
                .Select(n => n.Reference)
                .Count(s => !new[] {"a", "b", "c"}.Contains(s));

            Assert.Equal(wrongCount, 0);
        }
    }
}