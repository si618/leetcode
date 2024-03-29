﻿namespace LeetCode.Commands;

internal sealed class BenchmarkSettings : CommandSettings
{
    [Description("Filter by LeetCode.<C|F>Sharp.Benchmarks.<Name> (* wildcards accepted)")]
    [CommandArgument(0, "[filter]")]
    public string? Filter { get; init; }

    [Description("Only run C# benchmarks")]
    [CommandOption("--csharp")]
    public bool CSharp { get; init; }

    [Description("Only run F# benchmarks")]
    [CommandOption("--fsharp")]
    public bool FSharp { get; init; }

    [Description("Allow debug configuration to run - use only for development")]
    [CommandOption("--debug")]
    public bool Debug { get; init; }

    [Description("BenchmarkDotNet Exporters: GitHub/StackOverflow/RPlot/CSV/JSON/HTML/XML")]
    [CommandOption("--exporters")]
    public string? Exporters { get; init; }

    public override ValidationResult Validate()
    {
        if (CSharp && FSharp)
        {
            return ValidationResult.Error(Resources.BenchmarkSettings_Error_MutuallyExclusive);
        }

        if (!string.IsNullOrEmpty(Filter) && !BenchmarkFound())
        {
            return ValidationResult.Error(
                string.Format(Resources.BenchmarkSettings_Error_BenchmarkNotFound, Filter));
        }

        return ValidationResult.Success();
    }

    public Type[] BenchmarkTypes()
    {
        var types = new List<Type>();
        var all = !CSharp && !FSharp;

        if (all || CSharp)
        {
            types.AddRange(Reflection.GetCSharpBenchmarkTypes());
        }

        if (all || FSharp)
        {
            types.AddRange(Reflection.GetFSharpBenchmarkTypes());
        }

        return types
            .OrderBy(t => t.Name)
            .ThenBy(t => t.Namespace)
            .ToArray();
    }

    public string[] BuildArgs()
    {
        var args = new List<string> { "--filter" };

        // No filter means run all benchmarks for specified options
        if (string.IsNullOrEmpty(Filter))
        {
            if (CSharp)
            {
                args.Add("LeetCode.CSharp*");
            }
            else if (FSharp)
            {
                args.Add("LeetCode.FSharp*");
            }
            else
            {
                args.Add("LeetCode*");
            }
        }
        else
        {
            var benchmarks = Filter.Split(' ');

            foreach (var benchmark in benchmarks)
            {
                if (benchmark.Contains('*'))
                {
                    // User added wildcard so use whatever was passed
                    args.Add(benchmark);
                }
                else if (benchmark.Contains('.'))
                {
                    // User added namespace but no wildcard so add suffix
                    args.Add($"{benchmark}*");
                }
                else
                {
                    // No wildcard or namespace so add wildcard prefix
                    args.Add($"*{benchmark}");
                }
            }
        }

        if (string.IsNullOrEmpty(Exporters))
        {
            return args.ToArray();
        }

        args.Add("--exporters");
        args.Add(Exporters);

        return args.ToArray();
    }

    private bool BenchmarkFound() =>
        Reflection
            .GetCSharpBenchmarks()
            .Union(Reflection.GetFSharpBenchmarks())
            .Contains(Filter, StringComparer.InvariantCultureIgnoreCase);
}
