namespace LeetCode.ConsoleApp.Commands;

internal sealed class WorkflowCommand : Command<WorkflowSettings>
{
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] WorkflowSettings settings)
    {
        if (BenchmarkCommand.IsDebug())
        {
            return 1;
        }

        ConsoleWriter.WriteHeader(appendLine: true);

        BenchmarkCommand.RunBenchmarks(BuildTypes(), BuildArgs(settings));

        // TODO Combine benchmark results into single JSON for github-action-benchmark

        return 0;
    }

    private static Type[] BuildTypes()
    {
        var types = new List<Type>
        {
            typeof(CSharp.Benchmarks.Benchmark)
        };
        types.AddRange(Reflection.GetFSharpBenchmarkTypes());

        return types.ToArray();
    }

    private static string[] BuildArgs(WorkflowSettings settings)
    {
        var args = new List<string>();

        if (!string.IsNullOrEmpty(settings.Filter))
        {
            args.Add("--filter");
            args.Add(settings.Filter);
        }

        if (!string.IsNullOrEmpty(settings.Exporters))
        {
            args.Add("--exporters");
            args.Add(settings.Exporters);
        };

        if (settings.Memory)
        {
            args.Add("--memory");
        }

        return args.ToArray();
    }
}
