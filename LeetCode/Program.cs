using LeetCode;

var app = new CommandApp();

app.Configure(config =>
{
    config.SetApplicationName("LeetCode.exe");

    config.AddCommand<AppCommand>(Resources.Command_App)
        .WithDescription(Resources.Command_App_Description);

    config.AddCommand<BenchmarkCommand>(Resources.Command_Benchmark)
        .WithDescription(Resources.Command_Benchmark_Description);

    config.AddCommand<InfoCommand>(Resources.Command_Info)
        .WithDescription(Resources.Command_Info_Description);

    config.AddCommand<ListCommand>(Resources.Command_List)
        .WithDescription(Resources.Command_List_Description);

    config.AddCommand<WorkflowCommand>(Resources.Command_Workflow)
        .WithDescription(Resources.Command_Workflow_Description);

    config.AddExample(new[] { Resources.Command_Benchmark, "LRUCache", "--csharp" });
    config.AddExample(new[] { Resources.Command_Info, "MergeTwoLists" });
});

return await app.RunAsync(args);
