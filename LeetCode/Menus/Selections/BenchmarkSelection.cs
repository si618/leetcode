namespace LeetCode.Menus.Selections;

internal sealed record BenchmarkSelection : Selection
{
    private Problem Problem { get; }

    internal BenchmarkSelection(Problem problem, int order)
        : this(problem, "Run Benchmark", order)
    {
    }

    internal BenchmarkSelection(Problem problem, string name, int order)
        : base(name, order)
    {
        Problem = problem;
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true, appendLine: true);

        var settings = new BenchmarkSettings { Filter = Problem.Name };
        var summaries = BenchmarkRunner.BuildSummaries(settings);
        var builder = new SpectreReportBuilder(summaries);
        var report = builder.Build();

        AnsiConsole.Write(report);

        var menu = new BenchmarkMenu(Problem);
        var selected = menu.MenuItems.First();
        var prompt = new SelectionPrompt<Selection>()
            .AddChoices(menu.GetMenuItems())
            .UseConverter(m => m.Name);

        while (selected.Name != ExitSelection.Exit)
        {
            selected = AnsiConsole.Prompt(prompt);
            selected.Execute();
        }

        return 0;
    }
}