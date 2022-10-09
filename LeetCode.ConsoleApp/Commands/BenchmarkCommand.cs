namespace LeetCode.ConsoleApp.Commands;

using Spectre.Console.Rendering;

internal sealed class BenchmarkCommand : Command<BenchmarkSettings>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] BenchmarkSettings settings)
    {
        if (IsDebugRelease)
        {
            ConsoleWriter.WriteHeader(true);
            AnsiConsole.MarkupLine("[red]App must be in RELEASE configuration to run benchmarks[/]");
            Console.ReadLine();
            return 1;
        }

        var args = BuildArgs(settings);

        var summaries = RunBenchmarks(settings, args);

        var report = BuildReport(summaries);

        AnsiConsole.Write(report);

        return 0;
    }

    private static bool IsDebugRelease
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
                // User added wildcard
                args.Add(settings.Filter);
            }
            else if (settings.Filter.Contains('.'))
            {
                // User added namespace
                args.Add($"{settings.Filter}*");
            }
            else
            {
                args.Add($"*{settings.Filter}");
            }
        }

        return args.ToArray();
    }

    private static IEnumerable<Summary> RunBenchmarks(BenchmarkSettings settings, string[] args)
    {
        ConsoleWriter.WriteHeader(false);
        var consoleOut = Console.Out;
        Console.SetOut(TextWriter.Null);

        var summaries = new List<Summary>();

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start(settings.WaitingMessage(), _ =>
                summaries.AddRange(BenchmarkSwitcher
                    .FromTypes(settings.BenchmarkTypes())
                    .Run(args)));

        Console.SetOut(consoleOut);

        return summaries;
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
