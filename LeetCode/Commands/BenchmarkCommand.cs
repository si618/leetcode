﻿namespace LeetCode.Commands;

internal sealed class BenchmarkCommand : Command<BenchmarkSettings>
{
    [SuppressMessage("ReSharper", "RedundantNullableFlowAttribute")]
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] BenchmarkSettings settings)
    {
        try
        {
            ConsoleWriter.WriteHeader();

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
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
            return -99;
        }
    }
}
