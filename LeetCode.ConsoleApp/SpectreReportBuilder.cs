namespace LeetCode.ConsoleApp;

using System.Net.WebSockets;

internal sealed class SpectreReportBuilder
{
    private IEnumerable<Summary> Summaries { get; }

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
            AnsiConsole.MarkupLine("[orange1]Warning:[/] No benchmark summaries found");
            return new Text(string.Empty);
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
                $"[orange1]Warning:[/] No benchmark reports found [yellow]'{summary.Title}'[/]");
                continue;
            }

            BuildSummary(summary, table, headers);
        }

        return table;
    }

    private IEnumerable<string> BuildHeaders(Table table)
    {
        // Default column benchmarks via BenchmarkConfig and summaries in their expected order
        var defaultHeaders = new[]
        {
            "Lang", "Method", "Mean", "Median", "Error", "StdDev", "Op/s", "Gen0", "Gen1", "Gen2",
            "Allocated"
        };

        var summaryHeaders = Summaries
            .SelectMany(s => s.Table.Columns)
            .Where(c => c.NeedToShow)
            .DistinctBy(c => c.Header)
            .Select(c => c.Header)
            .ToList();

        // This could be a BenchmarkDotNet custom column instead of manual insertion
        summaryHeaders.Insert(0, "Lang");

        // First take the intersection of defaults and summaries, which ensures all columns are
        // included in their expected order, then append any remaining columns in summaries
        var headers = defaultHeaders
            .Intersect(summaryHeaders)
            .Union(summaryHeaders)
            .Distinct()
            .ToArray();

        foreach (var header in headers)
        {
            table.AddColumn(header, cfg => cfg.RightAligned());
        }

        // Language
        table.Columns[0].Centered();
        // Method
        table.Columns[1].LeftAligned();

        return headers;
    }

    private static void BuildSummary(Summary summary, Table table, IList<string> headers)
    {
        var csharp = summary.Title.Contains(".CSharp.");
        var colour = csharp ? "[blue]" : "[teal]";
        var language = csharp ? $"{colour}C#[/]" : $"{colour}F#[/]";

        foreach (var line in summary.Table.FullContent)
        {
            var columns = new string[headers.Count];
            columns[0] = language;
            for (var i = 1; i < headers.Count; i++)
            {
                columns[i] = string.Empty;
            }

            for (var columnIndex = 0; columnIndex < summary.Table.ColumnCount; columnIndex++)
            {
                var column = summary.Table.Columns[columnIndex];

                if (!column.NeedToShow)
                {
                    continue;
                }

                var index = headers.IndexOf(column.Header);
                if (index > 0)
                {
                    columns[index] = $"{colour}{line[columnIndex]}[/]";
                }
            }

            table.AddRow(columns.ToArray());
        }
    }
}
