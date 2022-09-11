namespace Benchmarks.CSharp;

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;

internal class RuntimeConfig : ManualConfig
{
    public RuntimeConfig()
    {
        AddDiagnoser(MemoryDiagnoser.Default);

        //AddJob(Job.Default.WithRuntime(CoreRuntime.Core70));
        AddJob(Job.Default.WithRuntime(CoreRuntime.Core60));

        AddColumn(StatisticColumn.OperationsPerSecond);
    }
}
