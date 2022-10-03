namespace LeetCode.ConsoleApp;

// public static class CommandBuilder
// {
//     public static RootCommand BuildRootCommand(IEnumerable<string> args)
//     {
//         Option<bool> summaryOption = new(
//             name: "--problems",
//             description: "Show problem summary without running benchmarks");
//
//         Option<string> problemOption = new(
//             name: "--problem",
//             description: "Show details for problem without running benchmarks");
//
//         const string description = @"Benchmark C# LeetCode problems using BenchmarkDotNet
// See: https://benchmarkdotnet.org/articles/guides/console-args.html";
//         var rootCommand = new RootCommand(description) { summaryOption, problemOption };
//
//         // Allow arguments to pass through to BenchmarkDotNet
//         // as that will fail and report any invalid arguments
//         rootCommand.TreatUnmatchedTokensAsErrors = false;
//
//         // Exclude known options from being passed to BenchmarkDotNet
//         var excludeArgs = new[] { summaryOption.Name, problemOption.Name };
//         var benchmarkArgs = args.Except(excludeArgs).ToArray();
//
//         rootCommand.SetHandler((summary, problem) =>
//             DoRootCommand(summary, benchmarkArgs, problem), summaryOption, problemOption);
//
//         return rootCommand;
//     }
//
//     private static void DoRootCommand(bool summary, string[] benchmarkArgs, string problem)
//     {
//         ConsoleWriter.WriteHeader();
//
//         switch (summary)
//         {
//             case false when string.IsNullOrEmpty(problem):
//                 if (IsDebugRelease)
//                 {
//                     AnsiConsole.MarkupLine(
//                         "[red]Unable to benchmark as app is running in DEBUG configuration[/]");
//                     return;
//                 }
//                 BenchmarkSwitcher
//                     .FromTypes(new[] { typeof(CSharp.Benchmarks), typeof(FSharp.Benchmarks) })
//                     .Run(benchmarkArgs);
//                 return;
//             case true:
//                 ConsoleWriter.WriteProblems();
//                 break;
//         }
//
//         if (!string.IsNullOrWhiteSpace(problem))
//         {
//             ConsoleWriter.WriteProblemDetail(problem);
//         }
//     }
//
//     private static bool IsDebugRelease
//     {
//         get
//         {
// #if DEBUG
//             return true;
// #else
//             return false;
// #endif
//         }
//     }
// }
