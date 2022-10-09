namespace LeetCode.ConsoleApp.Commands;

public sealed class ProblemSettings : CommandSettings
{
    public ProblemDetail? Problem { get; }

    public override ValidationResult Validate()
    {
        if (Problem is null)
        {
            return ValidationResult.Error("No problem set");
        }
        return Reflection.GetProblem(Problem.Name) is null
            ? ValidationResult.Error($"Problem '{Problem.Name}' not found")
            : ValidationResult.Success();
    }
}
