namespace MarsRover.Test;

public class UnitTest1
{
    private readonly FakeSonar _sonar = new FakeSonar();

    private static void AssertRover(Direction orientationExpected, Coordinate positionExpected, Rover rover)
    {
        Assert.Multiple(() =>
        {
            Assert.Equal(orientationExpected, rover.Orientation);
            Assert.Equal(positionExpected, rover.Position);
        });
    }

    [Fact]
    public void Constructor_SonarNull_ThrowArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Rover(Direction.North, null!));
    }

    [Theory]
    [InlineData(Direction.North)]
    [InlineData(Direction.East)]
    [InlineData(Direction.South)]
    [InlineData(Direction.West)]
    public void Constructor(Direction orientation)
    {
        // Arrange
        var positionExpected = new Coordinate(0,0);
        
        // Act
        var rover = new Rover(orientation, _sonar);
        
        // Assert
        AssertRover(orientation, positionExpected, rover);
    }
    
    [Theory]
    [InlineData(Direction.North, +0, +1)]
    [InlineData(Direction.East,  +1, +0)]
    [InlineData(Direction.South, +0, -1)]
    [InlineData(Direction.West,  -1, +0)]
    public void Forward(Direction orientation, int expectedX, int expectedY)
    {
        // Arrange
        var positionExpected = new Coordinate(expectedX, expectedY);
        var rover = new Rover(orientation, _sonar);
        
        // Act
        rover.Forward();
        
        // Assert
        AssertRover(orientation, positionExpected, rover);
    }
    
    [Theory]
    [InlineData(Rotate.Left,  Direction.North, Direction.East)]
    [InlineData(Rotate.Left,  Direction.East, Direction.South)]
    [InlineData(Rotate.Left,  Direction.South, Direction.West)]
    [InlineData(Rotate.Left,  Direction.West, Direction.North)]
    [InlineData(Rotate.Right, Direction.North, Direction.West)]
    [InlineData(Rotate.Right, Direction.West, Direction.South)]
    [InlineData(Rotate.Right, Direction.South, Direction.East)]
    [InlineData(Rotate.Right, Direction.East, Direction.North)]
    public void Turn(Rotate rotate, Direction orientationInitial, Direction orientationExpected)
    {
        // Arrange
        var positionExpected = new Coordinate(0,0);
        var rover = new Rover(orientationInitial, _sonar);
        
        // Act
        rover.Turn(rotate);
        
        // Assert
        AssertRover(orientationExpected, positionExpected, rover);
    }
}