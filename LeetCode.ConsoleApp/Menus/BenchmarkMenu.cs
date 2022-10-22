namespace LeetCode.ConsoleApp.Menus;

internal sealed class BenchmarkMenu : MenuBase
{
    private IEnumerable<Problem> Problems { get; init; }

    public BenchmarkMenu(Problem problem)
        : this(new List<Problem> { problem })
    {
    }

    public BenchmarkMenu(IEnumerable<Problem> problems)
    {
        Problems = problems.ToArray();
        MenuItems = new List<Selection>
        {
            new BenchmarkLogSelection(2),
            new ExitSelection(3)
        };
    }

    public override int Render()
    {
        AnsiConsole.Clear();

        ConsoleWriter.WriteHeader(appendLine: true);

        if (BenchmarkRunner.IsDebugConfiguration(true))
        {
            return 1;
        }

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
