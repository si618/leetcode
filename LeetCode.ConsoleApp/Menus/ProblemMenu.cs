namespace LeetCode.ConsoleApp.Menus;

internal sealed class ProblemMenu : MenuBase
{
    private Problem Problem { get; init; }

    public ProblemMenu(Problem problem)
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

        AnsiConsole.Write(Problem.ToMarkupTable());
        AnsiConsole.WriteLine();

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
}
