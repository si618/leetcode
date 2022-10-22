namespace LeetCode.Commands;

internal sealed class WorkflowCommand : Command
{
    public override int Execute([NotNull] CommandContext context)
    {
        ConsoleWriter.WriteHeader(appendLine: true);

        if (BenchmarkRunner.IsDebugConfiguration(true))
        {
            return 1;
        }

        var settings = new BenchmarkSettings { Exporters = "json" };
        BenchmarkRunner.RunBenchmarks(settings.BenchmarkTypes(), settings.BuildArgs());
        CombineBenchmarkResults();

        return 0;
    }

    private static void CombineBenchmarkResults(
        string resultsDir = "./BenchmarkDotNet.Artifacts/results",
        string resultsFile = "LeetCode.Benchmarks",
        string searchPattern = "LeetCode.*.json")
    {
        var resultsPath = Path.Combine(resultsDir, resultsFile + ".json");

        if (!Directory.Exists(resultsDir))
        {
            throw new DirectoryNotFoundException($"Directory not found '{resultsDir}'");
        }

        if (File.Exists(resultsPath))
        {
            File.Delete(resultsPath);
        }

        const string ns = "LeetCode.XSharp.Benchmarks.";
        var reports = Directory
            .GetFiles(resultsDir, searchPattern, SearchOption.TopDirectoryOnly)
            .OrderBy(report => report)
            .ThenBy(report => report[..ns.Length])
            .ToArray();
        if (!reports.Any())
        {
            throw new FileNotFoundException($"Reports not found '{searchPattern}'");
        }

        var firstReport = reports.First();
        var combinedReport = JsonNode.Parse(File.ReadAllText(firstReport))!;
        var title = combinedReport["Title"]!;
        var benchmarks = combinedReport["Benchmarks"]!.AsArray();
        SetBenchmarkName(firstReport, combinedReport["Benchmarks"]![0]!);

        // Rename title whilst keeping original timestamp
        combinedReport["Title"] = $"{resultsFile}{title.GetValue<string>()[^16..]}";

        foreach (var report in reports.Skip(1))
        {
            var node = JsonNode.Parse(File.ReadAllText(report))!["Benchmarks"]!;
            SetBenchmarkName(report, node[0]!);

            foreach (var benchmark in node.AsArray())
            {
                // Double parse avoids "The node already has a parent" exception
                benchmarks.Add(JsonNode.Parse(benchmark!.ToJsonString())!);
            }
        }

        File.WriteAllText(resultsPath, combinedReport.ToString());
    }

    private static void SetBenchmarkName(string report, JsonNode benchmark)
    {
        // Make pretty as only one method per benchmark - or tweak index.html?
        var language = report.Contains("CSharp") ? "C#" : "F#";
        benchmark["FullName"] = $"{benchmark["Method"]} in {language}";
    }
}
