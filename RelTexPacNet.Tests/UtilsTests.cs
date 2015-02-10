using System.Drawing;
using System.Linq;
using Xunit;

namespace RelTexPacNet
{
    public class UtilsTests
    {
        [Fact]
        public void GetCorners_returns_all_corners()
        {
            var input = new Rectangle(20, 20, 80, 80);
            var result = input.GetCorners();

            Assert.NotNull(result.Where(p => p.X == 20 && p.Y == 20).SingleOrDefault());
            Assert.NotNull(result.Where(p => p.X == 20 && p.Y == 100).SingleOrDefault());
            Assert.NotNull(result.Where(p => p.X == 100 && p.Y == 100).SingleOrDefault());
            Assert.NotNull(result.Where(p => p.X == 100 && p.Y == 20).SingleOrDefault());
        }
    }
}