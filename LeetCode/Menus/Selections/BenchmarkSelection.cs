namespace LeetCode.Menus.Selections;

internal sealed record BenchmarkSelection : Selection
{
    private Problem Problem { get; }

    internal BenchmarkSelection(Problem problem, int order)
        : this(problem, Resources.Selection_RunBenchmark, order)
    {
    }

    private BenchmarkSelection(Problem problem, string name, int order)
        : base(name, order)
    {
        Problem = problem;
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true);

        if (BenchmarkRunner.IsDebugConfiguration(true))
        {
            return 1;
        }

        var settings = new BenchmarkSettings { Filter = Problem.Name };
        var summaries = BenchmarkRunner.BuildSummaries(settings);
        var builder = new SpectreReportBuilder(summaries);
        var report = builder.Build();

        AnsiConsole.Write(report);

        ConsoleWriter.WaitForKeyPress();

        return 0;
    }
}