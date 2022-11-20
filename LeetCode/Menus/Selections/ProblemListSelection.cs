namespace LeetCode.Menus.Selections;

internal sealed record ProblemListSelection : Selection
{
    internal ProblemListSelection(int order) : base(Resources.Selection_ProblemList, order)
    {
    }

    public override int Execute()
    {
        ConsoleWriter.WriteHeader(clearConsole: true);

        var problems = Reflection
            .GetProblemsByCategory()
            .SelectMany(g => g)
            .ToArray();

        var padding = new ProblemPadding(
        problems.Max(problem => problem.Description.Length),
        problems.Max(problem => problem.Category.Description().Length));

        var prompt = new SelectionPrompt<Problem>()
            .AddChoices(problems)
            .PageSize(16)
            .UseConverter(problem => ConvertProblem(problem, padding))
            .MoreChoicesText(Resources.Selection_Benchmark_MoreChoicesText);

        var table = new Table
        {
            Border = TableBorder.Simple,
            UseSafeBorder = true
        };
        table.AddColumns(Resources.Problem_Name, Resources.Problem_Category, Resources.Problem_Difficulty);
        table.Columns[0].Width = padding.DescriptionPad;
        table.Columns[1].Width = padding.CategoryPad;

        AnsiConsole.Cursor.MoveUp();
        AnsiConsole.Write(table);

        // TODO Capture X (or whatever) to return to main menu instead of forcing selection
        // It would also be good to filter by keyboard input
        var problem = AnsiConsole.Prompt(prompt);

        new ProblemMenu(problem).Render();

        return 0;
    }

    private sealed record ProblemPadding(int DescriptionPad, int CategoryPad);

    private static string ConvertProblem(Problem problem, ProblemPadding padding)
        => new StringBuilder()
            .Append($"{problem.Description.PadRight(padding.DescriptionPad + 3)}")
            .Append($"{problem.Category.Description().PadRight(padding.CategoryPad + 3)}")
            .Append($"{problem.Difficulty.Markup()}")
            .ToString();
}