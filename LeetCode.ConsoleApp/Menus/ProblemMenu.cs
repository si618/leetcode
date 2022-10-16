namespace LeetCode.ConsoleApp.Menus;

internal sealed class ProblemMenu : MenuBase
{
    private ProblemDetail Problem { get; init; }

    public ProblemMenu(ProblemDetail problem)
    {
        Problem = problem;
        MenuItems = new List<Selection>
        {
            new BenchmarkSelection(Problem, 1),
            new ExitSelection(2)
        };
    }

    public override int Render()
    {
        AnsiConsole.Clear();
        ConsoleWriter.WriteHeader(appendLine: true);

        WriteProblemDetail();

        var selected = MenuItems.First();
        var prompt = new SelectionPrompt<Selection>()
            .AddChoices(GetMenuItems())
            .UseConverter(m => m.Name);

        var exitCode = 0;
        while (selected.Name != ExitSelection.Exit)
        {
            selected = AnsiConsole.Prompt(prompt);
            exitCode = selected.Execute();
        }
        return exitCode;
    }

    private void WriteProblemDetail()
    {
        AnsiConsole.MarkupLine($"[gray]Benchmark:[/]    {Problem.Name}");

        if (Problem.Name != Problem.Description)
        {
            AnsiConsole.MarkupLine($"[gray]Description:[/]  {Problem.Description}");
        }

        AnsiConsole.MarkupLine($"[gray]Difficulty:[/]   {Problem.Difficulty}");
        AnsiConsole.MarkupLine($"[gray]Category:[/]     {Problem.Category.Description()}");

        if (Problem.Link is not null)
        {
            AnsiConsole.MarkupLine($"[gray]NeetCode:[/]     {Problem.Link}");
        }

        AnsiConsole.WriteLine();
    }
}
