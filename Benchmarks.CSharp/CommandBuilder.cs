namespace Benchmarks.CSharp;

using BenchmarkDotNet.Running;
using System.CommandLine;
using System.Reflection;

internal static class CommandBuilder
{
    public static RootCommand BuildRootCommand(IEnumerable<string> args)
    {
        Option<bool> noBenchmarkOption = new(
            name: "--no-benchmark",
            description: "Do not run benchmarks");

        const string description = @"Benchmark C# LeetCode problems using BenchmarkDotNet
See: https://benchmarkdotnet.org/articles/guides/console-args.html";
        var rootCommand = new RootCommand(description) { noBenchmarkOption };

        // Allow arguments to pass through to BenchmarkDotNet
        // as that will fail and report any invalid arguments
        rootCommand.TreatUnmatchedTokensAsErrors = false;

        // Exclude known options from being passed to BenchmarkDotNet
        var excludeArgs = new[] { noBenchmarkOption.Name };
        var benchmarkArgs = args.Except(excludeArgs).ToArray();

        rootCommand.SetHandler(noBenchmark =>
            DoRootCommand(!noBenchmark, benchmarkArgs), noBenchmarkOption);

        return rootCommand;
    }

    private static void DoRootCommand(bool runBenchmark, string[] benchmarkArgs)
    {
        ConsoleWriter.WriteHeader();
        ConsoleWriter.WriteProblems();

        if (runBenchmark)
        {
            BenchmarkSwitcher
                .FromAssembly(Assembly.GetExecutingAssembly())
                .Run(benchmarkArgs);
        }
    }
}
