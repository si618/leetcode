namespace LeetCode.ConsoleApp.Menus.Selections;

internal sealed record BenchmarkSelection : Selection
{
    private ProblemDetail Problem { get; }

    internal BenchmarkSelection(ProblemDetail problem, int order)
        : this(problem, "Run Benchmark", order)
    {
    }

    internal BenchmarkSelection(ProblemDetail problem, string name, int order)
        : base(name, order)
    {
        Problem = problem;
    }

    public override int Execute()
    {
        AnsiConsole.Clear();

        ConsoleWriter.WriteHeader(appendLine: true);

        var settings = new BenchmarkSettings { Filter = Problem.Name };
        var args = BenchmarkRunner.BuildArgs(settings);
        var summaries = BenchmarkRunner.BuildSummaries(settings, args);
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