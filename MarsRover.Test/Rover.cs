namespace MarsRover.Test;

public class Rover(Direction orientation, ISonar sonar)
{
    public ISonar Sonar { get; init; } = sonar ?? throw new ArgumentNullException(nameof(sonar));
    public Direction Orientation { get; private set; } = orientation;
    public Coordinate Position { get; private set; } = new(0,0);

    public void Forward()
    {
        var movement = Orientation switch
        {
            Direction.North => new Movement(+0, +1),
            Direction.East  => new Movement(+1, +0),
            Direction.South => new Movement(+0, -1),
            Direction.West  => new Movement(-1, +0),
            _ => new Movement(0, 0)
        };
        
        Position += movement;
    }

    public void Turn(Rotate rotate)
    {
        Orientation = (Orientation, rotate)  switch
        {
            (Direction.North, Rotate.Left)  => Direction.East,
            (Direction.East,  Rotate.Left)  => Direction.South,
            (Direction.South, Rotate.Left)  => Direction.West,
            (Direction.West,  Rotate.Left)  => Direction.North,
            (Direction.North, Rotate.Right) => Direction.West,
            (Direction.West,  Rotate.Right) => Direction.South,
            (Direction.South, Rotate.Right) => Direction.East,
            (Direction.East,  Rotate.Right) => Direction.North,
            _ => Orientation
        };
    }
}