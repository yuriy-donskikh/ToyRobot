IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services
            .AddSingleton<IMapService, MapService>()
            .AddTransient<ICommand, PlaceCommand>()
            .AddTransient<ICommand, MoveCommand>()
            .AddTransient<ICommand, RotateCommand>()
            .AddTransient<ICommand, ReportCommand>()
            
            .AddHostedService<Worker>()
            ;
    })
    .Build();

await host.RunAsync();
