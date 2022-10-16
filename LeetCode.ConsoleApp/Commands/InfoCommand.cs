namespace LeetCode.ConsoleApp.Commands;

internal sealed class InfoCommand : Command<ProblemSettings>
{
    public override int Execute(
        [NotNull] CommandContext context,
        [NotNull] ProblemSettings settings)
    {
        ConsoleWriter.WriteHeader(appendLine: true);

        WriteProblemDetails(settings);

        return 0;
    }

    private static void WriteProblemDetails(ProblemSettings settings)
    {
        // ProblemSettings.Validate ensures non-null
        var problem = settings.Problem;

        AnsiConsole.MarkupLine($"[gray]Benchmark:[/]    {problem.Name}");

        if (problem.Name != problem.Description)
        {
            AnsiConsole.MarkupLine($"[gray]Description:[/]  {problem.Description}");
        }

        AnsiConsole.MarkupLine($"[gray]Difficulty:[/]   {problem.Difficulty}");
        AnsiConsole.MarkupLine($"[gray]Category:[/]     {problem.Category.Description()}");

        if (problem.Link is not null)
        {
            AnsiConsole.MarkupLine($"[gray]NeetCode:[/]     {problem.Link}");
        }
    }
}
