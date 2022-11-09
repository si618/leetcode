namespace LeetCode.CSharp;

public sealed class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        // FsUnit.xUnit has DEBUG reference
        WithOption(ConfigOptions.DisableOptimizationsValidator, true);

        AddDiagnoser(MemoryDiagnoser.Default);

        AddColumn(StatisticColumn.OperationsPerSecond);
    }
}
