namespace ToyRobotSimulator.UnitTests.Fixtures;

public class MapFixture
{
    public Map GetEmptyMap()
    {
        return new Map(4, 4);
    }

    public Map MapLB(Direction direction)
    {
        var result = GetEmptyMap();
        result.Set(0, 0, direction);
        return result;
    }

    public Map MapRB(Direction direction)
    {
        var result = GetEmptyMap();
        result.Set(3, 0, direction);
        return result;
    }

    public Map MapLT(Direction direction)
    {
        var result = GetEmptyMap();
        result.Set(0, 3, direction);
        return result;
    }

    public Map MapRT(Direction direction)
    {
        var result = GetEmptyMap();
        result.Set(3, 3, direction);
        return result;
    }

    public Map MapM(Direction direction)
    {
        var result = GetEmptyMap();
        result.Set(1, 1, direction);
        return result;
    }
}
