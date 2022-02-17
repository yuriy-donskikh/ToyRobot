namespace ToyRobotSimulator.Services.Services;

public class PlaceCommand : CommandBase
{
    private int _x = 0;
    private int _y = 0;
    private Direction _direction = Direction.NORTH;

    public PlaceCommand(IMapService map) : base(map)
    {
        _command = RobotCommand.PLACE;
    }

    public override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _map.SetAsync(_x, _y, _direction, cancellationToken);
    }

    public override async Task<bool> IsCommandAsync(string command, CancellationToken cancellationToken)
    {
        var parsed = ParseInternal(command);
        return await base.IsCommandAsync(parsed, cancellationToken) &&
            await _map.CanSetAsync(_x, _y, cancellationToken);
    }

    private string ParseInternal(string? command)
    {
        var splittedCommands = GetSplitted(command, ' ', ',').ToList();

        if (splittedCommands.Count < 1)
        {
            return string.Empty;
        }
        if (splittedCommands.Count == 1)
        {
            return string.Empty;
        }
        if (splittedCommands.Count() != 4) return string.Empty;
        if (!int.TryParse(splittedCommands[1], out _x)) return string.Empty;
        if (!int.TryParse(splittedCommands[2], out _y)) return string.Empty;
        if (!Enum.TryParse(splittedCommands[3], out _direction)) return string.Empty;

        return splittedCommands.First();
    }

    private static List<string> GetSplitted(string? command, params char[] delimiters)
    {
        var cmd = command?.Trim().ToUpper() ?? string.Empty;
        return cmd.Split(delimiters, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
    }

}
