namespace MarsRover.Test;

public record struct Coordinate(int X, int Y)
{
    public static Coordinate operator+(Coordinate coordinate, Movement movement) => 
        new(coordinate.X + movement.DeltaX, coordinate.Y + movement.DeltaY); 
}