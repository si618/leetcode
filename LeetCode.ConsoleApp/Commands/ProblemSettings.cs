namespace LeetCode.ConsoleApp.Commands;

internal sealed class ProblemSettings : CommandSettings
{
    [Description("Name of LeetCode problem")]
    [CommandArgument(0, "[name]")]
    public string Name { get; init; } = string.Empty;

    public ProblemDetail Problem => Reflection.GetProblem(Name)!;

    public override ValidationResult Validate() =>
        string.IsNullOrWhiteSpace(Name)
            ? ValidationResult.Error("No problem set")
            : Reflection.GetProblem(Name) is null
                ? ValidationResult.Error($"Problem '{Name}' not found")
                : ValidationResult.Success();
}