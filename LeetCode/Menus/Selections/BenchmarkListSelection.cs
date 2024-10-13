namespace LeetCode.Menus.Selections;

internal sealed record BenchmarkListSelection : Selection
{
    internal BenchmarkListSelection(int order) : base(Resources.Selection_RunBenchmarks, order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true);

        var categories = Reflection.GetProblemsByCategory().ToArray();

        var prompt = new MultiSelectionPrompt<string>()
            .Title(Resources.Selection_Benchmark_Title)
            .PageSize(16)
            .MoreChoicesText(Resources.Selection_Benchmark_MoreChoicesText)
            .InstructionsText(Resources.Selection_Benchmark_InstructionsText);

        foreach (var category in categories)
        {
            prompt.AddChoiceGroup(category.Key.Description(),
                category.Select(p => p.Description));
        }

        var selectedProblems = AnsiConsole.Prompt(prompt);
        if (selectedProblems.Count == 0)
        {
            return 0;
        }

        var names = categories
            .SelectMany(group => group)
            .Where(problem => selectedProblems.Contains(problem.Description))
            .Select(problem => problem.Name);

        var settings = new BenchmarkSettings { Filter = string.Join(" ", names) };
        var summaries = BenchmarkRunner.BuildSummaries(settings);
        var builder = new SpectreReportBuilder(summaries);
        var report = builder.Build();

        AnsiConsole.Write(report);

        ConsoleWriter.WaitForKeyPress();

        return 0;
    }
}