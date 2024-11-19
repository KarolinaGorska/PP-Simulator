using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinatesCorrectly()
    {
        //Arrange
        int x = 5, y = 10;
        //Act
        var point = new Point(x, y);
        //Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(1, 1, Direction.Left, 0, 1)]
    [InlineData(1, 1, Direction.Right, 2, 1)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        //Arrange
        var point = new Point(x, y);
        //Act
        var nextPoint = point.Next(direction);
        //Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    [InlineData(2, 2, Direction.Down, 1, 1)]
    [InlineData(3, 3, Direction.Left, 2, 4)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        //Arrange
        var point = new Point(x, y);
        //Act
        var nextPoint = point.NextDiagonal(direction);
        //Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
