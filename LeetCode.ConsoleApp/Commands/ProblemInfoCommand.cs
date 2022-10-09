namespace LeetCode.ConsoleApp.Commands;

public sealed class ProblemInfoCommand : Command<ProblemSettings>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] ProblemSettings settings)
    {
        ConsoleWriter.WriteHeader();
        WriteProblemDetails(settings);
        return 0;
    }

    private static void WriteProblemDetails(ProblemSettings settings)
    {
        // ProblemSettings.Validate ensures non-null
        var problem = settings.Problem!;

        AnsiConsole.Markup($"[gray]Benchmark:[/]    {problem.Name}");

        if (problem.Name != problem.Description)
        {
            AnsiConsole.WriteLine($"[gray]Description:[/]  {problem.Description}");
        }

        AnsiConsole.WriteLine($"[gray]Difficulty:[/]   {problem.Difficulty}");
        AnsiConsole.WriteLine($"[gray]Category:[/]     {problem.Category.Description()}");

        if (problem.Link is not null)
        {
            AnsiConsole.WriteLine($"[gray]NeetCode:[/]     {problem.Link}");
        }

        AnsiConsole.WriteLine();
    }
}
