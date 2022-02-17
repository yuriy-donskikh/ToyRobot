namespace ToyRobotSimulator.Services.Models;

public class Map
{
    private readonly List<Cell> _cells;
    private Cell? _position;
    private Cell? _moveTo;
    private Direction? _direction;

    public Map(int height, int length)
    {
        _cells = Initialize(height, length);
    }

    public bool Set(int x, int y, Direction direction)
    {
        _direction = direction;
        _position = Find(x, y);
        _moveTo = SetMoveTo(x, y, direction);
        return _position != null;
    }

    public void Move()
    {
        if(_moveTo == null || _direction == null) return;
        Set(_moveTo.X, _moveTo.Y, (Direction)(_direction!));
    }

    public void Rotate(Rotate rotate)
    {
        if(_direction == null || _position == null) return;
        switch (_direction)
        {
            case Direction.NORTH:
                _direction = rotate == Models.Rotate.LEFT ? Direction.WEST : Direction.EAST;
                break;
            case Direction.SOUTH:
                _direction = rotate == Models.Rotate.LEFT ? Direction.EAST : Direction.WEST;
                break;
            case Direction.EAST:
                _direction = rotate == Models.Rotate.LEFT ? Direction.NORTH : Direction.SOUTH;
                break;
            case Direction.WEST:
                _direction = rotate == Models.Rotate.LEFT ? Direction.SOUTH : Direction.NORTH;
                break;
        }
        _moveTo = SetMoveTo(_position.X, _position.Y, (Direction)_direction);
    }

    public (int? X, int? Y, Direction? Direction) Report()
    {
        return (_position?.X, _position?.Y, _direction);
    }

    public Cell? Find(int x, int y)
    {
        foreach (var cell in _cells)
        {
            if (cell == new Cell(x, y)) return cell;
        }
        return null;
    }

    public bool CanMove()
    {
        return _moveTo != null;
    }

    private static List<Cell> Initialize(int height, int length)
    {
        var result = new List<Cell>();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < length; x++)
            {
                result.Add(new Cell(x, y));
            }
        }
        return result;
    }

    private Cell? SetMoveTo(int x, int y, Direction direction)
    {
        return direction switch
        {
            Direction.NORTH => Find(x, y + 1),
            Direction.EAST => Find(x + 1, y),
            Direction.SOUTH => Find(x, y - 1),
            Direction.WEST => Find(x - 1, y),
            _ => null,
        };
    }
}
