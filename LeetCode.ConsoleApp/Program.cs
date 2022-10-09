var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<ConsoleAppCommand>("app")
        .WithDescription("Run interactive console application");
    config.AddCommand<BenchmarkCommand>("benchmark")
        .WithDescription("Run benchmarks against leetcode problems");
    config.AddCommand<ProblemInfoCommand>("problem")
        .WithDescription("Show information about a problem");
    config.AddCommand<ProblemListCommand>("list")
        .WithDescription("List information about problems");
});

await app.RunAsync(args);