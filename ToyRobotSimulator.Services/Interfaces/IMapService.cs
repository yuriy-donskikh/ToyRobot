namespace ToyRobotSimulator.Services.Interfaces;

public interface IMapService
{
    Task<(int? X, int? Y, Direction? Direction)> ReportAsync(CancellationToken cancellationToken);
    Task RotateAsync(Rotate rotate, CancellationToken cancellationToken);
    Task<bool> CanSetAsync(int x, int y, CancellationToken cancellationToken);
    Task<bool> SetAsync(int x, int y, Direction direction, CancellationToken cancellationToken);
    Task<bool> CanMoveAsync(CancellationToken cancellationToken);
    Task MoveAsync(CancellationToken cancellationToken);
}
