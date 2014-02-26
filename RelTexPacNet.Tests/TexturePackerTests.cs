using System.Drawing;
using System.Linq;
using Moq;
using Xunit;

namespace RelTexPacNet
{
    public class TexturePackerTests
    {
        private ITexture MockImage(int height, int width)
        {
            var result = new Mock<ITexture>();
            result.SetupGet(x => x.Height).Returns(height);
            result.SetupGet(x => x.Width).Returns(width);
            var blankImage = new Bitmap(width, height);
            result.SetupGet(x => x.Image).Returns(blankImage);
            return result.Object;
        }

        // No no no no no

        [Fact]
        public void Run_with_no_input_returns_WasSuccessful_false()
        {
            Assert.True(false);
        }

        [Fact]
        public void Run_with_bad_input_returns_WasSuccessful_false()
        {
            Assert.True(false);
        }

        [Fact]
        public void Run_with_no_input_returns_appropriate_error_message()
        {
            Assert.True(false);
        }

        [Fact]
        public void Run_with_bad_input_returns_appropriate_error_message()
        {
            Assert.True(false);
        }

        [Fact]
        public void Run_with_valid_input_returns_no_error_message()
        {
            Assert.True(false);
        }

        [Fact]
        public void Run_with_valid_input_returns_WasSuccessful_true()
        {
            var settings = new TexturePacker.Settings
            {
            };

            var packer = new TexturePacker(settings);
            packer.AddImage(MockImage(120, 60), "a");
            packer.AddImage(MockImage(64, 128), "b");
            packer.AddImage(MockImage(32, 32), "c");

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
            
            const int inputImageCount = 3;

            packer.AddImage(MockImage(120, 60), "a");
            packer.AddImage(MockImage(64, 128), "b");
            packer.AddImage(MockImage(32, 32), "c");

            var result = packer.Run();

            Assert.Equal(result.TextureAtlas.Nodes.Count(), inputImageCount);
        }
    }
}