using Xunit;

namespace RelTexPacNet
{
    public class TexturePackerTests
    {
        public void ReturnsRightValue()
        {
            var target = new TexturePacker(null);
            target.AddImage(null, "image01");
            target.AddImage(null, "image02");
            target.AddImage(null, "image03");
            var result = false;

            Assert.True(result);
        }
    }
}