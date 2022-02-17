namespace ToyRobotSimulator.Services.Interfaces;

public interface ICommand
{
    Task ExecuteAsync(CancellationToken cancellationToken);
    Task<bool> IsCommandAsync(string command, CancellationToken cancellationToken);
    Task<string?> OutputAsync(CancellationToken cancellationToken);
}
