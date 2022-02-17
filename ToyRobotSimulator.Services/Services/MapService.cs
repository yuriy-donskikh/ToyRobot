namespace ToyRobotSimulator.Services.Services;

public class MapService : IMapService
{
    private Lazy<Map> _map;

    public MapService(IOptions<MapConfiguration> config)
    {
        _map = new Lazy<Map>(() => new Map(config.Value.Height, config.Value.Length));
    }

    public Task<bool> SetAsync(int x, int y, Direction direction, CancellationToken cancellationToken)
    {
        return Task.Run(() => _map.Value.Set(x, y, direction), cancellationToken);
    }

    public Task RotateAsync(Rotate rotate, CancellationToken cancellationToken)
    {
        return Task.Run(() => _map.Value.Rotate(rotate), cancellationToken);
    }

    public Task<bool> CanSetAsync(int x, int y, CancellationToken cancellationToken)
    {
        return Task.Run(() => _map.Value.Find(x, y) != null, cancellationToken);
    }

    public Task<(int? X, int? Y, Direction? Direction)> ReportAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() => _map.Value.Report(), cancellationToken);
    }

    public Task<bool> CanMoveAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() => _map.Value.CanMove(), cancellationToken);
    }

    public Task MoveAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() => _map.Value.Move(), cancellationToken);
    }
}
