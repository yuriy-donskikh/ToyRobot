namespace ToyRobotSimulator.Services.Services;

public class RotateCommand : CommandBase
{
    public RotateCommand(IMapService map) : base(map)
    {
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var rotate = _command == RobotCommand.LEFT ? Rotate.LEFT : Rotate.RIGHT;
        return _map.RotateAsync(rotate, cancellationToken);
    }

    public override async Task<bool> IsCommandAsync(string command, CancellationToken cancellationToken)
    {
        if(!Enum.TryParse(command, out RobotCommand cmd)) return false;
        if(cmd != RobotCommand.LEFT && cmd != RobotCommand.RIGHT) return false;
        _command = cmd;
        return true && await CanExecuteAsync(cancellationToken);
    }

    private async Task<bool> CanExecuteAsync(CancellationToken cancellationToken)
    {
        var (x, y, _) = await _map.ReportAsync(cancellationToken);
        return x != null && y != null;
    }

}
