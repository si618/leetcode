namespace LeetCode.Commands;

internal sealed class ProblemSettings : CommandSettings
{
    [Description("Name of LeetCode problem")]
    [CommandArgument(0, "[name]")]
    public string Name { get; init; } = string.Empty;

    public override ValidationResult Validate() => string.IsNullOrWhiteSpace(Name)
            ? ValidationResult.Error(Resources.ProblemSettings_Error_NoArgumentPassed)
            : !Reflection.TryGetProblem(Name, out _)
            ? ValidationResult.Error(
                string.Format(CultureInfo.CurrentCulture, Resources.ProblemSettings_Error_ProblemNotFound, Name))
            : ValidationResult.Success();
}
