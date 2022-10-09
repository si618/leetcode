namespace LeetCode.ConsoleApp.Menus;

internal record BenchmarkMenuItem : MenuItem
{
    private ProblemDetail Problem { get; }

    internal BenchmarkMenuItem(ProblemDetail problem, int order) : base("Run Benchmark", order)
    {
        Problem = problem;
    }

    public override int Execute()
    {
        AnsiConsole.Clear();
        ConsoleWriter.WriteHeader(extraLine: true);

        // TODO Add Benchmark menu
        var problemMenu = new ProblemMenu(Problem);
        var selected = problemMenu.MenuItems.First();
        var prompt = new SelectionPrompt<MenuItem>()
            .AddChoices(problemMenu.GetMenuItems())
            .UseConverter(m => m.Name);

        while (selected.Name != "Exit")
        {
            selected = AnsiConsole.Prompt(prompt);
            selected.Execute();
        }

        return 0;
    }
}