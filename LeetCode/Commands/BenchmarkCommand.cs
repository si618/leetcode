namespace LeetCode.Commands;

internal sealed class BenchmarkCommand : Command<BenchmarkSettings>
{
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] BenchmarkSettings settings)
    {
        ConsoleWriter.WriteHeader(appendLine: true);

        if (BenchmarkRunner.IsDebugConfiguration(settings.Debug))
        {
            return 1;
        }

        var summaries = BenchmarkRunner.BuildSummaries(settings);
        var builder = new SpectreReportBuilder(summaries);
        var report = builder.Build();

        AnsiConsole.Write(report);

        AnsiConsole.WriteLine();

        return 0;
    }
}
