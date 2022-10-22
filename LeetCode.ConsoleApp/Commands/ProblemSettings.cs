namespace LeetCode.ConsoleApp.Commands;

internal sealed class ProblemSettings : CommandSettings
{
    [Description("Name of LeetCode problem")]
    [CommandArgument(0, "[name]")]
    public string Name { get; init; } = string.Empty;

    public override ValidationResult Validate() =>
        string.IsNullOrWhiteSpace(Name)
            ? ValidationResult.Error("No problem argument passed")
            : Reflection.TryGetProblem(Name, out _)
                ? ValidationResult.Success()
                : ValidationResult.Error($"Problem '{Name}' not found");
}