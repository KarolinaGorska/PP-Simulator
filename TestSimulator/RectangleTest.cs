using Simulator;

namespace TestSimulator;
public class RectangleTests
{
    [Fact]
    public void Constructor_ValidInput_ShouldCreateRectangle()
    {
        //Arrange
        int x1 = 1, y1 = 1, x2 = 3, y2 = 3;
        //Act
        var rectangle = new Rectangle(x1, y1, x2, y2);
        //Assert
        Assert.Equal(1, rectangle.X1);
        Assert.Equal(1, rectangle.Y1);
        Assert.Equal(3, rectangle.X2);
        Assert.Equal(3, rectangle.Y2);
    }

    [Fact]
    public void Constructor_InvalidInput_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 3));
    }

    [Theory]
    [InlineData(2, 2, 1, 1, 3, 3, true)]
    [InlineData(4, 4, 1, 1, 3, 3, false)]
    public void Contains_ShouldReturnCorrectValue(int px, int py, int x1, int y1, int x2, int y2, bool expected)
    {
        //Arrange
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        //Act
        var result = rectangle.Contains(point);
        //Assert
        Assert.Equal(expected, result);
    }
}