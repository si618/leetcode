using Benchmarks.CSharp;
using System.CommandLine;

await CommandBuilder.BuildRootCommand(args).InvokeAsync(args);
