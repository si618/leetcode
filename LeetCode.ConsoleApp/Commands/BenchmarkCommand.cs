namespace LeetCode.ConsoleApp.Commands;

internal sealed class BenchmarkCommand : Command<BenchmarkCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Filter by LeetCode.[C|F]Sharp.Benchmarks.<Name> (* wildcards accepted)")]
        [CommandArgument(0, "[filter]")]
        public string? Filter{ get; init; }

        [Description("Only run C# benchmarks")]
        [CommandOption("--csharp")]
        public bool CSharp { get; init; }

        [Description("Only run F# benchmarks")]
        [CommandOption("--fsharp")]
        public bool FSharp { get; init; }

        public override ValidationResult Validate()
        {
            return CSharp && FSharp
                ? ValidationResult.Error("CSharp and FSharp options are mutually exclusive")
                : ValidationResult.Success();
        }

        public Type[] BenchmarkTypes()
        {
            var types = new List<Type>();

            if (CSharp)
            {
                types.Add(typeof(CSharp.Benchmarks.Benchmark));
            }

            if (FSharp)
            {
                types.AddRange(Reflection.GetFSharpBenchmarkTypes());
            }

            return types.ToArray();
        }

        public string WaitingMessage()
        {
            var message = !CSharp && !FSharp
                ? "Running C# and F# benchmarks"
                : CSharp
                    ? "Running C# benchmarks"
                    : "Running F# benchmarks";

            if (Filter?.Length > 0)
            {
                message += $" matching [blue]{Filter}[/]";
            }

            return message;
        }

    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        if (IsDebugRelease)
        {
            ConsoleWriter.WriteHeader(true);
            AnsiConsole.MarkupLine("[red]App must be in RELEASE configuration to run benchmarks[/]");
            Console.ReadLine();
            return 1;
        }

        var args = new[] { "--filter", settings.Filter };

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

        foreach (var summary in summaries)
        {
            var table = new Table();
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

            AnsiConsole.Write(table);
        }

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
}
