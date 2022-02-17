namespace ToyRobotSimulator.Services.Services;

public class MoveCommand : CommandBase
{
    public MoveCommand(IMapService map) : base(map)
    {
        _command = RobotCommand.MOVE;
    }

    public override async Task<bool> IsCommandAsync(string command, CancellationToken cancellationToken)
    {
        return await base.IsCommandAsync(command, cancellationToken) &&
            await _map.CanMoveAsync(cancellationToken);
    }

    public override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        return _map.MoveAsync(cancellationToken);
    }
}
