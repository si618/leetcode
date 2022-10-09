namespace LeetCode.ConsoleApp.Menus;

internal class ProblemMenu : MenuBase
{
    private ProblemDetail Problem { get; init; }

    public ProblemMenu(ProblemDetail problem)
    {
        Problem = problem;
        MenuItems = new List<MenuItem>
        {
            new BenchmarkMenuItem(Problem, 1),
            new("Exit", 2)
        };
    }

    public override void Render()
    {
        AnsiConsole.Clear();
        ConsoleWriter.WriteHeader(extraLine: true);

        WriteProblemDetail();

        var selected = MenuItems.First();
        var prompt = new SelectionPrompt<MenuItem>()
            .AddChoices(GetMenuItems())
            .UseConverter(m => m.Name);

        while (selected.Name != "Exit")
        {
            selected = AnsiConsole.Prompt(prompt);
            selected.Execute();
        }
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
