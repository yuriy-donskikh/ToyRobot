namespace ToyRobotSimulator.UnitTests.Models;

public class Map:IClassFixture<MapFixture>
{
    private readonly MapFixture _map;

    public Map(MapFixture map)
    {
        _map = map;
    }

    [Fact]
    public void Set()
    {
        //Arrange
        var map = _map.GetEmptyMap();
        //Act
        map.Set(2, 1, Direction.SOUTH);
        var (x, y, direction) = map.Report();

        //Assert
        Assert.Equal(2, x);
        Assert.Equal(1, y);
        Assert.Equal(Direction.SOUTH, direction);
    }

    [Fact]
    public void SetOutOfRange()
    {
        //Arrange
        var map1 = _map.GetEmptyMap();
        var map2 = _map.GetEmptyMap();
        var map3 = _map.GetEmptyMap();

        //Act
        map1.Set(-1, -1, Direction.NORTH);
        map2.Set(4, 4, Direction.WEST);
        map3.Set(3, 4, Direction.EAST);
        var (x1, y1, _) = map1.Report();
        var (x2, y2, _) = map1.Report();
        var (x3, y3, _) = map1.Report();

        //Assert
        Assert.Null(x1); Assert.Null(y1);
        Assert.Null(x2); Assert.Null(y2);
        Assert.Null(x3); Assert.Null(y3);
    }

    [Fact]
    public void Move()
    {
        //Arrange
        var map = _map.MapM(Direction.NORTH);
        var map1 = _map.MapM(Direction.NORTH);
        var map2 = _map.MapM(Direction.SOUTH);
        var map3 = _map.MapM(Direction.EAST);
        var map4 = _map.MapM(Direction.WEST);

        //Act
        var (x, y, _) = map.Report();
        map1.Move();
        var (x1, y1, _) = map1.Report();
        map2.Move();
        var (x2, y2, _) = map2.Report();
        map3.Move();
        var (x3, y3, _) = map3.Report();
        map4.Move();
        var (x4, y4, _) = map4.Report();

        //Assert
        Assert.Equal(x, x1); Assert.Equal(y + 1, y1);
        Assert.Equal(x, x2); Assert.Equal(y - 1, y2);
        Assert.Equal(x + 1, x3); Assert.Equal(y, y3);
        Assert.Equal(x - 1, x4); Assert.Equal(y, y4);
    }

    [Fact]
    public void MoveOutOfRange()
    {
        //Arrange
        var map1 = _map.MapLB(Direction.SOUTH);
        var map2 = _map.MapLT(Direction.WEST);
        var map3 = _map.MapRT(Direction.NORTH);
        var map4 = _map.MapRB(Direction.EAST);

        //Act
        map1.Move();
        var (x1, y1, _) = map1.Report();
        map2.Move();
        var (x2, y2, _) = map2.Report();
        map3.Move();
        var (x3, y3, _) = map3.Report();
        map4.Move();
        var (x4, y4, _) = map4.Report();

        //Assert
        Assert.Equal(0, x1); Assert.Equal(0, y1);
        Assert.Equal(0, x2); Assert.Equal(3, y2);
        Assert.Equal(3, x3); Assert.Equal(3, y3);
        Assert.Equal(3, x4); Assert.Equal(0, y4);
    }

    [Fact]
    public void MapRotate()
    {
        //Arrange
        var map = _map.MapM(Direction.NORTH);

        //Act
        map.Rotate(Rotate.LEFT);
        var (_, _, dl1) = map.Report();
        map.Rotate(Rotate.LEFT);
        var (_, _, dl2) = map.Report();
        map.Rotate(Rotate.LEFT);
        var (_, _, dl3) = map.Report();
        map.Rotate(Rotate.LEFT);
        var (_, _, dl4) = map.Report();

        map.Rotate(Rotate.RIGHT);
        var (_, _, dr1) = map.Report();
        map.Rotate(Rotate.RIGHT);
        var (_, _, dr2) = map.Report();
        map.Rotate(Rotate.RIGHT);
        var (_, _, dr3) = map.Report();
        map.Rotate(Rotate.RIGHT);
        var (_, _, dr4) = map.Report();

        //Assert
        Assert.Equal(Direction.WEST, dl1);
        Assert.Equal(Direction.SOUTH, dl2);
        Assert.Equal(Direction.EAST, dl3);
        Assert.Equal(Direction.NORTH, dl4);

        Assert.Equal(Direction.EAST, dr1);
        Assert.Equal(Direction.SOUTH, dr2);
        Assert.Equal(Direction.WEST, dr3);
        Assert.Equal(Direction.NORTH, dr4);
    }

    [Fact]
    public void ReportOutOfRange()
    {
        //Arrange
        var map = _map.GetEmptyMap();

        //Act
        var (x, y, d) = map.Report();

        //Assert
        Assert.Null(x);
        Assert.Null(y);
        Assert.Null(d);
    }

    [Fact]
    public void Find()
    {
        //Arrange
        var map = _map.GetEmptyMap();

        //Act
        var cell0 = map.Find(2, 2);
        var cell1 = map.Find(-1, 2);
        var cell2 = map.Find(2, -1);
        var cell3 = map.Find(4, 2);
        var cell4 = map.Find(2, 4);

        //Assert
        Assert.Equal(cell0, new Cell(2, 2));
        Assert.Null(cell1);
        Assert.Null(cell2);
        Assert.Null(cell3);
        Assert.Null(cell4);
    }

    [Fact]
    public void CanMove()
    {
        //Arrange
        var map1 = _map.MapLB(Direction.NORTH);
        var map2 = _map.MapLT(Direction.EAST);
        var map3 = _map.MapRT(Direction.SOUTH);
        var map4 = _map.MapRB(Direction.WEST);

        //Act
        var c1 = map1.CanMove();
        var c2 = map2.CanMove();
        var c3 = map3.CanMove();
        var c4 = map4.CanMove();

        //Assert
        Assert.True(c1);
        Assert.True(c2);
        Assert.True(c3);
        Assert.True(c4);
    }

    [Fact]
    public void CanMoveNegative()
    {
        //Arrange
        var map = _map.GetEmptyMap();
        var map1 = _map.MapLB(Direction.SOUTH);
        var map2 = _map.MapLT(Direction.WEST);
        var map3 = _map.MapRT(Direction.NORTH);
        var map4 = _map.MapRB(Direction.EAST);

        //Act
        var c = map.CanMove();
        var c1 = map1.CanMove();
        var c2 = map2.CanMove();
        var c3 = map3.CanMove();
        var c4 = map4.CanMove();

        //Assert
        Assert.False(c);
        Assert.False(c1);
        Assert.False(c2);
        Assert.False(c3);
        Assert.False(c4);
    }
}
