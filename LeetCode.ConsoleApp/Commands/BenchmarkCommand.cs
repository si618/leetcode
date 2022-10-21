namespace LeetCode.ConsoleApp.Commands;

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

        var args = BenchmarkRunner.BuildArgs(settings);
        var summaries = BenchmarkRunner.BuildSummaries(settings, args);
        var builder = new SpectreReportBuilder(summaries);
        var report = builder.Build();

        AnsiConsole.Write(report);

        return 0;
    }
}
