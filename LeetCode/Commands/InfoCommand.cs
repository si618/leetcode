namespace LeetCode.Commands;

internal sealed class InfoCommand : Command<ProblemSettings>
{
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] ProblemSettings settings)
    {
        ConsoleWriter.WriteHeader(appendLine: true);

        if (!Reflection.TryGetProblem(settings.Name, out var problem))
        {
            throw new InvalidOperationException("Problem settings validation failed");
        }

        AnsiConsole.Write(problem.ToMarkupTable());

        AnsiConsole.WriteLine();

        return 0;
    }
}
