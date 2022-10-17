namespace LeetCode.ConsoleApp.Commands;

internal sealed class BenchmarkSettings : CommandSettings
{
    [Description("Filter by LeetCode.[C|F]Sharp.Benchmarks.<Name> (* wildcards accepted)")]
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

    public override ValidationResult Validate() =>
        CSharp && FSharp
            ? ValidationResult.Error("--csharp and --fsharp options are mutually exclusive")
            : string.IsNullOrEmpty(Filter) || BenchmarkFound()
                ? ValidationResult.Success()
                : ValidationResult.Error($"Benchmark not found '{Filter}'");

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

    private bool BenchmarkFound()
    {
        var benchmarks = BenchmarkTypes()
            .Select(b => b.Name.TrimEnd("Benchmark".ToCharArray()));

        return benchmarks.Contains(Filter, StringComparer.InvariantCultureIgnoreCase);
    }
}
