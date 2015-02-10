using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Xunit;
using Xunit.Extensions;

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

        [Theory]        
        [InlineData(10, 10, 50, 50, 10, 10, true)]
        [InlineData(10, 10, 50, 50, 10, 60, true)]
        [InlineData(10, 10, 50, 50, 60, 60, true)]
        [InlineData(10, 10, 50, 50, 60, 10, true)]
        public void SharesEdge_detects_when_point_lies_on_corner(int rectX, int rectY, int rectWidth, int rectHeight, int pointX, int pointY, bool expected)
        {
            var rectangle = new Rectangle(rectX, rectY, rectWidth, rectHeight);
            var point = new Point(pointX, pointY);

            var result = rectangle.SharesEdge(point);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 10, 50, 50, 10, 30, true)]
        [InlineData(10, 10, 50, 50, 60, 30, true)]
        [InlineData(10, 10, 50, 50, 30, 10, true)]
        [InlineData(10, 10, 50, 50, 30, 60, true)]        
        public void SharesEdge_detects_when_point_lies_on_edge(int rectX, int rectY, int rectWidth, int rectHeight, int pointX, int pointY, bool expected)
        {
            var rectangle = new Rectangle(rectX, rectY, rectWidth, rectHeight);
            var point = new Point(pointX,pointY);

            var result = rectangle.SharesEdge(point);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 10, 50, 50, 10, 70, false)]
        [InlineData(10, 10, 50, 50, 70, 10, false)]
        [InlineData(10, 10, 50, 50, 0, 0, false)]
        [InlineData(10, 10, 50, 50, 70, 70, false)]
        public void SharesEdge_detects_when_point_lies_outside_rectangle(int rectX, int rectY, int rectWidth, int rectHeight, int pointX, int pointY, bool expected)
        {
            var rectangle = new Rectangle(rectX, rectY, rectWidth, rectHeight);
            var point = new Point(pointX, pointY);

            var result = rectangle.SharesEdge(point);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 10, 50, 50, 50, 50, false)]
        [InlineData(10, 10, 50, 50, 20, 20, false)]        
        public void SharesEdge_detects_when_point_lies_inside_rectangle(int rectX, int rectY, int rectWidth, int rectHeight, int pointX, int pointY, bool expected)
        {
            var rectangle = new Rectangle(rectX, rectY, rectWidth, rectHeight);
            var point = new Point(pointX, pointY);

            var result = rectangle.SharesEdge(point);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(50, 50, true)]
        [InlineData(40, 50, false)]
        [InlineData(50, 40, false)]
        [InlineData(0, 0, false)]        
        public void ISSurroundedBy_detects_when_surrounded_by_four_corners(int x, int y, bool expected)
        {
            var rectangles = new[] { 
                new Rectangle(0,0,50,50),
                new Rectangle(50,40,30,10),
                new Rectangle(-10,50,60,90),
                new Rectangle(50,50,80,5),
            };
            var result = new Point(x, y).IsSurroundedBy(rectangles);
            Assert.Equal(expected, result);
        }
    }
}