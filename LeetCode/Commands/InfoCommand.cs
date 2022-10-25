namespace LeetCode.Commands;

internal sealed class InfoCommand : Command<ProblemSettings>
{
    [SuppressMessage("ReSharper", "RedundantNullableFlowAttribute")]
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] ProblemSettings settings)
    {
        ConsoleWriter.WriteHeader();

        if (!Reflection.TryGetProblem(settings.Name, out var problem))
        {
            throw new InvalidOperationException("Problem settings validation failed");
        }

        AnsiConsole.Write(problem.Markup());

        AnsiConsole.WriteLine();

        return 0;
    }
}
