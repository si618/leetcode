namespace LeetCode.ConsoleApp.Commands;

internal sealed class BenchmarkCommand : Command<BenchmarkSettings>
{
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] BenchmarkSettings settings)
    {
        if (IsDebugConfiguration())
        {
            return 1;
        }

        var args = BuildArgs(settings);
        var summaries = BuildSummaries(settings, args);
        var report = BuildReport(summaries);

        AnsiConsole.Write(report);

        return 0;
    }

    internal static IEnumerable<Summary> RunBenchmarks(Type[] types, string[] args) =>
        BenchmarkSwitcher.FromTypes(types).Run(args);

    internal static bool IsDebugConfiguration()
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

        ConsoleWriter.WriteHeader(true);
        AnsiConsole.MarkupLine(
        "[red]Error:[/] App must be in [yellow]RELEASE[/] configuration to run benchmarks");

        return true;
    }

    private static string[] BuildArgs(BenchmarkSettings settings)
    {
        var args = new List<string> { "--filter" };

        // No filter means run all benchmarks for specified options
        if (string.IsNullOrEmpty(settings.Filter))
        {
            if (settings.CSharp)
            {
                args.Add("LeetCode.CSharp*");
            }
            else if (settings.FSharp)
            {
                args.Add("LeetCode.FSharp*");
            }
            else
            {
                args.Add("LeetCode*");
            }
        }
        else
        {
            if (settings.Filter.Contains('*'))
            {
                // User added wildcard so use whatever was passed
                args.Add(settings.Filter);
            }
            else if (settings.Filter.Contains('.'))
            {
                // User added namespace but no wildcard so add suffix
                args.Add($"{settings.Filter}*");
            }
            else
            {
                // No wildcard or namespace so add wildcard prefix
                args.Add($"*{settings.Filter}");
            }
        }

        return args.ToArray();
    }

    private static IEnumerable<Summary> BuildSummaries(BenchmarkSettings settings, string[] args)
    {
        if (args.Length != 2)
        {
            throw new ArgumentOutOfRangeException(nameof(args));
        }

        ConsoleWriter.WriteHeader(false);
        var consoleOut = Console.Out;
        Console.SetOut(TextWriter.Null);

        var parsedFilter = args[1];
        var summaries = new List<Summary>();

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start(WaitingMessage(settings, parsedFilter), _ =>
                summaries.AddRange(RunBenchmarks(settings.BenchmarkTypes(), args)));

        Console.SetOut(consoleOut);

        return summaries;
    }

    private static string WaitingMessage(BenchmarkSettings settings, string parsedFilter)
    {
        var message = !settings.CSharp && !settings.FSharp
            ? "Running C# and F# benchmarks"
            : settings.CSharp
                ? "Running C# benchmarks"
                : "Running F# benchmarks";

        if (settings.Filter?.Length > 0)
        {
            message += $" matching [blue]{parsedFilter}[/]";
        }

        return message;
    }

    private static IRenderable BuildReport(IEnumerable<Summary> summaries)
    {
        var table = new Table();

        foreach (var summary in summaries)
        {
            var columns = summary.GetColumns();
            foreach (var column in columns)
            {
                table.AddColumn(column.ColumnName);
            }

            foreach (var report in summary.Reports)
            {
                foreach (var measurement in report.AllMeasurements)
                {
                    foreach (var column in columns)
                    {
                        // TODO
                        //var val = column.GetValue(summary, measurement);
                    }
                }
            }
        }

        return table;
    }
}
