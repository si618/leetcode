namespace LeetCode.ConsoleApp.Commands;

public sealed class BenchmarkSettings : CommandSettings
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

    public override ValidationResult Validate()
    {
        return CSharp && FSharp
            ? ValidationResult.Error("CSharp and FSharp options are mutually exclusive")
            : ValidationResult.Success();
    }

    public Type[] BenchmarkTypes()
    {
        var types = new List<Type>();

        if (CSharp)
        {
            types.Add(typeof(CSharp.Benchmarks.Benchmark));
        }

        if (FSharp)
        {
            types.AddRange(Reflection.GetFSharpBenchmarkTypes());
        }

        return types.ToArray();
    }

    public string WaitingMessage()
    {
        var message = !CSharp && !FSharp
            ? "Running C# and F# benchmarks"
            : CSharp
                ? "Running C# benchmarks"
                : "Running F# benchmarks";

        if (Filter?.Length > 0)
        {
            message += $" matching [blue]{Filter}[/]";
        }

        return message;
    }
}
