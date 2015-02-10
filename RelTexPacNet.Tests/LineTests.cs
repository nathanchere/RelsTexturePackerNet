using Xunit;

namespace RelTexPacNet
{
    public class LineTests
    {
        [Fact]
        public void Equals_works_regardless_of_point_order()
        {
            var line1 = new Line(0, 0, 10, 10);
            var line2 = new Line(10, 10, 0, 0);
            Assert.Equal(line1, line2);
        }
    }
}