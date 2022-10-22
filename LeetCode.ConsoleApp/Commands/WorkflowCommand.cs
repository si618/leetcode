namespace LeetCode.ConsoleApp.Commands;

internal sealed class WorkflowCommand : Command
{
    public override int Execute([NotNull] CommandContext context)
    {
        ConsoleWriter.WriteHeader(appendLine: true);

        if (BenchmarkRunner.IsDebugConfiguration(true))
        {
            return 1;
        }

        var settings = new BenchmarkSettings { CSharp = true, FSharp = true };
        var args = BuildWorkflowArgs();
        args.AddRange(settings.BuildArgs());
        BenchmarkRunner.RunBenchmarks(settings.BenchmarkTypes(), args.ToArray());
        CombineBenchmarkResults();

        return 0;
    }

    private static Type[] BuildTypes() =>
        Reflection.GetCSharpBenchmarkTypes()
            .Union(Reflection.GetFSharpBenchmarkTypes())
            .ToArray();

    private static List<string> BuildWorkflowArgs() =>
        new()
        {
            "--exporters", "json",
            "--memory"
        };

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

        var combinedReport = JsonNode.Parse(File.ReadAllText(reports.First()))!;
        var title = combinedReport["Title"]!;
        var benchmarks = combinedReport["Benchmarks"]!.AsArray();

        // Rename title whilst keeping original timestamp
        combinedReport["Title"] = $"{resultsFile}{title.GetValue<string>()[^16..]}";

        foreach (var report in reports.Skip(1))
        {
            var node = JsonNode.Parse(File.ReadAllText(report))!["Benchmarks"]!.AsArray();

            // Make pretty as only one method per benchmark - or tweak index.html
            var language = report.Contains("CSharp") ? "C#" : "F#";

            foreach (var benchmark in node.AsArray())
            {
                benchmark!["FullName"] = $"{benchmark["Method"]} in {language}";
                // Double parse avoids "The node already has a parent" exception
                benchmarks.Add(JsonNode.Parse(benchmark!.ToJsonString())!);
            }
        }

        File.WriteAllText(resultsPath, combinedReport.ToString());
    }
}
