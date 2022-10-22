namespace LeetCode.CSharp;

public sealed class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        // FsUnit.xUnit has DEBUG reference
        WithOption(ConfigOptions.DisableOptimizationsValidator, true);

        AddDiagnoser(MemoryDiagnoser.Default);

        //AddJob(Job.Default.WithRuntime(CoreRuntime.Core70));
        AddJob(Job.Default.WithRuntime(CoreRuntime.Core60));

        AddColumn(StatisticColumn.OperationsPerSecond);
    }
}
