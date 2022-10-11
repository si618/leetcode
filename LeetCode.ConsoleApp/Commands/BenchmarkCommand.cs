namespace LeetCode.ConsoleApp.Commands;

internal sealed class BenchmarkCommand : Command<BenchmarkSettings>
{
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] BenchmarkSettings settings)
    {
        if (!IsDebug)
        {
            ConsoleWriter.WriteHeader(true);
            AnsiConsole.MarkupLine("[red]App must be in RELEASE configuration to run benchmarks[/]");

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

    private static bool IsDebug
    {
        get
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }

    private static string[] BuildArgs(BenchmarkSettings settings)
    {
        var args = new List<string> { "--filter" };

        // No filter means run all benchmarks
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
                // User added wildcard so use whatever they passed
                args.Add(settings.Filter);
            }
            else if (settings.Filter.Contains('.'))
            {
                // User added namespace but no wildcard
                args.Add($"{settings.Filter}*");
            }
            else
            {
                // No wildcard or namespace, so add wildcard prefix
                args.Add($"*{settings.Filter}");
            }
        }

        return args.ToArray();
    }

    private static IEnumerable<Summary> BuildSummaries(BenchmarkSettings settings, string[] args)
    {
        ConsoleWriter.WriteHeader(false);
        var consoleOut = Console.Out;
        Console.SetOut(TextWriter.Null);

        var summaries = new List<Summary>();

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start(WaitingMessage(settings), _ =>
                summaries.AddRange(RunBenchmarks(settings.BenchmarkTypes(), args)));

        Console.SetOut(consoleOut);

        return summaries;
    }

    private static string WaitingMessage(BenchmarkSettings settings)
    {
        var message = !settings.CSharp && !settings.FSharp
            ? "Running C# and F# benchmarks"
            : settings.CSharp
                ? "Running C# benchmarks"
                : "Running F# benchmarks";

        if (settings.Filter?.Length > 0)
        {
            message += $" matching [blue]{settings.Filter}[/]";
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
