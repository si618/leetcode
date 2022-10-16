namespace LeetCode.ConsoleApp;

internal sealed class SpectreReportBuilder
{
    public IEnumerable<Summary> Summaries { get; }

    public SpectreReportBuilder(IEnumerable<Summary> summaries)
    {
        Summaries = summaries;
    }

    public IRenderable Build()
    {
        var table = new Table
        {
            Border = TableBorder.Ascii2,
            BorderStyle = new Style(foreground: Color.Grey),
            UseSafeBorder = true
        };

        if (!Summaries.Any())
        {
            AnsiConsole.MarkupLine("[Warn]Warning:[/] No summaries found");
            return table;
        }

        foreach (var infoLine in Summaries.First().HostEnvironmentInfo.ToFormattedString())
        {
            SpectreLogger.Logger.WriteLine(infoLine);
        }

        var headers = BuildHeaders(table).ToArray();

        foreach (var summary in Summaries)
        {
            if (summary.Table.FullContent.Length == 0)
            {
                AnsiConsole.MarkupLine(
                $"[Warn]Warning:[/] No benchmarks found [yellow]'{summary.Title}'[/]");
                continue;
            }

            BuildSummary(summary, table, headers);
        }

        return table;
    }

    private IEnumerable<SummaryTable.SummaryTableColumn> BuildHeaders(Table table)
    {
        table.AddColumn("Lang");

        var headers = Summaries
            .SelectMany(s => s.Table.Columns)
            .Where(c => c.NeedToShow)
            .DistinctBy(c => c.Header)
            .ToArray();

        foreach (var header in headers)
        {
            table.AddColumn(header.Header, cfg => cfg.RightAligned());
        }

        // Language
        table.Columns[0].Centered();
        // Benchmark method
        table.Columns[1].LeftAligned();

        return headers;
    }

    private static void BuildSummary(
        Summary summary,
        Table table,
        IEnumerable<SummaryTable.SummaryTableColumn> headers)
    {
        var csharp = summary.Title.Contains(".CSharp.");
        var colour = csharp ? "[blue]" : "[green]";
        var columns = new List<string>
        {
            new (csharp ? $"{colour}C#[/]" : $"{colour}F#[/]")
        };
        columns.AddRange(
            headers
                .Select(header => header.Header)
                .Distinct());

        foreach (var line in summary.Table.FullContent)
        {
            for (var columnIndex = 0; columnIndex < summary.Table.ColumnCount; columnIndex++)
            {
                var column = summary.Table.Columns[columnIndex];
                if (!column.NeedToShow)
                {
                    continue;
                }

                var index = columns.IndexOf(column.Header);
                columns[index] = index >= 0
                    ? $"{colour}{line[columnIndex]}[/]"
                    : string.Empty;
            }
        }

        table.AddRow(columns.ToArray());
    }
}
