using Xunit;
using Xunit.Extensions;

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

        [Theory]
        [InlineData(0,
            0, 0, 20, 0,
            0, 0, 0, 20)]
        [InlineData(10,
            0, 0, 0, 20,
            0, 5, 0, 15)]
        [InlineData(5,
            0, 0, 0, 20,
            0, 15, 0, 40)]
        [InlineData(10,
            0, 0, 20, 0,
            5, 0, 15, 0)]
        [InlineData(10,
            0, 10, 0, 20,
            0, 10, 0, 20)]
        public void GetOverlap_calculates_correct_overlap_of_two_lines(
            int expected,
            int Ax1, int Ay1, int Ax2, int Ay2,
            int Bx1, int By1, int Bx2, int By2            )
        {
            var line1 = new Line(Ax1, Ay1, Ax2, Ay2);
            var line2 = new Line(Bx1, By1, Bx2, By2);
            var result = line1.GetOverlap(line2);

            Assert.Equal(expected, result);
        }
    }
}