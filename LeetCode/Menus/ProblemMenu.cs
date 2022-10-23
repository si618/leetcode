namespace LeetCode.Menus;

internal sealed class ProblemMenu : MenuBase
{
    private Problem Problem { get; init; }

    public ProblemMenu(Problem problem)
    {
        Problem = problem;
        Choices = new List<Selection>
        {
            new BenchmarkSelection(Problem, 1),
            new ExitSelection(2)
        };
    }

    public override int Render()
    {
        ConsoleWriter.WriteHeader(clearConsole: true, appendLine: true);

        AnsiConsole.Write(Problem.Markup());
        AnsiConsole.WriteLine();

        var prompt = new SelectionPrompt<Selection>()
            .AddChoices(GetChoices())
            .UseConverter(m => m.Name);

        var selected = AnsiConsole.Prompt(prompt);
        var exitCode = selected.Execute();

        return exitCode;
    }
}
