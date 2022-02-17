namespace ToyRobotSimulator.Services.Services;

public abstract class CommandBase : ICommand
{
    protected readonly IMapService _map;
    protected RobotCommand? _command;

    public CommandBase(IMapService map)
    {
        _map = map;
    }

    public abstract Task ExecuteAsync(CancellationToken cancellationToken);

    public virtual Task<bool> IsCommandAsync(string command, CancellationToken cancellationToken)
    {
        return Task.Run(() => command.Equals(
            Enum.GetName((RobotCommand)(_command!)),
            StringComparison.InvariantCultureIgnoreCase),
            cancellationToken);
    }

    public virtual Task<string?> OutputAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult<string?>(null);
    }
}
