namespace ToyRobotSimulator.Services.Services;

public class ReportCommand : CommandBase
{
    public ReportCommand(IMapService map) : base(map)
    {
        _command = RobotCommand.REPORT;
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        return _map.ReportAsync(cancellationToken);
    }

    public override async Task<string?> OutputAsync(CancellationToken cancellationToken)
    {
        var (x, y, direction) = await _map.ReportAsync(cancellationToken);
        
        var dir = direction == null ? string.Empty : Enum.GetName((Direction)direction!);
        return $"{x},{y},{dir}";
    }
}
