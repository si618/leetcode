var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<AppCommand>("app")
        .WithDescription("Run interactive console application");
    config.AddCommand<BenchmarkCommand>("benchmark")
        .WithDescription("Run benchmarks against leetcode problems");
    config.AddCommand<InfoCommand>("info")
        .WithDescription("Show information about a problem");
    config.AddCommand<ListCommand>("list")
        .WithDescription("List information about problems");
});

return await app.RunAsync(args);