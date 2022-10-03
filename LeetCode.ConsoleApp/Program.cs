var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<ConsoleAppCommand>("app");
    config.AddCommand<BenchmarkCommand>("benchmark");
    config.AddCommand<ProblemInfoCommand>("problem");
    config.AddCommand<ProblemListCommand>("list");
});

await app.RunAsync(args);