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

        public Type[] BenchmarkTypes() =>
            !CSharp && !FSharp
                ? new[] { typeof(Benchmarks), typeof(FSharp.Benchmarks) }
                : CSharp
                    ? new[] { typeof(Benchmarks) }
                    : new[] { typeof(FSharp.Benchmarks) };
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
            AnsiConsole.WriteLine(summary.Title);
            foreach (var report in summary.Reports)
            {
            }
            foreach (var column in summary.GetColumns())
            {
            }
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
