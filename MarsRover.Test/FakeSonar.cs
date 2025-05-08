namespace MarsRover.Test;

internal class FakeSonar : ISonar
{
    public bool HasObstacle()
    {
        return false;
    }
}