namespace LeetCode;

internal static class BenchmarkRunner
{
    public static IEnumerable<Summary> BuildSummaries(BenchmarkSettings settings)
    {
        var args = settings.BuildArgs();
        if (args.Length != 2)
        {
            // ReSharper disable once LocalizableElement - Exceptions in English
            throw new ArgumentOutOfRangeException(nameof(settings), "Invalid arguments");
        }

        Console.SetOut(TextWriter.Null);

        var parsedFilter = ParseFilterForBenchmark(args[1]);

        var summaries = new List<Summary>();
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start(WaitingMessage(settings, parsedFilter), _ =>
                summaries.AddRange(RunBenchmarks(settings.BenchmarkTypes(), args)));

        Console.SetOut(Console.Out);

        return summaries;
    }

    public static IEnumerable<Summary> RunBenchmarks(Type[] types, string[] args) =>
        BenchmarkSwitcher.FromTypes(types).Run(args);

    private static string WaitingMessage(BenchmarkSettings settings, string parsedFilter)
    {
        var message = new StringBuilder();

        if (Reflection.TryGetProblem(parsedFilter, out var problem))
        {
            var language = problem.Language($" {Resources.Problem_Language_Separator} ");
            var benchmark = problem.CSharp & problem.FSharp
                ? Resources.Benchmark_Plural : Resources.Benchmark_Singular;
            message.AppendFormat(Resources.BenchmarkRunner_SingleProblem_Markup,
                language, benchmark, problem.Name);
        }
        else
        {
            message.Append(!settings.CSharp && !settings.FSharp
                ? Resources.BenchmarkRunner_Running_BothBenchmarks
                : settings.CSharp
                    ? Resources.BenchmarkRunner_Running_CSharpBenchmarks
                    : Resources.BenchmarkRunner_Running_FSharpBenchmarks);

            if (settings.Filter?.Length > 0)
            {
                message.AppendFormat(
                    Resources.BenchmarkRunner_Running_FilterSuffix_Markup, settings.Filter!);
            }
        }

        return message.ToString();
    }

    internal static bool IsDebugConfiguration(bool warnRatherThanFail = false)
    {
        var debug = false;

#if DEBUG
        debug = true;
#else
        debug = false;
#endif

        if (!debug)
        {
            return false;
        }

        if (warnRatherThanFail)
        {
            AnsiConsole.MarkupLine(
                "[orange1]Warning:[/] App should be in [yellow]RELEASE[/] configuration to run benchmarks");

            AnsiConsole.WriteLine();

            return false;
        }

        AnsiConsole.MarkupLine(
            "[red]Error:[/] App must be in [yellow]RELEASE[/] configuration to run benchmarks");

        AnsiConsole.WriteLine();

        return true;
    }

    private static string ParseFilterForBenchmark(string filter)
    {
        var benchmark = filter.Trim('*');
        var found = Reflection.GetCSharpBenchmarks()
            .FirstOrDefault(b => b.Equals(benchmark, StringComparison.OrdinalIgnoreCase));
        return found ?? filter;
    }
}
