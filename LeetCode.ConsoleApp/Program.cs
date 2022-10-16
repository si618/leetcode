var app = new CommandApp();

app.Configure(config =>
{
    config.SetApplicationName("LeetCode.exe");
    config.AddCommand<AppCommand>("app")
        .WithDescription("Run interactive console application");
    config.AddCommand<BenchmarkCommand>("benchmark")
        .WithDescription("Run benchmarks against leetcode problems");
    config.AddCommand<InfoCommand>("info")
        .WithDescription("Show information about a problem");
    config.AddCommand<ListCommand>("list")
        .WithDescription("List information about problems");
    config.AddCommand<WorkflowCommand>("workflow")
        .WithDescription("Run benchmarks for GitHub workflow");
    config.AddExample(new[] { "benchmark", "LRUCache", "--csharp" });
    config.AddExample(new[] { "info", "MergeTwoLists" });
});

return await app.RunAsync(args);