namespace LeetCode.ConsoleApp.Commands;

internal sealed class InfoCommand : Command<ProblemSettings>
{
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] ProblemSettings settings)
    {
        ConsoleWriter.WriteHeader(appendLine: true);

        AnsiConsole.MarkupLine(settings.Problem.ToMarkup());

        return 0;
    }
}
