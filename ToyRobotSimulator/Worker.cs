namespace ToyRobotSimulator;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
            var command = Console.ReadLine()?.Trim().ToUpper();
            var output = await RunCommandAsync(command, stoppingToken);
            if (!string.IsNullOrEmpty(output))
            {
                Console.WriteLine(output);
            }
        }
    }

    private async Task<string?> RunCommandAsync(string? command, CancellationToken cancellationToken)
    {
        try
        {
            var commandService = _serviceProvider.GetServices<ICommand>();

            foreach (var service in commandService)
            {
                if (await service.IsCommandAsync(command ?? string.Empty, cancellationToken))
                {
                    await service.ExecuteAsync(cancellationToken);
                    return await service.OutputAsync(cancellationToken);
                }
            }
            throw new CommandException(command);
        }
        catch (CommandException ex)
        {
            _logger.LogInformation(ex.Message);
            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Exception is happened!");
            return null;
        }
    }
}
