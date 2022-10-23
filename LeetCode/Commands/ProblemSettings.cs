namespace LeetCode.Commands;

internal sealed class ProblemSettings : CommandSettings
{
    [Description("Name of LeetCode problem")]
    [CommandArgument(0, "[name]")]
    public string Name { get; init; } = string.Empty;

    public override ValidationResult Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            return ValidationResult.Error(Resources.ProblemSettings_Error_NoArgumentPassed);
        }

        if (!Reflection.TryGetProblem(Name, out _))
        {
            return ValidationResult.Error(
                string.Format(Resources.ProblemSettings_Error_ProblemNotFound, Name));
        }

        return ValidationResult.Success();
    }
}